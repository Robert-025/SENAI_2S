CREATE DATABASE Filmes;

USE Filmes;

CREATE TABLE Genero (
		idGenero INT PRIMARY KEY IDENTITY,
		Nome	 VARCHAR (100) NOT NULL
);

CREATE TABLE Filme(
		idFilme  INT PRIMARY KEY IDENTITY,
		Titulo	 VARCHAR (100) NOT NULL,
		idGenero INT FOREIGN KEY REFERENCES Genero(idGenero)
);