USE Locadora;

SELECT Alugueis.DataInicio, Alugueis.DataFim, Clientes.Nome AS Cliente, Modelos.Descrição AS Modelo
FROM Alugueis
INNER JOIN Clientes
ON Alugueis.idCliente = Clientes.idCliente
INNER JOIN Veículos
ON Alugueis.idVeiculo = Veículos.idVeiculo
INNER JOIN Modelos
ON Veículos.idModelo = Modelos.idModelo;

SELECT Clientes.Nome,  Alugueis.DataInicio, Alugueis.DataFim, Modelos.Descrição AS Modelo
FROM Clientes
INNER JOIN Alugueis
ON Clientes.idCliente = Alugueis.idCliente
INNER JOIN Veículos
ON Alugueis.idVeiculo = Veículos.idVeiculo
INNER JOIN Modelos
ON Veículos.idModelo = Modelos.idModelo
WHERE Clientes.idCliente = 2;