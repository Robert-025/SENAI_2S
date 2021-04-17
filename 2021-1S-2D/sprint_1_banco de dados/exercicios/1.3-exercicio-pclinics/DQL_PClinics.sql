USE PClinics;

select * from Clinicas;
select * from Veterin�rios;
select * from Donos;
select * from TiposPets;
select * from Racas;
select * from Pets;
select * from Atendimentos;

select idVeterinario, Nome, CRMV, Veterin�rios.idClinica, Clinicas.Raz�oSocial as NomeClinica
from Veterin�rios
INNER JOIN Clinicas
on Veterin�rios.idClinica = Clinicas.idClinica;

select Descri��o from Racas where Descri��o like 'S%';

select Descri��o from TiposPets where Descri��o like '%o';

select Pets.Nome, DataNascimento, idRa�a, Donos.idDono, Donos.Nome as NomeDono
from Pets
inner join Donos
on Pets.idDono = Donos.idDono

select idAtendimento ,Veterin�rios.Nome as NomeVeterinario, Pets.Nome as NomePet,  Racas.Descri��o as Ra�as,
	   TiposPets.Descri��o as TipoPet, Donos.Nome as NomeDono, Clinicas.Raz�oSocial as NomeClinica
from Atendimentos
inner join Veterin�rios
on Atendimentos.idVeterinario = Veterin�rios.idVeterinario
inner join Pets
on Atendimentos.idPet = Pets.idPet
inner join Racas
on Pets.idRa�a = Racas.idRa�a
inner join TiposPets
on Racas.idTipoPet = TiposPets.idTipoPet
inner join Donos
on Pets.idDono = Donos.idDono
inner join Clinicas
on Veterin�rios.idClinica = Clinicas.idClinica;