   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MediChart.WindowsMediChart.Windows  5   	   (    "MediChart.Windows.AddRecordsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MediChart.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$0  *Окно добавление записи��5	   	   $	��780��6)   $
��1100��66   
������  � WindowStartupLocation$ CenterScreen=�6\    � WindowStyle$
 None=�6�    � AllowsTransparency . .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   $��2��67   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 	#FF1D712E��6#   
 � Offset$

 0.06Q�65   � 5      $	 	#FF3C790D��6#   $
 1Q�65   5      5      �� 5   
   -   5        $��
icon_Exit2��5       � Cursor$
 Hand��6"   $��1��60   $%��/Resources/Images/icon_Exit.png��6@   $��Right=�6�   $��	0 25 35 0q�6�   $��25��6�   $	��Top=�6�   $��25��6�   �� 5   
   $M��GФорма медработника | Добавление записи��6   $��20(�6A   $��	20 20 0 0q�6O   $
��Left=�6b   $	��Top=�6}   
���������6�   Z� 6�   �� 5   
   $��0��6   $��2��6!   $	��320��62   $	��Top=�6?   $	��480��6W   $ 10��6c   $��	0 65 0 20q�6u   
�������6�   �� 5    
   $��0��6   $��1��6%   .+�5!      �� $%��Заполните данные��6   $��20(�6/   $��0 20 0 0q�6=   $��Center=�6O   $��Regular"�6l   
���   �6�   �� 5"      -   5        $��combobox_FioPacients��5"       �� 
IsEditable . $	��350��6E   $��	10 0 10 0q�6Q   $��20(�6d   
���   �$��60��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �	#FF51F308)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ФИО пациента��6�   
���   �   
Foreground
 �   �$��0 0 0 2q�6:  �� 5#      -   5        $��textbox_FioPersonal��5#      $	��350��61    �� 
IsReadOnly . $��
10 10 10 0q�6O   $��20(�6c   
���   � %  !MaterialDesignFloatingHintTextBox#��[  6�   $" ФИО сотрудника:��6�   $��60��6�    �	#FF51F308
���   �
 �   �$��0 0 0 2q�6w  �� 5$      -   5        $��textbox_Data��5$      $	��250��6*    . $��
10 10 10 0q�6H   $��20(�6\   
���   �#��[  6}   $ 	Дата:��6�   $��60��6�    �	#FF51F308
���   �
 �   �$��0 0 0 2q�6f  �� 5%      -   5        $��combobox_Diagnoz��5%   S    .  �� 
IsReadOnly . $��60��6;   $	��250��6G    �	#FF51F308$��Bottom=�6�   
���   �
���   �$ Диагноз��6�   $��18(�6  5&      �� 5(   
   -   5        $��textbox_Jalobi��5*       ! MaterialDesignOutlinedTextBox#��[ 5)      $��Center=�5+      $��20(�5,      $��0��5-      $��1��5.      $	��320��5/      $��0 0 0 50q�50      $��Bottom=�51       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�53      " �� VerticalScrollBarVisibility$
 Auto=�54      $$ Жалобы пациента:��55         
Background
 ���� 
 �   �
���   �$	��480��59         FloatingScale$	 0.8Q�5:      
������� �� 	MaxLength$	 300��5<      
�������5=      �� 5?   
   -   5        $��textbox_Lechenie��5A      #��[ 5@      $��Center=�5B      $	��Top=�6*   $��20(�5C      $��1��5D      $��2��5E      $	��340��5F       . $
 Wrap=�5H      $
 Auto=�5I      $ Лечение:��5J      
 ���� 
 �   �
���   �$	��480��5N      $��	0 10 0 15q�5O      $	 0.8Q�5P      
�������$	 300��5R      
�������5S      � 5T   
   $��Center=�6   $��1��61   $��1��6A   $��0 90 0 0q�6N   $��Center=�6`   .+�5U      �� -   5        $��button_ViewDocument��5U      $��0 0 0 0q�6R   $	��220��6c   $��55��6o   $/��)Сформировать документ��6{   $��16(�6�   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������ $
 Hand��6  ���	#FF1DA463 J� Effect 5V      3  -System.Windows.Media.Effects.DropShadowEffect  5W         
BlurRadius$ 5Q�6'   5Y      �� 5Z      -	   5        $��button_AddRecord��5Z      $��1��6-   $��2��6=   $��30 0 0 0q�6i   $	��220��6{   $��55��6�   $#��Добавить запись��6�   $��16(�6�   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������ $
 Hand��6  ���	#FF1DA463 5[        5\      $ 5Q�6'   5^      5_      5`      5a      