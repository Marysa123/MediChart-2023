   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MediChart.WindowsMediChart.Windows  5   	   )    #MediChart.Windows.MenuPacientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MediChart.Windows     5   	     � Title$0  *Окно меню пользователя��5   	   $	��840��6(   $
��1400��65    � WindowStartupLocation$ CenterScreen=�6B    � AllowsTransparency .  � WindowStyle$
 None=�6�   
������ .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .+�5   
   ��  �� CornerRadius$ 25��6   ��5      �� 5      $ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5      �  � Color$ 	#FF3A8003��5      	 � Offset$		 0.7Q�5      � 5      -   5        AnimationColor3��$ 	#FF4B8020��5      $		 0.2Q�5      � 5      -   5        AnimationColor2��$ 	#FF60A22C��5      $	 1Q�6+   5      ._�5      � 
 � ColumnDefinitions
 5      �� 5      $	��200 �6'   �� 5      .+�5!      �  � RowDefinitions 5"      �� 5#      $	��200 �6(   �� 5$      $��70 �6(   �� 5%      $��70 �6(   �� 5&      $��80 �6(   �� 5'      �� 5)      $	��100 �6)   .+�5+      �� 
�������$��6��60   $ 10 10 10 10��6A   �� 5-      -   5        $��button_InfoApp��5-   [   $��1��6    $��0��6-   $��10 0 0 0q�6=   $��50��6O   $	��190��6q    � Cursor$
 Hand��6�   �� 5.      -   5        $��	icon_Info��5.       $��40��61   $%��\Resources\Images\icon_Info.png��6=   $��Right=�6f   $��40��6�   $��10 0 0 0q�6�    �� 5/      $��30��6    $��Ознакомление��6,   $
��17px(�6C   $��5 0 0 5q�6S   50      �� 52      -   5        $��button_Profile��52   \   $��2��6    $��0��6-   $��	10 20 0 0q�6=   $��50��6P   $	��190��6r   $
 Hand��6�   �� 53      -   5        $��icon_UserProfile��53       $��40��68   $,��&\Resources\Images\icon_UserProfile.png��6D   $��Right=�6t   $��40��6�   $��10 0 0 0q�6�    �� 54      $��30��6    $��Профиль��6,   $
��17px(�6>   $��10 0 0 5q�6N   55      �� 57      -   5        $��button_InfoRecords��57   \   $��3��6    $��0��6-   $��50��6=   $��	10 30 0 0q�6I   $	��190��6v   $
 Hand��6�   �� 58      -   5        $��icon_InfoRecords��58       $��40��68   $(��"\Resources\Images\icon_Records.png��6D   $��Right=�6p   $��40��6�   $��10 0 0 0q�6�    �� 59      $��30��6    $��Записи��6,   $
��17px(�6=   $��10 0 0 5q�6M   5:      �� 5<      -	   5        $
��Logo��5<      $��0��6(   $��0��68   $%��\Resources\Images\icon_Logo.png��6E   $��Center=�6n   $	��100��6�   $��Center=�6�   $	��100��6�   �� 5=      -
   5        $
��exit��5=      $
 Hand��6(   $��0��66   $��5��6F   $+��%\Resources\Images\icon_ExitWindow.png��6S   $
��Left=�6�   $��30 0 0 0q�6�   $��40��6�   $��Center=�6�   $��40��6�   6�   5>      �� 5@      $��1��6!   ��61   �� 5A      5B      5C      5D      