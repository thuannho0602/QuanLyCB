BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DatCho]') AND [c].[name] = N'MaCho');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [DatCho] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [DatCho] DROP COLUMN [MaCho];
GO

ALTER TABLE [DatCho] ADD [MaChoID] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [GheGiuCho] (
    [Id] int NOT NULL IDENTITY,
    [MaCho] nvarchar(max) NULL,
    CONSTRAINT [PK_GheGiuCho] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221022141459_AddGheGiuChoQLCB', N'5.0.1');
GO

COMMIT;
GO

