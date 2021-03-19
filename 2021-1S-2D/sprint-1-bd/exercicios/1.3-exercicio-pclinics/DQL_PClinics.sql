USE PClinics;

select * from Clinicas;
select * from Veterinários;
select * from Donos;
select * from TiposPets;
select * from Racas;
select * from Pets;
select * from Atendimentos;

select idVeterinario, Nome, CRMV, Veterinários.idClinica, Clinicas.RazãoSocial as NomeClinica
from Veterinários
INNER JOIN Clinicas
on Veterinários.idClinica = Clinicas.idClinica;

select Descrição from Racas where Descrição like 'S%';

select Descrição from TiposPets where Descrição like '%o';

select Pets.Nome, DataNascimento, idRaça, Donos.idDono, Donos.Nome as NomeDono
from Pets
inner join Donos
on Pets.idDono = Donos.idDono

select idAtendimento ,Veterinários.Nome as NomeVeterinario, Pets.Nome as NomePet,  Racas.Descrição as Raças,
	   TiposPets.Descrição as TipoPet, Donos.Nome as NomeDono, Clinicas.RazãoSocial as NomeClinica
from Atendimentos
inner join Veterinários
on Atendimentos.idVeterinario = Veterinários.idVeterinario
inner join Pets
on Atendimentos.idPet = Pets.idPet
inner join Racas
on Pets.idRaça = Racas.idRaça
inner join TiposPets
on Racas.idTipoPet = TiposPets.idTipoPet
inner join Donos
on Pets.idDono = Donos.idDono
inner join Clinicas
on Veterinários.idClinica = Clinicas.idClinica;