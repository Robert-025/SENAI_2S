USE Inlock_Games_Tarde;

-- Listar todos os usu�rios
SELECT * FROM usuarios;

-- Listar todos os est�dios
SELECT * FROM estudios;

-- Listar todos os jogos
SELECT * FROM jogos;

-- Listar todos os tipos de usuario
SELECT * FROM tiposUsuario;

-- Lista todos os jogos e seus respectivos est�dios
SELECT nomejogo[Jogo], nomeEstudio[Est�dio], descricao, dataLancamento, valor
FROM jogos J
LEFT JOIN estudios E
ON J.idEstudio = E.idEstudio;

-- Buscar e trazer na lista todos os est�dios com os respectivos jogos
SELECT nomeEstudio[Est�dio], nomeJogo[Jogo], descricao, dataLancamento, valor
FROM estudios E
FULL OUTER JOIN jogos J
ON E.idEstudio = J.idEstudio

-- Buscar um usu�rio por email e senha(login)
SELECT nome, email FROM usuarios
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';

-- Busca um jogo por idJogo
SELECT * FROM jogos
WHERE idJogo = 3;

-- Busca um est�dio por idEstudio
SELECT * FROM estudios
WHERE idEstudio = 1;