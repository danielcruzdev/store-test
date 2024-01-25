CREATE DATABASE Store_Stefanini;
GO

USE Store_Stefanini;
GO 

DROP TABLE IF EXISTS ItensPedido;
DROP TABLE IF EXISTS Pedido;
DROP TABLE IF EXISTS Produto;

CREATE TABLE Produto (
    Id          INT IDENTITY(1,1) NOT NULL,
    NomeProduto VARCHAR(20)       NOT NULL,
    Valor       DECIMAL(10,2)     NOT NULL

    CONSTRAINT PK_Produto PRIMARY KEY CLUSTERED (Id ASC)
);

GO

CREATE TABLE Pedido (
    Id           INT IDENTITY(1,1) NOT NULL,
    NomeCliente  VARCHAR(60)       NOT NULL,
    EmailCliente VARCHAR(60)       NOT NULL,
    DataCriacao  DATETIME          NOT NULL DEFAULT GETDATE(),
    Pago         BIT               NOT NULL DEFAULT 0

    CONSTRAINT PK_Pedido PRIMARY KEY CLUSTERED (Id ASC)
);

GO

CREATE TABLE ItensPedido (
    Id         INT IDENTITY(1,1) NOT NULL,
    IdPedido   INT               NOT NULL,
    IdProduto  INT               NOT NULL,
    Quantidade INT               NOT NULL

    CONSTRAINT PK_ItensPedido PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_ItensPedido_IdPedido FOREIGN KEY (IdPedido) REFERENCES Pedido(Id),
    CONSTRAINT FK_ItensPedido_IdProduto FOREIGN KEY (IdProduto) REFERENCES Produto(Id)
);