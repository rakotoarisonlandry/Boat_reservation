   M S B A M L   `   `   `  ����J  FBoatReservation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BoatReservationBoatReservation  5   	   "    BoatReservation.WindowVoyage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BoatReservation     5   	     � Title$  Editer��5   	   $	��600��6   $	��471��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H    � Topmost . .��5	      � .+�5
   
   �� -   5         ��Name$ StackpanelEdit��5
       �� Orientation$ Vertical=�6-   $
��Left=�6E   $	��382��6`   $��	75,24,0,0q�6m   $	��Top=�6�   $	��312��6�   .+�5      �� -   5         ��Name$ label_Itineraire��5      $��
Itineraire��6.   $
��Left=�6C   $��-2,0,0,0q�6^   $	��Top=�6p   �� 5      -   5         ��Name$ textBox_itineraire��5      $��32��62   $��0,5,0,0q�6>    �� TextWrapping$
 Wrap=�6O   $	��Top=�6�   $
��Left=�6�   $	��312��6  ��6c   �� *
Itineraire+	 �� UpdateSourceTrigger$	 PropertyChanged=�6  �� 5      -   5        $ label_DateDepart��5      $��Date du Depart��6.   $
��Left=�6G   $	��Top=�6c   $��0,14,0,0q�6{   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 textBox_Date��5      $	��Top=�6M   $��32��6e   $��0,5,0,0q�6q      Text 60   �� *
DateDepart+6q   �� 5      -   5        $ label_Durée��5      $��Durrée��6)   $
��Left=�6:   $	��Top=�6V   $��0,15,0,0q�6n   �� 5      -   5        $ textBox_durée��5      $��32��6-   $
 Wrap=�69   $	��Top=�6�   $��0,5,0,0q�6�   ��6M   �� *Durer+$	 PropertyChanged=�6�   �� 5      -   5        $ label_frais��5      $��Frais��6)   $
��Left=�69   $	��Top=�6U    J� RenderTransformOrigin$ 0.632,0.692&�6m   $��0,15,0,0q�6�   �� 5      -	   5        $ textBox_frais��5      $��32��6-   $
 Wrap=�69   $	��Top=�6�   $ 
0.484,0.25&�6�   $��0,5,0,0q�6�   ��6M   �� *Frais+$	 PropertyChanged=�6�   �� 5      -
   5        $ label_IdBateau��5      $��	Id Bateau��6,   $��0,15,0,0q�6@   �� 5      -   5        $ textBoxIdBateau��5      $��32��6/   $
 Wrap=�6z   ��6;   �� *
IdBateau+$	 PropertyChanged=�6z   5      �� 5   
   -   5         ��Name$ button_Annuler��5       �� IsCancel .  $��Annuler��6:   $��268,424,78,0q�6L   ���	#FFB7BAC3
�������$	��Top=�6�   $��32��6�   $	��119��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5       ��  �@��CornerRadius$ 4��65   5!      5"      5#      �� 5$   
   -   5        $ button_Enregister��5$       �� 	IsDefault . ���	#FFF6A935
�������$��	Confirmer��6g   $
��Left=�6{   $��
75,426,0,0q�6�   $	��Top=�6�   $	��118��6�   $��32��6�    5&      ��%^   '��       �� 5'      " ��6   .�5(      ��  �@��CornerRadius$ 4��65   5)      5*      5+      5,      5-      