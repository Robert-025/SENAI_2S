USE Locadora;

SELECT Alugueis.DataInicio, Alugueis.DataFim, Clientes.Nome AS Cliente, Modelos.Descri��o AS Modelo
FROM Alugueis
INNER JOIN Clientes
ON Alugueis.idCliente = Clientes.idCliente
INNER JOIN Ve�culos
ON Alugueis.idVeiculo = Ve�culos.idVeiculo
INNER JOIN Modelos
ON Ve�culos.idModelo = Modelos.idModelo;

SELECT Clientes.Nome,  Alugueis.DataInicio, Alugueis.DataFim, Modelos.Descri��o AS Modelo
FROM Clientes
INNER JOIN Alugueis
ON Clientes.idCliente = Alugueis.idCliente
INNER JOIN Ve�culos
ON Alugueis.idVeiculo = Ve�culos.idVeiculo
INNER JOIN Modelos
ON Ve�culos.idModelo = Modelos.idModelo
WHERE Clientes.idCliente = 2;