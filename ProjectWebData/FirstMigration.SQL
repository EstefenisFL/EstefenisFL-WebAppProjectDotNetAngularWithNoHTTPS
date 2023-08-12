IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(80) NOT NULL,
    [PhoneNumber] CHAR(11) NULL,
    [CEP] CHAR(8) NOT NULL,
    [State] VARCHAR(80) NOT NULL,
    [City] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [BarCode] VARCHAR(14) NOT NULL,
    [Description] VARCHAR(60) NULL,
    [Value] decimal(18,2) NOT NULL,
    [ProductType] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [Started] datetime2 NOT NULL DEFAULT (GETDATE()),
    [Finished] datetime2 NOT NULL,
    [FreightType] int NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Note] VARCHAR(512) NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedidos_Clientes_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PedidoItens] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL DEFAULT 1,
    [Value] decimal(18,2) NOT NULL,
    [Discount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PedidoItens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidoItens_Pedidos_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidoItens_Produtos_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [idx_cliente_telefone] ON [Clientes] ([PhoneNumber]);
GO

CREATE INDEX [IX_PedidoItens_OrderId] ON [PedidoItens] ([OrderId]);
GO

CREATE INDEX [IX_PedidoItens_ProductId] ON [PedidoItens] ([ProductId]);
GO

CREATE INDEX [IX_Pedidos_ClientId] ON [Pedidos] ([ClientId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230727215504_FirstMigration', N'7.0.0');
GO

COMMIT;
GO

