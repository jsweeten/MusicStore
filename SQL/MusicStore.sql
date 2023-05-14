CREATE TABLE [Guitar] (
  [Id] int PRIMARY KEY,
  [Name] varchar(100) NOT NULL,
  [BrandId] int NOT NULL,
  [GuitarTypeId] int NOT NULL,
  [CategoryId] int NOT NULL,
  [Strings] int NOT NULL,
  [NumFrets] int NOT NULL,
  [Price] float NOT NULL,
  [ImagePath] nvarchar(255) NOT NULL,
  [Used] bit
)
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(255) NOT NULL,
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [UserTypeId] int NOT NULL
)
GO

CREATE TABLE [UserType] (
  [Id] int PRIMARY KEY,
  [Name] varchar(20) NOT NULL
)
GO

CREATE TABLE [Brand] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(100) NOT NULL,
  [Logo] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Category] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(25) NOT NULL
)
GO

CREATE TABLE [GuitarType] (
  [Id] int PRIMARY KEY,
  [Name] varchar(50) NOT NULL
)
GO

ALTER TABLE [Guitar] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [Guitar] ADD FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
GO

ALTER TABLE [Guitar] ADD FOREIGN KEY ([GuitarTypeId]) REFERENCES [GuitarType] ([Id])
GO
