USE PClinics;

INSERT INTO TiposPets(Descrição)
VALUES				 ('Cachorro'),
					 ('Gato');

	DELETE FROM TiposPets WHERE idTipoPet = 3;
	DELETE FROM TiposPets WHERE idTipoPet = 4;

INSERT INTO Donos(Nome)
VALUES			 ('Paulo'),
				 ('Odirlei');

	DELETE FROM Donos WHERE idDono = 3;
	DELETE FROM Donos WHERE idDono = 4;
	DELETE FROM Donos WHERE idDono = 5;
	DELETE FROM Donos WHERE idDono = 6;

INSERT INTO Clinicas(RazãoSocial, CNPJ, Endereço)
VALUES				('Meu Pimpão', 99999999999999,'Av. Barão de Limeira, 539');

INSERT INTO Racas(Descrição, idTipoPet)
VALUES			 ('Poodle', 1),
				 ('Labrador', 1),
				 ('SRD', 1),
				 ('Siamês', 2);

	DELETE FROM Racas WHERE	idRaça = 5;
	DELETE FROM Racas WHERE	idRaça = 6;
	DELETE FROM Racas WHERE	idRaça = 7;
	DELETE FROM Racas WHERE	idRaça = 8;

INSERT INTO Veterinários(Nome, CRMV, idClinica)
VALUES					('Saulo', 432551, 2),
						('Caique', 653655, 2);

INSERT INTO Pets(Nome, DataNascimento, idRaça, idDono)
VALUES			('Junior', '2018/10/10', 1, 1),
				('Loli', '2017/05/18', 4, 1),
				('Sammy', '2016/06/16', 1, 2);

	DELETE FROM Pets WHERE	idPet = 4;
	DELETE FROM Pets WHERE	idPet = 5;
	DELETE FROM Pets WHERE	idPet = 6;

INSERT INTO Atendimentos(Descrição, DataAtendimento, idVeterinario, idPet)
VALUES					('Restam 10 dias de vida', '2019/01/22', 5, 1),
						('O paciente está OK', '2019/01/21', 6, 2),
						('O paciente está OK', '2019/01/22', 6, 1);