USE Pessoas;

INSERT INTO Pessoa(Nome)
VALUES			  ('Saulo'),
				  ('Caique');

INSERT INTO Telefone(Descri��o, idPessoa)
VALUES				('99999999', 1),
					('88888888', 1),
					('77777777', 2);

INSERT INTO Emails(Descri��o, idPessoa)
VALUES			  ('s.santos@email.com', 1),
				  ('c.zaneti@email.com', 2);

INSERT INTO CNHs(Descri��o, idPessoa)
VALUES			('1234', 1),
				('4321', 2);