USE Filmes;

INSERT INTO Genero(Nome)
VALUES			  ('Ação'),
				  ('Romance');

INSERT INTO Filme(Titulo, idGenero)
VALUES			 ('Rambo', 1),
				 ('Vingadores', 1),
				 ('Ghost', 2),
				 ('Diário de uma paixão', 2);