   M S B A M L   `   `   `  ����J  FWordleCopy_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WordleCopy_v1._0.ViewWordleCopy_v1._0.View  5   	   W0clr-namespace:WordleCopy_v1._0.View.UserControls"WordleCopy_v1._0.View.UserControls  5   	   &     WordleCopy_v1._0.View.ResultView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WordleCopy_v1._0.View     5   	   IuserControls0clr-namespace:WordleCopy_v1._0.View.UserControls     5   	     � Title$  
ResultView��5	   	   
������ $	��180��5   	   $	��280��6    � WindowStartupLocation$ CenterOwner=�6"    � WindowStyle$
 None=�6F    � 
ResizeMode$ NoResize=�6Y   $��3q�6o   ���	#FF8D999C.��5      �� $��0q�6   
������ ._�5   
   � ���	#FF3C3232 � RowDefinitions 5      �� 5      $��6* �6    �� 5      $��4* �6!    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      .+�5      2   ,WordleCopy_v1._0.View.UserControls.MyTextBox  -   5        	  Name$	 ResultViewTextBox��5   %   $��0��5   %   
 J� IsHitTestVisible$
 False��5   %   $��False��5   %   $��	CONGRATS!��5   %   .��66   5      � 5      $��1��6   
������  � ColumnDefinitions 5      �� 5       �� 5!      .+�5#      �� -   5        $��0��5#      $��
PLAY AGAIN��5$      $��18(�5%      $
��bold"�5&      
����������	#FF4BAB4B$��10q�5)      $��0q�5*       5+      ��%^   '��       �� 5,      " ��6    .�5-      ��  �@��CornerRadius$ 5��6=   5.      5/      50      �� 51      -   5        $��1��51      $
��QUIT��52      $��20(�53      $
��bold"�54      
����������	#FFCCCC32$��10q�57      $��0q�58       59      ��%^   '��       �� 5:      " ��6    .�5;      ��  �@��CornerRadius$ 5��6=   5<      5=      5>      5?      5@      5A      5C      