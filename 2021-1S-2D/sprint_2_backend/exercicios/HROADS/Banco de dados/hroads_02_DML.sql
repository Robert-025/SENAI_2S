USE SENAI_HROADS_TARDE;

INSERT INTO Classe(Nome)
VALUES			  ('Bárbaro'),
				  ('Cruzado'),
				  ('Caçadora de demônios'),
				  ('Monge'),
				  ('Necromante'),
				  ('Feiticeiro'),
				  ('Arcanista');

INSERT INTO TipoHabilidade(Nome)
VALUES				  ('Ataque'),
					  ('Defesa'),
					  ('Cura'),
					  ('Magia');

INSERT INTO Habilidade(idTipo, Nome)
VALUES				  (1, 'Lança mortal'),
					  (2, 'Escudo supremo'),
					  (3, 'Recuperar vida');

INSERT INTO HabilidadeClasse(idClasse, idHabilidade)
VALUES						(1, 5),
							(1, 6),
							(2, 6),
							(3, 5),
							(4, 7),
							(4, 6),
							(5, NULL),
							(6, 7),
							(7, NULL);

INSERT INTO Personagem(idClasse, Nome, MáxVida, MáxMana, DataAtualização, DataCriação)
VALUES				  (1, 'DeuBug', 100, 80, '03/03/2021', '18/01/2017'),
					  (4, 'BitBug', 70, 100, '03/03/2021', '17/03/2016'),
					  (7, 'Fer8', 75, 60, '03/03/2021', '18/03/2018');

UPDATE Personagem
SET Nome = 'Fer7'
WHERE idPersonagem = 3;

UPDATE Classe
SET Nome = 'Necromancer'
WHERE idClasse = 5;

INSERT INTO TiposUsuarios(Descricao)
VALUES					 ('Administrador'),
						 ('Comum');

INSERT INTO Usuarios(Email, Senha, idTiposUsuarios)
VALUES				('admin@admin.com', 'admin', 1),
					('comum@comum.com', 'comum', 2);