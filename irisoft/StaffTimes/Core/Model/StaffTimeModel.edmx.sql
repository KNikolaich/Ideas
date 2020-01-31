
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/31/2020 15:35:50
-- Generated from EDMX file: E:\git\Ideas\irisoft\StaffTimes\Core\Model\StaffTimeModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_WeekUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Week] DROP CONSTRAINT [FK_WeekUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskWeek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_TaskWeek];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_ProjectProjectType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_ProjectTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Week]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Week];
GO
IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Task];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[ProjectType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(75)  NOT NULL,
    [Login] nvarchar(75)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] int  NOT NULL
);
GO

-- Creating table 'Week'
CREATE TABLE [dbo].[Week] (
    [UserId] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [EditStarted] datetime  NOT NULL,
    [EditEnded] datetime  NULL,
    [Approved] bit  NOT NULL,
    [WeekNumber] int  NOT NULL,
    [Year] smallint  NOT NULL
);
GO

-- Creating table 'Task'
CREATE TABLE [dbo].[Task] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Duration] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [WeekId] int  NOT NULL,
    [ProjectId] int  NOT NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectTypeId] int  NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProjectType_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectType'
CREATE TABLE [dbo].[ProjectType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Week'
ALTER TABLE [dbo].[Week]
ADD CONSTRAINT [PK_Week]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Task'
ALTER TABLE [dbo].[Task]
ADD CONSTRAINT [PK_Task]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectType'
ALTER TABLE [dbo].[ProjectType]
ADD CONSTRAINT [PK_ProjectType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Week'
ALTER TABLE [dbo].[Week]
ADD CONSTRAINT [FK_WeekUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WeekUser'
CREATE INDEX [IX_FK_WeekUser]
ON [dbo].[Week]
    ([UserId]);
GO

-- Creating foreign key on [WeekId] in table 'Task'
ALTER TABLE [dbo].[Task]
ADD CONSTRAINT [FK_TaskWeek]
    FOREIGN KEY ([WeekId])
    REFERENCES [dbo].[Week]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskWeek'
CREATE INDEX [IX_FK_TaskWeek]
ON [dbo].[Task]
    ([WeekId]);
GO

-- Creating foreign key on [ProjectType_Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_ProjectProjectType]
    FOREIGN KEY ([ProjectType_Id])
    REFERENCES [dbo].[ProjectType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectType'
CREATE INDEX [IX_FK_ProjectProjectType]
ON [dbo].[Project]
    ([ProjectType_Id]);
GO

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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------