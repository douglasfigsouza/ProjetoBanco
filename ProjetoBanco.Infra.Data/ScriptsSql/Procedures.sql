
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
				