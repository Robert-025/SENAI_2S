USE Inlock_Games_Tarde;

INSERT INTO estudios(nomeEstudio)
VALUES				('Blizzard'),
					('Rockstar Studios'),
					('Square Enix');

INSERT INTO jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '15/05/2012', 99.00, 1),
				 ('Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00, 2);

INSERT INTO tiposUsuario(titulo)
VALUES					('Administrador'),
						('Cliente');

INSERT INTO usuarios(nome, email, senha, idTipoUsuario)
VALUES				('Robert', 'admin@admin.com', 'admin', 1),
					('Saulo', 'cliente@cliente.com', 'cliente', 2);