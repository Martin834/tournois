   M S B A M L   `   `   `  ����  
AppTournoi%    AppTournoi.GestionTournoiWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion des Tournois��5   	   $	��450��6&   $	��820��63   $	��450��6?   $	��820��6O   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��Ajouter un Tournoi��5      $��0��6.   $��0��6;   $��10q�6K   6W   �� 5   
   -   5        $��Modifier le Tournoi��5      $��0��6/   $��1��6<   $��10q�6L   6X   �� 5   
   -   5        $��Supprimer le Tournoi��5      $��0��60   $��2��6=   $��10q�6M   6Y   �� 5   
   -   5         ��Name$ ListeTournois��5      $��1��6*   $��3��67   $��10q�6K    �� View 5      �� 5      .P�5      �� $	��Nom��6%    �� Width$	 200��6\    �� DisplayMemberBinding 62   �� *
Intitule+6\   �� 5      $
��Date��6%   $	 200��6`    63   �� *DateTournoi+6`   �� 5      $
��Lieu��6%   $	 200��6Z    63   �� *Sport+6Z   5      5      �� 5    
   $��2��6   $��3��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5!      �� $
��Nom:��6   $��Center=�6#   $��5q�6>   �� 5"      -   5         ��Name$ 
NomTextBox��5"      $	��200��6*   $��5q�66   �� 5#      $��Date:��6   $��Center=�6$   $��5q�6?   (  "System.Windows.Controls.DatePicker  5$      -   5        	  Name$	 
DatePicker��5$      $	��200��6-   $��5q�69   �� 5%      $��Sport:��6   $��Center=�6%   $��5q�6@   �� 5&      -   5        
 ��Name$
 SportComboBox��5&      $	��200��6.   $��5q�6:   5'      5(      5)      