USE SENAI_HROADS_TARDE;

SELECT * FROM Personagem;

SELECT * FROM Usuarios;

SELECT * FROM TiposUsuarios;

SELECT * FROM Classe;

SELECT Nome FROM Classe;

SELECT * FROM Habilidade;

SELECT COUNT(Habilidade.Nome) AS NumHabilidades
FROM Habilidade;

SELECT Habilidade.idHabilidade FROM Habilidade
ORDER BY idHabilidade ASC;

SELECT * FROM TipoHabilidade;

SELECT Habilidade.idHabilidade, Habilidade.Nome, TipoHabilidade.Nome AS Tipo 
FROM Habilidade 
INNER JOIN TipoHabilidade
ON Habilidade.idTipo = TipoHabilidade.idTipo;

SELECT Personagem.idPersonagem, Personagem.Nome, Classe.idClasse AS Classe, Personagem.MáxVida, Personagem.MáxMana 
FROM Personagem
INNER JOIN Classe
ON Personagem.idClasse = Classe.idClasse;

SELECT * 
FROM Personagem
FULL OUTER JOIN Classe 
ON Personagem.idClasse = Classe.idClasse

-- SELECT * FROM HabilidadeClasse;

SELECT Classe.Nome, Habilidade.Nome 
FROM Classe
INNER JOIN HabilidadeClasse
ON Classe.idClasse = HabilidadeClasse.idClasse
INNER JOIN Habilidade
ON Habilidade.idHabilidade = HabilidadeClasse.idHabilidade;

SELECT Personagem.idPersonagem, Personagem.Nome, HabilidadeClasse.idClasse, Habilidade.Nome 
FROM HabilidadeClasse
INNER JOIN Personagem
ON HabilidadeClasse.idClasse = Personagem.idClasse
INNER JOIN Habilidade
ON HabilidadeClasse.idHabilidade = Habilidade.idHabilidade;


SELECT Personagem.idPersonagem, Personagem.Nome, HabilidadeClasse.idClasse, Habilidade.Nome 
FROM Personagem
LEFT JOIN HabilidadeClasse
ON HabilidadeClasse.idClasse = Personagem.idClasse
FULL OUTER JOIN Habilidade
ON HabilidadeClasse.idHabilidade = Habilidade.idHabilidade;