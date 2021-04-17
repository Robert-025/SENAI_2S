USE Pessoas;

SELECT Pessoa.idPessoa, Pessoa.Nome, Telefone.Descrição AS Telefone, Emails.Descrição AS Email, CNHs.Descrição AS CNH FROM Pessoa
INNER JOIN Telefone
ON Pessoa.idPessoa = Telefone.idPessoa
INNER JOIN Emails
ON Pessoa.idPessoa = Emails.idPessoa
INNER JOIN CNHs
ON Pessoa.idPessoa = CNHs.idPessoa
ORDER BY Nome DESC;