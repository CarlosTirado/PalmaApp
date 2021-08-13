use PalmApp;

Insert into PalmApp.Tercero (Identificacion, Nombres, Apellidos, Telefono, Direccion, Email, FechaNacimiento, Estado)
values 
('111111111', 'John', 'Connor', '5885599', 'C 8 · 33 -55', 'john@gmail.com', SYSDATETIME(), 'AC'),
('222222222', 'Sarah', 'Connor', '5885599', 'C 8 · 33 -55', 'sarah@gmail.com', SYSDATETIME(), 'AC');

insert into AspNetRoles (Id, Name, NormalizedName)
values
('Dueño', 'Dueño', 'Dueño'),
('Administrador', 'Administrador', 'Administrador'),
('Operario', 'Operario', 'Operario');

update AspNetUsers 
set PasswordHash = (select PasswordHash from AspNetUsers where UserName = 'john@gmail.com')
where UserName = 'orley333@gmail.com';

insert into AspNetUserRoles (UserId, RoleId) values
((select Id from AspNetUsers where UserName = 'orley333@gmail.com'), 'Dueño'),
((select Id from AspNetUsers where UserName = 'sarah@gmail.com'), 'Administrador'),
((select Id from AspNetUsers where UserName = 'john@gmail.com'), 'Operario');

commit;





