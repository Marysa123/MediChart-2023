   M S B A M L   `   `   `  ����D  @MediChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MediChart.WindowsMediChart.Windows  5   	   #    MediChart.Windows.SignInAndUp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MediChart.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$?  9Окно авторизации и регистрации��5	   	   $	��360��60   $	��370��6=    � WindowStartupLocation$ CenterScreen=�6I    � WindowStyle$
 None=�6n    � AllowsTransparency . 
������ .��5
      � .+�5   
   ��  �� CornerRadius$ 10��6   ��5      �� 5      .��5      �  � Color$ 	#FF3A8003��5       � Offset$ 0.169Q�5      � 5      $ 	#FF97E45A��5      $ 1Q�5      5      5      �� 5   
   -   5        $��	icon_Exit��5       � Cursor$
 Hand��6!   $%��/Resources/Images/icon_Exit.png��6O   $��Right=�6x   $��	0 25 25 0q�6�   $��24��6�   $	��Top=�6�   $��2��6�   � 5   
   $��20 20 20 20q�6   .+�5      �� $��Medium"�6   $��Вход��6(   $��24(�67   $
��Left=�6E   $��	40 20 0 0q�6`   $	��Top=�6s   
�������$��Roboto)�6�   �� 5      -   5        $��button_Registration��5   \   $��Right=�6   $	��Top=�61   $��	0 20 50 0q�6I   ._�5      �� -   5        $��label_ShowRegister��5   �   $��Medium"�6   $��Регистрация��6,   $��24(�6B   $��Right=�6P   $	��Top=�6l   $
 Hand��6�   
�������$��Roboto)�6�   ��5      �� 5       �� 
TargetType" ��6   .�5       �� 	 �� Property	 � ��
 �� Value$
 0 0 0 2q�6<   �� 5!      	 �@��CornerRadius$	
 0.5��69    �� Triggers 5"      P� 5#       P� Property �@J�IsMouseOver P� Value . . �5$   "   �� 	 � ��
 �	#FF3FC1346@   5%      5'      5)      '  !MaterialDesignThemes.Wpf.PackIcon  5+      
�������$��0 0 0 80q�69   $��35��6K   $��35��6V      Kind$ 
UserCircle=�6b   $��Center=�6t     5,      
�������$��0 50 0 0q�69   $��35��6K   $��35��6V   $	 Key=�6b   $��Center=�6m   �� 5-      $��	30 80 0 0q�6   .+�5.      �� -   5        $��textbox_Login��5.       �� 
CaretBrush
 ��������	#FF138300$��10 0 0 0q�6^   $��20(�6p   
�������.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Введите логин:��6  $��65��61  $	��280��6=     UnderlineBrush �	#FF3FC134   
Foreground
 �����$��0 0 0 2q�6�  G� 5/      -   5         G�Name$ textbox_Password��5/      $��45��68   $	��280��6D   $" Введите пароль:��50       . ���	#FF138300 G� 
CaretBrush
 �����$�� 0 0 0 2q�54      $��20(�55      $��	10 20 0 0q�56      
�������
������  �	#FF3FC13459      5:      �� 5<      -   5         ��Name$ border_SignIn��5<      $��1q�6P   $	��170��6d   $��40��6p   $ 20��6|   $��Bottom=�6�   $��0 0 0 10q�6�   $��Center=�6�   $
 Hand��6�   ��5=      �� 5>       �� 
StartPoint$ 0.5,0&�6*    �� EndPoint$ 0.5,1&�6=   .��5?      � $ White��6'   $ 0Q�5@   '   � 5A      $ 	#FF317D1D��6'   $ 1Q�5B   '   5C      ��5E      �� 5F      " ��6   .�5G      �� 	 � ��

 ���� 67    5H      �� 5I       �� Binding 6*   �� *IsMouseOver+ �� ElementName$ border_SignIn�� �� Value true6d   .a�5J   "   �� 	 � ��
 5K   &   �� 5L   *   $ 0.5,0&�6>   $ 0.5,1&�6Q   .��5M   .   � $ 	#FF6DC82A��6;   $ 0Q�5N   '   � 5O   .   $ 	#FF61B325��6;   $ 1Q�5P   '   5Q   +   5S   #   5T      5V      ._�5X      �� $��
Войти��6   $��19(�6(   
�������$!��Bahnschrift Light Condensed)�6I   $��Center=�6r   $��Center=�6�   5Y      5Z      5[      5\      