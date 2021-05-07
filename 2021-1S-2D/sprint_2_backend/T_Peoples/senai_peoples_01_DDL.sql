CREATE DATABASE T_Peoples;
GO

USE T_Peoples;
GO

CREATE TABLE funcionarios 
(
	idFuncionario		INT PRIMARY KEY IDENTITY,
	nome				VARCHAR(250) NOT NULL,
	sobrenome			VARCHAR(250) NOT NULL
);
GO