create table Propietario(
	--El id es equivalente al nit a nivel de codigo
    id int IDENTITY, 
    Nombre_propietario varchar(40),
    Apellido_propietario varchar(40),
	Correo_propietario varchar(255),
    Descripcion_direccion varchar(255),
	Zona_direccion int,
	Numero_telefono varchar(25),
    estatus tinyint,
    PRIMARY KEY (id)
);

create table Raza(
    id int IDENTITY,
    Nombre_raza varchar(40),
    estatus tinyint,
    PRIMARY KEY (id)
);

create table Cliente(
    id int IDENTITY,
    Nombre_cliente varchar(40),
    Codraza int,
    Codpropietario int,
	ImagePath_cliente varchar(255),
    estatus tinyint,
    PRIMARY KEY (id),
    CONSTRAINT FK_Codraza_cliente
	FOREIGN KEY (Codraza)
	REFERENCES Raza (id),
    CONSTRAINT FK_Codpropietario_cliente
	FOREIGN KEY (Codpropietario)
	REFERENCES Propietario (id)
);

create table Membresia(
    id int identity,
    NoMembresia_membresia int,
    FechaAdquisicion_membresia date,
    FechaVencimiento_membresia date,
    Tarifa_membresia float,
    NumServicios_membresia int,
    Gratis_membresia tinyint,
    estatus tinyint, 
    PRIMARY KEY (id)
);

create table Tarifa(
	id int identity,
	Condicional_tarifa varchar(255),
	Precio_tarifa float,
	Codmembresia int,
	primary key(id),
	constraint FK_Codmembresia_tarifa
	foreign key (Codmembresia)
	references Membresia(id)
);

create table MembresiaCliente(
	id int identity,
    Codmembresia int,
    Codcliente int,
	primary key(id),
    CONSTRAINT FK_Codmembresia_memcli
    FOREIGN KEY (Codmembresia)
    REFERENCES Membresia (id),
    CONSTRAINT FK_Codcliente_memcli
    FOREIGN KEY (Codcliente)
    REFERENCES Cliente (id)
);

create table TipoPago(
    id int IDENTITY,
    Tipo_pago varchar(40),
    estatus tinyint,
    PRIMARY KEY(id)
);

create table Servicio(
    id int IDENTITY,
    Nombre_servicio varchar(40),
	Precio_servicio float,
    estatus tinyint,
    PRIMARY KEY (id)
);

create table Puesto(
    id int IDENTITY,
    Nombre_puesto varchar(40),
    estatus tinyint,
    PRIMARY KEY (id)
);

create table Empleado(
	--El id es equivalente al dpi a nivel de codigo
    id int IDENTITY,
    Nombre_empleado varchar(40),
    Apellido_empleado varchar(40),
    Codpuesto int,
    estatus tinyint,
    PRIMARY KEY (id),
    CONSTRAINT FK_Codpuesto_empleado
    FOREIGN KEY (Codpuesto)
    REFERENCES Puesto (id)
);

create table CitaEncabezado(
    id int IDENTITY,
    Fecha_citae date,
    Hora_citae varchar(15),
    Codpago int,
    Codempleado int,
    ServicioDomicilio_citae tinyint,
    Total_citae float,
	Saldo float,
    estatus tinyint,
    PRIMARY KEY (id),
    CONSTRAINT FK_Codpago_citae
    FOREIGN KEY (Codpago)
    REFERENCES TipoPago (id),
    CONSTRAINT FK_Codempleado_citae
    FOREIGN KEY (Codempleado)
    REFERENCES Empleado (id)
);

create table ControlMembresia(
	id int identity,
	Fecha_Control date,
	Codmembresia int,
	Codcita int,
	primary key(id),
	constraint FK_Codmembresia_control
	foreign key (Codmembresia)
	references Membresia(id),
	constraint FK_Codcita_control
	foreign key (Codcita)
	references CitaEncabezado(id)
);

create table CitaDetalle(
	id int identity,
    Codcitae int,
    Codservicio int,
    Codmembresia int,
	Descuento_citad float,
	Subtotal_citad float,
    Especificaciones_citad varchar(200),
	primary key(id),
    CONSTRAINT FK_Codcitae_citad
    FOREIGN KEY (Codcitae)
    REFERENCES CitaEncabezado (id),
    CONSTRAINT FK_Codservicio_citad
    FOREIGN KEY (Codservicio)
    REFERENCES Servicio (id),
    CONSTRAINT FK_Codmembresia_citad
    FOREIGN KEY (Codmembresia)
    REFERENCES Membresia (id)
);

create table CitaCliente(  
	id int identity, 
    Codcitae int,
    Codcliente int,
	primary key (id),
    CONSTRAINT FK_Codcitae_citacli
    FOREIGN KEY (Codcitae)
    REFERENCES CitaEncabezado (id),
    CONSTRAINT FK_Codcliente_citacli
    FOREIGN KEY (Codcliente)
    REFERENCES Cliente (id)
);

-- Tablas para la seguridad

create table Perfil(
    id int IDENTITY,
    Nombre_perfil varchar(40),
    Detalles_perfil varchar(100),
    estatus tinyint,
    PRIMARY KEY (id)
);

-- las tareas o funciones que se le asignarán a los perfiles de los usuarios.
create table Funcion(
    id int IDENTITY,
    Detalle_funcion varchar(100),
    estatus tinyint,
    PRIMARY KEY (id)
);

create table FuncionPerfil(
	id int identity,
    Codperfil int,
    Codfuncion int,
	primary key (id),
    CONSTRAINT FK_Codperfil_funcionper
    FOREIGN KEY (Codperfil)
    REFERENCES Perfil (id),
    CONSTRAINT FK_Codfuncion_funcionper
    FOREIGN KEY (Codfuncion)
    REFERENCES Funcion (id)
);

create table Usuario(
    id int IDENTITY,
    Codempleado int,
    Nick_usuario varchar(40),
    Pass_usuario varbinary(max),
    Codperfil int,
    estatus tinyint,
    PRIMARY KEY (id),
    CONSTRAINT FK_Codperfil_usuario
    FOREIGN KEY (Codperfil)
    REFERENCES Perfil (id),
    CONSTRAINT FK_Codempleado_usuario
    FOREIGN KEY (Codempleado)
    REFERENCES Empleado (id)
);

create table Operacion(
    id int IDENTITY,
    Descripcion_operacion varchar(40),
    estatus tinyint,
    PRIMARY KEY(id)
);

create table Bitacora(
    id int IDENTITY,
    Codusuario int,
    Codoperacion int,
    TablaAfectada_bitacora varchar(40),
    FechaHora_bitacora datetime2(0),
    PRIMARY KEY (id),
    CONSTRAINT FK_Codusuario_bitacora
    FOREIGN KEY (Codusuario)
    REFERENCES Usuario (id),
    CONSTRAINT FK_Codoperacion_bitacora
    FOREIGN KEY (Codoperacion)
    REFERENCES Operacion (id)
);

insert into operacion values('INICIAR SESIÓN',0);
insert into operacion values('GUARDAR',0);
insert into operacion values('ELIMINAR',0);
insert into operacion values('MODIFICAR',0);
insert into operacion values('CERRAR SESIÓN',0);
insert into operacion values('GENERAR REPORTE',0);