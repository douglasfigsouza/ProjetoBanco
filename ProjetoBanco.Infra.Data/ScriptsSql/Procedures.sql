IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLESTADOS]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLESTADOS]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLESTADOS]
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Busca Todos os Estado
	Autor.............: SMN - Douglas
	Data..............: 01/10/2017
	Ex................: EXEC [dbo].[PBSP_GETALLESTADOS]

	*/

	BEGIN
		SELECT  EstadoId,
				Sigla 
				FROM Estado WITH(NOLOCK)
	END
	GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETCIDADESBYIDESTADO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETCIDADESBYIDESTADO]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETCIDADESBYIDESTADO]
		@id SMALLINT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna todas as cidades vinculadas ao estado informado
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_GETCIDADESBYIDESTADO]

	*/

	BEGIN
		SELECT cidade.CidadeId, 
			   cidade.Nome 
			   FROM [dbo].[Cidade] AS cidade WITH(NOLOCK)
					INNER JOIN [dbo].[Estado] AS estado WITH(NOLOCK) on Cidade.EstadoId = Estado.EstadoId
		WHERE Estado.EstadoId = @id
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTCLIENTE]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTCLIENTE]
		@cidadeId INT,
		@nome VARCHAR (200),
		@cpf VARCHAR(20),
		@rg VARCHAR(20),
		@fone VARCHAR(20),
		@rua VARCHAR(100),
		@bairro VARCHAR(200),
		@num INT,
		@dataCadastro DATETIME,
		@nivel CHAR(1),
		@ativo BIT
		AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Cadastro de Clientes/Funcionários
	Autor.............: SMN - Douglas
	Data..............: 02/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTCLIENTE]

	*/

	BEGIN

		INSERT INTO Clientes(CidadeId ,nome, cpf, rg, bairro, rua, num, dataCadastro, fone, nivel, ativo)
			VALUES(@cidadeId, @nome, @cpf, @rg, @bairro, @rua, @num, @dataCadastro, @fone, @nivel, @ativo)

	END
GO
--Busca todos os clientes Ativos

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLCLIENTES]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLCLIENTES]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLCLIENTES]
		@op INT = 1
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Buscar Todos os Clientes Ativos
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_GETALLCLIENTES]

	*/

	BEGIN
		IF(@op=1)
			BEGIN
				SELECT  Id,
						nome,
						cpf,
						rg,
						fone,
						rua,
						bairro,
						num,
						nivel,
						dataCadastro 
						FROM [dbo].[Clientes]WITH(NOLOCK)
				WHERE Clientes.ativo = 1;
			END
		ELSE
		BEGIN
			SELECT  Id,
					nome,
					cpf,
					rg,
					fone,
					rua,
					bairro,
					num,
					nivel,
					dataCadastro 
					FROM [dbo].[Clientes]WITH(NOLOCK)
		END
	END
GO

--insert banco

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTBANCO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTBANCO]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTBANCO]
		@nome VARCHAR(200),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Inserir Banco
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTBANCO]

	*/

	BEGIN
		INSERT INTO Banco
			VALUES(@nome, @ativo)
	END
GO

--busca todos os bancos cadastrados e ativos

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLBANCOS]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLBANCOS]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLBANCOS]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna Todos os Bancos cadastrados e atvos
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_GETALLBANCOS]

	*/
	BEGIN
		SELECT  Id,
				nome,
				ativo
				FROM Banco
		WHERE Banco.ativo=1;
	END
GO


--insert usuários

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTUSUARIOS]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTUSUARIOS]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTUSUARIOS]
		@clienteId SMALLINT,
		@nome VARCHAR(20),
		@senha VARCHAR(20),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Insere usuários
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTUSUARIOS]

	*/

	BEGIN
		INSERT INTO USUARIO(clienteId, nome, senha, ativo)
			VALUES(@clienteId, @nome, @senha, @ativo)
	END
GO

--verifica se tem o usuario do acesso cadastrado

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_AUTENTICA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_AUTENTICA]
GO

CREATE PROCEDURE [dbo].[PBSP_AUTENTICA]
	@nome VARCHAR(20),
	@senha VARCHAR(8)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: verifica se existe o usuario informado no banco, se houver retorna
	Autor.............: SMN - Douglas
	Data..............: 03/10/2017
	Ex................: EXEC [dbo].[PBSP_AUTENTICA]

	*/
	BEGIN
		SELECT  Usuario.clienteId,
				Usuario.nome,
				Usuario.senha, 
				Clientes.nivel 
			FROM [dbo].[Usuario] WITH(NOLOCK)
				INNER JOIN Clientes 
					ON Clientes.Id = Usuario.clienteId
			WHERE [dbo].[Usuario].nome=@nome 
				AND [dbo].[Usuario].senha=@senha
	END
GO
--insere Operacaoes

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTOPERACAO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTOPERACAO]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTOPERACAO]
		@descricao VARCHAR(200),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Inserir Opercaoes
	Autor.............: SMN - Douglas
	Data..............: 04/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTOPERACAO]

	*/

	BEGIN
		INSERT INTO [dbo].[Operacoes](descricao, ativo)
			VALUES(@descricao,@ativo)
	END
GO
--Insere Agencia

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTAGENCIA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTAGENCIA]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTAGENCIA]
		@cidadeId INT,
		@bancoId SMALLINT,
		@agencia INT,
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Inserir agencias
	Autor.............: SMN - Douglas
	Data..............: 04/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTAGENCIA]

	*/

	BEGIN
		INSERT INTO [dbo].[Agencia](CidadeId, bancoId, agencia, ativo)
			VALUES(@cidadeId, @bancoId, @agencia, @ativo)
	END
GO
/*Retona todas as agencias*/

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLAGENCIAS]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLAGENCIAS]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLAGENCIAS]

	AS
	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna todas as agências
	Autor.............: SMN - Douglas
	Data..............: 04/10/2017
	Ex................: EXEC [dbo].[PBSP_GETALLAGENCIAS]

	*/

	BEGIN
		SELECT 	agencia,
				bancoId,
				CidadeId, 
				ativo 
				FROM[dbo].[Agencia] WITH(NOLOCK)
	END
GO

--insert conta

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTCONTA]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTCONTA]
		@num VARCHAR(20),
		@senha VARCHAR(8),
		@tipo CHAR(3),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Insere conta
	Autor.............: SMN - Douglas
	Data..............: 05/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTCONTA]

	*/
	BEGIN TRY
		DECLARE @contaId INT=0;
		INSERT INTO [dbo].[Conta](num, tipo, senha, ativo)
			VALUES(@num, @tipo ,@senha, @ativo);
		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN ERROR_MESSAGE();
	END CATCH
GO

--insere na contacliente

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCONTACLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_INSERTCONTACLIENTE]
GO

	CREATE PROCEDURE [dbo].[PBSP_INSERTCONTACLIENTE]
		@contaId SMALLINT ,
		@agencia SMALLINT,
		@clienteId SMALLINT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Vincular os clientes na conta
	Autor.............: SMN - Douglas
	Data..............: 05/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTCONTACLIENTE]

	*/

	BEGIN
		DECLARE @bancoId INT=0
		SET @bancoId = (SELECT Id 
							FROM [dbo].[Banco] WITH(NOLOCK)
								INNER JOIN [dbo].[Agencia] WITH(NOLOCK) ON Banco.Id = Agencia.bancoId
							WHERE Agencia.agencia = @agencia);
		INSERT INTO[dbo].[ContaCliente](contaId, agencia, bancoId, clienteId)
			VALUES(@contaId, @agencia, @bancoId, @clienteId);
	END
GO
/*Busca clientes pelo id informado*/

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETCLIENTEBYID]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETCLIENTEBYID]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETCLIENTEBYID]
	 @id INT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna cliente pelo id informado
	Autor.............: SMN - Douglas
	Data..............: 05/10/2017
	Ex................: EXEC [dbo].[PBSP_GETCLIENTEBYID]

	*/
	BEGIN
		SELECT  cli.Id,
				cli.CidadeId,
				cli.nome,
				cli.cpf,
				cli.rg,
				cli.fone,
				cli.bairro,
				cli.rua,
				cli.num,
				cli.ativo,
				cli.nivel,
				cli.dataCadastro,
				estado.EstadoId 
			FROM Clientes AS cli WITH(NOLOCK)
				INNER JOIN Cidade AS city WITH(NOLOCK)  
					ON cli.CidadeId= city.CidadeId
				INNER JOIN Estado AS estado WITH(NOLOCK) 
					ON city.EstadoId = estado.EstadoId
			WHERE cli.Id=@id;
	END
GO

--Retorna dados do cliente para operação


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_SELDADOSCLIENTESAQUE]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_SELDADOSCLIENTESAQUE]
GO

	CREATE PROCEDURE [dbo].[PBSP_SELDADOSCLIENTESAQUE]
		@senhaCli VARCHAR(20),
		@conta VARCHAR(20),
		@clienteId SMALLINT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........:	Retorna dados do cliente para Saque
	Autor.............: SMN - Douglas
	Data..............: 06/10/2017
	Ex................: EXEC [dbo].[PBSP_SELDADOSCLIENTESAQUE]

	*/

	BEGIN
		SELECT  Clientes.Id AS clienteId,
				Clientes.nome,
				Banco.Id AS bancoId, 
				Agencia.agencia, 
				Conta.Id AS
				contaId 
				FROM ContaCliente
					INNER JOIN Clientes ON ContaCliente.clienteId = Clientes.Id
					INNER JOIN Conta ON ContaCliente.contaId = Conta.Id
					INNER JOIN Agencia ON ContaCliente.agencia = Agencia.agencia
					INNER JOIN Banco ON ContaCliente.bancoId = Banco.Id
		WHERE ContaCliente.clienteId = @clienteId AND Conta.num=@conta AND Conta.senha=@senhaCli AND Conta.ativo=1;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_SELDADOSCLIENTEDEPOSITO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_SELDADOSCLIENTEDEPOSITO]
GO

	CREATE PROCEDURE [dbo].[PBSP_SELDADOSCLIENTEDEPOSITO]
		@conta VARCHAR(20)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........:	Retorna dados do cliente para depósito
	Autor.............: SMN - Douglas
	Data..............: 06/11/2017
	Ex................: EXEC [dbo].[PBSP_SELDADOSCLIENTEDEPÓSITO]

	*/

	BEGIN
		SELECT  Clientes.Id AS clienteId,
				Clientes.nome,
				Banco.Id AS bancoId, 
				Agencia.agencia, 
				Conta.Id AS
				contaId 
				FROM ContaCliente
					INNER JOIN Clientes ON ContaCliente.clienteId = Clientes.Id
					INNER JOIN Conta ON ContaCliente.contaId = Conta.Id
					INNER JOIN Agencia ON ContaCliente.agencia = Agencia.agencia
					INNER JOIN Banco ON ContaCliente.bancoId = Banco.Id
		WHERE  Conta.num= @conta AND Conta.ativo=1 ;
	END
GO
--insere operacao realizada

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_DEPOSITO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_DEPOSITO]
	GO

	CREATE PROCEDURE [dbo].[PBSP_DEPOSITO]
		@codTipoOp SMALLINT,
		@clienteId SMALLINT,
		@contaId SMALLINT,
		@dataOp DATETIME,
		@valorOp DECIMAL(18,2)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Faz o depósito na conta selecionada
	Autor.............: SMN - Douglas
	Data..............: 06/10/2017
	Ex................: EXEC [dbo].[PBSP_DEPOSITO]

	*/

	BEGIN
		DECLARE @bancoId SMALLINT,
				@saldoAnterior DECIMAL(18,2),
				@agencia SMALLINT;
		SET @saldoAnterior = dbo.RetornaSaldo(@contaId);
		SET @agencia = dbo.RetornaAgenciaDaConta(@contaId);
		SET @bancoId = dbo.RetornaIdBanco(@agencia);
		INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId, dataOP, saldoAnterior, valorOp)
		VALUES(@codTipoOp, @clienteId, @contaId, @agencia, @bancoId, @dataOp, @saldoAnterior, @valorOp)

	END
	GO
	--Saque

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_SAQUE]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_SAQUE]
GO

	CREATE PROCEDURE [dbo].[PBSP_SAQUE]
		@codTipoOp SMALLINT,
		@clienteId SMALLINT,
		@contaId SMALLINT,
		@dataOp DATETIME,
		@valorOp DECIMAL(18,2)
	AS

	/*

	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Faz o saque na conta selecionada
	Autor.............: SMN - Douglas
	Data..............: 09/10/2017
	Ex................: EXEC [dbo].[PBSP_SAQUE]

	*/

	BEGIN
		DECLARE @bancoId SMALLINT,
				@saldoAnterior DECIMAL(18,2),
				@agencia SMALLINT = dbo.RetornaAgenciaDaConta(@contaId);;
		SET	@bancoId = dbo.RetornaIdBanco(@agencia);
		SET @saldoAnterior = dbo.RetornaSaldo(@contaId);
		IF((@saldoAnterior - @valorOp) >= 0)
			BEGIN
				INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId, dataOP, saldoAnterior, valorOp)
					VALUES(@codTipoOp, @clienteId, @contaId, @agencia, @bancoId, @dataOp, @saldoAnterior, @valorOp*(-1))
				RETURN 1;
			END
		ELSE
			BEGIN
				RETURN 0;
			END

	END
GO
GO

--consulta Saldo
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_CONSULTASALDO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_CONSULTASALDO]
GO

	CREATE PROCEDURE [dbo].[PBSP_CONSULTASALDO]
		@agencia INT,
		@nivel CHAR,
		@senhaCli VARCHAR(20)='',
		@clienteId SMALLINT,
		@conta VARCHAR(20)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Consultar o saldo
	Autor.............: SMN - Douglas
	Data..............: 06/10/2017
	Ex................: EXEC [dbo].[PBSP_CONSULTASALDO]

	*/
	BEGIN
		DECLARE @contaId SMALLINT,
		@saldoConta DECIMAL(18,2);
			SET @contaId = (SELECT Conta.Id 
									FROM Conta WITH(NOLOCK)
										INNER JOIN ContaCliente WITH(NOLOCK) ON Conta.Id = ContaCliente.contaId
										INNER JOIN Clientes WITH(NOLOCK) ON ContaCliente.clienteId = Clientes.Id
										INNER JOIN Agencia WITH(NOLOCK) ON ContaCliente.agencia = Agencia.agencia
								WHERE Conta.num = @conta AND ContaCliente.clienteId = @clienteId
									AND Conta.senha=@senhaCli AND Conta.ativo=1
									AND agencia.ativo=1 AND Clientes.ativo=1);
			SELECT	dbo.RetornaSaldo(@contaId) AS saldo, 
					Clientes.nome AS nome, 
					Conta.num AS num, 
					OperacoesRealizadas.Id AS opId

					FROM OperacoesRealizadas WITH(NOLOCK)
						INNER JOIN Conta WITH(NOLOCK) ON Conta.ID = OperacoesRealizadas.contaId
						INNER JOIN ContaCliente WITH(NOLOCK) ON Conta.Id = ContaCliente.contaId
						INNER JOIN Clientes WITH(NOLOCK) ON ContaCliente.clienteId = Clientes.Id
			WHERE Conta.Id = @contaId
		END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_VERIFICADADOSDATRANSFERENCIA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_VERIFICADADOSDATRANSFERENCIA]
GO
	CREATE PROCEDURE [dbo].[PBSP_VERIFICADADOSDATRANSFERENCIA]
		@conta VARCHAR(16),
		@agencia INT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Verifica se existem as duas contas informadas para transação
	Autor.............: SMN - Douglas
	Data..............: 10/10/2017
	Ex................: EXEC [dbo].[PBSP_VERIFICADADOSDATRANSFERENCIA]

	*/


	BEGIN
		SELECT Clientes.Id AS clienteId,
			   Clientes.nome,
			   Banco.Id AS bancoId, 
			   Agencia.agencia, 
			   Conta.Id as 
			   contaId 
			   FROM ContaCliente WITH(NOLOCK)
					INNER JOIN Clientes ON ContaCliente.clienteId = Clientes.Id
					INNER JOIN Conta ON ContaCliente.contaId = Conta.Id
					INNER JOIN Agencia ON ContaCliente.agencia = Agencia.agencia
					INNER JOIN Banco ON ContaCliente.bancoId = Banco.Id
		WHERE Conta.num = @conta AND Agencia.agencia = @agencia AND Agencia.ativo=1
			AND Conta.ativo=1 AND Clientes.ativo=1;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_TRANSFERENCIA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_TRANSFERENCIA]
GO

	CREATE PROCEDURE [dbo].[PBSP_TRANSFERENCIA]
		@codTipoOp SMALLINT,
		@contaId SMALLINT,
		@agencia INT,
		@dataOp DATETIME,
		@valorOp DECIMAL(18,2)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Faz a transferencia entre duas contas
	Autor.............: SMN - Douglas
	Data..............: 09/10/2017
	Ex................: EXEC [dbo].[PBSP_TRANSFERENCIA]

	*/

	BEGIN
		DECLARE @bancoId SMALLINT,
		@saldoAnterior DECIMAL(18,2),
		@clienteId SMALLINT;
		SET	@bancoId = dbo.RetornaIdBanco(@agencia);
		SET @saldoAnterior = dbo.RetornaSaldo(@contaId);
		SET @clienteId = dbo.RetornaIdClienteConta(@contaId);
		BEGIN
			INSERT INTO OperacoesRealizadas(codTipoOp, clienteId,contaId, agencia, bancoId, dataOP, saldoAnterior, valorOp)
				VALUES(@codTipoOp, @clienteId, @contaId, @agencia, @bancoId, @dataOp, @saldoAnterior, @valorOp);
		END
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_UPDATECLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_UPDATECLIENTE]
GO

	CREATE PROCEDURE [dbo].[PBSP_UPDATECLIENTE]
		@id SMALLINT,
		@cidadeId INT,
		@nome VARCHAR(200),
		@fone VARCHAR(20),
		@cpf VARCHAR(20),
		@rg VARCHAR(20),
		@bairro VARCHAR(200),
		@rua VARCHAR(100),
		@num INT,
		@nivel CHAR(1),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualiza dados do cliente
	Autor.............: SMN - Douglas
	Data..............: 11/10/2017
	Ex................: EXEC [dbo].[PBSP_UPDATECLIENTE]

	*/

	BEGIN
		UPDATE  Clientes 
			SET CidadeId=@cidadeId, 
				nome=@nome,
				cpf=@cpf,
				rg=@rg,
				fone=@fone,
				bairro=@bairro,
				rua=@rua,
				num=@num,
				ativo=@ativo,
				nivel=@nivel
			WHERE Clientes.Id = @id;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLUSERS]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLUSERS]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLUSERS]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna todos os usuarios cadastrados
	Autor.............: SMN - Douglas
	Data..............: 01/01/2017
	Ex................: EXEC [dbo].[PBSP_GETALLUSERS]

	*/

	BEGIN
		SELECT  clienteId,Usuario.nome as usuNome,
				Cli.nome as cliNome,
				senha 
				FROM USUARIO WITH(NOLOCK)
					INNER JOIN Clientes AS Cli WITH(NOLOCK) ON USUARIO.clienteId = Cli.Id
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETBYUSUARIOID]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETBYUSUARIOID]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETBYUSUARIOID]
		@id SMALLINT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Busca usuários pelo id
	Autor.............: SMN - Douglas
	Data..............: 11/10/2017
	Ex................: EXEC [dbo].[PBSP_GETBYUSUARIOID]

	*/

	BEGIN
		SELECT clienteId,
			   nome,
			   senha, 
			   ativo
			   FROM USUARIO WITH(NOLOCK)
		WHERE USUARIO.clienteId = @id;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_UPDATEUSUARIO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_UPDATEUSUARIO]
GO

	CREATE PROCEDURE [dbo].[PBSP_UPDATEUSUARIO]
		@clienteId SMALLINT,
		@nome VARCHAR(20),
		@senha VARCHAR(20),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualizar dados do usuario
	Autor.............: SMN - Douglas
	Data..............: 11/10/2017
	Ex................: EXEC [dbo].[PBSP_UPDATEUSUARIO]

	*/

	BEGIN
		UPDATE USUARIO 
			SET nome=@nome,
				senha=@senha,
				ativo =@ativo
		WHERE USUARIO.clienteId=@clienteId
	END
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLOPERACOESESTORNO]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETALLOPERACOESESTORNO]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETALLOPERACOESESTORNO]

	AS
	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Recupera todas as operaçoes realiazadas para o estorno
	Autor.............: SMN - Douglas
	Data..............: 16/10/2017
	Ex................: EXEC [dbo].[PBSP_GETALLOPERACOESESTORNO]

	*/

	BEGIN

		SELECT	opReal.Id,
				opReal.codTipoOp, 
				opReal.dataOP,
				opReal.valorOp,
				opReal.saldoAnterior, 
				op.descricao, ag.agencia,
				conta.num , cli.nome
				FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
					INNER JOIN Operacoes AS op WITH(NOLOCK) on opReal.codTipoOp = op.Id
					INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia = ag.agencia
					INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId = conta.Id
					INNER JOIN Clientes AS cli WITH(NOLOCK) ON opReal.clienteId = cli.Id
	END
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETOPREALIZADASPORCONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_GETOPREALIZADASPORCONTA]
GO

	CREATE PROCEDURE [dbo].[PBSP_GETOPREALIZADASPORCONTA]
		@conta VARCHAR(20),
		@agencia INT,
		@senha VARCHAR(20)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna operações realizadas por conta
	Autor.............: SMN - Douglas
	Data..............: 16/10/2017
	Ex................: EXEC [dbo].[PBSP_GETOPREALIZADASPORCONTA]

	*/

	BEGIN
		SELECT opReal.Id,
			   opReal.codTipoOp, 
			   opReal.dataOP,
			   opReal.valorOp,
			   opReal.saldoAnterior, 
			   op.descricao, 
			   ag.agencia,
			   conta.num , cli.nome
			   FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
					INNER JOIN Operacoes AS op WITH(NOLOCK) on opReal.codTipoOp = op.Id
					INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia = ag.agencia
					INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId = conta.Id
					INNER JOIN Clientes AS cli WITH(NOLOCK) ON opReal.clienteId = cli.Id
		WHERE conta.num=@conta AND ag.agencia=@agencia AND conta.senha=@senha
			AND conta.ativo=1 AND ag.ativo=1 AND cli.ativo=1;
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_ESTORNA]') AND objectproperty(id, N'IsPROCEDURE')=1)
DROP PROCEDURE [dbo].[PBSP_ESTORNA]
GO

	CREATE PROCEDURE [dbo].[PBSP_ESTORNA]
		@id SMALLINT,
		@opId SMALLINT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Grava o estorno
	Autor.............: SMN - Douglas
	Data..............: 16/10/2017
	Ex................: EXEC [dbo].[PBSP_ESTORNA]

	*/

	BEGIN
		DECLARE @clienteId SMALLINT,
				@contaId SMALLINT,
				@agencia INT,
				@bancoId SMALLINT,
				@saldoAnterior DECIMAL(18,2),
				@valorOp DECIMAL(18,2),
				@valorUltOp DECIMAL(18,2),
				@op SMALLINT,
				@cliente2Id SMALLINT,
				@conta2Id SMALLINT,
				@agencia2 INT,
				@banco2Id SMALLINT,
				@saldoAnterior2 DECIMAL(18,2),
				@valorOp2 DECIMAL(18,2),
				@valorUltOp2 DECIMAL(18,2)

				SET @clienteId = (SELECT opReal.clienteId 
										FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
											INNER JOIN  Clientes as cli WITH(NOLOCK) on opReal.clienteId=cli.Id
								  WHERE opReal.Id = @id);

				SET @contaId = (SELECT opReal.contaId 
									FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
										INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId= conta.Id
								WHERE opReal.Id = @id);

				SET @agencia = (SELECT opReal.agencia 
									FROM OperacoesRealizadas  AS opReal WITH(NOLOCK)
										INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia =  ag.agencia
								WHERE opReal.Id = @id);

				SET @bancoId = dbo.RetornaIdBanco(@agencia);

				SET @op=dbo.RetornaIdProxOpRealizada(@id);

				SET @saldoAnterior = dbo.RetornaSaldo(@contaId);
				SET @valorOp = (SELECT opReal.valorOp 
									FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
								WHERE opReal.Id = @id)*(-1);

				SET @valorUltOp = dbo.RetornaValorUltOp(@id);
				--recupera o valor da op da primeira opercão
				IF(@valorUltOp < 0)
					BEGIN
						SET @op=dbo.RetornaIdProxOpRealizada(@id);
						--lembrar de mudar caso mude o id da operação
						IF(@op=4)
							BEGIN 
								SET @cliente2Id = (SELECT opReal.clienteId 
														FROM OperacoesRealizadas AS opReal WITH(NOLOCK) 
															INNER JOIN  Clientes as cli WITH(NOLOCK) on opReal.clienteId=cli.Id
												   WHERE opReal.Id = @id+1 AND cli.ativo=1);

								SET @conta2Id = (SELECT opReal.contaId 
													FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
														INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId= conta.Id
												 WHERE opReal.Id = @id+1 AND conta.ativo=1);

								SET @agencia2 = (SELECT opReal.agencia 
													FROM OperacoesRealizadas  AS opReal WITH(NOLOCK)
														INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia =  ag.agencia
												 WHERE opReal.Id = @id+1 AND ag.ativo=1);

								SET @banco2Id = dbo.RetornaIdBanco(@agencia);
								SET @saldoAnterior2 = dbo.RetornaSaldo(@conta2Id);

								--estorna conta1
								INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, 
											agencia,bancoId,dataOP,saldoAnterior,valorOp)
									VALUES(@opId, @clienteId ,@contaId, @agencia, @bancoId,
											GETDATE(),@saldoAnterior, @valorOp);
								
								--estorna conta 2
								INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId,
											dataOP, saldoAnterior, valorOp)
									VALUES(@opId, @cliente2Id, @conta2Id, @agencia2, @banco2Id, GETDATE(), 
											@saldoAnterior2, @valorUltOp);
							END
							ELSE
								BEGIN
									INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia ,bancoId, 
												dataOP, saldoAnterior, valorOp)
										VALUES(@opId, @clienteId, @contaId, @agencia, @bancoId, GETDATE(), @saldoAnterior, 
												@valorOp);
								END
						END	

						ELSE
							BEGIN 
								SET @op=dbo.RetornaIdProxOpRealizada(@id);
								IF(@op=4)
									BEGIN
										SET @cliente2Id = (SELECT opReal.clienteId 
																FROM OperacoesRealizadas AS opReal WITH(NOLOCK) 
																	INNER JOIN  Clientes as cli WITH(NOLOCK) on opReal.clienteId=cli.Id
															WHERE opReal.Id = @id-1 AND cli.ativo=1);

										SET @conta2Id = (SELECT opReal.contaId 
															FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
																INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId= conta.Id
														 WHERE opReal.Id = @id-1 AND conta.ativo=1);

										SET @agencia2 = (SELECT opReal.agencia 
															FROM OperacoesRealizadas  AS opReal WITH(NOLOCK)
																INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia =  ag.agencia
														 WHERE opReal.Id = @id-1 AND ag.ativo=1);

										SET @banco2Id = dbo.RetornaIdBanco(@agencia);
										SET @saldoAnterior2 = dbo.RetornaSaldo(@conta2Id);

										--estorna conta1
										INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId, 
													dataOP, saldoAnterior, valorOp)
											VALUES(@opId, @clienteId, @contaId, @agencia, @bancoId, GETDATE(), @saldoAnterior, 
													@valorOp);
								
										--estorna conta 2
										INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId, 
														dataOP, saldoAnterior, valorOp)
											VALUES(@opId, @cliente2Id, @conta2Id, @agencia2, @banco2Id, GETDATE(), 
											@saldoAnterior2, @valorUltOp);
									END
									ELSE
										BEGIN
											INSERT INTO OperacoesRealizadas(codTipoOp, clienteId, contaId, agencia, bancoId, 
															dataOP,saldoAnterior,valorOp)
												VALUES(@opId, @clienteId, @contaId, @agencia, @bancoId, GETDATE(), 
															@saldoAnterior, @valorOp);
										END
							END
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_SELDADOSCONTACLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_SELDADOSCONTACLIENTE]
GO

CREATE PROCEDURE [dbo].[PBSP_SELDADOSCONTACLIENTE]
	@contaId VARCHAR(20)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna dados da conta cliente com os clientes pertecentes a conta 
	Autor.............: SMN - Douglas
 	Data..............: 01/01/2017
	Ex................: EXEC [dbo].[PBSP_SELDADOSCONTACLIENTE]

	*/

	BEGIN
		SELECT	c.num,
				c.senha,
				c.ativo,
				a.agencia,
				cli.nome 
			FROM Conta AS c WITH(NOLOCK)
				INNER JOIN ContaCliente AS cc WITH(NOLOCK)
					ON c.Id = cc.contaId
				INNER JOIN Agencia AS a WITH(NOLOCK)
					ON cc.agencia = a.agencia
				INNER JOIN Clientes AS cli
					ON cc.clienteId = cli.Id
			WHERE c.Id = @contaId
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETCLIENTEBYCPF]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETCLIENTEBYCPF]
GO

CREATE PROCEDURE [dbo].[PBSP_GETCLIENTEBYCPF]
		@cpf VARCHAR(20)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Obtem o cliente pelo cpf
	Autor.............: SMN - Douglas
 	Data..............: 17/10/2017
	Ex................: EXEC [dbo].[PBSP_GETCLIENTEBYCPF]

	*/

	BEGIN
	
		SELECT	cli.Id,
				cli.nome 
				FROM Clientes AS cli WITH(NOLOCK)
		WHERE cli.cpf = @cpf 
			AND cli.ativo=1
	END
GO
				

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_UPDATECONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_UPDATECONTA]
GO

CREATE PROCEDURE [dbo].[PBSP_UPDATECONTA]
		@conta VARCHAR(20),
		@senha VARCHAR(20),
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Atualizar uma conta
	Autor.............: SMN - Douglas
 	Data..............: 18/10/2017
	Ex................: EXEC [dbo].[PBSP_UPDATECONTA]

	*/

	BEGIN
		UPDATE Conta 
			SET senha=@senha,
				ativo=@ativo
			WHERE Conta.num = @conta;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETAGENCIABYNUM]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETAGENCIABYNUM]
GO

CREATE PROCEDURE [dbo].[PBSP_GETAGENCIABYNUM]
		@agencia INT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Obtem agencia pelo numero
	Autor.............: SMN - Douglas
 	Data..............: 18/10/2017
	Ex................: EXEC [dbo].[PBSP_GETAGENCIABYNUM]

	*/

	BEGIN
		SELECT ag.agencia, 
			   banco.nome,
			   ag.ativo 
			   FROM Agencia	AS ag WITH(NOLOCK)
					INNER JOIN Banco AS banco WITH(NOLOCK) ON ag.bancoId = banco.Id
		WHERE ag.agencia=@agencia;
	END
GO
														

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_UPDATEAGENCIA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_UPDATEAGENCIA]
GO

CREATE PROCEDURE [dbo].[PBSP_UPDATEAGENCIA]
		@agencia INT,
		@ativo BIT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Altera agencia
	Autor.............: SMN - Douglas
 	Data..............: 18/10/2017
	Ex................: EXEC [dbo].[PBSP_UPDATEAGENCIA]

	*/

	BEGIN
		UPDATE Agencia 
			SET ativo = @ativo
		WHERE agencia = @agencia;
	END
GO
			
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETOPREALIZADAESTORNOBYID]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETOPREALIZADAESTORNOBYID]
GO

CREATE PROCEDURE [dbo].[PBSP_GETOPREALIZADAESTORNOBYID]
		@Id INT
	AS
	
	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retona a operação requisitada para estorno 
	Autor.............: SMN - Douglas
 	Data..............: 26	/10/2017
	Ex................: EXEC [dbo].[PBSP_GETOPREALIZADAESTORNOBYID]

	*/

	BEGIN
		SELECT opReal.Id,
			   opReal.codTipoOp, 
			   opReal.dataOP,
			   opReal.valorOp,
			   opReal.saldoAnterior, 
			   op.descricao, 
			   ag.agencia,
			   conta.num , cli.nome
			   FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
					INNER JOIN Operacoes AS op WITH(NOLOCK) on opReal.codTipoOp = op.Id
					INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia = ag.agencia
					INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId = conta.Id
					INNER JOIN Clientes AS cli WITH(NOLOCK) ON opReal.clienteId = cli.Id
		WHERE opReal.Id = @Id
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_EXTRATOPORDATA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_EXTRATOPORDATA]
GO

CREATE PROCEDURE [dbo].[PBSP_EXTRATOPORDATA]
	@conta VARCHAR(8),
	@senha VARCHAR(8),
	@dataInicial DATETIME,
	@dataFinal DATETIME
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Recupera dados para geração do relatoriuo por data
	Autor.............: SMN - Douglas
 	Data..............: 10/11/2017
	Ex................: EXEC [dbo].[PBSP_EXTRATOPORDATA]

	*/

	BEGIN
			DECLARE @saldo DECIMAL(18,2),
					@contaId SMALLINT
			SET @contaId = (SELECT Id FROM Conta WITH(NOLOCK)
								WHERE Conta.num=@conta
			)
			SET @saldo = dbo.RetornaSaldo(@contaId)
			SELECT opReal.Id,
				   @saldo AS SALDO,
				   opReal.codTipoOp, 
				   opReal.dataOP,
				   opReal.valorOp,
				   opReal.saldoAnterior, 
				   op.descricao, 
				   ag.agencia,
				   conta.num , cli.nome
				   FROM OperacoesRealizadas AS opReal WITH(NOLOCK)
					INNER JOIN Operacoes AS op WITH(NOLOCK) on opReal.codTipoOp = op.Id
					INNER JOIN Agencia AS ag WITH(NOLOCK) ON opReal.agencia = ag.agencia
					INNER JOIN Conta AS conta WITH(NOLOCK) ON opReal.contaId = conta.Id
					INNER JOIN Clientes AS cli WITH(NOLOCK) ON opReal.clienteId = cli.Id
			WHERE conta.num=@conta AND conta.senha=@senha
				AND conta.ativo=1 AND ag.ativo=1 AND cli.ativo=1 AND opReal.dataOp BETWEEN @dataInicial AND @dataFinal
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLCONTAS]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETALLCONTAS]
GO

CREATE PROCEDURE [dbo].[PBSP_GETALLCONTAS]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna todas as contas bem como seus donos 
	Autor.............: SMN - Douglas
 	Data..............: 13/11/2017
	Ex................: EXEC [dbo].[PBSP_GETALLCONTAS]

	*/
	BEGIN
		SELECT 	cli.nome,
				cli.Id AS clienteId,
				contaCli.clienteId AS Id,
				contaCli.contaId,
				conta.num, 
				conta.senha, 
				ag.agencia
			FROM ContaCliente AS contaCli WITH(NOLOCK)	
				INNER JOIN Clientes AS cli WITH(NOLOCK) ON contaCli.clienteId = cli.Id
				INNER JOIN Conta AS conta WITH(NOLOCK) ON contaCli.contaId = conta.Id
				INNER JOIN Agencia AS ag WITH(NOLOCK)	ON ag.agencia = contaCli.agencia
	END
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLCLIENTESCONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETALLCLIENTESCONTA]
GO

CREATE PROCEDURE [dbo].[PBSP_GETALLCLIENTESCONTA]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna todos os clientes da conta 
	Autor.............: SMN - Douglas
 	Data..............: 14/11/2017
	Ex................: EXEC [dbo].[PBSP_GETALLCLIENTESCONTA]

	*/

	BEGIN
		SELECT Cli.nome,
			   Cli.Id,
			   contaCli.contaId AS contaCliId
			FROM ContaCliente as contaCli WITH(NOLOCK) 
				INNER JOIN Clientes AS Cli WITH(NOLOCK) ON contaCli.clienteId = Cli.Id	
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLDADOSECLIENTESDACONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETALLDADOSECLIENTESDACONTA]
GO

CREATE PROCEDURE [dbo].[PBSP_GETALLDADOSECLIENTESDACONTA]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Retorna dados conta e clientes da mesma
	Autor.............: SMN - Douglas
 	Data..............: 14/11/2017
	Ex................: EXEC [dbo].[PBSP_GETALLDADOSECLIENTESDACONTA]

	*/

	BEGIN
		SELECT DISTINCT	cliente.nomesClientes AS nome,
				contaCli.contaId,
				conta.num, 
				conta.senha, 
				ag.agencia
			FROM ContaCliente AS contaCli WITH(NOLOCK)	
				INNER JOIN Clientes AS cli WITH(NOLOCK) 
					ON contaCli.clienteId = cli.Id
				INNER JOIN Conta AS conta WITH(NOLOCK) 
					ON contaCli.contaId = conta.Id
				INNER JOIN Agencia AS ag WITH(NOLOCK)	
					ON ag.agencia = contaCli.agencia	
				CROSS APPLY(
						SELECT STUFF(( --Busca todas os nomes dos clientes vinculados as contas
							SELECT  ', ' + nome
								FROM ContaCliente AS cc WITH(NOLOCK)	
									INNER JOIN Clientes AS c WITH(NOLOCK) 
										ON c.Id = cc.clienteId
								WHERE cc.contaId = contaCli.contaId
						  FOR XML PATH('') ), 1, 1, '') AS nomesClientes
				)cliente		
	END
GO
---Procedure estorna refatorado e ainda nao executado testar

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_ESTORNOREFATORADO]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_ESTORNO]
GO

CREATE PROCEDURE [dbo].[PBSP_ESTORNO]
	@opReal SMALLINT,
	@clienteId SMALLINT,
	@agencia INT
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Douglas
 	Data..............: 01/01/2017
	Ex................: EXEC [dbo].[PBSP_ESTORNO]

	*/

	BEGIN
		DECLARE @codTipoOp SMALLINT,
				@idConta SMALLINT,
				@valorOp DECIMAL(18,2), 
				@bancoId SMALLINT, 
				@saldoAnterior DECIMAL(18,2)

		SET @codTipoOp = (SELECT opRealizadas.codTipoOp
								FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
						  WHERE opRealizadas.Id = @opReal)
		SET @valorOp = (SELECT opRealizadas.valorOp
								FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
						  WHERE opRealizadas.Id = @opReal)
		SET @idConta = (SELECT opRealizadas.contaId
								FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
						  WHERE opRealizadas.Id = @opReal)
		SET @bancoId = (SELECT opRealizadas.bancoId
							FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
						WHERE opRealizadas.Id = @opReal)
		SET @saldoAnterior = dbo.RetornaSaldo(@idConta)

		IF(@codTipoOp = 4)
			BEGIN
				INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
					VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	

				SET @codTipoOp = (SELECT opRealizadas.codTipoOp
								FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
						  WHERE opRealizadas.Id = @opReal)
				SET @valorOp = (SELECT opRealizadas.valorOp
										FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
								  WHERE opRealizadas.Id = @opReal - 1)
				SET @idConta = (SELECT opRealizadas.contaId
										FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
								  WHERE opRealizadas.Id = @opReal - 1)
				SET @bancoId = (SELECT opRealizadas.bancoId
									FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
								WHERE opRealizadas.Id = @opReal - 1)
				SET @saldoAnterior = dbo.RetornaSaldo(@idConta)

				INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
					VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	
			END
		ELSE IF(@codTipoOp = 2)
			BEGIN
				IF((SELECT opRealizadas.codTipoOp 
						FROM OperacoesRealizadas AS opRealizadas
					WHERE opRealizadas.Id=@opReal)=4)
					BEGIN
						INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
							VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	

						SET @codTipoOp = (SELECT opRealizadas.codTipoOp
										FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
								  WHERE opRealizadas.Id = @opReal)
						SET @valorOp = (SELECT opRealizadas.valorOp
												FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
										  WHERE opRealizadas.Id = @opReal + 1)
						SET @idConta = (SELECT opRealizadas.contaId
												FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
										  WHERE opRealizadas.Id = @opReal + 1)
						SET @bancoId = (SELECT opRealizadas.bancoId
											FROM OperacoesRealizadas AS opRealizadas WITH(NOLOCK)
										WHERE opRealizadas.Id = @opReal + 1)
						SET @saldoAnterior = dbo.RetornaSaldo(@idConta)

						INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
							VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	

					END
				ELSE
					BEGIN
						INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
							VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	
					END

		END
		ELSE
			BEGIN
				INSERT INTO OperacoesRealizadas(agencia , bancoId, clienteId, codTipoOp, contaId, dataOp, SaldoAnterior, valorOp)
							VALUES(@agencia, @bancoId, @clienteId, 5, @idConta, GETDATE(), @saldoAnterior, @valorOp * (-1))	
			END
	END
GO
				
					
																									
--Funções
--função que retorna o Saldo
CREATE FUNCTION dbo.RetornaSaldo(@contaId SMALLINT)
	RETURNS DECIMAL(18,2)
	BEGIN
		DECLARE @saldo Decimal(18,2);
		SET @saldo = (SELECT SUM(OperacoesRealizadas.valorOp) 
							FROM OperacoesRealizadas WITH(NOLOCK)
								INNER JOIN Conta WITH(NOLOCK) ON Conta.ID = OperacoesRealizadas.contaId
					  WHERE Conta.Id = @contaId );
		IF(@saldo IS NULL)
			BEGIN
				SET @saldo=0
			END
		RETURN @saldo
	END	
GO
	--função que retorna id do banco em função da agencia
CREATE FUNCTION dbo.RetornaIdBanco(@agencia INT)
	RETURNS SMALLINT
	BEGIN
		RETURN (SELECT Banco.Id 
					FROM Banco WITH(NOLOCK)
						INNER JOIN Agencia WITH(NOLOCK) ON Banco.Id = Agencia.bancoId
				WHERE Agencia.agencia = @agencia);

	END	
GO
--Retorna id do cliente da conta 
CREATE FUNCTION dbo.RetornaIdClienteConta(@contaId SMALLINT)
	RETURNS SMALLINT
	BEGIN
		RETURN (SELECT TOP(1) Clientes.Id 
					FROM Clientes WITH(NOLOCK)
						INNER JOIN ContaCliente WITH(NOLOCK) ON Clientes.Id = ContaCliente.clienteId
						INNER JOIN Conta WITH(NOLOCK) ON ContaCliente.contaId = Conta.Id
				WHERE Conta.Id = @contaId
				ORDER BY Clientes.nome);

	END	
GO

--função que retorna o valor da ultima operação realizada
CREATE FUNCTION dbo.RetornaValorUltOp(@idOpReal SMALLINT)
	RETURNS DECIMAL(18,2)
	BEGIN
		DECLARE @valorOp Decimal(18,2);
		SET @valorOp = (SELECT valorOp 
							FROM OperacoesRealizadas WITH(NOLOCK)
						WHERE Id=@idOpReal );
		IF(@valorOp IS NULL)
			BEGIN
				SET @valorOp=0
			END
		RETURN @valorOp;
	END
GO
CREATE FUNCTION dbo.RetornaIdProxOpRealizada(@idOpReal SMALLINT)
	RETURNS SMALLINT
	BEGIN
		DECLARE @opProxOpReal SMALLINT;
		SET @opProxOpReal = (SELECT codTipoOp 
								FROM OperacoesRealizadas WITH(NOLOCK)
							 WHERE Id=@idOpReal+1);
		IF(@opProxOpReal IS NULL)
			BEGIN
				SET @opProxOpReal=(SELECT codTipoOp 
										FROM OperacoesRealizadas WITH(NOLOCK)
								   WHERE Id=@idOpReal)
			END
		RETURN @opProxOpReal;
	END
GO
--Retorna o id da agencia da conta vinculada
CREATE FUNCTION dbo.RetornaAgenciaDaConta(@contaId SMALLINT)
	RETURNS SMALLINT
	BEGIN
		RETURN (SELECT TOP(1) Agencia.agencia 
					FROM Agencia WITH(NOLOCK)
						INNER JOIN ContaCliente WITH(NOLOCK) ON Agencia.agencia = ContaCliente.agencia
						INNER JOIN Conta WITH(NOLOCK) on ContaCliente.contaId = Conta.id
				WHERE Conta.Id = @contaId);
	END
GO