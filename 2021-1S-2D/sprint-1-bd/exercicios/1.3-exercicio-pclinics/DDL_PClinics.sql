CREATE DATABASE PClinics;

USE PClinics;

CREATE TABLE TiposPets(
		idTipoPet		INT PRIMARY KEY IDENTITY,
		Descri��o		VARCHAR(255) NOT NULL
);

CREATE TABLE Donos(
		idDono			INT PRIMARY KEY IDENTITY,
		Nome			VARCHAR(255) NOT NULL
);

CREATE TABLE Ra�as(
		idRa�a			INT PRIMARY KEY IDENTITY,
		Descri��o		VARCHAR(255) NOT NULL,
		idTipoPet		INT FOREIGN KEY REFERENCES TiposPets(idTipoPet),
);

CREATE TABLE Clinicas(
		idClinica		INT PRIMARY KEY IDENTITY,
		Raz�oSocial		VARCHAR(255) NOT NULL,
		CNPJ			INT,
		Endere�o		VARCHAR(255) NOT NULL
);

CREATE TABLE Veterin�rios(
		idVeterinario	INT PRIMARY KEY IDENTITY,
		Nome			VARCHAR(255) NOT NULL,
		CRMV			VARCHAR(255) NOT NULL,
		idClinica		INT FOREIGN KEY REFERENCES Clinicas(idClinica)
);

CREATE TABLE Pets(
		idPet			INT PRIMARY KEY IDENTITY,
		Nome			VARCHAR(255) NOT NULL,
		DataNascimento	DATE,
		idRa�a			INT FOREIGN KEY REFERENCES Ra�as(idRa�a),
		idDono			INT FOREIGN KEY REFERENCES Donos(idDono)
);

CREATE TABLE Atendimentos(
		idAtendimento	INT PRIMARY KEY IDENTITY,
		Descri��o		VARCHAR(255) NOT NULL,
		DataAtendimento	DATE,
		idVeterinario	INT FOREIGN KEY REFERENCES Veterin�rios(idVeterinario),
		idPet			INT FOREIGN KEY REFERENCES Pets(idPet)
);