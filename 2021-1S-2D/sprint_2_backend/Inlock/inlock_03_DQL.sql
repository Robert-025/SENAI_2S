USE Inlock_Games_Tarde;

-- Listar todos os usuários
SELECT * FROM usuarios;

-- Listar todos os estúdios
SELECT * FROM estudios;

-- Listar todos os jogos
SELECT * FROM jogos;

-- Listar todos os tipos de usuario
SELECT * FROM tiposUsuario;

-- Lista todos os jogos e seus respectivos estúdios
SELECT nomejogo[Jogo], nomeEstudio[Estúdio], descricao, dataLancamento, valor
FROM jogos J
LEFT JOIN estudios E
ON J.idEstudio = E.idEstudio;

-- Buscar e trazer na lista todos os estúdios com os respectivos jogos
SELECT nomeEstudio[Estúdio], nomeJogo[Jogo], descricao, dataLancamento, valor
FROM estudios E
FULL OUTER JOIN jogos J
ON E.idEstudio = J.idEstudio

-- Buscar um usuário por email e senha(login)
SELECT nome, email FROM usuarios
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';

-- Busca um jogo por idJogo
SELECT * FROM jogos
WHERE idJogo = 3;

-- Busca um estúdio por idEstudio
SELECT * FROM estudios
WHERE idEstudio = 1;