   M S B A M L   `   `   `  ����>  :EMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EMS.Views	EMS.Views  5      %clr-namespace:EMS.Model	EMS.Model  64   -clr-namespace:EMS.ViewModelEMS.ViewModel  6Z       EMS.Views.Technology   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:EMS.Views     5      )modelclr-namespace:EMS.Model     64   .local1clr-namespace:EMS.ViewModel     6Z     � 	Resources  5
      ��%    5      .��5      �� .+�5   
   �� $��0��6   $��
Technology��6   $��30(�63   �� 5   
   � 5   
    � ColumnDefinitions 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	0 20 0 0 q�63   $��0��6F   .+�5      �� $��Technology: ��6   $��Center=�6/   � 5      .+�5      �� -   5         ��Name$ SearchTermTextBox��5   U   $��Center=�6   $
��Left=�6:   $��5q�6p   
���   ���6�   �� *" CurrentTechnology.TechnologyName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=��� 5       J� IsHitTestVisible .  $��Technology Name��69   $��Center=�6P   $
��Left=�6k   $��10,0,0,0q�6�   
���������5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � y�	 �� Value$	 	Collapsed=�6?   
 �� Triggers
 5   "   �� 5    &    �� Binding 62   �� *Text+ �� ElementName$ SearchTermTextBox�� �� Value  6j   .a�5!   *   ��  � y�$	 Visible=�6G   5"   '   5$      5&      5'      5(      �� 5)      $ 
Horizontal=�6   $��
60 20 0 0 q�62   $��Right=�6F   $��1��6b   .+�5*      �� $
��Save��6   $	��100��6(   $��	0 0 20 0 q�64   $��SaveEditOperation��6p   ��6G   �� *TechnologyOperations+6p   �� 5+      $
��Edit��6   $	��100��6(   $��	0 0 20 0 q�64   $��EditTechnology��6�   {�6G   �� $ technologyTable�� �� Path$ SelectedItems.Count���6�   �� *TechnologyOperations+6�   �� 5-      -   5         ��Name$ delete��5-   *   $��Delete��6   $	��100��6:   $��DeleteTechnology��6�   {�6G   �� $ technologyTable��$ SelectedItems.Count���6�   �� *TechnologyOperations+5/      50      51      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ technologyTable��52        AutoGenerateColumns .     CanUserAddRows .  $��	0 50 0 50q�6p   $
��auto��6�   $   HorizontalScrollBarVisibility$ Disabled=�6�   "   VerticalScrollBarVisibility$
 Auto=�6�      CanUserResizeRows .     CanUserResizeColumns .     
IsReadOnly . $	��200��6�     HeadersVisibility$ Column=�6�  ��6   �� $ Technologies� �� SelectedItem 6.  �� *AlterTechnology+$ TwoWay=�$ PropertyChanged=�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54         
Foreground
 �   �,  &System.Windows.Controls.DataGridColumn   Header$ ID��68      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� $ TechnologyID�  55      
 �   �$ 
Technology��68   $ 6* 6L    6W   �� $ TechnologyName�58      5:      5;      