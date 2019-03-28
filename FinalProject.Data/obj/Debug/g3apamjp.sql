IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'movie') IS NULL EXEC(N'CREATE SCHEMA [movie];');

GO

CREATE TABLE [movie].[titles] (
    [titleId] varchar(12) NOT NULL,
    [titleType] nvarchar(20) NULL,
    [primaryTitle] nvarchar(1000) NULL,
    [originalTitle] nvarchar(1000) NULL,
    [isAdult] bit NULL,
    [startYear] smallint NULL,
    [endYear] smallint NULL,
    [runtimeMinutes] int NULL,
    [genres] nvarchar(50) NULL,
    CONSTRAINT [PK_titles] PRIMARY KEY ([titleId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190324182512_initial', N'2.2.3-servicing-35854');

GO

