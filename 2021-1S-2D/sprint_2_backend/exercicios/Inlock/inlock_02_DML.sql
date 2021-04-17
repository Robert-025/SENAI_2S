USE Inlock_Games_Tarde;

INSERT INTO estudios(nomeEstudio)
VALUES				('Blizzard'),
					('Rockstar Studios'),
					('Square Enix');

INSERT INTO jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '15/05/2012', 99.00, 1),
				 ('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '26/10/2018', 120.00, 2);

INSERT INTO tiposUsuario(titulo)
VALUES					('Administrador'),
						('Cliente');

INSERT INTO usuarios(nome, email, senha, idTipoUsuario)
VALUES				('Robert', 'admin@admin.com', 'admin', 1),
					('Saulo', 'cliente@cliente.com', 'cliente', 2);