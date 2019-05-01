using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
namespace FlightSimulator.Model
{
    public class ControlModel : FlightSimulator.ViewModels.BaseNotify
    {   
        static private readonly string ThrottlePath = "controls/engines/current-engine/throttle";
        static private readonly string RudderPath = "controls/flight/rudder";
        static private readonly string ElevatorPath = "controls/flight/elevator";
        static private readonly string AileronPath = "controls/flight/aileron";
        private Thread readingFromSimulatorThread = null;
        private Thread connectingToSimulatorThread = null;
        /// <summary>listener which is used to get simulator client.</summary>
        private TcpListener listener = null;
        /// <summary>Binary writer, which is used to send information to simulator.</summary>
        private BinaryWriter Writer { set; get; }
        public bool IsConnectedToSimulator
        {
            get
            {
                return isConnectedToSimulator;
            }
        }
        private bool isConnectedToSimulator = false;
        private bool isServerActivated = false;
        public bool IsServerActivated
        {
            get { return isServerActivated; }
        }
        //Client which connects to the flight simulator
        private TcpClient AppClient { set; get; }
        public double Throttle
        {
            set
            {
                ExecuteCommand("set " + ThrottlePath + " " + value.ToString() + "\r\n");
            }
        }
        public double Rudder
        {
            set
            {
                ExecuteCommand("set " + RudderPath + " " + value.ToString() + "\r\n");
            }
        }
        public double Aileron
        {
            set
            {
                ExecuteCommand("set " + AileronPath + " " + value.ToString() + "\r\n");
            }
        }
        public double Elevator
        {
            set
            {
                ExecuteCommand("set " + ElevatorPath + " " + value.ToString() + "\r\n");
            }
        }
        public ControlModel()
        {
            isServerActivated = false;
            isConnectedToSimulator = false;
            lon = null;
            lat = null;
        }
        /// <summary>
        /// lon - longtitude of the plane in simulator.
        /// lat- latitude of the plane  in simulator.
        /// </summary>
        private float? lon, lat;
        /// <summary>
        /// longtitude of the plane in simulator.
        /// </summary>
        public float Lon
        {
            get
            {
                if (lon == null)
                {
                    throw new Exception("The server is not activated and therefore the simulator can't send data.");
                }
                return (float)lon;
            }
        }
        /// <summary>
        /// latitude of the plane  in simulator.
        /// </summary>
        public float Lat
        {
            get
            {
                if (lat == null)
                {
                    throw new Exception("The server is not activated and therefore the simulator can't send data.");
                }
                return (float)lat;
            }
        }

        /// <summary>
        /// This methods creates to chanels of connection with simulator:
        /// 1)command chanel -
        /// connects to the simululator as client to send to it information.
        /// 2)info chanel- creates a server to which simulator will be connected and send information
        /// to the application.
        /// </summary>
        /// <param name="ipAddress">Ip address ofsimulator's server.</param>
        /// <param name="commandsChanelPort">port for sending commands.</param>
        public void ConnectToSimulator(IPAddress ipAddress, int commandsChanelPort)
        {
            Thread connectionThread = new Thread(new ParameterizedThreadStart((object endPoint) =>
            {
                while (!isConnectedToSimulator)
                {
                    try
                    {
                        AppClient = new TcpClient();
                        AppClient.Connect((IPEndPoint)endPoint);
                        NetworkStream stream = AppClient.GetStream();
                        Writer = new BinaryWriter(stream);
                        isConnectedToSimulator = true;
                    }
                    catch (Exception) { }
                }
            }));

            IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, commandsChanelPort);
            connectingToSimulatorThread = connectionThread;
            connectionThread.Start(iPEndPoint);
        }
        /// <summary>
        /// This method closes commands chanel.
        /// </summary>
        public void DisconectFromSimulator()
        {
            //If the client was created, but waits for server response(the thread of establishing communication still runs)
            if (connectingToSimulatorThread != null && connectingToSimulatorThread.IsAlive)
            { 
                AppClient.Close();
                connectingToSimulatorThread.Abort();
            }
            //if the connection was fully established.
            else if (IsConnectedToSimulator)
            {
                AppClient.Close();
                Writer = null;
            }
            isConnectedToSimulator = false;


        }
        /// <summary>
        /// This method starts the server to which simulator connects as a client and sends to it information
        /// and read from simulator Longtitude and latitude values.
        /// </summary>
        /// <param name="ipAddress">ipAddress of simulator's client.</param>
        /// <param name="commandsChanelPort">port of information passing from simulator to this application.</param>
        public void StartServer(IPAddress ipAddress, int infoChanelPort)
        {
            Thread creatingServerThread = new Thread(new ParameterizedThreadStart((object endPoint) =>
            {
                listener = new TcpListener((IPEndPoint)endPoint);
                listener.Start();
                TcpClient simulatorClient = listener.AcceptTcpClient();
                listener.Stop();
                isServerActivated = true;
                using (NetworkStream stream = simulatorClient.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    /*Reading first value outside of loop to initialize longtitude and langtitude.
                     *We do it, in order to be able to distinguish, whether these values were changed,
                     *and thus we shold call for notifyPropertyChanged event. Otherwise, these properties
                     * are not changed and we haven't call for notifyPropertyChanged.
                     */
                    string readVal = BinaryReaderExtension.ReadLine(reader);
                    //this is seperator between valaues in message that simulator sends.
                    char[] seperator = { ',' };
                    string[] splitedFirstResult = readVal.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    lon = float.Parse(splitedFirstResult[0]);
                    lat = float.Parse(splitedFirstResult[1]);
                    while (IsServerActivated)
                    {
                        stream.Flush();
                        readVal = BinaryReaderExtension.ReadLine(reader);
                        string[] splitedResult = readVal.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                        float lonFromServer = float.Parse(splitedResult[0]);
                        if (lonFromServer != lon)
                        {
                            // If lon in simulator have changed, we will change it in model.
                            lon = lonFromServer;
                            this.NotifyPropertyChanged("Lon");
                        }
                        float latFromServer = float.Parse(splitedResult[1]);
                        if (latFromServer != lat)
                        {
                            // If lat in simulator have changed, we will change it in model.
                             lat = latFromServer;
                            this.NotifyPropertyChanged("Lat");
                        }

                    }
                    
                    simulatorClient.Close();
                }
            }));
            readingFromSimulatorThread = creatingServerThread;
            creatingServerThread.Start(new IPEndPoint(ipAddress, infoChanelPort));
        }
        /// <summary>
        /// Realizing all resources that were allocated for server work. 
        /// </summary>
        public void TurnOffServer()
        {
            
            if  (!isServerActivated && connectingToSimulatorThread != null && readingFromSimulatorThread.IsAlive)
            {
                listener.Stop();
                readingFromSimulatorThread.Abort();
            }
            else
                this.isServerActivated = false;
        }
        
        public void ExecuteCommand(string command)
        {
            if (isConnectedToSimulator)
            {
                Writer.Write(Encoding.ASCII.GetBytes(command));
                Writer.Flush();
            }
        }
    }
}
