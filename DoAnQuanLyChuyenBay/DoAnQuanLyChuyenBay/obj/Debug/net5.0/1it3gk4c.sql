BEGIN TRANSACTION;
GO

ALTER TABLE [User] ADD [DiaChi] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [User] ADD [HovaTen] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [NgaySinh] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [PassWord] nvarchar(max) NULL;
GO

ALTER TABLE [User] ADD [SoDienThoai] int NULL;
GO

CREATE TABLE [ChuyenBay] (
    [MaChuyenBay] nvarchar(450) NOT NULL,
    [SanBayDi] nvarchar(max) NULL,
    [SanBayDen] nvarchar(max) NULL,
    [GioiDi] datetime2 NOT NULL,
    [GioiDen] datetime2 NOT NULL,
    CONSTRAINT [PK_ChuyenBay] PRIMARY KEY ([MaChuyenBay])
);
GO

CREATE TABLE [KhachHang] (
    [MaKhachHang] nvarchar(450) NOT NULL,
    [HoTenKH] nvarchar(max) NULL,
    [NgaySinh] datetime2 NOT NULL,
    [DiaChi] nvarchar(max) NULL,
    [GioiTinh] bit NOT NULL,
    [SoDienThoai] int NOT NULL,
    [NguoiTao] nvarchar(max) NULL,
    [NgayTao] datetime2 NOT NULL,
    [NguoiCapNhat] nvarchar(max) NULL,
    [NgayCapNhat] datetime2 NOT NULL,
    [UserId] nvarchar(450) NULL,
    CONSTRAINT [PK_KhachHang] PRIMARY KEY ([MaKhachHang]),
    CONSTRAINT [FK_KhachHang_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [LoaiMayBay] (
    [MaLoai] nvarchar(450) NOT NULL,
    [HangSanXuat] nvarchar(max) NULL,
    CONSTRAINT [PK_LoaiMayBay] PRIMARY KEY ([MaLoai])
);
GO

CREATE TABLE [MayBay] (
    [SoHieu] nvarchar(450) NOT NULL,
    [TenMayBay] nvarchar(max) NULL,
    [MaLoai] nvarchar(max) NULL,
    [LoaiMayBayMaLoai] nvarchar(450) NULL,
    CONSTRAINT [PK_MayBay] PRIMARY KEY ([SoHieu]),
    CONSTRAINT [FK_MayBay_LoaiMayBay_LoaiMayBayMaLoai] FOREIGN KEY ([LoaiMayBayMaLoai]) REFERENCES [LoaiMayBay] ([MaLoai]) ON DELETE NO ACTION
);
GO

CREATE TABLE [LichBay] (
    [MaLichBay] int NOT NULL IDENTITY,
    [NgayDi] datetime2 NOT NULL,
    [NgayDen] datetime2 NOT NULL,
    [MaChuyenBay] nvarchar(max) NULL,
    [SoHieu] nvarchar(max) NULL,
    [MayBaySoHieu] nvarchar(450) NULL,
    [ChuyenBayMaChuyenBay] nvarchar(450) NULL,
    CONSTRAINT [PK_LichBay] PRIMARY KEY ([MaLichBay]),
    CONSTRAINT [FK_LichBay_ChuyenBay_ChuyenBayMaChuyenBay] FOREIGN KEY ([ChuyenBayMaChuyenBay]) REFERENCES [ChuyenBay] ([MaChuyenBay]) ON DELETE NO ACTION,
    CONSTRAINT [FK_LichBay_MayBay_MayBaySoHieu] FOREIGN KEY ([MayBaySoHieu]) REFERENCES [MayBay] ([SoHieu]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DatCho] (
    [Cho] int NOT NULL IDENTITY,
    [SoGhe] nvarchar(max) NULL,
    [MaLichBay] int NULL,
    [LichBayMaLichBay] int NULL,
    [MaKhachHang] nvarchar(max) NULL,
    [KhachHangMaKhachHang] nvarchar(450) NULL,
    CONSTRAINT [PK_DatCho] PRIMARY KEY ([Cho]),
    CONSTRAINT [FK_DatCho_KhachHang_KhachHangMaKhachHang] FOREIGN KEY ([KhachHangMaKhachHang]) REFERENCES [KhachHang] ([MaKhachHang]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DatCho_LichBay_LichBayMaLichBay] FOREIGN KEY ([LichBayMaLichBay]) REFERENCES [LichBay] ([MaLichBay]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_DatCho_KhachHangMaKhachHang] ON [DatCho] ([KhachHangMaKhachHang]);
GO

CREATE INDEX [IX_DatCho_LichBayMaLichBay] ON [DatCho] ([LichBayMaLichBay]);
GO

CREATE INDEX [IX_KhachHang_UserId] ON [KhachHang] ([UserId]);
GO

CREATE INDEX [IX_LichBay_ChuyenBayMaChuyenBay] ON [LichBay] ([ChuyenBayMaChuyenBay]);
GO

CREATE INDEX [IX_LichBay_MayBaySoHieu] ON [LichBay] ([MayBaySoHieu]);
GO

CREATE INDEX [IX_MayBay_LoaiMayBayMaLoai] ON [MayBay] ([LoaiMayBayMaLoai]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220924045513_AddTableAll', N'5.0.1');
GO

COMMIT;
GO

