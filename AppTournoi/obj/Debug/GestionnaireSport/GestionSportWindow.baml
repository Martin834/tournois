   M S B A M L   `   `   `  ����E  AAppTournoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:AppTournoi.GestionnaireSportAppTournoi.GestionnaireSport  5   	   5    /AppTournoi.GestionnaireSport.GestionSportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:AppTournoi.GestionnaireSport     5   	     � Title$  GestionSportWindow��5   	   $	��450��6$   $	��800��61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��Ajouter un Sport��5      $��0��6,   $��0��69   $��10q�6I   6U   �� 5   
   -   5        $��Modifier le Sport��5      $��0��6-   $��1��6:   $��10q�6J   6V   �� 5   
   -   5        $��Supprimer le Sport��5      $��0��6.   $��2��6;   $��10q�6K   6W   �� 5   
   -   5         ��Name$ ListeSports��5      $��1��6(   $��3��65   $��10q�6I    �� View 5      �� 5      .P�5      �� $	��Nom��6%    �� Width$	 600��6\    �� DisplayMemberBinding 62   �� *
Intitule+6\   5      5       �� 5"   
   $��2��6   $��3��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��10q�6l   .+�5#      �� $
��Nom:��6   $��Center=�6#   $��5q�6>   �� 5$      -   5         ��Name$ 
NomTextBox��5$      $	��600��6*   $��5q�66   5%      5&      5'      