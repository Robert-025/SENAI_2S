CREATE DATABASE SENAI_HROADS_TARDE;

CREATE TABLE Classe(
		
		idClasse INT PRIMARY KEY IDENTITY,
		Nome   	 VARCHAR(100) NOT NULL
);

CREATE TABLE TipoHabilidade(

		idTipo INT PRIMARY KEY IDENTITY,
		Nome   VARCHAR(100) NOT NULL
);

CREATE TABLE Habilidade(

		idHabilidade INT PRIMARY KEY IDENTITY,
		idTipo		 INT FOREIGN KEY REFERENCES TipoHabilidade(idTipo),
		Nome		 VARCHAR(100) NOT NULL
);

CREATE TABLE HabilidadeClasse(

		idClasse	 INT FOREIGN KEY REFERENCES Classe(idClasse),
		idHabilidade INT FOREIGN KEY REFERENCES	Habilidade(idHabilidade)
);

CREATE TABLE Personagem(

		idPersonagem	INT PRIMARY KEY IDENTITY,
		idClasse		INT FOREIGN KEY REFERENCES Classe(idClasse),
		Nome			VARCHAR(100) NOT NULL
		MáxVida			TINYINT NOT NULL,
		MáxMana			TINYINT NOT NULL,
		DataAtualização DATE NOT NULL,
		DataCriação		DATE NOT NULL
);