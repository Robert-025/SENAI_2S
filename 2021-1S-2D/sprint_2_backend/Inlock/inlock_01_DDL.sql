CREATE DATABASE Inlock_Games_Tarde;
GO

USE Inlock_Games_Tarde;
GO

CREATE TABLE estudios
(
	idEstudio		INT PRIMARY KEY IDENTITY,
	nomeEstudio		VARCHAR(100) UNIQUE NOT NULL,
);
GO

CREATE TABLE jogos
(
	idJogo			INT PRIMARY KEY IDENTITY,
	nomeJogo		VARCHAR(250) UNIQUE NOT NULL,
	descricao		VARCHAR(1000) UNIQUE NOT NULL,
	dataLancamento	DATE NOT NULL,
	valor			MONEY NOT NULL,			
	idEstudio		INT FOREIGN KEY REFERENCES estudios(idEstudio)
);
GO

CREATE TABLE tiposUsuario
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY,
	titulo			VARCHAR(250) NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario		INT PRIMARY KEY IDENTITY,
	nome			VARCHAR(250) NOT NULL,
	email			VARCHAR(250) UNIQUE NOT NULL,
	senha			VARCHAR(250) NOT NULL,
	idTipoUsuario	INT FOREIGN KEY REFERENCES tiposUsuario(idTipoUsuario)
);
GO