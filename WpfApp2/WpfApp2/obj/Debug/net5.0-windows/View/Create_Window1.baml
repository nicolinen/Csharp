   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.Create_Window1   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	      backgroundImage#���   5   	     � Title$  Create_Window1��5	   	   $	��450��6    $	��800��6-   $��16(�69    � 	Resources 5        	imgSource �� ImageSource �� Opacity��%�   &	       &	  e     ��5   
   QMC:/Users/nikol/source/repos/WpfApp2/WpfApp2/bin/Debug/net5.0-windows/food.jpg��6w   �� 5   
   # �  6-   $	 0.8Q�6W   6g   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��9* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   .+�5#   
   �� $��0��6   $��2��6   $��Danie:��6-   $
��Bold"�6>   
��� ���$��Comic Sans MS)�6d   �� 5$   
   $��0��6   $��3��6   $��Kraj pochodzenia:��6-   $
��Bold"�6I   
��� ���$��Comic Sans MS)�6o   �� 5&   
   -   5        $��txtName��5&   /   $��1��6   $��2��6   $��Comic Sans MS)�6>   �� 5'   
   -   5        $��
txtCountry��5'   /   $��1��6   $��3��6   $��Comic Sans MS)�6A   �� 5(   
   -   5         ��Name$ imgPhoto��5(   >   $��2��6   $��0��6   $��2��6-   6>   �� 5*   
   -   5        $��txtDescription��5*   C   $��2��6   $��2��6   $��2��6/   
������� �� TextWrapping$
 Wrap=�6r   �� 5+   
   -   5        $��btnUploadPhoto��5+   H   $��3��6   $��0��6   $��Wczytaj zdjęcie��6.   $��18(�6^   $
��Bold"�6l   
��� ���$��Comic Sans MS)�6�   �� 5,   
   -   5        $��btnSave��5,   ?   $��3��6   $��2��6   $��Zapisz��6.   $��18(�6N   $
��Bold"�6\   
��� ���$��Comic Sans MS)�6�   �� 5-   
   -   5        $��btnClose��5-   @   $��3��6   $��3��6   $��Zamknij��6.   $��18(�6P   $
��Bold"�6^   
��� ���$��Comic Sans MS)�6�   54      55      