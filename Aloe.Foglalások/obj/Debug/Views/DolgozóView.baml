   M S B A M L   `   `   `  ����K  GAloe.Foglalások, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Aloe.Foglalások.ViewModelsAloe.Foglalások.ViewModels  5      )    #Aloe.Foglalások.Views.DolgozóView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      E ACatel.MVVM, Version=4.4.0.0, Culture=neutral, PublicKeyToken=nullT PCatel.Extensions.Controls, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      <
ViewModels)clr-namespace:Aloe.Foglalások.ViewModels   5        � 	Resources  5      ��%    5      .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   $	��300��6)   .+�5   
   �� $��0��6+   $��1��68   ��6   �� *Title+68   �� 5   
   $
��Név��6   $��1��6   �� 5    
   $��1��6a   $��1��6n   ��6   �� *Név+ �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 6n   �� 5#   
   $��Jelszó��6   �� 5$   
   $��2��6d   $��1��6q   ��6   �� *	Jelszó+ .  . 6q   5%      5&      