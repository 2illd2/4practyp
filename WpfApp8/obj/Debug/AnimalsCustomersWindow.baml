   M S B A M L   `   `   `  ����B  >WpfApp8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp8WpfApp8  5   	   $    WpfApp8.AnimalsCustomersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp8     5   	     � Title$  AnimalsCustomersWindow��5   	   $	��450��6(   $	��800��65    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  '��       �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 0 10q�6'   �� 5       � �� �	#FF31C8F96+   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5       .��5!      �  � ColumnDefinitions 5"   
   �� 5#      �� 5$       � RowDefinitions 5'   
   �� 5(      $��* �6   �� 5)      $��* �6   �� 5*      $��* �6   �� 5+      $��* �6   .+�5-   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 AnimalsCustomersGrd��5-      
   AutoGenerateColumns
 .  $��0��6L   $��4��6Y      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ имя животного��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
AnimalName+6D     50      $ тип��6G    6%   �� *AnimalSpecies+6G     51      $ возраст��6C    6%   �� *	AnimalAge+6C     52      $ цена��6E    6%   �� *AnimalPrice+6E     53      $ имя клиента��6F    6%   �� *CustomerName+6F     54      $ 
почта��6G    6%   �� *CustomerEmail+6G   56      �� 57   
   -   5         ��Name$ TextBoxName��57      $��1��6X   $��1��6e   $��100px��6u   $��30��6�   ���	#3389B498$
��Left=�6�   �� 58   
   -   5        $ TextBoxSpecies��58      $��1��6^   $��1��6k   $��100px��6{   $��30��6�   ���	#3389B4986�   �� 59   
   -   5        $ 
TextBoxAge��59   A   $��2��6U   $��1��6b   $��100px��6r   $��30��6�   ���	#3389B498$
��Left=�6�   �� 5:   
   -   5        $ TextBoxPrice��5:   C   $��2��6Y   $��1��6f   $��100px��6v   $��30��6�   ���	#3389B4986�   �� 5;   
   -   5        $ TextBoxCustomerName��5;      $��1��60   $��1��6=   $��100px��6M   $��30��6[   ���	#3389B498$��Right=�6~   �� 5<   
   -   5        $ TextBoxCustomerEmail��5<      $��2��61   $��1��6>   $��100px��6N   $��30��6\   ���	#3389B498$��Right=�6   �� 5=   
   $��Имя клиента:��6   $��1��6(   $��1��68   $	��Top=�6E   $��Right=�6]   �� 5>   
   $��Почта:��6   $	��Top=�6"   $��2��6:   $��1��6G   $��Right=�6W   �� 5?   
   $ ��Имя животного:��6   $��1��6*   $��1��6:   $	��Top=�6G   $
��Left=�6_   �� 5@   
   $��Тип:��6   $	��Top=�6    $��1��68   $��1��6H   $��Center=�6U   �� 5A   
   $��Возраст:��6   $
��Left=�6$   $	��Top=�6?   $��1��6W   $��2��6g   6v   �� 5B   
   $��	Цена:��6   $	��Top=�6"   $��1��6:   $��2��6J   $��Center=�6W   6v   (  "System.Windows.Controls.DatePicker  5C   
   -   5          Name$ DatePickerOrderDate��5C         SelectedDateFormat$ Short=�62   $��3��6M   $��1��6Z   $��100px��6j   $��30��6x   ���	#3389B498$
��Left=�6�   �� 5D   
   $��	Дата:��6   $	��Top=�6"   $��1��6:   $��3��6J   $
��Left=�6W   6t   �� 5G   
   -	   5        $��Добавить��5G      $	��Top=�6<   $��0��6T   $��1��6a   $	��100��6q   $
��Left=�6}   �� 5H   
   -
   5        $��Изменить��5H      $	��Top=�6?   $��0��6W   $��1��6d   $	��100��6t   $��Center=�6�   �� 5I   
   -   5        $��Удалить��5I      $	��Top=�6>   $��0��6V   $��2��6c   $	��100��6s   $��Right=�6   �� 5J   
   -   5        $��
Назад��5J      $��1��64   $��3��6D   $	��100��6R   $��Right=�6^   $��Bottom=�6z   5L      5M      