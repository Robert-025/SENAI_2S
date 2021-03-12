USE Pessoas;

SELECT Pessoa.idPessoa, Pessoa.Nome, Telefone.Descri��o AS Telefone, Emails.Descri��o AS Email, CNHs.Descri��o AS CNH FROM Pessoa
INNER JOIN Telefone
ON Pessoa.idPessoa = Telefone.idPessoa
INNER JOIN Emails
ON Pessoa.idPessoa = Emails.idPessoa
INNER JOIN CNHs
ON Pessoa.idPessoa = CNHs.idPessoa
ORDER BY Nome DESC;