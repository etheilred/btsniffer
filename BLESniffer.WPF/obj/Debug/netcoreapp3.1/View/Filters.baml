   M S B A M L   `   `   `  ����I  EBLESniffer.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BLESniffer.WPF.ViewBLESniffer.WPF.View  5      C&clr-namespace:BLESniffer.WPF.ViewModelBLESniffer.WPF.ViewModel  5      !    BLESniffer.WPF.View.Filters   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BLESniffer.WPF.View     5      5VM&clr-namespace:BLESniffer.WPF.ViewModel     5        � DataContext  5
      /   )BLESniffer.WPF.ViewModel.FiltersViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   .+�5   
   9�  9� 
IsExpanded$
 True��6   .��5      ��  �� SelectionMode$ Single=�5      $��Stretch=�5       �� SelectedItem 5      �� *SelectedManufacturer+��5      �� *bluetoothData.Manufacturers+ �� 
AsyncState$
 true����5      �� 5      .R�5      �� $��25��6!   $��1q�6-   
�������._�5      �� ��6(   �� *ManufacturerName+5      5      5       5!      5"      5#      