   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediChart.WindowUserControlMediChart.WindowUserControl  5      5    /MediChart.WindowUserControl.InfoMedicinesMedRab   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MediChart.WindowUserControl     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��840��5	      $
��1200��6   .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��750 �6   �� 5      .+�5   
   �� $��2��6    �� CornerRadius$ 	0 30 30 0��6%   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF3A8003��5       � Offset$	 0.7Q�5      � 5      -   5        AnimationColor3��$ 	#FF4B8020��5      $	 0.2Q�5      � 5      -   5        AnimationColor2��$ 	#FF60A22C��5      $ 1Q�6+   5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        $
��Grid��5       $��20(�6      AutoGenerateColumns . 
���   �$��10 70 20 10q�6[    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"      	   
BlurRadius$	 8Q�6'   
   ShadowDepth$
 10Q�66      Opacity$ 0.995Q�6G      Color$ 	#FF669D6C��6W   ��5$      �� 5%       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5&      -   5        5'      5)      �� 5*   
   $��2��6   $	��Top=�6!   $��Center=�69   $	��400��6V   $ 10��6b   $��	0 110 0 0q�6t   
�������$	��300��6�   �� 5+   
   $��0 0 0 0q�6   $��1��6b    � DataContext 6&   ��  �� ElementName$
 Grid�� �� Path$ SelectedValue�.+�5,      �� -   5        $��	icon_Exit��5,       � Cursor$
 Hand��6)   $��2��67   $%��/Resources/Images/icon_Exit.png��6K   $��Right=�6�   $��	0 25 25 0q�6�   $��24��6�   $	��Top=�6�   �� 5.      $%��Заполните данные��6   $��20(�63   $��0 20 0 0q�6A   $��Regular"�6S   $��Center=�6i   $	��Top=�6�   
�������6�   �� 50      -   5        $��textbox_SeriasNomer��50      $	��350��6V   $��
10 20 10 0q�6b   $��20(�6v   
���   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$" Серийный номер:��6  $��60��68     UnderlineBrush �	#FF51F308   
Foreground
 �   �$��0 0 0 2q�6�  ���	#FF285602��66   �� *Серийный номер+6�  �� 51      -   5        $��textbox_FullName��51      $	��350��6T   $��
10 10 10 0q�6`   $��20(�6t   
���   � . #��[  6�   $$ Полное название:��6  $��60��67   �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��63   �� *Полное название+6�  �� 52      -   5        $��textbox_Kolvo��52      $��
10 10 10 0q�6L   $	��350��6`   $��20(�6l   
���   � . #��[  6�   $ Количество:��6�   $��60��6*   �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��60   �� *Количество+6�  �� 53      -	   5        $��textbox_EdIzm��53      $��
10 10 10 0q�6S   $	��350��6g   $��20(�6s   
���   � . #��[  6�   $( "Единица измерения:��6  $��60��68   �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��60   �� *#!Единица измерения+6�  �� 55      -
   5        $��textbox_InfoMedicines��57       ! MaterialDesignOutlinedTextBox#��[ 56      $	��Top=�58      $	��290��59      $��
10 30 10 0q�5:      $��20(�5;       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5>      " �� VerticalScrollBarVisibility$
 Auto=�5?      $* $Описание лекарства:��5@         
Background
 ���� 
 �   �
���   �   FloatingScale$	 0.8Q�5D      
������� �� 	MaxLength$	 400��5F      
���������5<      �� *%#Описание лекарства+{�5G      �� $ 	IsChecked�$2 ,MaterialDesignOutlinedTextBoxEnabledComboBox��6x   �� 5H      -   5        $��label_Номер��5H   q   
�������$��20(�6O   $y�Hidden=�6]   $��40��6�   $%��Bahnschrift Light SemiCondensed)�6�   ��6   �� *Номер лекарства+6�   � 5I      $��Center=�6   .+�5J      �� -   5        $��button_AddMedicines��5J      $	��252��6V   $��55��6b   $��Добавить��6n   $��16(�6�   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������ $
 Hand��6�     StyleButtonAllApplication#��[ 6�   �� 5K      -   5        $��40��5K      $��40��6$   $(��"/Resources/Images/icon_Refresh.png��60   $
 Hand��6\   $��	30 10 0 0q�6�   5L      5M      �� 5N   
   $X��RФорма медработника | Информация о лекарствах��6   $��20(�6G   $��	20 20 0 0q�6U   $
��Left=�6h   $	��Top=�6�   
���������6�   Z� 6�   5O      5P      