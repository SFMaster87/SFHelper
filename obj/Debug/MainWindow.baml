   M S B A M L   `   `   `  ����C  ?SFHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SFHelperSFHelper  5   	   G CToggleSwitch, Version=1.2.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:ToggleSwitch;assembly=ToggleSwitchToggleSwitch 6.       SFHelper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SFHelper     5   	   IToggleSwitch0clr-namespace:ToggleSwitch;assembly=ToggleSwitch     6.   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ SFHelper��5	   	   $	��476��6   $	��714��6'   .��5
      � .+�5   
   )  #ToggleSwitch.HorizontalToggleSwitch  -   5          Name$ EditButtonOnOff��5      #  ToggleSwitch.ToggleSwitchBase   	IsChecked .  $��Bottom=�5      $��	0,0,11,13q�5      $��Right=�5      $��81��6)   $��35��64   6b   �� 5   
   -   5         ��Name$ TablesComboBox��5      $��	10,10,0,0q�6+   $
��Left=�6q   $	��220��6�   $��30��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ TitlesListBox��5      $��10,118,0,56q�6*   $
��Left=�6q   $	��220��6�   �� 5   
   -   5         ��Name$ AddTableButton��5      $#��Добавить раздел��6)   $
��Left=�6C   $��40��6^   $��	10,45,0,0q�6j   $	��Top=�6}   $	��105��6�   6�   �� 5   
   -   5         ��Name$ 	TextTitle��5       �� 
IsReadOnly . 	 �� TextWrapping$
	 Wrap=�67   $��14(�6K   "
 �� VerticalScrollBarVisibility$

 Auto=�6Y   $��235,10,11,56q�6|    �� AcceptsReturn . 6�   �� 5   
   -   5        $ AddTitleButton��5      $��Добавить тему��6)   $
��Left=�6A   $��9,0,0,10q�6\   $	��105��6n   $��41��6�   $��Bottom=�6�   �� 5   
   -   5        $ DelTableButton��5      $!��Удалить раздел��6)   $
��Left=�6B   $��40��6]   $��
120,45,0,0q�6i   $	��Top=�6}   $	��111��6�   6�   �� 5   
   -	   5        $ DelTitleButton��5      $��Удалить тему��6)   $��
119,0,0,10q�6@   $��41��6q   $��Bottom=�6}   $
��Left=�6�   $	��111��6�   �� 5   
   -
   5        $ PrimenitButton��5      $��Применить��6)   $��	0,0,97,13q�6=   {�.  $��Right=�6b   $	��114��6~   $��35��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ 	searchBox��5      $
��Left=�6%   $��23��6@   $��	60,90,0,0q�6L   $
	 Wrap=�6_   $	��Top=�6s   $	��170��6�   6�   �� 5   
   $��Поиск:��6   $
��Left=�6!   $��	15,93,0,0q�6<   $	��Top=�6O   $��40��6g   $��20��6r   
���   ���6~   Z� 6�   �� 5   
   -   5        $ searchBoxInText��5      $
��Left=�6+   $��23��6F   $��313,403,0,0q�6R   $
	 Wrap=�6g   $	��Top=�6{   $	��170��6�   6�   �� 5   
   $��Поиск:��6   $
��Left=�6!   $��268,406,0,0q�6<   $	��Top=�6Q   $��40��6i   $��20��6t   
���   ���6�   Z� 6�   5      5      