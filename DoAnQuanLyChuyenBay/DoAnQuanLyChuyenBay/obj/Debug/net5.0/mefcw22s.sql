BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DatCho]') AND [c].[name] = N'MaChoID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [DatCho] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [DatCho] DROP COLUMN [MaChoID];
GO

ALTER TABLE [GheGiuCho] ADD [DatChoId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221022142553_ChangeGheGiuChoQLCB', N'5.0.1');
GO

COMMIT;
GO

