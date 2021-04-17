USE Locadora;

INSERT INTO Empresas(Nome)
VALUES				('Unidas'),
					('Localiza');

INSERT INTO Marcas(Nome)
VALUES			  ('Ford'),
				  ('GM'),
				  ('Fiat');

INSERT INTO Clientes(Nome, CPF)
VALUES				('Saulo', '12345678900'),
					('Caique', '09876543211');

INSERT INTO Modelos(Descrição, idMarca)
VALUES			   ('Fiesta', 1),
				   ('Onix', 2),
				   ('Argo', 3)

INSERT INTO Veículos(idModelo, Placa, idEmpresa)
VALUES				(1, 'HEL1805', 1),
					(2, 'FER1010', 1),
					(3, 'POR1978', 2),
					(1, 'LEM9876', 2);

INSERT INTO Alugueis(idCliente, idVeiculo, DataInicio, DataFim)
VALUES				(2, 3, '12/02/2010', '12/03/2010'),
					(1, 2, '02/04/2017', '02/04/2018');