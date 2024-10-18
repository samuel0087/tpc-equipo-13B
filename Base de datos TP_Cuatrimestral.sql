create database TP_Cuatrimestral
go
use TP_Cuatrimestral
go
create table Clientes(

IdCliente int primary key identity(1,1),
Nombre varchar(50)not null,
Apellido varchar(50)not null,
DNI int unique not null,
Celular varchar(50) not null,
Email varchar(50) not null,
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
Telefono varchar(50) not null,
Celular varchar(50) not null,
Direccion varchar(50)not null,
Provincia varchar(50)not null,
Pais varchar(100)not null
);

go

create table Productos(
IdProducto int not null primary key identity(1,1),
Codigo int unique not null, 
Nombre varchar(50)not null,
Marca varchar(50)not null,
IdProveedor int not null,
Stock bigint not null,
Tipo varchar(50),
CONSTRAINT FK_Producto_Proveedor foreign key(IdProveedor) references Provedores(IdProveedor)
);

go

create table Usuarios(
IdUsuario int primary key identity(1,1),
Nombre varchar(50) not null,
Contrase�a varchar(50) not null,
Rol varchar(50) not null
);

go

create table MetodoDePago(
IdMetodoDePago int primary key identity(1,1),
Nombre varchar(50) unique
);

go

create table Ventas(
IdDeVenta int primary key identity(1,1),
IdCliente int not null,
Fecha date not null ,
IdVendedor int not null,
IdMetodoDePago int not null,
FacturaGenerada bit not null,
CostoTotal money not null,
constraint fk_Ventas_Cliente foreign key (IdCliente) references Clientes(IdCliente),
constraint fk_Ventas_Usuario foreign key (IdVendedor) references Usuarios(IdUsuario),
constraint fk_Ventas_MetodoDePago foreign key(IdMetodoDePago) references MetodoDePago(IdMetodoDePago)
);

go 

create table Compras(
IdCompra int primary key identity(1,1),
IdProveedor int not null ,
IdMetodoDePago int not null,
FechaCompra date not null,
CostoTotal money not null,
Recibido bit not null,
constraint fk_Compra_Proveedor foreign key (IdProveedor) references Provedores(IdProveedor),
constraint fk_Compra_MetodoDePago foreign key(IdMetodoDePago) references MetodoDePago(IdMetodoDePago)
);

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

/*Datos de pueba de la tabla Marcas*/
INSERT INTO Marcas (Nombre)
VALUES
('Coca-Cola Argentina'),
('Patagonia'),
('Arcor'),
('Felfort'),
('La Serenísima'),
('Quilmes');


