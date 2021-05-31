
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2021 19:38:33
-- Generated from EDMX file: D:\BP\Repository\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BP2DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientDealsWith]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DealsWiths] DROP CONSTRAINT [FK_ClientDealsWith];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyDealsWith]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DealsWiths] DROP CONSTRAINT [FK_CompanyDealsWith];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_CompanyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ContractProject];
GO
IF OBJECT_ID(N'[dbo].[FK_DealsWithContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_DealsWithContract];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ManagerProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignments] DROP CONSTRAINT [FK_TaskAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignments] DROP CONSTRAINT [FK_TeamAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamTeamProficiency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamProficiencies] DROP CONSTRAINT [FK_TeamTeamProficiency];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamDeveloper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Developer] DROP CONSTRAINT [FK_TeamDeveloper];
GO
IF OBJECT_ID(N'[dbo].[FK_ProficiencyTeamProficiency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamProficiencies] DROP CONSTRAINT [FK_ProficiencyTeamProficiency];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyAsset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assets] DROP CONSTRAINT [FK_CompanyAsset];
GO
IF OBJECT_ID(N'[dbo].[FK_SupplierAsset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assets] DROP CONSTRAINT [FK_SupplierAsset];
GO
IF OBJECT_ID(N'[dbo].[FK_Manager_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Manager] DROP CONSTRAINT [FK_Manager_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Developer_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Developer] DROP CONSTRAINT [FK_Developer_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Supplier_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Supplier] DROP CONSTRAINT [FK_Supplier_inherits_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[DealsWiths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DealsWiths];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[Assignments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assignments];
GO
IF OBJECT_ID(N'[dbo].[Proficiencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proficiencies];
GO
IF OBJECT_ID(N'[dbo].[TeamProficiencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamProficiencies];
GO
IF OBJECT_ID(N'[dbo].[Assets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assets];
GO
IF OBJECT_ID(N'[dbo].[Employees_Manager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Manager];
GO
IF OBJECT_ID(N'[dbo].[Employees_Developer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Developer];
GO
IF OBJECT_ID(N'[dbo].[Employees_Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Supplier];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DealsWiths'
CREATE TABLE [dbo].[DealsWiths] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [CompanyId] int  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [DateSigned] datetime  NOT NULL,
    [DealsWithId] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ContractId] int  NULL,
    [ManagerId] int  NULL,
    [ManagerCompanyId] int  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ProjectId] int  NOT NULL,
    [TaskId] int  NULL,
    [TaskProjectId] int  NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Assignments'
CREATE TABLE [dbo].[Assignments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TaskId] int  NOT NULL,
    [TaskProjectId] int  NOT NULL,
    [TeamId] int  NOT NULL
);
GO

-- Creating table 'Proficiencies'
CREATE TABLE [dbo].[Proficiencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TeamProficiencies'
CREATE TABLE [dbo].[TeamProficiencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeamId] int  NOT NULL,
    [ProficiencyId] int  NOT NULL
);
GO

-- Creating table 'Assets'
CREATE TABLE [dbo].[Assets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SupplierId] int  NULL,
    [SupplierCompanyId] int  NULL
);
GO

-- Creating table 'Employees_Manager'
CREATE TABLE [dbo].[Employees_Manager] (
    [Id] int  NOT NULL,
    [CompanyId] int  NOT NULL
);
GO

-- Creating table 'Employees_Developer'
CREATE TABLE [dbo].[Employees_Developer] (
    [TeamId] int  NULL,
    [Id] int  NOT NULL,
    [CompanyId] int  NOT NULL
);
GO

-- Creating table 'Employees_Supplier'
CREATE TABLE [dbo].[Employees_Supplier] (
    [Id] int  NOT NULL,
    [CompanyId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DealsWiths'
ALTER TABLE [dbo].[DealsWiths]
ADD CONSTRAINT [PK_DealsWiths]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [CompanyId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id], [CompanyId] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [ProjectId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([Id], [ProjectId] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [PK_Assignments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proficiencies'
ALTER TABLE [dbo].[Proficiencies]
ADD CONSTRAINT [PK_Proficiencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamProficiencies'
ALTER TABLE [dbo].[TeamProficiencies]
ADD CONSTRAINT [PK_TeamProficiencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [CompanyId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [PK_Assets]
    PRIMARY KEY CLUSTERED ([Id], [CompanyId] ASC);
GO

-- Creating primary key on [Id], [CompanyId] in table 'Employees_Manager'
ALTER TABLE [dbo].[Employees_Manager]
ADD CONSTRAINT [PK_Employees_Manager]
    PRIMARY KEY CLUSTERED ([Id], [CompanyId] ASC);
GO

-- Creating primary key on [Id], [CompanyId] in table 'Employees_Developer'
ALTER TABLE [dbo].[Employees_Developer]
ADD CONSTRAINT [PK_Employees_Developer]
    PRIMARY KEY CLUSTERED ([Id], [CompanyId] ASC);
GO

-- Creating primary key on [Id], [CompanyId] in table 'Employees_Supplier'
ALTER TABLE [dbo].[Employees_Supplier]
ADD CONSTRAINT [PK_Employees_Supplier]
    PRIMARY KEY CLUSTERED ([Id], [CompanyId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'DealsWiths'
ALTER TABLE [dbo].[DealsWiths]
ADD CONSTRAINT [FK_ClientDealsWith]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientDealsWith'
CREATE INDEX [IX_FK_ClientDealsWith]
ON [dbo].[DealsWiths]
    ([ClientId]);
GO

-- Creating foreign key on [CompanyId] in table 'DealsWiths'
ALTER TABLE [dbo].[DealsWiths]
ADD CONSTRAINT [FK_CompanyDealsWith]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyDealsWith'
CREATE INDEX [IX_FK_CompanyDealsWith]
ON [dbo].[DealsWiths]
    ([CompanyId]);
GO

-- Creating foreign key on [CompanyId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_CompanyEmployee]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyEmployee'
CREATE INDEX [IX_FK_CompanyEmployee]
ON [dbo].[Employees]
    ([CompanyId]);
GO

-- Creating foreign key on [ContractId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ContractProject]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractProject'
CREATE INDEX [IX_FK_ContractProject]
ON [dbo].[Projects]
    ([ContractId]);
GO

-- Creating foreign key on [DealsWithId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_DealsWithContract]
    FOREIGN KEY ([DealsWithId])
    REFERENCES [dbo].[DealsWiths]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DealsWithContract'
CREATE INDEX [IX_FK_DealsWithContract]
ON [dbo].[Contracts]
    ([DealsWithId]);
GO

-- Creating foreign key on [ManagerId], [ManagerCompanyId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ManagerProject]
    FOREIGN KEY ([ManagerId], [ManagerCompanyId])
    REFERENCES [dbo].[Employees_Manager]
        ([Id], [CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerProject'
CREATE INDEX [IX_FK_ManagerProject]
ON [dbo].[Projects]
    ([ManagerId], [ManagerCompanyId]);
GO

-- Creating foreign key on [ProjectId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_ProjectTask]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTask'
CREATE INDEX [IX_FK_ProjectTask]
ON [dbo].[Tasks]
    ([ProjectId]);
GO

-- Creating foreign key on [TaskId], [TaskProjectId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskTask]
    FOREIGN KEY ([TaskId], [TaskProjectId])
    REFERENCES [dbo].[Tasks]
        ([Id], [ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTask'
CREATE INDEX [IX_FK_TaskTask]
ON [dbo].[Tasks]
    ([TaskId], [TaskProjectId]);
GO

-- Creating foreign key on [TaskId], [TaskProjectId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_TaskAssignment]
    FOREIGN KEY ([TaskId], [TaskProjectId])
    REFERENCES [dbo].[Tasks]
        ([Id], [ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskAssignment'
CREATE INDEX [IX_FK_TaskAssignment]
ON [dbo].[Assignments]
    ([TaskId], [TaskProjectId]);
GO

-- Creating foreign key on [TeamId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_TeamAssignment]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamAssignment'
CREATE INDEX [IX_FK_TeamAssignment]
ON [dbo].[Assignments]
    ([TeamId]);
GO

-- Creating foreign key on [TeamId] in table 'TeamProficiencies'
ALTER TABLE [dbo].[TeamProficiencies]
ADD CONSTRAINT [FK_TeamTeamProficiency]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamProficiency'
CREATE INDEX [IX_FK_TeamTeamProficiency]
ON [dbo].[TeamProficiencies]
    ([TeamId]);
GO

-- Creating foreign key on [TeamId] in table 'Employees_Developer'
ALTER TABLE [dbo].[Employees_Developer]
ADD CONSTRAINT [FK_TeamDeveloper]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamDeveloper'
CREATE INDEX [IX_FK_TeamDeveloper]
ON [dbo].[Employees_Developer]
    ([TeamId]);
GO

-- Creating foreign key on [ProficiencyId] in table 'TeamProficiencies'
ALTER TABLE [dbo].[TeamProficiencies]
ADD CONSTRAINT [FK_ProficiencyTeamProficiency]
    FOREIGN KEY ([ProficiencyId])
    REFERENCES [dbo].[Proficiencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProficiencyTeamProficiency'
CREATE INDEX [IX_FK_ProficiencyTeamProficiency]
ON [dbo].[TeamProficiencies]
    ([ProficiencyId]);
GO

-- Creating foreign key on [CompanyId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [FK_CompanyAsset]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyAsset'
CREATE INDEX [IX_FK_CompanyAsset]
ON [dbo].[Assets]
    ([CompanyId]);
GO

-- Creating foreign key on [SupplierId], [SupplierCompanyId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [FK_SupplierAsset]
    FOREIGN KEY ([SupplierId], [SupplierCompanyId])
    REFERENCES [dbo].[Employees_Supplier]
        ([Id], [CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SupplierAsset'
CREATE INDEX [IX_FK_SupplierAsset]
ON [dbo].[Assets]
    ([SupplierId], [SupplierCompanyId]);
GO

-- Creating foreign key on [Id], [CompanyId] in table 'Employees_Manager'
ALTER TABLE [dbo].[Employees_Manager]
ADD CONSTRAINT [FK_Manager_inherits_Employee]
    FOREIGN KEY ([Id], [CompanyId])
    REFERENCES [dbo].[Employees]
        ([Id], [CompanyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id], [CompanyId] in table 'Employees_Developer'
ALTER TABLE [dbo].[Employees_Developer]
ADD CONSTRAINT [FK_Developer_inherits_Employee]
    FOREIGN KEY ([Id], [CompanyId])
    REFERENCES [dbo].[Employees]
        ([Id], [CompanyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id], [CompanyId] in table 'Employees_Supplier'
ALTER TABLE [dbo].[Employees_Supplier]
ADD CONSTRAINT [FK_Supplier_inherits_Employee]
    FOREIGN KEY ([Id], [CompanyId])
    REFERENCES [dbo].[Employees]
        ([Id], [CompanyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------