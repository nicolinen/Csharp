   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	      backgroundImage#���   5	   	     � Title$  Książka kucharska��5
   	   $	��450��6#   $	��800��60   $��16(�5   	    � 	Resources 5        	imgSource �� ImageSource �� Opacity��%�   &	       &	  e     ��5   
   QMC:/Users/nikol/source/repos/WpfApp2/WpfApp2/bin/Debug/net5.0-windows/food.jpg��6w   �� 5   
   # �  6-   $	 0.8Q�6W   6g   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    �� 5      $��9* �6    �� 5       $��* �6     � ColumnDefinitions 5$      �� 5%      $��* �6'   �� 5&      $��* �6'   �� 5'      $��* �6'   �� 5(      $��* �6'   .+�5+      �� $��0��6   $��0��6%   $��Wybór:��65   $
��Bold"�6F   
��� ���$��Comic Sans MS)�6l   �� 5,      $��0��6   $��2��6%   $��Danie:��65   $
��Bold"�6F   
��� ���$��Comic Sans MS)�6l   �� 5-      $��0��6   $��3��6%   $��Kraj pochodzenia:��65   $
��Bold"�6Q   
��� ���$��Comic Sans MS)�6w   �� 5.      -   5        $��cmbListView��5.   L   $��1��6   $��0��6(   $��2��68   6�   �� 50      -   5        $��txtName��50   I   $��1��6   $��2��6'    �� 
IsReadOnly$
 True��67   $��Comic Sans MS)�6X   �� 51      -   5        $��
txtCountry��51   I   $��1��6   $��3��6'   $
 True��67   $��Comic Sans MS)�6[   �� 52      -   5         ��Name$ imgPhoto��52   F   $��2��6   $��0��6%   $��2��65   6F   �� 54      -   5        $��txtDescription��54   ]   $��2��6   $��2��6'   $��2��67   $
 True��6K    �� TextWrapping$
 Wrap=�6s   
�������6�   �� 55      -   5        $��	btnCreate��55   N   $��3��6   $��0��6&   $��Dodaj przepis��66   $��18(�6_   $
��Bold"�6m   
��� ���$��Comic Sans MS)�6�   �� 56      -   5        $��	btnUpdate��56   G   $��3��6   $��1��6&   $��Edytuj��66   $��18(�6X   $
��Bold"�6f   
��� ���$��Comic Sans MS)�6�   �� 57      -   5        $��	btnDelete��57   E   $��3��6   $��2��6&   $��Usuń��66   $��18(�6V   $
��Bold"�6d   
��� ���$��Comic Sans MS)�6�   �� 58      -	   5        $��btnClose��58   H   $��3��6   $��3��6&   $��Zamknij��66   $��18(�6X   $
��Bold"�6f   
��� ���$��Comic Sans MS)�6�   5A      5B      