
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2020 12:21:51
-- Generated from EDMX file: E:\git\Ideas\irisoft\StaffTimes\Core\Model\StaffTimes.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StaffTimes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTasks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_UserTasks];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Task];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(75)  NOT NULL,
    [Login] nvarchar(75)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] int  NOT NULL
);
GO

-- Creating table 'Task'
CREATE TABLE [dbo].[Task] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Duration] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [ProjectId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Task'
ALTER TABLE [dbo].[Task]
ADD CONSTRAINT [PK_Task]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectId] in table 'Task'
ALTER TABLE [dbo].[Task]
ADD CONSTRAINT [FK_ProjectTask]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTask'
CREATE INDEX [IX_FK_ProjectTask]
ON [dbo].[Task]
    ([ProjectId]);
GO

-- Creating foreign key on [UserId] in table 'Task'
ALTER TABLE [dbo].[Task]
ADD CONSTRAINT [FK_UserTasks]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTasks'
CREATE INDEX [IX_FK_UserTasks]
ON [dbo].[Task]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------