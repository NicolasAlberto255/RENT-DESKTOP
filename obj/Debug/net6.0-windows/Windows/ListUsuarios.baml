   M S B A M L   `   `   `  ?????  ;RENT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RENT.WindowsRENT.Windows  5          RENT.Windows.ListUsuarios   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RENT.Windows     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N? Title$  ListUsuarios??5      .??5      ? 
???????.+?5   
   ?? $	??850??5      $	??500??5      $??Center=?5      $??Center=?5      ???	#FF192EA0$??5,5,5,5q?5      $
??Bold"?5      $??Listar Usuarios??5      &   System.Windows.Controls.DataGrid  5   
   <my-http://schemas.microsoft.com/wpf/2008/toolkit     5      -   5          Name$ 
dgUsuarios??5      $??286,84,31,137q?5         AutoGenerateColumns$ False??5         CanUserAddRows$ False??5      ??5      ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ID Usuario??6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *	idUsuario+6C     5       $ Nombre??6G    6%   ?? *nombreUsuario+6G     5!      $ Apellido??6I    6%   ?? *apellidoUsuario+6I     5"      $ Cedula??6G    6%   ?? *cedulaUsuario+6G     5#      $ Correo??6G    6%   ?? *correoUsuario+6G     5$      $ Telefono??6I    6%   ?? *telefonoUsuario+6I     5%      $	 Rol??6D    6%   ?? *
rolUsuario+6D     5&      $ Region??6G    6%   ?? *regionUsuario+6G     5'      $ Comuna??6G    6%   ?? *comunaUsuario+6G   5)      ?? 5+   
   -   5         ??Name$ idBtn??5,      $	??119??5-      $??137,165,0,0q?5.      $??2q?5/      $
??Left=?50      $	??Top=?51      $??Buscar por ID??53       ? 	Resources 54      	 ?? 
TargetType
 ?? Property ?? Value??%?   '??       ?? 55      "	 ??6   .?56      ?? 
 ? ?? ?	#FF144FBE64   ?? 57      
 ?@??CornerRadius$ 5??65   58      59      5:      ?? 5;   
   -   5        $ 	cedulabtn??5<      $	??119??5=      $??137,129,0,0q?5>      $??2q?5?      $
??Left=?5@      $	??Top=?5A      $??Buscar por Cedula??5C       5D      ??%?   '??       ?? 5E      "	 ??6   .?5F      ?? 
 ? ?? ?	#FF144FBE64   ?? 5G      
 ?@??CornerRadius$ 5??65   5H      5I      5J      ?? 5L   
   -   5         ??Name$ 
lblMessage??5M      $??37??5N      $??	64,43,0,0q?5O      $
??Left=?5P      $	??Top=?5Q      $?? ??5R       J? RenderTransformOrigin$ 0.101,0.595&?5S      $y?Hidden=?5T      ?? 5U   
   -   5         ??Name$ cedulaFindTxt??5V      $	??101??5W      $??20??5X      $??
31,130,0,0q?5Y      $
??Left=?5Z      $	??Top=?5[      $?? ??5\       ?? TextWrapping$
 Wrap=?5]      .??6!    5^      ??%^   '??       ?? 5_      "	 ??6   .?5`      ?? 
 ?@??CornerRadius$ 3??65   5a      5b      .??6!   5c      ?? 5d   
   -   5        $ 	idFindTxt??5e      $??31??5f      $??20??5g      $??101,165,0,0q?5h      $
??Left=?5i      $	??Top=?5j      $?? ??5l      $
 Wrap=?5m      .??6!    5n      ??%^   '??       ?? 5o      "	 ??6   .?5p      ?? 
 ?@??CornerRadius$ 3??65   5q      5r      .??6!   5s      ?? 5t   
   -   5        $ cargarUsuariobtn??5u      $	??119??5v      $??137,202,0,0q?5w      $??2q?5x      $
??Left=?5y      $	??Top=?5z      $??Cargar Usuarios??5|       5}      ??%?   '??       ?? 5~      "	 ??6   .?5      ?? 
 ? ?? ?	#FF144FBE64   ?? 5?      
 ?@??CornerRadius$ 5??65   5?      5?      5?      5?      5?      