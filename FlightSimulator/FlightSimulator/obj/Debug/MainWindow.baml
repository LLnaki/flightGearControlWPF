   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FlightSimulatorFlightSimulator  5   	   =#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5   	   M+clr-namespace:FlightSimulator.Views.WindowsFlightSimulator.Views.Windows  5   	        FlightSimulator.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FlightSimulator     5   	   >mainComponents#clr-namespace:FlightSimulator.Views     5   	   ?windows+clr-namespace:FlightSimulator.Views.Windows     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   (� $��3��6   $��Center=�6'   $��60��6D   .��5      �� $��22(�6   
����+��$��Heavy"�6:   $��0,5,0,5q�6M   .��6^   Flight Simulator6p   5      (� 5   
   $��1��6   $��2��6   $��0,0,0,5q�63   .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��settingsButton��5   ,   $��10,0,0,0q�6   $��25��6D   $��50��6P   $��Center=�5      $��Center=�65   
���������5   -   �� *SettingsCommand+.��6Q   
settings6[   �� 5      -   5        $��connectButton��5      $��5,0,0,0q�6.   $��25��6?   $��50��6K   $��Center=�5       $��Center=�69   
���������5!   -   �� *ConnectCommand+.��6P   	connect6Y   5"      5#      '   !FlightSimulator.Views.FlightBoard  5%   
   $��2��6%   $��2��62   $��0,0,10,0q�6F    � DataContext 6X   �� *FlightBViewModel+�� 5&   
   $��1��6   $��2��6"   $��2��62   .@�5'      �� $��Manual��6   .��5(      (� .��5)      1   +FlightSimulator.Views.Windows.ManualControl   6,   �� *ManualConViewModel+5*      5+      �� 5,      $��
Auto Pilot��6   .��5-      (� .��5.      4   .FlightSimulator.Views.Windows.AutoPilotControl   6/   �� *AutoPilViewModel+5/      50      51      52      53      