   M S B A M L   `   `   `  ����  LifeGameProject&     LifeGameProject.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   N JPrism.DryIoc.Wpf, Version=7.2.0.1367, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1367, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title 5   	   �� *Title+.��5	      � -   5         �Name$ GameGrid��5	       � ColumnDefinitions 5
   
   �� 5      -   5         ��Name$ 
GameColumn��5      $	��600 �63   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $	��400 �6   .+�5   
   �� -   5        $��AnimatedLabel��5      $��	LIFE GAME��6%   $��0��69   $��1��6F   $��2��6V   $��Center=�6g   $��25(�6�   
��� E��$��2��6�    � Triggers 5      :� 5      	 :� RoutedEvent$	 Label.Loaded��6   .[�5      �� .��5      �� .��5      W� 
 �� 
TargetName$
 AnimatedLabel��5       �� TargetProperty$ Opacity�5       W� From$	 1.0X�5      	 W� To$	 0.1X�6(    g� Duration$ 0:0:1D�61    g� AutoReverse .  g� RepeatBehavior$ Forever��5   0   5       5!      5"      5$      �� 5&   
   $��1��6   $��1��6   $��5q�6.   $��2��69   ._�5'      �� $��One step��6E   ��6   �� *NextGenerationButtonCommand+6Z   5(      �� 5*   
   $��2��6   $��1��6   $��5q�6.   ._�5+      �� -   5         ��Name$ NStepsInput��5+      $��Center=�5,      $��-1,0,1,0q�68   ��5+   +   �� *NGenerationsInput+ �� UpdateSourceTrigger$ PropertyChanged=�5,   w   5-      �� 5/   
   $��2��6   $��2��6   $��5q�6.   ._�50      �� $��N steps��6   ��6'   �� *NGenerationsButtonCommand+6W   51      �� 53   
   $��0��6   $��0��6   $��5q�6.   $��1��69   $��4��6M   ._�54      �� ��6   �� *	GameCells+��55      �� 56      .R�57      A� 
���   � A� Columns 6&   �� *
FieldWidth+ A� Rows 6E   �� *FieldHeight+6b   58      ��5:      �� 5;      .R�5<      �� .��5=      �� $��1q�6%   ._�5>   "   �� ��6,   �� *Color+ J� InputBindings 5?   &   d� 5@   *    d� MouseAction$ 	LeftClicke�67    �� Command 6O   �� *DataContext.CellClickCommand+ �� RelativeSource ��  �� AncestorType$ ItemsControlL� �� CommandParameter 5A   7   �� *
Position+5C   #   5D      5E      5F      5H      5I      5L      5M      