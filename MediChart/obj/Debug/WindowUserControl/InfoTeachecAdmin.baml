   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediChart.WindowUserControlMediChart.WindowUserControl  5      2    ,MediChart.WindowUserControl.InfoTeachecAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MediChart.WindowUserControl     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��840��5	      $
��1200��6   .��5
      � .+�5   
   �   � ColumnDefinitions  5      �� 5      $	��750 �6#   �� 5      .+�5      �� $��2��6    �� CornerRadius$ 	0 30 30 0��6)   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    � MappingMode$ RelativeToBoundingBox=�6;    �� 
StartPoint$ 0.5,0&�6_   .��5      �  � Color$ 	#FF3A8003��5       � Offset$	 0.7Q�5      � 5      -   5        AnimationColor3��$ 	#FF4B8020��5      $	 0.2Q�5      � 5      -   5        AnimationColor2��$ 	#FF60A22C��5      $ 1Q�6+   5      5      &   System.Windows.Controls.DataGrid  5!      -   5        $
��Grid��5!      $��20(�6#      AutoGenerateColumns . 
���   �$��10 70 20 10q�6_    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#      	   
BlurRadius$	 8Q�6'   
   ShadowDepth$
 10Q�66      Opacity$ 0.995Q�6G      Color$ 	#FF669D6C��6W   ��5%      �� 5&       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5'      -   5        5(      5*      �� 5+      $��2��6   $	��Top=�6%   $��Center=�6=   $	��410��6Z   $ 15��6f   $��
0 110 10 0q�6x   
�������$	��580��6�   �� 5,      $��0 0 0 0q�6   $��1��6f    � DataContext 6*   ��  �� ElementName$
 Grid�� �� Path$ SelectedValue�.+�5-      �� -   5        $��	icon_Exit��5-       � Cursor$
 Hand��6)   $��2��67   $%��/Resources/Images/icon_Exit.png��6K   $��Right=�6�   $��	0 25 25 0q�6�   $��24��6�   $	��Top=�6�   �� 5/      $%��Заполните данные��6   $��20(�63   $��0 20 0 0q�6A   $��Regular"�6S   $��Center=�6i   $	��Top=�6�   
�������6�   �� 50      -   5        $��textbox_Fam��50      $	��350��6.   ���	#FF138300$��	10 0 10 0q�6k   $��20(�6~   
���   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия*:��6  $��60��6:     UnderlineBrush �	#FF51F308   
Foreground
 �   �$��0 0 0 2q�6�  ��6R   �� *Фамилия+6�  �� 51      -   5        $��textbox_Ima��51      $	��350��6.   ���	#FF138300$��
10 10 10 0q�6g   $��20(�6{   
���   � . #��[  6�   $ Имя*:��6  $��60��63   �	#FF51F308
 �   �$��0 0 0 2q�6�  ��6R   �� *Имя+6�  �� 52      -   5        $��textbox_Otch��52      $	��350��6/   ���	#FF138300$��
10 10 10 0q�6m   $��20(�6�   
���   � . #��[  6�   $ Отчество*:��6  $��60��6>   �	#FF51F308
 �   �$��0 0 0 2q�6�  ��6S   �� *Отчество+6�  �� 53      -	   5        $��textbox_EMail��53      $	��350��6/   ���	#FF138300   LeadingIcon$ MailboxOpenUp=�6S      LeadingIconSize$ 25Q�6�      HasLeadingIcon . $��
10 10 10 0q�6  $��20(�6.  
���   � . #��[  6�  $ E-mail*:��6�  $��60��6�   �	#FF51F308
 �   �$��0 0 0 2q�6\  ��6�   �� *#!Электронная почта+6\  �� 54      -
   5        $��textbox_Phone��54      $	��350��6/   ���	#FF138300$ Phone=�6S      
PrefixText$ +7��6�   $ 25Q�6�    . $��
10 10 10 0q�6?  $��20(�6S  /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions .  �� 	MaxLength$ 10��6�  
���   � . #��[  6�  $# Номер телефона*:��6.  $��60��6`   �	#FF51F308
 �   �$��0 0 0 2q�6�  $ Arrow��6�  ��6�   �� *Номер телефона+6�  �� 55      -   5        $��textbox_Adress��55      $	��350��60   ���	#FF138300$��
10 10 10 0q�6v   $��20(�6�    . 
���   � . #��[  6  $' !Место проживания*:��6V  $��60��6�   �	#FF51F308
 �   �$��0 0 0 2q�6�  $ Arrow��6  ��6T   �� *!Адрес проживания+6  � 56      $��	50 0 50 0q�6   .+�57      �� -   5        $��combobox_Pol��57   7   $��60��6   $	��150��6+   ���	#FF138300 �	#FF51F308$��Bottom=�6�   $ Пол��6�   $��18(�6�    �� Text 6�   �� *Пол+.@�58      �� $��Мужской��6'   �� 59      $��Женский��6'   5:      �� 5;      -   5        $��combobox_Class��5;   �   $��60��6   $	��150��6+   $��	50 20 0 0q�67   ���	#FF138300 �	#FF51F308
���   �$��Bottom=�6�   $ 
Класс��6  $��18(�6+   6�   �� *%#Закрепленный класс+6+  (  "System.Windows.Controls.DatePicker  5<      -   5        $��datapicker_data��5<   -   $��60��6!   ���	#FF138300$��0 20 0 0q�6\   
 �   � �	#FF51F308$ Дата рождения��6�    $  MaterialDesignOutlinedDatePicker#��[ 6#  $��16(�6]     Text 6�   �� *Дата рождения+6]  5=      �� 5?      -   5        $��label_Номер��5?   g   
�������$��20(�6E   $y�Hidden=�6S   $��40��6z   $%��Bahnschrift Light SemiCondensed)�6�   ��6   �� *
Номер+6�   � 5@      $��Center=�6   .+�5A      �� -   5        $��button_AddClassRuk��5A      $	��252��6X   $��55��6d   $��Добавить��6p   $��16(�6�   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������ $
 Hand��6�     StyleButtonAllApplication#��[ 6  �� 5B      -   5        $��40��5B      $��40��6(   $(��"/Resources/Images/icon_Refresh.png��64   $
 Hand��6`   $��	30 10 0 0q�6�   5C      5D      �� 5E      $u��oФорма администратора | Информация об классных руководителях��6   $��20(�6Z   $��	20 20 0 0q�6h   $
��Left=�6{   $	��Top=�6�   
���������6�   Z� 6�   5F      5G      5H      