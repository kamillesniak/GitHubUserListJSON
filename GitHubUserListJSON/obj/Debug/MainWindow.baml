   M S B A M L   `   `   `  ����M  IGitHubUserListJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GitHubUserListJSONGitHubUserListJSON  5   	   #    GitHubUserListJSON.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GitHubUserListJSON     5   	     � Title$  
MainWindow��5   	   $	��294��6   $	��480��6)   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��0.25* �6   �� 5      $��* �6   �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��0.75* �6   �� 5      $��* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ AvatarImage��5      $��Stretch=�6%   $��1��6C   $��2��6S   $��Stretch=�6`   �� 5   
   -   5         ��Name$ LoginComboBox��5      $��2��6*   $��Stretch=�6:   $��2��6X   $	��Top=�6e   $��30��6~   $��0,41,0,0q�6�   �� 5   
   -   5        $ UserRepositoriesComboBox��5      $��2��65   $��Stretch=�6E   $��30��6c   $��2��6o   $��Bottom=�6|   �� 5   
   -   5         ��Name$ RepositoriesLabel��5      $��Repositories count: ��6+   $��17(�6J   $��2��6X   $
��Left=�6h   $��40��6�   $��2��6�   $��Center=�6�   $	��150��6�   �� 5   
   -   5        $ RepositoriesCountLabel��5      $��17(�60   $��2��6>   $��Right=�6N   $��40��6j   $��2��6w   $��Center=�6�   $��87��6�   �� 5   
   -   5        $ 	NickLabel��5      $��Nick:��6#   $��2��63   $��17(�6C   $
��Left=�6Q   $��40��6l   $��2��6x   $	��Top=�6�   $	��107��6�   �� 5    
   -   5        $ PublicRepositoriesLabel��5       $��Public Repositories:��61   $��2��6P   $��17(�6`   $
��Left=�6n   $��40��6�   $��2��6�   $��Bottom=�6�   $	��160��6�   $��0,0,0,26q�6�   5#      5$      