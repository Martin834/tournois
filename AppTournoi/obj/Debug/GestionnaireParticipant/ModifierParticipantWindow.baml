   M S B A M L   `   `   `  ����E  AAppTournoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AppTournoi.GestionnaireParticipant"AppTournoi.GestionnaireParticipant  5   	   B    <AppTournoi.GestionnaireParticipant.ModifierParticipantWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:AppTournoi.GestionnaireParticipant     5   	     � Title$  Modifier le Participant��5   	   $	��400��6)   $	��400��66   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Nom:��6   $��0��6   $��0��6,   $��10q�6<   �� 5   
   -   5         ��Name$ 
NomTextBox��5      $��0��6&   $��1��63   $��10q�6C   �� 5   
   $��Prénom:��6   $��1��6"   $��0��6/   $��10q�6?   �� 5   
   -   5        $ PrenomTextBox��5      $��1��6)   $��1��66   $��10q�6F   �� 5   
   $��Date de Naissance:��6   $��2��6-   $��0��6:   $��10q�6J   (  "System.Windows.Controls.DatePicker  5    
   -   5          Name$ DateNaissancePicker��5       $��2��62   $��1��6?   $��10q�6O   �� 5"   
   $��Sexe:��6   $��3��6    $��0��6-   $��10q�6=   �� 5#   
   -   5        $ SexeTextBox��5#      $��3��6'   $��1��64   $��10q�6D   �� 5%   
   $��Photo:��6   $��4��6!   $��0��6.   $��10q�6>   �� 5&   
   -   5        $��Choisir une photo��5&      $��4��6-   $��1��6:   $��10q�6J   6V   �� 5(   
   $��Tournoi:��6   $��5��6#   $��0��60   $��10q�6@   �� 5)   
   -   5        $ TournoiTextBox��5)      $��5��6*   $��1��67   $��10q�6G   �� 5+   
   -   5        $��Modifier��5+      $��6��6$   $��2��61   $��10q�6E   6Q   5,      5-      