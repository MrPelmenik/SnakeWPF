   M S B A M L   `   `   `  ����I  EWPF_MVVM_SNAKE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF_MVVM.ViewModelsWPF_MVVM.ViewModels  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      (    "WPF_MVVM.View.Pages.StatisticsPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0vm!clr-namespace:WPF_MVVM.ViewModels     5      6sys&clr-namespace:System;assembly=mscorlib     5        � DataContext  5
      -   'WPF_MVVM.ViewModels.StatisticsViewModel  5   
    � 	Resources 5         StatisticsText��%,   &	        ��5   
   
Statistics��68   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��1��6    5      �� 5       $��* �6    �� 5!      $
��Auto �6    �� 5"      $��* �6     5$      �� 5%      $	��.5* �6#   �� 5&      $
��Auto �6#   �� 5'      $	��.5* �6#   .+�5)      �� $��1��6   $��0��6"     SmallButtonStyle#��[ 62    � Cursor$
 Hand��5+   �   ��5*      �� *NavigateToMenuPage+��5+      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" N�.��5,      �� $'��!../../Assets/Images/backspace.png��6   5-      �� 5.      $��1��6   $��1��6!     
LabelStyle#��[ 61   #��[  6U   5/      �� 50   
   $��1��6   $��1��6     TableBoardBorderStyle#��[ 6.   ._�51      &   System.Windows.Controls.DataGrid    StatisticsTableStyle#��[ 6D   ��6   �� *StatisticsCollection+   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6)   
   Header$
 Player��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Name+   HeaderStyle 54      �� 55       �� ResourceKey$  StatisticsTableHeaderStyle��6-      ElementStyle 57      �� 58      $ StatisticsTableRowStyle��6-   5:        5;      $	 * 6)   $
 
Best score��63    6G   �� *Score+ 5<      �� 5=      $  StatisticsTableHeaderStyle��6-    5?      �� 5@      $ StatisticsTableRowStyle��6-   5B      5D      5E      5F      5G      