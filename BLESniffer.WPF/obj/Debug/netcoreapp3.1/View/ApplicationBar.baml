   M S B A M L   `   `   `  ����  BLESniffer.WPF(    "BLESniffer.WPF.View.ApplicationBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth	   	Direction
   Opacity A�Name �� Stretch   
BlurRadius �� Triggers :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration	 t� To��%z  '��       'd� �     �� 5	   
   " ��6   .�5
      ��  � ��
 �����6+   �� 5       � ��
 �iii�6+   �� 5       � ��$ 0q�60   5      �� 5   
   " d�6   .�5      ��  � �� 5      �� 5      " d�6&   .R�5      (� .��5      �� $ Border��6%   $ 10��65   ���	#FFFFFFFF$��40��5      $��20��6(    5   "     5   &   $	 0.5Q�67   $	 0Q�6I   $	
 0.3Q�6W   ._�5   "   A� $ Ellipse��6*   ���	#FFFFFFFF$ Uniform=�6L   $��2 1 2 1q�5   "   
�������$	��0.2��5   0   $��Stretch=�5   "    5   &     5   *   $ 10Q�6;   $ 1Q�6K   $	
 0.3Q�6[   $		 260Q�6i   5    #   5!      5"       5#      :� 5$      $ Checked��6+   .[�5%   "   �� .��5&   &   �� .��5'   *   �� $ Border��69   $1 +(Border.Background).(SolidColorBrush.Color)�5(   5    	#FF4CD6615)   5   $ 0:0:0.1D�5*   5   t� 5+   *   $ Ellipse��6=   $ Margin�5,   9    20 1 2 15-   9   $ 0:0:0.1D�5.   9   5/   '   50   #   51      :� 52      $ 	Unchecked��6+   .[�53   "   �� .��54   &   �� .��55   *   �� $ Border��69   $1 +(Border.Background).(SolidColorBrush.Color)�56   5   	 White57   5   $ 0:0:0.1D�58   5   t� 59   *   $ Ellipse��6=   $ Margin�5:   9    2 1 2 15;   9   $ 0:0:0.1D�5<   9   5=   '   5>   #   5?      5A      5C      5D      5E      .��5F      ]� .+�5G   
   � $	��Top=�6   .+�5H      �� $	��150��6   ��5I      �� 5J      " ��6   .�5K      ��  � ��$  Scanning for BLE Telegrams��61   �� 5L       � ��$ Center=�6@   �� 5M       � ��$ Center=�6>    �� Triggers 5N      �� 5O       �� Binding 6*   �� *ScanningState+ �� Value	 false6L   .a�5P   "   ��  � ��$ Stopped scanning��69   5Q      5S      5U      d� 5V   
   $��20��5W      $��Right=�5X       d� 	IsChecked 5Y      �� *ScanningState+5Z      �� 5[   
   $	��Top=�6   $��Stretch=�6'   $��Export��6E   ��6V   �� *
ExportData+�� 5]   
   $��Bottom=�6   $��35��6B   ��6,   �� *Info+6B   5^      5_      