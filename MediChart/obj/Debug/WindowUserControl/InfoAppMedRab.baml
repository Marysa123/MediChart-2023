   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MediChart.WindowUserControlMediChart.WindowUserControl  5      /    )MediChart.WindowUserControl.InfoAppMedRab   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MediChart.WindowUserControl     5      $	��840��5      $
��1200��6   .��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $V��PФорма медработника | Информация о программе��6   $��20(�6F   $��	20 20 0 0q�6T   $
��Left=�6g   $	��Top=�6�   
���������6�   Z� 6�   �� 5   
   $����Здравствуйте! Данная программа предназначена для автоматизации работы медпункта. Она находится на стадии тестирования, поэтому не которые функции могут работать неправильно.��6    �� TextAlignment$ Justify=�6�   $��0��6�   $��0��6�   $
��Wrap=�6�   $��	30 65 0 0q�6  $��18(�6%  $
��Left=�63  $	��Top=�6N  
�������6f  �� 5   
   -   5        $��	icon_Exit��5       � Cursor$
 Hand��6!   $��2��6/   $%��/Resources/Images/icon_Exit.png��6C   $��Right=�6�   $��	0 25 25 0q�6�   $��24��6�   $	��Top=�6�   �� 5   
   $I��CГрафик работы медицинского кабинета��6   $��20(�6>   $��0 20 0 0q�6L   $��Regular"�6^   $��0��6s   $��1��6�   $��Center=�6�   $	��Top=�6�   
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5   E   $��0��6   $��1��6#   $��20 60 20 20q�60      AutoGenerateColumns .    CanUserAddRows .     HeadersVisibility$	 All=�6�      
IsReadOnly . 6�   5      5      