create database TP_Cuatrimestral
go
use TP_Cuatrimestral

go

create table Marcas(
IdMarca int primary key identity(1,1),
Nombre varchar(50) unique
);

go

create table Tipos(
IdTipo int primary key identity(1,1),
Nombre varchar(50) not null unique
);

go

create table Categorias(
IdCategoria int primary key identity(1,1),
Nombre varchar(50) unique
);

go 

create table Productos(
IdProducto int not null primary key identity(1,1),
Codigo int unique not null, 
Nombre varchar(50)not null,
IdMarca int not null,
IdTipo int not null,
Ganancia float not null,
constraint fk_producto_Marca foreign key(idmarca) references Marcas(idmarca),
constraint fk_producto_Tipos foreign key(idtipo) references tipos(idtipo)
);

go
create table Clientes(
IdCliente int primary key identity(1,1),
Nombre varchar(50)not null,
Apellido varchar(50)not null,
DNI int unique not null,
Celular varchar(50)  null,
Email varchar(50)  null,
Direccion varchar(100)null,
Provincia varchar(50)null,
Pais varchar(50)null,
Telefono varchar(50) not null

);

go

create table Provedores(
IdProveedor int primary key identity(1,1),
Nombre varchar(50) not null ,
Apellido varchar(50)not null,
Email varchar(50)not null,
Telefono int null,
Celular int  null,
Direccion varchar(50)not null,
Provincia varchar(50)not null,
Pais varchar(100)not null,
);


go

create table Roles(
IdRol int primary key identity(1,1),
Rol varchar(50) not null
);

create table Usuarios(
IdUsuario int primary key identity(1,1),
Nombre varchar(50) not null,
Contraseña varchar(50) not null,
IdRol int not null,
constraint fk_Usuario_Rol foreign key (IdRol) references Roles(IdRol)
);

go

create table MetodoDePago(
IdMetodoDePago int primary key identity(1,1),
Nombre varchar(50) unique
);

INSERT INTO Marcas (Nombre) VALUES
('Marca A'),
('Marca B'),
('Marca C'),
('Marca D'),
('Marca E'),
('Marca F'),
('Marca G'),
('Marca H'),
('Marca I'),
('Marca J');
go
INSERT INTO Tipos (Nombre) VALUES
('Tipo A'),
('Tipo B'),
('Tipo C'),
('Tipo D'),
('Tipo E'),
('Tipo F'),
('Tipo G'),
('Tipo H'),
('Tipo I'),
('Tipo J');

go

INSERT INTO Categorias (Nombre) VALUES
('Categoria A'),
('Categoria B'),
('Categoria C'),
('Categoria D'),
('Categoria E'),
('Categoria F'),
('Categoria G'),
('Categoria H'),
('Categoria I'),
('Categoria J');

go

INSERT INTO Productos (Codigo, Nombre, IdMarca, IdTipo, Ganancia) VALUES
(1001, 'Producto A', 1, 1, 1.2),
(1002, 'Producto B', 2, 1, 1.2),
(1003, 'Producto C', 1, 2, 1.2),
(1004, 'Producto D', 3, 2, 1.2),
(1005, 'Producto E', 1, 1, 1.2),
(1006, 'Producto F', 2, 3, 1.2),
(1007, 'Producto G', 3, 3, 1.2),
(1008, 'Producto H', 1, 1, 1.2),
(1009, 'Producto I', 2, 2, 1.2),
(1010, 'Producto J', 3, 3, 1.2);



go
INSERT INTO Clientes (Nombre, Apellido, DNI, Celular, Email, Direccion, Provincia, Pais, Telefono) VALUES
('Juan', 'P�rez', 12345678, '1234567890', 'juan.perez@example.com', 'Av. Siempre Viva 742', 'Buenos Aires', 'Argentina', '01112345678'),
('Mar�a', 'Gonz�lez', 87654321, '0987654321', 'maria.gonzalez@example.com', 'Calle Falsa 123', 'CABA', 'Argentina', '01187654321'),
('Carlos', 'Mart�nez', 11223344, '1231231234', 'carlos.martinez@example.com', 'Calle de la Paz 456', 'Tigre', 'Argentina', '01111223344'),
('Laura', 'L�pez', 44332211, '9876543210', 'laura.lopez@example.com', 'Av. Libertador 789', 'Tigre', 'Argentina', '01144332211'),
('Ana', 'Fern�ndez', 22334455, '3213214321', 'ana.fernandez@example.com', 'Calle Nueva 101', 'San Fernando', 'Argentina', '01122334455'),
('Pedro', 'Ram�rez', 33445566, '6543219870', 'pedro.ramirez@example.com', 'Av. Belgrano 202', 'CABA', 'Argentina', '01133445566'),
('Luc�a', 'S�nchez', 55667788, '7890123456', 'lucia.sanchez@example.com', 'Calle de la Independencia 303', 'San Isidro', 'Argentina', '01155667788'),
('Diego', 'Hern�ndez', 99887766, '4321098765', 'diego.hernandez@example.com', 'Calle de los H�roes 404', 'Pilar', 'Argentina', '01199887766'),
('Gabriela', 'Torres', 66554433, '2345678901', 'gabriela.torres@example.com', 'Av. San Mart�n 505', 'San Fernando', 'Argentina', '01166554433'),
('Javier', 'Guti�rrez', 55443322, '5678901234', 'javier.gutierrez@example.com', 'Calle del Sol 606', 'Tigre', 'Argentina', '01155443322');
go
INSERT INTO Provedores (Nombre, Apellido, Email, Telefono, Celular, Direccion, Provincia, Pais) VALUES
('Provedor', 'Uno', 'provedor1@example.com', '01112345678', '1234567890', 'Calle 1', 'Buenos Aires', 'Argentina'),
('Provedor', 'Dos', 'provedor2@example.com', '01123456789', '0987654321', 'Calle 2', 'CABA', 'Argentina'),
('Provedor', 'Tres', 'provedor3@example.com', '01134567890', '1122334455', 'Calle 3', 'Tigre', 'Argentina'),
('Provedor', 'Cuatro', 'provedor4@example.com', '01145678901', '2233445566', 'Calle 4', 'San Fernando', 'Argentina'),
('Provedor', 'Cinco', 'provedor5@example.com', '01156789012', '3344556677', 'Calle 5', 'San Isidro', 'Argentina'),
('Provedor', 'Seis', 'provedor6@example.com', '01167890123', '4455667788', 'Calle 6', 'Pilar', 'Argentina'),
('Provedor', 'Siete', 'provedor7@example.com', '01178901234', '5566778899', 'Calle 7', 'San Fernando', 'Argentina'),
('Provedor', 'Ocho', 'provedor8@example.com', '01189012345', '6677889900', 'Calle 8', 'CABA', 'Argentina'),
('Provedor', 'Nueve', 'provedor9@example.com', '01190123456', '7788990011', 'Calle 9', 'Tigre', 'Argentina'),
('Provedor', 'Diez', 'provedor10@example.com', '01101234567', '8899001122', 'Calle 10', 'Buenos Aires', 'Argentina');
go
INSERT INTO Roles (Rol) VALUES ('Administrador'), ('Vendedor');
go
INSERT INTO Usuarios (Nombre, Contraseña, IdRol) VALUES
('admin1', 'password1', 1),
('admin2', 'password2', 1),
('user1', 'password1', 2),
('user2', 'password2', 2)

go
INSERT INTO MetodoDePago (Nombre) VALUES
('Efectivo'),
('Tarjeta de Cr�dito'),
('Tarjeta de D�bito'),
('Transferencia Bancaria'),
('Cheque'),
('PayPal'),
('MercadoPago'),
('Bitcoin'),
('Criptomoneda'),
('Gift Card');
-- go

-- create table Ventas(
-- IdDeVenta int primary key identity(1,1),
-- IdCliente int not null,
-- Fecha date not null ,
-- IdVendedor int not null,
-- IdMetodoDePago int not null,
-- FacturaGenerada bit not null,
-- CostoTotal money not null,
-- constraint fk_Ventas_Cliente foreign key (IdCliente) references Clientes(IdCliente),
-- constraint fk_Ventas_Usuario foreign key (IdVendedor) references Usuarios(IdUsuario),
-- constraint fk_Ventas_MetodoDePago foreign key(IdMetodoDePago) references MetodoDePago(IdMetodoDePago)
-- );

-- go 

-- create table Compras(
-- IdCompra int primary key identity(1,1),
-- IdProveedor int not null ,
-- IdMetodoDePago int not null,
-- FechaCompra date not null,
-- CostoTotal money not null,
-- Recibido bit not null,
-- constraint fk_Compra_Proveedor foreign key (IdProveedor) references Provedores(IdProveedor),
-- constraint fk_Compra_MetodoDePago foreign key(IdMetodoDePago) references MetodoDePago(IdMetodoDePago)
-- );
-- go

-- INSERT INTO Ventas (IdCliente, Fecha, IdVendedor, IdMetodoDePago, FacturaGenerada, CostoTotal) VALUES
-- (1, '2024-10-01', 1, 1, 1, 100.00),
-- (2, '2024-10-02', 1, 2, 1, 200.00),
-- (3, '2024-10-03', 1, 3, 1, 150.00),
-- (4, '2024-10-04', 2, 4, 1, 300.00),
-- (5, '2024-10-05', 2, 5, 1, 250.00),
-- (6, '2024-10-06', 2, 6, 1, 400.00),
-- (7, '2024-10-07', 2, 7, 1, 350.00),
-- (8, '2024-10-08', 3, 8, 1, 450.00),
-- (9, '2024-10-09', 3, 9, 1, 500.00),
-- (10, '2024-10-10', 3, 10, 1, 550.00);
-- go
-- INSERT INTO Compras (IdProveedor, IdMetodoDePago, FechaCompra, CostoTotal, Recibido) VALUES
-- (1, 1, '2024-10-01', 500.00, 1),
-- (2, 2, '2024-10-02', 600.00, 1),
-- (3, 3, '2024-10-03', 700.00, 1),
-- (4, 4, '2024-10-04', 800.00, 1),
-- (5, 5, '2024-10-05', 900.00, 1),
-- (6, 6, '2024-10-06', 1000.00, 1),
-- (7, 7, '2024-10-07', 1100.00, 1),
-- (8, 8, '2024-10-08', 1200.00, 1),
-- (9, 9, '2024-10-09', 1300.00, 1),
-- (10, 10, '2024-10-10', 1400.00, 1);
-- go
/*
create table VentaXProducto (
    IdVentaProducto int primary key identity(1,1),
    IdDeVenta int not null,
    IdProducto int not null,
    Cantidad int not null,
    PrecioUnitario money not null,
    constraint fk_VentaXProducto_Venta foreign key (IdDeVenta) references Ventas(IdDeVenta),
    constraint fk_VentaXProducto_Producto foreign key (IdProducto) references Productos(IdProducto)
);

go

create table CompraXProducto (
    IdCompraProducto int primary key identity(1,1),
    IdCompra int not null,
    IdProducto int not null,
    Cantidad int not null,
    PrecioCompraUnitario money not null,
    constraint fk_CompraXProducto_Compra foreign key(IdCompra) references Compras(IdCompra),
    constraint fk_CompraXProducto_Producto foreign key (IdProducto) references Productos(IdProducto)
);

go

create table ProductoXCategoria (
    IdProducto int not null,
    IdCategoria int not null,
    constraint fk_ProductoXCategoria_Producto foreign key (IdProducto) references Productos(IdProducto),
    constraint fk_ProductoXCategoria_Categoria foreign key (IdCategoria) references Categorias(IdCategoria),
    primary key (IdProducto, IdCategoria)
);

go

create table ProveedorXProducto (
    IdProveedor int not null,
    IdProducto int not null,
	Precio money not null,
    constraint fk_ProveedorXProducto_Proveedor foreign key (IdProveedor) references Provedores(IdProveedor),
    constraint fk_ProveedorXProducto_Producto foreign key (IdProducto) references Productos(IdProducto),
    primary key(IdProveedor, IdProducto)
);

go

create table ClienteXUsuario (
    IdClienteVendedor int primary key identity(1,1),
    IdCliente int not null,
    IdUsuario int not null,
    FechaAsignacion date not null,
    constraint fk_ClienteXVendedor_Cliente foreign key (IdCliente) references Clientes(IdCliente),
    constraint fk_ClienteXVendedor_Vendedor foreign key (IdUsuario) references Usuarios(IdUsuario)
);

go

create table PrecioProducto (
    IdProducto int not null,
    PrecioVenta money not null,
    FechaVigencia date not null,  
    constraint fk_PrecioProducto_Producto foreign key (IdProducto) references Productos(IdProducto),
    primary key(IdProducto, FechaVigencia)
);

*/