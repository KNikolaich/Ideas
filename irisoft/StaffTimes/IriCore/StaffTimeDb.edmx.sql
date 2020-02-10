
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2020 12:55:01
-- Generated from EDMX file: e:\git\Ideas\irisoft\StaffTimes\Core\StaffTimeDb.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsArchive] bit  NULL
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

-- Creating table 'PropertySet'
CREATE TABLE [dbo].[PropertySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Key] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActiveProjectOnStaffSet'
CREATE TABLE [dbo].[ActiveProjectOnStaffSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ProjectId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'PropertySet'
ALTER TABLE [dbo].[PropertySet]
ADD CONSTRAINT [PK_PropertySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActiveProjectOnStaffSet'
ALTER TABLE [dbo].[ActiveProjectOnStaffSet]
ADD CONSTRAINT [PK_ActiveProjectOnStaffSet]
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

-- Creating foreign key on [UserId] in table 'ActiveProjectOnStaffSet'
ALTER TABLE [dbo].[ActiveProjectOnStaffSet]
ADD CONSTRAINT [FK_ActiveProjectOnStaffUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActiveProjectOnStaffUser'
CREATE INDEX [IX_FK_ActiveProjectOnStaffUser]
ON [dbo].[ActiveProjectOnStaffSet]
    ([UserId]);
GO

-- Creating foreign key on [ProjectId] in table 'ActiveProjectOnStaffSet'
ALTER TABLE [dbo].[ActiveProjectOnStaffSet]
ADD CONSTRAINT [FK_ProjectActiveProjectOnStaff]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActiveProjectOnStaff'
CREATE INDEX [IX_FK_ProjectActiveProjectOnStaff]
ON [dbo].[ActiveProjectOnStaffSet]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------