-- dotnet ef migrations script 0 FirstMigration -s ../DevFreela.API -o ./Scripts/FirstMigration.sql

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Skills] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProvidedServices] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [IdClient] int NOT NULL,
    [IdFreelancer] int NOT NULL,
    [TotalCost] decimal(18,2) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [StartedAt] datetime2 NULL,
    [FinishedAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_ProvidedServices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProvidedServices_Users_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProvidedServices_Users_IdFreelancer] FOREIGN KEY ([IdFreelancer]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [UsersSkills] (
    [Id] int NOT NULL IDENTITY,
    [IdUser] int NOT NULL,
    [IdSkill] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_UsersSkills] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UsersSkills_Skills_IdSkill] FOREIGN KEY ([IdSkill]) REFERENCES [Skills] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UsersSkills_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ProvidedServices_IdClient] ON [ProvidedServices] ([IdClient]);

GO

CREATE INDEX [IX_ProvidedServices_IdFreelancer] ON [ProvidedServices] ([IdFreelancer]);

GO

CREATE INDEX [IX_UsersSkills_IdSkill] ON [UsersSkills] ([IdSkill]);

GO

CREATE INDEX [IX_UsersSkills_IdUser] ON [UsersSkills] ([IdUser]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210516000624_FirstMigration', N'3.1.15');

GO

