   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:FlightSimulator.Views.WindowsFlightSimulator.Views.Windows  5      =#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5      1    +FlightSimulator.Views.Windows.ManualControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:FlightSimulator.Views.Windows     5      >mainComponents#clr-namespace:FlightSimulator.Views     5      .��5
      � .+�5   
   ]� .+�5      � $	��Top=�6     � ColumnDefinitions  5      �� 5      $��4* �6'   �� 5      $��* �6'   .+�5      �� $��Center=�6   $��	115,0,0,0q�65   $
��Bold"�6H   $��20(�6Z   .��6h   ← aileron →6u   �� 5      $
��Left=�6   $��20(�67   $
��Bold"�6E   $��1��6W   ��6g   �� *	Aileron+5      � 5      $
��Left=�6     5      �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   .+�5      �� $��2��6   $��Center=�6,   $
��Left=�6G   $��10,-15,5,300q�6b   $��20(�6x   $
��Bold"�6�   ��6�   ��  �� ElementName$ throttleSlider�� �� Path$ Value� �� Mode$ OneWay=��� 5      $��20(�6   $
��Bold"�6'   $��	-5,0,0,40q�69   $��Center=�6L   .��6g   ← throttle → � LayoutTransform 5      �� 5       �� Angle$ 90Q�6*   5       �� 5!      -   5        $��throttleSlider��5!      $��1��60   $��Center=�6@   $
��Left=�6[   $	��230��5"   !   $��22��6-    � Minimum$ -1Q�69    � Maximum$ 1Q�6F   $��-5,0,-70,40q�6R    �� IsSnapToTickEnabled . 	 �� TickFrequency$		 0.1Q�6�   
 � Value
 6g   �� *
Throttle+$ OneWayToSource=� 5#      �� 5$      $	 270Q�6*   5&      5'      � 5(      $��Bottom=�6     5)      �� 5*      $��4* �6'   �� 5+      $��* �6'    � RowDefinitions 5-      �� 5.      $��* �6$   �� 5/      $��* �6$   .+�51      �� -   5        $��rudderSlider��51      $��Center=�6-   $��Center=�6H   $	��230��6e   $��17��6q   $ -1Q�6}   $ 1Q�6�   $��	0,7,-40,0q�6�    . $		 0.1Q�6�   
 6�   �� *Rudder+$ OneWayToSource=�6�   �� 52      $��1��6   $��
45,-10,0,0q�6%   $��Center=�69   $��20(�6V   $
��Bold"�6e   .��6w   ← rudder →6�   �� 53      $��Bottom=�6   $
��Left=�67   $��20(�6R   $
��Bold"�6`   $��1��6r   ��6�   �� $ rudderSlider��$ Value�$ OneWay=�54      � 55      $��Right=�6    56      �� 57      $��* �6$   �� 58      $��9* �6$   .+�5:      �� $��Center=�6   $��Bottom=�69   $
��Bold"�6T   $��20(�6f   ��6t   �� *
Elevator+ 5;      �� 5<      $ 90Q�6*   5>      �� 5?      $��1��6   $��Center=�6%   $��Center=�6B   $��0,0,0,15q�6]   $
��Bold"�6p   $��20(�6�   .��6�   ← elevator → 5@      �� 5A      $ 90Q�6*   5C      5D      $   FlightSimulator.Views.Joystick  5F      5H      5I      5J      