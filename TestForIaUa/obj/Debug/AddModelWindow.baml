   M S B A M L   `   `   `  ����F  BTestForIaUa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestForIaUaTestForIaUa  5   	        TestForIaUa.AddModelWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestForIaUa     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$'  !Добавление модели��5
   	   $��10��6$   $
��auto��63   $
��auto��6A   .��5      � $��10��6   $
��auto��6   $
��auto��6)   .+�5   
   �� -   5         ��Name$ mainStackPanel��5      $��10��6.   $
��auto��6=   $
��auto��6K   .+�5      �� -   5        $ firstStackPanel��5       �� Orientation$ 
Horizontal=�63   $��10��6L   $
��auto��6[   $
��auto��6i   .+�5      �� -   5         ��Name$ 
labelManuf��5      $1��+Выберите производителя��6,   $��25��6M   �� 5      -   5         ��Name$ buttonAddNewManuf��5      $!��Создать нового��64   6M   5      �� 5      -   5         ��Name$ ComboBoxManuf��5       �� DisplayMemberPath$
 Name��6.   6H   �� 5      $��5��6   
���   �6    �� 5      -   5        $ secondStackPanel��5      $ 
Horizontal=�64   $��10��6M   $
��auto��6\   $
��auto��6j   .+�5      �� -   5        $ 	labelType��5      $6��0Выберите тип оборудования��6+   �� 5      -   5        $ buttonAddNewType��5      $��Создать новое��63   6K   5      �� 5      -	   5        $ ComboBoxType��5      $
 Name��6.   �� 5      $��5��6   
���   �6    �� 5      -
   5        $ label��5      $2��,Введите название модели��6#   �� 5      -   5         ��Name$ textBoxName��5      $��24��6+    �� TextWrapping$
 Wrap=�67   $�� ��6K   �� 5      $��5��6   
���   �6    �� 5      -   5        $ 	buttonAdd��5      $G��AДобавить новую модель в базу данных��6(   6V   5      5      5       