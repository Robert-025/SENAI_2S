USE Filmes;

INSERT INTO Genero(Nome)
VALUES			  ('A��o'),
				  ('Romance');

INSERT INTO Filme(Titulo, idGenero)
VALUES			 ('Rambo', 1),
				 ('Vingadores', 1),
				 ('Ghost', 2),
				 ('Di�rio de uma paix�o', 2);