   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      > :EMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EMS.Views	EMS.Views 5      -clr-namespace:EMS.ViewModelEMS.ViewModel 64   -clr-namespace:EMS.ViewModelEMS.ViewModel 5         EMS.Views.Project   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9system&clr-namespace:System;assembly=mscorlib     5      )localclr-namespace:EMS.Views     5      1	viewmodelclr-namespace:EMS.ViewModel     64   .local2clr-namespace:EMS.ViewModel     5        � DataContext  5      $  EMS.ViewModel.ProjectViewModel  5   
    � 	Resources 5         actions �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value
 ��Name��%[  &	        �� 5   
   " ��6    .�5      ��  � ��$ 	20 5 10 5q�6'   �� 5       � ��$ 30��6&   �� 5       � ��$ 30��6'   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   
�������$��1q�6F   ��5      �� 5   "   " ��6(    5   &   P� 5   *    �@J�IsMouseOver	 . . �5    .   ��  � ��
 �����6K   5"   +   5%   #   ._�5(      �� $
 ContentPresenter��6/   #��z��6I   #��z��6}   $��Center=�6�   $��Center=�6�   5*      5+      5-      5/      51      52      .��53      � .+�54   
   � y�6   �� *ProjectMain+.+�55      ��  �� Orientation$ Vertical=�6   $��1��60   .+�57      �� $��Project��6   $��30(�6*   �� 58      $	��ADD��6   $��70��6(   $��30��63   $
��Left=�6?   $��0 10 0 0q�6Z   $��
AddProject��6�   ��6l   �� *ProjectOperations+6�   �� 59      $��	0 10 0 20q�6   � 5:       � ColumnDefinitions 5;      �� 5<      $
��auto �6+   �� 5=      $
��auto �6,   �� 5>       � RowDefinitions 5@      �� 5A      �� 5B      .+�5D      �� $��0��6!   $��0��6.   $ 
Horizontal=�6>   .+�5E      �� $��Code:��6    $��Center=�60   $��0 0 20 0q�6K   � 5F      .+�5G      �� -   5         ��Name$ ProjectCode��5G   ]   $��Center=�6'   $
��Left=�6B   $��5q�6r   
���   ���6�   �� *CurrentProject.ProjectCode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5H       J� IsHitTestVisible .  $��Project Code��6A   $��Center=�6U   $
��Left=�6p   $��10,0,0,0q�6�   
���������5I   "   �� 5J   &   " ��6,   .�5K   *   ��  � y�$ 	Collapsed=�6G    5L   *   �� 5M   .    �� Binding 6:   �� *Text+ �� ElementName$ ProjectCode�� �� Value  6l   .a�5N   2   ��  � y�$ Visible=�6O   5O   /   5Q   '   5S      5T      5U      �� 5W      $��1��6!   $��0��6.   $ 
Horizontal=�6>   .+�5X      �� $��Start Date:��6    $��Center=�66   (  "System.Windows.Controls.DatePicker  5Y         IsTodayHighlighted . |�.     SelectedDate 6%   �� *CurrentProject.StartDate+$ PropertyChanged=�$ TwoWay=�6�   5[      �� 5]      $��0��6!   $��1��6.   $ 
Horizontal=�6>   $��20 0 0 0q�6W   .+�5^      �� $��Name:��6    $��Center=�60   $��0 0 12 0q�6K   � 5_      .+�5`      �� -   5        $ ProjectName��5`   ]   $��Center=�6'   $
��Left=�6B   $��5q�6r   
���   ���6�   �� *CurrentProject.ProjectName+$ TwoWay=�$ PropertyChanged=��� 5a       .  $��Project Name��6A   $��Center=�6U   $
��Left=�6p   $��10,0,0,0q�6�   
���������5b   "   �� 5c   &   " ��6,   .�5d   *   ��  � y�$ 	Collapsed=�6G    5e   *   �� 5f   .    6:   �� *Text+$ ProjectName��  6l   .a�5g   2   ��  � y�$ Visible=�6O   5h   /   5j   '   5l      5m      5n      �� 5o      $��1��6!   $��1��6.   $ 
Horizontal=�6>   $��20 0 0 0q�6W   .+�5p      �� $��	End Date:��6    $��Center=�64     5q       . |�.   6%   �� *CurrentProject.EndDate+$ PropertyChanged=�$ TwoWay=�6�   5s      � 5t      $��1��6   $��2��6(   $��40 0 0 0q�68   $��Right=�6J    5u      �� 5v      �� 5w      .+�5z      �� $��Search��6!   $��0��62   $��80��6B   $��Search��6s   $��0 0 10 0q�6�   ��6M   �� *ProjectOperations+6�   �� 5{      $��Clear��6!   $��1��61   $��80��6A   $��Clear��6r   $��0 0 10 0q�6�   ��6L   �� *ProjectOperations+6�   5|      5}      �� 5~      $��	0 15 0 25q�6   &   System.Windows.Controls.DataGrid  5      -   5          Name$ projectTable��5   �      AutoGenerateColumns .     CanUserAddRows .  $
��auto��6O   $   HorizontalScrollBarVisibility$ Disabled=�6]   "   VerticalScrollBarVisibility$
 Auto=�6�      CanUserResizeRows .     CanUserResizeColumns .     
IsReadOnly . $	��200��6
     HeadersVisibility$ Column=�6  ��65  ��   �� Path$  Projects�! �� SelectedItem! 6[  �� $  AlterProject�$ TwoWay=�$ PropertyChanged=�"   Columns" 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn#   Header$
# Code��6-   $   Width5  /System.Windows.Controls.DataGridLengthConverter$$ 2* 6;   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 6F   �� *ProjectCode+  5�      $
# Name��6-   $$ 6* 6;   % 6F   �� *ProjectName+  5�      $# 
Start Date��6-   $$ 3* 6A   % 6L   �� *	StartDate+  5�      $# End Date��6-   $$ 3* 6?   % 6J   �� *	EndDate+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $$ 5* 61   $# Actions��6<   &   CellTemplate& 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� #��[  61   $
��edit��6�   ��6R   �� *DataContext.ProjectOperations+' �� RelativeSource' �� ( �� AncestorType$( DataGridL�) �� AncestorLevel$) 1��.��5�   .   �� $.��(C:\Users\NEHA UTTWANI\Downloads\edit.png��64   5�   +   �� 5�   *   #��[  61   $��Remove��6�   ��6R   �� *DataContext.ProjectOperations+' �� $( DataGridL�$) 1��.��5�   .   �� $0��*C:\Users\NEHA UTTWANI\Downloads\remove.png��64   5�   +   �� 5�   *   #��[  61   $��employeeMapping��6�   ��6R   �� *DataContext.ProjectOperations+' �� $( DataGridL�$) 1��.��5�   .   �� $3��-C:\Users\NEHA UTTWANI\Downloads\employees.png��64   5�   +   5�   '   5�   #   5�      5�      5�      5�      � 5�      y�6   �� *
ProjectAdd+.+�5�      �  5�      �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   .+�5�      �� $��Project - Add��6   $��30(�60   $��0��6>   �� 5�      $��1��6   $��	0 10 0 30q�6*   �� 5�      $��2��6   $ 
Horizontal=�6*   {�.  $��0 0 0 10q�6U   .+�5�      �� $��Code:��6   $��Center=�6,   $��0 0 20 0q�6G   $��2��6Y   $��0��6f   � 5�      $��2��6   $��1��6(   $��24 0 0 0q�68   .+�5�      �� -   5        $
 Code��5�   Y   $��Center=�6#   $
��Left=�6>   $��5q�6g   
���   ���6�   �� *CurrentProject.ProjectCode+$ TwoWay=�$ PropertyChanged=��� 5�       .  $��Project Code��6=   $��Center=�6Q   $
��Left=�6l   $��10,0,0,0q�6�   
���������5�      �� 5�   "   " ��6(   .�5�   &   ��  � y�$ 	Collapsed=�6C    5�   &   �� 5�   *    66   �� *Text+$
 Code��  6a   .a�5�   .   ��  � y�$ Visible=�6K   5�   +   5�   #   5�      5�      5�      �� 5�      $��3��6   $ 
Horizontal=�6*   $��0 0 0 10q�6C   .+�5�      �� $��*Name:��6   $��Center=�6-   $��0 0 20 0q�6H   $��2��6Z   $��0��6g   � 5�      $��2��6   $��1��6(   $��16 0 0 0q�68   .+�5�      �� -   5        $
 Name��5�   Y   $��Center=�6#   $
��Left=�6>   $��5q�6g   
���   ���6�   �� *CurrentProject.ProjectName+$ TwoWay=�$ PropertyChanged=��� 5�       .  $��Project Name��6=   $��Center=�6Q   $
��Left=�6l   $��10,0,0,0q�6�   
���������5�      �� 5�   "   " ��6(   .�5�   &   ��  � y�$ 	Collapsed=�6C    5�   &   �� 5�   *    66   �� *Text+$
 Name��  6a   .a�5�   .   ��  � y�$ Visible=�6K   5�   +   5�   #   5�      5�      5�      �� 5�      $��4��6   $ 
Horizontal=�6*   $��0 0 0 20q�6C   .+�5�      �� $��*Start Date:��6   $��Center=�63     5�       . $��21 0 0 0q�6�   |�.   6<   �� *CurrentProject.StartDate+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $��5��6   $ 
Horizontal=�6*   $��0 0 0 20q�6C   .+�5�      �� $��	End Date:��6   $��Center=�60     5�      $��30 0 0 0q�6�   |�.   6"   �� *CurrentProject.EndDate+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $��6��6   $ 
Horizontal=�6*   $��0 0 0 50q�6C   .+�5�      �� $��*Technology: ��6   $��Center=�64   �� 5�      $	��200��6K   $��10 0 0 0q�6W   $
��Auto=�6i   $��Disabled=�6�   $
��auto��6�   $	��150��6�   * �� SelectionMode$* Single=�6J  ��6   �� *ProjectTechnologies+! 6�   �� *CurrentTechnology+$ TwoWay=�$ PropertyChanged=���5�      �� 5�      .R�5�   "   �� ��6,   �� *TechnologyName+5�      5�      5�      �� 5�      $��7��6   $ 
Horizontal=�6*   $��90 0 0 0q�6C   .+�5�      �� $
��Save��6   $��80��6,   $��0 0 16 0q�67   $��SaveProject��6o   ��6I   �� *ProjectOperations+6o   �� 5�      $��Cancel��6   $��80��6.   $��16 0 0 0q�69   $��35��6K   $��Cancel��6}   ��6W   �� *ProjectOperations+6}   5�      5�      5�      5�      5�      