create database Optus;
go

use Optus;
go

create table Artistas
(
	IdArtista		int primary key identity,
	Nome			varchar(100) not null
);
go

create table Estilos
(
	IdEstilo		int primary key identity,
	Nome			varchar(50) not null
);
go

create table Ativo
(
	IdAtivo			int primary key identity,
	Descricao		varchar(255) not null
);

create table Usuarios
(
	IdUsuario		int primary key identity,
	Nome			varchar(100) not null,
	Email			varchar (150) UNIQUE not null,
	Senha			varchar(20) not null,
	Permissao		varchar(100) not null
);
go

CREATE TABLE Albuns
(
	IdAlbum			int primary key identity,
	Titulo			varchar(100) not null,
	DataLancamento	date,
	Localizacao		varchar(100) not null,
	QtdMinutos		int not null,
	IdAtivo			int foreign key references Ativo(IdAtivo),
	IdArtista		int foreign key references Artistas(IdArtista)
);
go

create table AlbunsEstilos
(
	IdAlbum		int foreign key references Albuns(IdAlbum),
	IdEstilo	int foreign key references Estilos(IdEstilo)
);
go