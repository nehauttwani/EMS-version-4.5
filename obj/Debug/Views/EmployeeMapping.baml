   M S B A M L   `   `   `  ����>  :EMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EMS.ViewModelEMS.ViewModel  5   	   clr-namespace:EMSEMS  67       EMS.Views.EmployeeMapping   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1	viewmodelclr-namespace:EMS.ViewModel     5   	   $local1clr-namespace:EMS     67     � Title$  Employee Mapping��5	   	   $	��450��6"   $	��550��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � 	Resources 5
         actions �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value ��Name��%[  &	        �� 5   
   " ��6    .�5      ��  � ��$ 	20 5 10 5q�6'   �� 5       � ��$ 30��6&   �� 5       � ��$ 30��6'   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   
�������$��1q�6F   ��5      �� 5   "   " ��6(   	 5   &   P� 5   *   
 �@J�IsMouseOver . . �5   .   ��  � ��
 �����6K   5   +   5    #   ._�5#      �� $ ContentPresenter��6/   #��z��6I   #��z��6}   $��Center=�6�   $��Center=�6�   5%      5&      5(      5*      5,      5-      .��5.      � .+�5/   
   �� .+�50      ��  �� Orientation$ 
Horizontal=�6   .+�51      �� $��0��6   $��Employee mapping -��6"   $��20(�6?   $��10 0 0 0q�6M   �� 52      $��0��6   $��20(�6x   ��6&   ��  �� Path$ Project.ProjectName� �� UpdateSourceTrigger$ PropertyChanged=�6x   53      �� 54      � 55       � ColumnDefinitions 56      �� 57      $
��auto �6'   �� 58      $
��auto �6'   .+�5:      �� $ 
Horizontal=�6   $��	0 20 0 0 q�67   $��0��6J   .+�5;      �� $��
Employee: ��6   $��Center=�61   $��10 0 0 0q�6L   �� 5<       �� 
IsEditable .  �� IsTextSearchEnabled .   �� DisplayMemberPath$ FullName��6x   $	��300��6�    �� SelectedValuePath$ FullName��6�   ��6M   �� *FilteredEmployees+ �� Text 6�   �� *
SearchText+ �� Mode$ TwoWay=�$ PropertyChanged=� �� SelectedValue 5=      �� *CurrentEmployee.FullName+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 5>      �� *CurrentEmployee+$ TwoWay=�$ PropertyChanged=� � Triggers 5@      :� 5A       :� RoutedEvent$ TextBoxBase.TextChanged��6+   .[�5B   "   �� .��5C   &   �� .��5D   *   ��  �� TargetProperty$ IsDropDownOpen�6I   .p�5E   .   s�  �� Value .  �� KeyTime$ 0:0:0��6S   5F   +   5G   '   5H   #   5I      5K      5M      �� 5O      $
��Save��6   $	��100��6,   $��40 20 20 0 q�68   $��EmployeeMap��6s   $��1��6�   $��35��6�   ��6M   �� *MappingOperations+6�   5R      &   System.Windows.Controls.DataGrid  5S         AutoGenerateColumns .     CanUserAddRows .  $��
15 50 7 50q�6w   $
��auto��6�   $    HorizontalScrollBarVisibility$  Disabled=�6�   "!   VerticalScrollBarVisibility$
! Auto=�6�   "   CanUserResizeRows" .  #   CanUserResizeColumns# .  $   
IsReadOnly$ . $	��200��6�  %   HeadersVisibility$% Column=�6�  ��6   �� $ MappedEmployees� 6  �� *SelectedEmployee+$ OneWayToSource=�$ PropertyChanged=�&   Columns& 5T      0  *System.Windows.Controls.DataGridTextColumn  5V      '   
Foreground
' �   �,  &System.Windows.Controls.DataGridColumn(   Header$( Employee Name��6<   )   Width5  /System.Windows.Controls.DataGridLengthConverter$) 6* 6S   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 6^   �� $ FullName�4  .System.Windows.Controls.DataGridTemplateColumn  5W      $( Actions��6-   $) 2* 6>   +   CellTemplate+ 5X      �� 5Y      .R�5Z   "   �� #��[  6)   $��
deleteQual��6�   $��15��6�   $��20��6�   ��6J   �� *DataContext.MappingOperations+, �� RelativeSource, �� - �� AncestorType$- DataGridL�. �� AncestorLevel$. 1��.��5[   &   �� $0��*C:\Users\NEHA UTTWANI\Downloads\cancel.png��6,   5\   #   5^      5`      5c      5e      5f      5g      