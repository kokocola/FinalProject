use IMDb;
GO
sp_rename 'movie.titlebasics', 'titles';
GO
sp_rename 'movie.titles.tconst', 'titleId', 'COLUMN';
GO
ALTER TABLE movie.titles ALTER COLUMN titleId varchar(12) NOT NULL;
GO
ALTER TABLE movie.titles ADD CONSTRAINT PK_titleId PRIMARY KEY(titleId);
GO
ALTER SCHEMA dbo TRANSFER movie.titles;  
GO
ALTER TABLE dbo.titles ALTER COLUMN primaryTitle nvarchar(850); -- max unclustered index size = 1700 bytes, unicode chars = 2 bytes
ALTER TABLE dbo.titles ALTER COLUMN originalTitle nvarchar(850); -- uniformity
CREATE INDEX IX_titles ON dbo.titles(primaryTitle);
CREATE TABLE [__EFMigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    [ProductVersion] nvarchar(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId]));