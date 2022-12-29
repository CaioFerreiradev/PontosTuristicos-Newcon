CREATE PROCEDURE uspPontoTuristico
@Pais varchar(50),
@Cidade varchar(50),
@Estado varchar(50),
@Endereco varchar(50),
@PontoTuristico varchar(100)

AS
BEGIN

INSERT INTO [Projeto Teste]
( 
Pais,
Cidade,
Estado,
Endereco,
PontoTuristico
)
VALUES
(
@Pais,
@Cidade,
@Estado,
@Endereco,
@PontoTuristico
)

SELECT @@IDENTITY AS Retorno

END
