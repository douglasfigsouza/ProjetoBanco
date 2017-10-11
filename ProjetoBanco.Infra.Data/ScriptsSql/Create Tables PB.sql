CREATE TABLE [Estado](
	[EstadoId] [tinyint]  NOT NULL PRIMARY KEY,
	[Sigla] [char](2) NOT NULL,
)
CREATE TABLE [Cidade]
(
	[CidadeId] [SMALLINT] NOT NULL PRIMARY KEY,
	[Nome] [varchar](38) NOT NULL,
	[EstadoId] [tinyint] NULL,
	[Capital] [bit] NOT NULL,	CONSTRAINT FK_ESTADOID FOREIGN KEY (EstadoId)
	REFERENCES Estado
)
CREATE TABLE [Conta]
(
	Id [SMALLINT] NOT NULL PRIMARY KEY IDENTITY,
	num [VARCHAR](15) NOT NULL UNIQUE,
	senha [VARCHAR](6) NOT NULL,
	tipo [CHAR](1) NOT NULL, 
	ativo [BIT]
)
CREATE TABLE Banco
(
	Id [SMALLINT] NOT NULL PRIMARY KEY IDENTITY, 
	nome [VARCHAR](100),
	ativo[BIT]
)
CREATE TABLE [Clientes]
(
	Id [SMALLINT] NOT NULL PRIMARY KEY IDENTITY,
	cidadeId [SMALLINT] NOT NULL,
	nome [VARCHAR](200) NOT NULL, 
	cpf [VARCHAR](20)NOT NULL UNIQUE, 
	rg [VARCHAR](20)NOT NULL UNIQUE,
	fone [VARCHAR](20) NOT NULL,
	rua [VARCHAR](200) NOT NULL,
	bairro [VARCHAR](200) NOT NULL,
	num [INT],
	dataCadastro [DATETIME],
	nivel [CHAR](1),
	ativo [BIT],
	CONSTRAINT FK_Cidade_Clientes FOREIGN KEY(CidadeId) REFERENCES Cidade,
)
CREATE TABLE [USUARIO]
(
	clienteId[SMALLINT] NOT NULL,
	nome[VARCHAR](20) NOT NULL UNIQUE, 
	senha[VARCHAR](8) NOT NULL,
	ativo BIT,
	CONSTRAINT FK_ClienteUsuario FOREIGN KEY(clienteId) REFERENCES Clientes
)
CREATE TABLE Agencia
(
	agencia [SMALLINT] NOT NULL,
	bancoId [SMALLINT] NOT NULL ,
	cidadeId [SMALLINT] NOT NULL,
	ativo BIT,
	CONSTRAINT PK_AGENCIA PRIMARY KEY(agencia, bancoId),
	CONSTRAINT FK_Cidade_Agencia FOREIGN KEY(CidadeId) REFERENCES Cidade,
	CONSTRAINT FK_Banco_Agencia foreign key (bancoId) REFERENCES Banco
)
GO
CREATE TABLE ContaCliente
(
	clienteId[SMALLINT] NOT NULL, 
	contaId[SMALLINT] NOT NULL,
	agenciaId[SMALLINT] NOT NULL,
	bancoId[SMALLINT] NOT NULL,
	CONSTRAINT FK_Cliente_ContaCliente FOREIGN KEY(clienteId) REFERENCES Clientes,
	CONSTRAINT FK_Conta_ContaCliente FOREIGN KEY(contaId)REFERENCES Conta,
	CONSTRAINT FK_Agencia_ContaCliente FOREIGN KEY(agenciaId,bancoId) REFERENCES Agencia,
)
GO
CREATE TABLE Operacoes
(
	Id[SMALLINT] NOT NULL PRIMARY KEY IDENTITY, 
	descricao[VARCHAR](100) NOT NULL, 
	ativo BIT
)
GO
CREATE TABLE OperacoesRealizadas
(
	operacaoId[SMALLINT] NOT NULL,
	clienteId[SMALLINT] NOT NULL, 
	agenciaId[SMALLINT] NOT NULL,
	bancoId[SMALLINT] NOT NULL,
	contaId[SMALLINT] NOT NULL,
	dataOp[DATETIME] NOT NULL,
	SaldoAnterior DECIMAL NOT NULL,
	valorOp DECIMAL NOT NULL
	CONSTRAINT FK_Opercoes_OpRealizadas FOREIGN KEY(operacaoId) REFERENCES Operacoes,
	CONSTRAINT FK_Clientes_OpRealizadas FOREIGN KEY(clienteId) REFERENCES Clientes,
	CONSTRAINT FK_Agencia_OpRealizadas FOREIGN KEY(agenciaId,bancoId) REFERENCES Agencia,
	CONSTRAINT FK_Conta_OpRealizadas FOREIGN KEY(contaId) REFERENCES Operacoes
);
