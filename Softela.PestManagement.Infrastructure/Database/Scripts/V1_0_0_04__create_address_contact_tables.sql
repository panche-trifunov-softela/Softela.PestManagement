-- Address and Contact Tables Migration
-- Core supporting tables for accounts and sites

-- Addresses
CREATE TABLE Addresses (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    CompanyName NVARCHAR(100),
    StreetNumber NVARCHAR(50),
    PreDirection NVARCHAR(50),
    StreetName NVARCHAR(50),
    StreetSuffix NVARCHAR(50),
    PostDirection NVARCHAR(50),
    SecondaryAddress NVARCHAR(50),
    City NVARCHAR(50),
    State NVARCHAR(50),
    PostalCode NVARCHAR(15),
    PostalCodeEx NVARCHAR(100),
    CountryId INT NOT NULL,
    LocaleId INT NOT NULL,
    SuffixId INT NOT NULL,
    Latitude DECIMAL(18,15),
    Longitude DECIMAL(18,15),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Addresses_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);
GO

-- Contacts
CREATE TABLE Contacts (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    FirstName NVARCHAR(50),
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50),
    Suffix NVARCHAR(10),
    Title NVARCHAR(50),
    Department NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    PhoneExt NVARCHAR(10),
    Mobile NVARCHAR(20),
    Fax NVARCHAR(20),
    Notes NVARCHAR(MAX),
    IsActive BIT NOT NULL DEFAULT 1,
    IsPrimary BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL
);
GO
