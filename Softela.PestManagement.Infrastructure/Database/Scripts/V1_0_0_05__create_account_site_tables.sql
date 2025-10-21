-- Account and Site Tables Migration
-- Main customer account and service location tables

-- AccountEntities (renamed from Accounts to avoid conflict with existing table)
CREATE TABLE AccountEntities (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    AccountNum NVARCHAR(50) NOT NULL,
    AccountType INT NOT NULL,
    BillingAddressId INT,
    BillingContactId INT,
    BillingCenterId INT NOT NULL,
    LocaleId INT NOT NULL,

    -- Communication preferences
    SendInvoice BIT NOT NULL DEFAULT 0,
    EmailInvoice BIT NOT NULL DEFAULT 0,
    SendStatement BIT NOT NULL DEFAULT 0,
    EmailStatement BIT NOT NULL DEFAULT 0,
    SendRenewal BIT NOT NULL DEFAULT 0,
    EmailRenewal BIT NOT NULL DEFAULT 0,
    MarketingEmail BIT NOT NULL DEFAULT 0,
    NotificationsMail BIT NOT NULL DEFAULT 0,

    -- Notes and instructions
    Instructions NVARCHAR(900),
    PrimaryNote NVARCHAR(200),
    SecondaryNote NVARCHAR(200),

    -- Status and hierarchy
    IsActive SMALLINT NOT NULL DEFAULT 1,
    MasterAccountId INT,
    MasterAccountSubId INT,
    RegistrationNum NVARCHAR(15),

    -- Business info
    DiscountTypeId INT,
    AccountManagerId INT,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_AccountEntities_BillingAddress FOREIGN KEY (BillingAddressId) REFERENCES Addresses(Id),
    CONSTRAINT FK_AccountEntities_BillingContact FOREIGN KEY (BillingContactId) REFERENCES Contacts(Id)
);
GO

-- SiteEntities (renamed from Sites to avoid conflict with existing table)
CREATE TABLE SiteEntities (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    AddressId INT,
    PrimaryContactId INT,
    PropertyType INT NOT NULL,
    Notes NVARCHAR(MAX),
    Latitude DECIMAL(18,15),
    Longitude DECIMAL(18,15),
    Instructions NVARCHAR(900),
    TaxTypeId INT,
    SalespersonId INT,
    SiteReferenceNumber NVARCHAR(50),
    SendCompletedWoMethod SMALLINT NOT NULL DEFAULT 0,
    SendCompletedWoTo SMALLINT NOT NULL DEFAULT 0,
    Facility INT NOT NULL DEFAULT 0,
    FacilityType INT NOT NULL DEFAULT 0,
    SiteManagerId INT,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_SiteEntities_Address FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
    CONSTRAINT FK_SiteEntities_PrimaryContact FOREIGN KEY (PrimaryContactId) REFERENCES Contacts(Id),
    CONSTRAINT FK_SiteEntities_SiteManager FOREIGN KEY (SiteManagerId) REFERENCES Contacts(Id),
    CONSTRAINT FK_SiteEntities_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id)
);
GO

-- AccountSites (Junction table for many-to-many relationship)
CREATE TABLE AccountSites (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_AccountSites_Account FOREIGN KEY (AccountId) REFERENCES AccountEntities(Id),
    CONSTRAINT FK_AccountSites_Site FOREIGN KEY (SiteId) REFERENCES SiteEntities(Id),
    CONSTRAINT UQ_AccountSites_AccountId_SiteId UNIQUE (AccountId, SiteId)
);
GO
