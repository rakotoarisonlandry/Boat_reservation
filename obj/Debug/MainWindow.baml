   M S B A M L   `   `   `  ����J  FBoatReservation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BoatReservationBoatReservation  5   	        BoatReservation.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BoatReservation     5   	   -   5          �Name$  IndexWindow��5   	    � Title$ Boat Reservation��5   	   $	��600��6"   $	��800��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   .��5
      ��  �� CornerRadius$ 
10 0 10 10��6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��12* �6#   �� 5      $
��385* �6#   .+�5       � -   5          �Name$ 	MainImage��5      ���#6e77ee$
��Left=�6<   $	��571��6X   $	��Top=�6e   $	��401��6}   $��2��6�   ��5      �� 5      $0��*image/3905531_resized-removebg-preview.png��6   $��	0,-2,0,80q�6P   6f   5      � 5      $
��Left=�6   $	��382��6.   $��
461,86,0,0q�6;   $	��Top=�6O   $	��251��6g   $��1��6s    � RowDefinitions 5      �� 5      $
��167* �6$   �� 5      $
��119* �6$   .+�5      �� -   5         ��Name$ UsernameLabel��5      $��Nom d'utilusateur��6/   $
��Left=�6K   $��
-22,0,0,85q�6f   $��Bottom=�6z   $	��167��6�   $��16(�6�   �� 5      -   5        $ Passwordlabel��5      $��Mot de passe��6/   $
��Left=�6F   $��-22,187,0,0q�6a   $	��Top=�6v   $	��167��6�   $��16(�6�   �� 5      -   5        	 ��Name$	 UsernameField��5      $��34��61   $��-22,142,0,0q�6=   $��
5 ,7 ,0 ,0q�6S   
 �� TextWrapping$

 Wrap=�6h   $	��Top=�6|   $	��273��6�   $
��Left=�6�   .��6�   5      �� 5       -   5        $ Label��5       $��Bienvenue a��6'   $
��Left=�6=   $��-463,0,0,-13q�6X   
�������$��Bottom=�6�   $	��207��6�   $��32(�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.498,6.774&�6�   $��1��6�   �� 5!      -   5        $ 
Label_Copy��5!      $�� X-BOAT��6,   $
��Left=�6>   $��-256,0,0,-13q�6Y   
�������$��Bottom=�6�   $	��145��6�   $��32(�6�   $
��Bold"�6�   ���	#FFF6A935$��1��6�   5"      G� 5$      -   5         G�Name$ PasswordField��5$      $
��Left=�63   $��
5 ,7 ,0 ,0q�6N   $��440,306,0,0q�6c   $	��Top=�6x   $	��272��6�   $��36��6�   $��1��6�    � 	Resources 5%       �� 
TargetType �� Property �� Value��%_   '��       �� 5&      " ��6   .�5'      ��  �@��CornerRadius$ 15��69   5(      5)      5*      �� 5,      -	   5         ��Name$ SubmitLogin��5,      $��Se connecter��6*   $
��Left=�6A   $��440,372,0,0q�6\   
�������$	��Top=�6�   $	��272��6�   $ 
-0.687,0.4&�6�   $��38��6�   $��16(�6�   $
��Bold"�6�   ���	#FF6E77EE$��1��6(   5-      ��%_   '��       �� 5.      " ��6   .�5/      ��  �@��CornerRadius$ 15��69   50      51      53      �� 54      -
   5        $ label��54      $
��Left=�6$   $��
494,90,0,0q�6?   $	��Top=�6S   $	��168��6k   $��21.333(�6w   $��Center=�6�   $��1��6�   ��55      �� 56      $��image/user.png��6   $��80��64   $��80��6?   6M   59      5:      5;      5=      