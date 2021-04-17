use Optus;

select Nome, Email, Permissao from Usuarios
where Permissao = 'Administrador';

select * from Albuns
where DataLancamento > '1997/01/01';

select * from Usuarios
where Email is not null and Senha = '123456'

select Titulo, Artistas.Nome as Artista, DataLancamento, Estilos.Nome as Estilo
from Albuns
inner join Artistas
on Albuns.IdArtista = Artistas.IdArtista
inner join AlbunsEstilos
on Albuns.IdAlbum = AlbunsEstilos.IdAlbum
inner join Estilos
on AlbunsEstilos.IdEstilo = Estilos.IdEstilo;