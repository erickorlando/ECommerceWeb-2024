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

CREATE TABLE [Categoria] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Comentarios] nvarchar(100) NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Marca] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_Marca] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoCliente] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(100) NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_TipoCliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Producto] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Descripcion] nvarchar(100) NOT NULL,
    [PrecioUnitario] real NOT NULL,
    [UrlImagen] nvarchar(100) NULL,
    [CategoriaId] int NOT NULL,
    [MarcaId] int NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Producto_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Producto_Marca_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marca] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nombres] nvarchar(100) NOT NULL,
    [Apellidos] nvarchar(100) NOT NULL,
    [Email] varchar(200) NOT NULL,
    [FechaNacimiento] DATE NOT NULL,
    [TipoClienteId] int NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_TipoCliente_TipoClienteId] FOREIGN KEY ([TipoClienteId]) REFERENCES [TipoCliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Venta] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [Total] real NOT NULL,
    [FechaTransaccion] DATETIME NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_Venta] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Venta_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [VentaDetalle] (
    [Id] int NOT NULL IDENTITY,
    [VentaId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [Precio] real NOT NULL,
    [Cantidad] int NOT NULL,
    [Total] real NOT NULL,
    [Estado] bit NOT NULL,
    CONSTRAINT [PK_VentaDetalle] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_VentaDetalle_Producto_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Producto] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_VentaDetalle_Venta_VentaId] FOREIGN KEY ([VentaId]) REFERENCES [Venta] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comentarios', N'Estado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Categoria]'))
    SET IDENTITY_INSERT [Categoria] ON;
INSERT INTO [Categoria] ([Id], [Comentarios], [Estado], [Nombre])
VALUES (1, NULL, CAST(1 AS bit), N'Celulares'),
(2, NULL, CAST(1 AS bit), N'Televisores'),
(3, NULL, CAST(1 AS bit), N'Computadoras');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comentarios', N'Estado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Categoria]'))
    SET IDENTITY_INSERT [Categoria] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Marca]'))
    SET IDENTITY_INSERT [Marca] ON;
INSERT INTO [Marca] ([Id], [Estado], [Nombre])
VALUES (1, CAST(1 AS bit), N'Samsung'),
(2, CAST(1 AS bit), N'Apple'),
(3, CAST(1 AS bit), N'Xiaomi'),
(4, CAST(1 AS bit), N'LG'),
(5, CAST(1 AS bit), N'Sony'),
(6, CAST(1 AS bit), N'Honor'),
(7, CAST(1 AS bit), N'Oppo');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estado', N'Nombre') AND [object_id] = OBJECT_ID(N'[Marca]'))
    SET IDENTITY_INSERT [Marca] OFF;
GO

CREATE INDEX [IX_Cliente_TipoClienteId] ON [Cliente] ([TipoClienteId]);
GO

CREATE INDEX [IX_Producto_CategoriaId] ON [Producto] ([CategoriaId]);
GO

CREATE INDEX [IX_Producto_MarcaId] ON [Producto] ([MarcaId]);
GO

CREATE INDEX [IX_Venta_ClienteId] ON [Venta] ([ClienteId]);
GO

CREATE INDEX [IX_VentaDetalle_ProductoId] ON [VentaDetalle] ([ProductoId]);
GO

CREATE INDEX [IX_VentaDetalle_VentaId] ON [VentaDetalle] ([VentaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417005615_PrimeraMigracion', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(100) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(100) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(100) NOT NULL,
    [NombreCompleto] nvarchar(100) NOT NULL,
    [FechaNacimiento] DATE NOT NULL,
    [Direccion] nvarchar(100) NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(100) NULL,
    [SecurityStamp] nvarchar(100) NULL,
    [ConcurrencyStamp] nvarchar(100) NULL,
    [PhoneNumber] nvarchar(100) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(100) NOT NULL,
    [ClaimType] nvarchar(100) NULL,
    [ClaimValue] nvarchar(100) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(100) NOT NULL,
    [ClaimType] nvarchar(100) NULL,
    [ClaimValue] nvarchar(100) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(100) NOT NULL,
    [ProviderKey] nvarchar(100) NOT NULL,
    [ProviderDisplayName] nvarchar(100) NULL,
    [UserId] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(100) NOT NULL,
    [RoleId] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(100) NOT NULL,
    [LoginProvider] nvarchar(100) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Value] nvarchar(100) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417015910_TablasSeguridad', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Estado') AND [object_id] = OBJECT_ID(N'[TipoCliente]'))
    SET IDENTITY_INSERT [TipoCliente] ON;
INSERT INTO [TipoCliente] ([Id], [Descripcion], [Estado])
VALUES (1, N'Cliente Normal', CAST(1 AS bit)),
(2, N'Cliente Especial', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'Estado') AND [object_id] = OBJECT_ID(N'[TipoCliente]'))
    SET IDENTITY_INSERT [TipoCliente] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417022722_TiposDeCliente', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE PROCEDURE uspDashboard
                    AS
                    BEGIN
	                    
	                    SELECT
		                    SUM(V.Total) AS TotalVenta,
		                    COUNT(V.ID) AS CantidadVentas,
		                    (SELECT COUNT(C.ID) FROM Cliente C (NOLOCK) WHERE C.Estado = 1) CantidadClientes,
		                    (SELECT COUNT(P.ID) FROM Producto P (NOLOCK) WHERE P.Estado = 1) CantidadProductos
	                    FROM VENTA V (NOLOCK)
	                    WHERE V.Estado = 1

                    END
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240424015023_SpDashboard', N'8.0.4');
GO

COMMIT;
GO

