   M S B A M L   `   `   `  ����>  :EMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EMS.Views	EMS.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 64   -clr-namespace:EMS.ViewModelEMS.ViewModel  6u       EMS.Views.Dashboard   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:EMS.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     64   1	viewmodelclr-namespace:EMS.ViewModel     6u   .��5	      �   � RowDefinitions  5
   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� 
���   �$��3,3,3,3q�6%   $	��180��6@   $��5q�6M   $	��350��6X   $��0��6d   $��0��6q   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ ��Designation-wise Employees��6   $��Center=�6=   $��Medium"�6Z   $��15(�6n     LiveCharts.Wpf.PieChart  5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6      	Hoverable . $	��120��6_      DataTooltip 6H   Z�    Series 6l   �� *
Collection+5      5      5      �� 5   
   
��� � �$��3,3,3,3q�6%   $	��180��6@   $��5q�6M   $	��350��6X   $��0��6d   $��1��6q   5      �� 5    
   
��� � �$��3,3,3,3q�6%   $	��180��6@   $��5q�6M   $	��350��6X   $��1��6d   $��0��6q   5"      �� 5#   
   
��� � �$��3,3,3,3q�6%   $	��180��6@   $��5q�6M   $	��350��6X   $��1��6d   $��1��6q   5%      5&      5'      