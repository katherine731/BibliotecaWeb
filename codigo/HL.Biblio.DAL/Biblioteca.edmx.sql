
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/18/2013 10:37:55
-- Generated from EDMX file: D:\Users\H\Desktop\DoplomadoKatherine\SlnBiblio\HL.Biblio.DAL\Biblioteca.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbBiblio1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PaisEditorial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Editoriales] DROP CONSTRAINT [FK_PaisEditorial];
GO
IF OBJECT_ID(N'[dbo].[FK_PaisAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autores] DROP CONSTRAINT [FK_PaisAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_AutorLibro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Libros] DROP CONSTRAINT [FK_AutorLibro];
GO
IF OBJECT_ID(N'[dbo].[FK_EditorialLibro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Libros] DROP CONSTRAINT [FK_EditorialLibro];
GO
IF OBJECT_ID(N'[dbo].[FK_EjemplarLibro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ejemplares] DROP CONSTRAINT [FK_EjemplarLibro];
GO
IF OBJECT_ID(N'[dbo].[FK_ClasificacionLibro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Libros] DROP CONSTRAINT [FK_ClasificacionLibro];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Libros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Libros];
GO
IF OBJECT_ID(N'[dbo].[Autores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autores];
GO
IF OBJECT_ID(N'[dbo].[Editoriales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editoriales];
GO
IF OBJECT_ID(N'[dbo].[Ejemplares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ejemplares];
GO
IF OBJECT_ID(N'[dbo].[Paises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paises];
GO
IF OBJECT_ID(N'[dbo].[Clasificaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clasificaciones];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Libros'
CREATE TABLE [dbo].[Libros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(100)  NOT NULL,
    [ISBN] nvarchar(50)  NOT NULL,
    [Titulo] nvarchar(200)  NOT NULL,
    [Resumen] nvarchar(max)  NOT NULL,
    [Edicion] nvarchar(100)  NOT NULL,
    [FechaPublicacion] datetime  NULL,
    [Idioma] nvarchar(100)  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL,
    [Imagen] varbinary(max)  NULL,
    [Tipo] int  NOT NULL,
    [Estado] int  NOT NULL,
    [Autor_Id] int  NULL,
    [Editorial_Id] int  NULL,
    [Clasificacion_Id] int  NULL
);
GO

-- Creating table 'Autores'
CREATE TABLE [dbo].[Autores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(100)  NOT NULL,
    [Apellidos] nvarchar(100)  NOT NULL,
    [Estado] int  NOT NULL,
    [Pais_Id] int  NULL
);
GO

-- Creating table 'Editoriales'
CREATE TABLE [dbo].[Editoriales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NOT NULL,
    [Estado] int  NOT NULL,
    [Pais_Id] int  NULL
);
GO

-- Creating table 'Ejemplares'
CREATE TABLE [dbo].[Ejemplares] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(100)  NOT NULL,
    [CodRFID] nvarchar(100)  NOT NULL,
    [CodBarras] nvarchar(50)  NOT NULL,
    [TipoPrestamo] int  NOT NULL,
    [Ubicacion] nvarchar(100)  NOT NULL,
    [Estado] int  NOT NULL,
    [Libro_Id] int  NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [dbo].[Paises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NOT NULL,
    [Gentilicio] nvarchar(100)  NOT NULL,
    [Estado] int  NOT NULL
);
GO

-- Creating table 'Clasificaciones'
CREATE TABLE [dbo].[Clasificaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(100)  NOT NULL,
    [Abreviatura] nvarchar(20)  NOT NULL,
    [Descripcion] nvarchar(200)  NOT NULL,
    [Estado] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Libros'
ALTER TABLE [dbo].[Libros]
ADD CONSTRAINT [PK_Libros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [PK_Autores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Editoriales'
ALTER TABLE [dbo].[Editoriales]
ADD CONSTRAINT [PK_Editoriales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ejemplares'
ALTER TABLE [dbo].[Ejemplares]
ADD CONSTRAINT [PK_Ejemplares]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Paises'
ALTER TABLE [dbo].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clasificaciones'
ALTER TABLE [dbo].[Clasificaciones]
ADD CONSTRAINT [PK_Clasificaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Pais_Id] in table 'Editoriales'
ALTER TABLE [dbo].[Editoriales]
ADD CONSTRAINT [FK_PaisEditorial]
    FOREIGN KEY ([Pais_Id])
    REFERENCES [dbo].[Paises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaisEditorial'
CREATE INDEX [IX_FK_PaisEditorial]
ON [dbo].[Editoriales]
    ([Pais_Id]);
GO

-- Creating foreign key on [Pais_Id] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [FK_PaisAutor]
    FOREIGN KEY ([Pais_Id])
    REFERENCES [dbo].[Paises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaisAutor'
CREATE INDEX [IX_FK_PaisAutor]
ON [dbo].[Autores]
    ([Pais_Id]);
GO

-- Creating foreign key on [Autor_Id] in table 'Libros'
ALTER TABLE [dbo].[Libros]
ADD CONSTRAINT [FK_AutorLibro]
    FOREIGN KEY ([Autor_Id])
    REFERENCES [dbo].[Autores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AutorLibro'
CREATE INDEX [IX_FK_AutorLibro]
ON [dbo].[Libros]
    ([Autor_Id]);
GO

-- Creating foreign key on [Editorial_Id] in table 'Libros'
ALTER TABLE [dbo].[Libros]
ADD CONSTRAINT [FK_EditorialLibro]
    FOREIGN KEY ([Editorial_Id])
    REFERENCES [dbo].[Editoriales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EditorialLibro'
CREATE INDEX [IX_FK_EditorialLibro]
ON [dbo].[Libros]
    ([Editorial_Id]);
GO

-- Creating foreign key on [Libro_Id] in table 'Ejemplares'
ALTER TABLE [dbo].[Ejemplares]
ADD CONSTRAINT [FK_EjemplarLibro]
    FOREIGN KEY ([Libro_Id])
    REFERENCES [dbo].[Libros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EjemplarLibro'
CREATE INDEX [IX_FK_EjemplarLibro]
ON [dbo].[Ejemplares]
    ([Libro_Id]);
GO

-- Creating foreign key on [Clasificacion_Id] in table 'Libros'
ALTER TABLE [dbo].[Libros]
ADD CONSTRAINT [FK_ClasificacionLibro]
    FOREIGN KEY ([Clasificacion_Id])
    REFERENCES [dbo].[Clasificaciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClasificacionLibro'
CREATE INDEX [IX_FK_ClasificacionLibro]
ON [dbo].[Libros]
    ([Clasificacion_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------