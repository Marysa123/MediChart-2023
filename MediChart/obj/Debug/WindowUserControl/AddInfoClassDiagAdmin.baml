   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediChart.WindowUserControlMediChart.WindowUserControl  5      7    1MediChart.WindowUserControl.AddInfoClassDiagAdmin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MediChart.WindowUserControl     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��840��5	      $
��1200��6   .��5
      �   � RowDefinitions  5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��6   $��2��6%    �� CornerRadius$ 	0 30 30 0��66   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF3A8003��5       � Offset$	 0.7Q�5      � 5      -   5        AnimationColor3��$ 	#FF4B8020��5      $	 0.2Q�5      � 5      -   5        AnimationColor2��$ 	#FF60A22C��5      $ 1Q�6+   5       5"      �� 5$   
   $���{Форма администратора | Добавление информации о классах и диагнозах��6   $��2��6]   $��20(�6q   $��	20 20 0 0q�6   $
��Left=�6�   $	��Top=�6�   
���������6�   Z� 6�   &   System.Windows.Controls.DataGrid  5%   
   -   5        $��GridListClass��5%      $��20(�6(      AutoGenerateColumns . $��0��6Q   	   
IsReadOnly	 . $��0��6s   
���   �$��20 70 20 10q�6�   
 J� Effect
 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         
BlurRadius$ 8Q�6#      ShadowDepth$ 10Q�62      Opacity$ 0.995Q�6C      Color$ 	#FF669D6C��6S   ��5)      �� 5*       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5+      -   5        5,      5.      �� 50   
   $%��Заполните данные��6   $��20(�6+   $��1��69   $��0 60 0 0q�6I   $��Regular"�6[   $��Center=�6q   $	��Top=�6�   
�������6�   �� 51   
   $��2��6   $	��Top=�6!   $��Center=�69   $	��400��6V   $ 10��6b   $��	0 110 0 0q�6t   
�������$	��240��6�   ._�52      ��  � DataContext 6   ��  �� ElementName$ GridListClass�� �� Path$ SelectedValue�.+�53      �� -   5        $��textbox_NomerClass��53      $	��350��6L   $��
10 20 10 0q�6X   $��20(�6l   
���   �.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Номер класса:��6�   $��60��6,   �� 
IsReadOnly .    UnderlineBrush �	#FF51F308   
Foreground
 �   �$��0 0 0 2q�6�  ���	#FF285602��65   �� *
Номер+6�  �� 54      -   5        $��textbox_NameClass��54      $	��350��6U   $��
10 10 10 0q�6a   $��20(�6u   
���   � . #��[  6�   $$ Название класса:��6  $��60��68   �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��64   �� *Название класса+6�  � 55      $��Center=�6   $��0 20 0 0q�69   .+�56      �� -   5        $��button_AddClass��56      $	��200��6R   $��55��6^   $��Добавить��6j   $��16(�6}   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������  � Cursor$
 Hand��6�     StyleButtonAllApplication#��[ 6�   �� 57      -   5        $��40��57      $��40��6(   $(��"/Resources/Images/icon_Refresh.png��64   $
 Hand��6`   $��	30 10 0 0q�6�   58      59      5:        5<   
   -	   5        $��GridListDignoz��5<      $��20(�6)   	 .  . $��1��6d   $��0��6q   
���   �$��20 20 20 10q�6�   
 5=        5>      $ 8Q�6#   $ 10Q�62   $ 0.995Q�6C   $ 	#FF669D6C��6S   ��5@      �� 5A      "  6   .�5B      -
   5        5C      5E      �� 5G   
   $%��Заполните данные��6   $��20(�6+   $��1��69   $��0 60 0 0q�6I   $��1��6[   $��Regular"�6h   $��Center=�6~   $	��Top=�6�   
�������6�   �� 5H   
   $��2��6   $	��Top=�6!   $��Center=�69   $��1��6V   $	��400��6c   $ 10��6o   $��	0 110 0 0q�6�   
�������$	��240��6�   ._�5I      ��  6   �� $ GridListDignoz��$ SelectedValue�.+�5J      �� -   5        $��textbox_NomerDiagnoz��5J      $	��350��6N   $��
10 20 10 0q�6Z   $��20(�6n   
���   � . #��[  6�   $" Номер диагноза:��6�   $��60��60   .  �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��67   �� *
Номер+6�  �� 5K      -   5        $��textbox_NameDiagnoz��5K      $	��350��6]   $��
10 10 10 0q�6i   $��20(�6}   
���   � . #��[  6�   $0 *Наименование диагноза:��6  $��60��6F   �	#FF51F308
 �   �$��0 0 0 2q�6�  ���	#FF285602��66   �� *+)Наименование диагноза+6�  � 5L      $��Center=�6   $��0 20 0 0q�69   .+�5M      �� -   5        $��button_AddDiagnoz��5M      $	��200��6V   $��55��6b   $��Добавить��6n   $��16(�6�   $��Center=�6�   $��0q�6�   $��Bahnschrift)�6�   
������ $
 Hand��6�   #��[ 6�   �� 5N      -   5        $��40��5N      $��40��6(   $(��"/Resources/Images/icon_Refresh.png��64   $
 Hand��6`   $��	30 10 0 0q�6�   5O      5P      5Q      �� 5R   
   -   5        $��	icon_Exit��5R      $
 Hand��6!   $��2��6/   $%��/Resources/Images/icon_Exit.png��6C   $��Right=�6�   $��	0 25 25 0q�6�   $��24��6�   $	��Top=�6�   5U      5V      