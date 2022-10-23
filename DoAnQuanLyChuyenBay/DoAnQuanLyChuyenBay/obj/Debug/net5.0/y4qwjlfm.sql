BEGIN TRANSACTION;
GO

EXEC sp_rename N'[User].[PassWord]', N'Password', N'COLUMN';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'SoDienThoai');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [User] ALTER COLUMN [SoDienThoai] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [FirstName] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [LastName] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220925062644_changeTableUser', N'5.0.1');
GO

COMMIT;
GO

