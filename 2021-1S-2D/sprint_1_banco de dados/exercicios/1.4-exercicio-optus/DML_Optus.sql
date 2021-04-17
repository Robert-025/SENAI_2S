use Optus;
go

insert into Artistas(Nome)
values				('Angra'),
					('Madonna'),
					('Shaman');
go

insert into Estilos(Nome)
values			   ('Rock'),
				   ('Pop'),
				   ('Metal');
go

insert into Ativo(descricao)
values			 ('Ativado'),
				 ('Desativado');
go

insert into Usuarios(Nome, Email, Senha, Permissao)
values				('Saulo', 's.santos@email.com', '123456', 'Administrador'),
					('Caique', 'c.zaneti@email.com', '123456', 'Comum');
go

insert into Albuns(Titulo, DataLancamento, Localizacao, QtdMinutos, IdAtivo, IdArtista)
values			  ('Holy Land', '1996/03/23', 'Brasil', 57, 2, 1),
				  ('MDNA', '2012/03/23', 'EUA', 75, 1, 2);
go

insert into AlbunsEstilos(IdAlbum, IdEstilo)
values					 (2, 1),
						 (2, 3),
						 (3, 1);
go

delete from Albuns
where IdAlbum = 4;

delete from Albuns
where IdAlbum = 5;

update Albuns 
set IdAtivo = 1
where IdAlbum = 2;

update Albuns 
set IdAtivo = 2
where IdAlbum = 3;