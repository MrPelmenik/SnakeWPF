   M S B A M L   `   `   `  ����I  EWPF_MVVM_SNAKE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF_MVVM.ViewModelsWPF_MVVM.ViewModels  5      9!clr-namespace:WPF_MVVM.ConvertersWPF_MVVM.Converters  5      "    WPF_MVVM.View.Pages.GamePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0vm!clr-namespace:WPF_MVVM.ViewModels     5      1cnv!clr-namespace:WPF_MVVM.Converters     5      $
|�True��5	        � DataContext  5      '   !WPF_MVVM.ViewModels.GameViewModel  5   
    � 	Resources 5      A   ;WPF_MVVM.Converters.IntArrayToObservableCollectionConverter   IntToCollectionConverter/   )WPF_MVVM.Converters.ValueToColorConverter  ValueToColorConverter  CellTemplate  CellBorderStyle �� 	Converter  CellLabelStyle �� TextAlignment  BoardTemplate �� Orientation��%�  &	        &	      &	 &     7  7  7  &	 �       5   
   66     5   
   6$   �� 5   
   .R�5      �� 8��  ��5      �� 8  ._�5      �� 8�� $ Center=�6D   $y�Hidden=�6l   ��6[   �� 6l   5      5      �� 5   
   .R�5      �� #���  63   ��6   �� ��5      �� 5      .R�5      �� $ 
Horizontal=�6%   5      5!      5"      5#       J� InputBindings 5%      �� 5&   
   
 �� Key$
 Left��6    �� Command 6    �� *ShiftLeftCommand+�� 5'   
   $ Right��6    6!   �� *ShiftRightCommand+�� 5(   
   $
 Down��6    6    �� *ShiftDownCommand+�� 5)   
   $ Up��6    6   �� *ShiftUpCommand+.��5,      � -   5         �Name$ GamePageGrid��5,      	 � RowDefinitions	 5-   
   �� 5.      $��* �6   �� 5/      $
��Auto �6   �� 50      $��* �6   
 � ColumnDefinitions
 52   
   �� 53      $��* �6   �� 54      $
��Auto �6   �� 55      $��* �6   .+�58   
   � $��1��6   	 59      �� 5:      $��* �6    �� 5;      $
��Auto �6    �� 5<      $��* �6    
 5>      �� 5?      $	��.5* �6#   �� 5@      $	��.5* �6#   �� 5A      $��* �6#   �� 5B      $��* �6#   .+�5E      ��   SmallButtonStyle#��[ 6   $��1��6?   $��0��6L   ��5F      �� *NavigateToMenuPage+��5G      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" N�.��5H      �� $"��../../Assets/Images/menu.png��6   5I      �� 5J      #��[ 6   $��1��6?   $��1��6L   ��5K      �� *ResetCommand+.��5L      �� $$��../../Assets/Images/reload.png��6   5M      �� 5N        InfoTabStyle#��[ 6   $��1��6;   $��3��6H   ._�5O      ��   InfoTabLabelStyle#��[ 6   ��6G   �� *Score+ �� StringFormat$ 
Score: {0}��6{   5P      5Q      �� 5S   
   $��1��6   $��1��6    	 BoardBorderStyle#��[	 6.   ._�5T      �� #���  5U      ��5T      �� *Board+# [  5U      5V      5W      5X      