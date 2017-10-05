
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTCLIENTE]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTCLIENTE] 
	@cidadeId[INT],
	@nome[VARCHAR](200),
	@cpf[VARCHAR](20),
	@rg[VARCHAR](20),
	@fone[VARCHAR](20),
	@rua[VARCHAR](100),
	@bairro[VARCHAR](200),
	@num[INT],
	@dataCadastro[DATETIME],
	@nivel[CHAR](1),
	@ativo[BIT]
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
	
		INSERT INTO Clientes(CidadeId,nome,cpf,rg,bairro,rua,num,dataCadastro,fone,nivel,ativo)
			VALUES(@cidadeId,@nome,@cpf,@rg,@bairro,@rua,@num,@dataCadastro,@fone,@nivel,@ativo)

	END
GO
--Busca todos os clientes Ativos

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_GETALLCLIENTES]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_GETALLCLIENTES]
GO

CREATE PROCEDURE [dbo].[PBSP_GETALLCLIENTES]

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
	
		SELECT Id,nome,cpf,rg,fone,rua,bairro,num,nivel,dataCadastro FROM [dbo].[Clientes]WITH(NOLOCK)
			WHERE [dbo].[Clientes].ativo=1;

	END
GO
				
--insert banco

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTBANCO]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTBANCO]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTBANCO]
	@nome[VARCHAR](200),
	@ativo[BIT]
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
			VALUES(@nome,@ativo)
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
	
		SELECT * FROM Banco
			WHERE Banco.ativo=1;

	END
GO
				

--insert usuários

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTUSUARIOS]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTUSUARIOS]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTUSUARIOS]
	@clienteId[SMALLINT], 
	@nome[VARCHAR](20),
	@senha[VARCHAR](20)
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
	
		INSERT INTO [dbo].[Usuario]
			VALUES(@clienteId, @nome, @senha)

	END
GO

--verifica se tem o usuario do acesso cadastrado

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_AUTENTICA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_AUTENTICA]
GO

CREATE PROCEDURE [dbo].[PBSP_AUTENTICA]
	@nome[VARCHAR](20),
	@senha[VARCHAR](8)
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
	
		SELECT Usuario.clienteId,Usuario.nome,Usuario.senha, Clientes.nivel FROM [dbo].[Usuario] with(nolock)
			INNER JOIN Clientes ON Clientes.Id = Usuario.clienteId
			WHERE [dbo].[Usuario].nome=@nome and [dbo].[Usuario].senha=@senha

	END
GO
--insere Operacaoes		

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTOPERACAO]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTOPERACAO]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTOPERACAO]
	@descricao[VARCHAR](200)
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
	
		INSERT INTO [dbo].[Operacoes](descricao)
			VALUES(@descricao)

	END
GO
--Insere Agencia

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTAGENCIA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTAGENCIA]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTAGENCIA]
	@cidadeId[INT],
	@bancoId[SMALLINT],
	@agencia[INT]
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
	
		INSERT INTO [dbo].[Agencia](CidadeId,bancoId,agencia)
			VALUES(@cidadeId,@bancoId,@agencia)

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
	
		SELECT 	agencia,bancoId,CidadeId FROM[dbo].[Agencia] WITH(NOLOCK)

	END
GO

--insert conta 

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCONTA]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTCONTA]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTCONTA]
	@num[VARCHAR](20),
	@senha[VARCHAR](20),
	@tipo[VARCHAR](100)
	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Insere conta
	Autor.............: SMN - Douglas
 	Data..............: 05/10/2017
	Ex................: EXEC [dbo].[PBSP_INSERTCONTA]

	*/
	BEGIN
		DECLARE @contaId INT=0;
		INSERT INTO [dbo].[Conta](num,tipo,senha)
			VALUES(@num,@tipo,@senha);
			RETURN SCOPE_IDENTITY();
	END
GO

--insere na contacliente

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[PBSP_INSERTCONTACLIENTE]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[PBSP_INSERTCONTACLIENTE]
GO

CREATE PROCEDURE [dbo].[PBSP_INSERTCONTACLIENTE]
	@contaId[SMALLINT],
	@agencia[SMALLINT],
	@clienteId[SMALLINT]
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
		SET @bancoId = (SELECT Id FROM [dbo].[Banco] WITH(NOLOCK)
			INNER JOIN [dbo].[Agencia] WITH(NOLOCK) ON Banco.Id = Agencia.bancoId
			WHERE Agencia.agencia = @agencia);

		INSERT INTO[dbo].[ContaCliente](contaId,agencia,bancoId,clienteId)
			VALUES(@contaId,@agencia,@bancoId,@clienteId);		

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
	
		SELECT Id,nome,cpf,rg,fone,rua,bairro,num,nivel,dataCadastro FROM [dbo].[Clientes]WITH(NOLOCK)
			WHERE Clientes.ativo=1 AND Clientes.Id=@id;

	END
GO
				