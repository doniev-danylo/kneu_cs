
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2023 12:45:14
-- Generated from EDMX file: C:\Users\onion\source\repos\Lr5Ex2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDatabase2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MyTableSet'
CREATE TABLE [dbo].[MyTableSet] (
    [Table_id] int IDENTITY(1,1) NOT NULL,
    [Some_info] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MyTable2Set'
CREATE TABLE [dbo].[MyTable2Set] (
    [Table_id] int IDENTITY(1,1) NOT NULL,
    [Some_add_info] nvarchar(max)  NOT NULL,
    [MyTable_Table_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Table_id] in table 'MyTableSet'
ALTER TABLE [dbo].[MyTableSet]
ADD CONSTRAINT [PK_MyTableSet]
    PRIMARY KEY CLUSTERED ([Table_id] ASC);
GO

-- Creating primary key on [Table_id] in table 'MyTable2Set'
ALTER TABLE [dbo].[MyTable2Set]
ADD CONSTRAINT [PK_MyTable2Set]
    PRIMARY KEY CLUSTERED ([Table_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MyTable_Table_id] in table 'MyTable2Set'
ALTER TABLE [dbo].[MyTable2Set]
ADD CONSTRAINT [FK_MyTableMyTable2]
    FOREIGN KEY ([MyTable_Table_id])
    REFERENCES [dbo].[MyTableSet]
        ([Table_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MyTableMyTable2'
CREATE INDEX [IX_FK_MyTableMyTable2]
ON [dbo].[MyTable2Set]
    ([MyTable_Table_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------