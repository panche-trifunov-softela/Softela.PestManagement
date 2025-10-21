-- Account and Site Tables Enhancement Migration
-- Adds additional columns to existing Accounts and Sites tables

-- Drop existing foreign key constraint on Sites table
ALTER TABLE Sites DROP CONSTRAINT FK_Sites_Accounts;
GO

-- Enhance Accounts table with additional columns
ALTER TABLE Accounts ADD CompanyId INT NOT NULL DEFAULT 1;
ALTER TABLE Accounts ADD AccountNum NVARCHAR(50) NOT NULL DEFAULT '';
ALTER TABLE Accounts ADD AccountType INT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD BillingAddressId INT NULL;
ALTER TABLE Accounts ADD BillingContactId INT NULL;
ALTER TABLE Accounts ADD BillingCenterId INT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD LocaleId INT NOT NULL DEFAULT 0;

-- Communication preferences
ALTER TABLE Accounts ADD SendInvoice BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailInvoice BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD SendStatement BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailStatement BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD SendRenewal BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailRenewal BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD MarketingEmail BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD NotificationsMail BIT NOT NULL DEFAULT 0;

-- Notes and instructions
ALTER TABLE Accounts ADD Instructions NVARCHAR(900) NULL;
ALTER TABLE Accounts ADD PrimaryNote NVARCHAR(200) NULL;
ALTER TABLE Accounts ADD SecondaryNote NVARCHAR(200) NULL;

-- Status and hierarchy (IsActive already exists but is BIT, need to change to SMALLINT)
ALTER TABLE Accounts DROP COLUMN IsActive;
ALTER TABLE Accounts ADD IsActive SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Accounts ADD MasterAccountId INT NULL;
ALTER TABLE Accounts ADD MasterAccountSubId INT NULL;
ALTER TABLE Accounts ADD RegistrationNum NVARCHAR(15) NULL;

-- Business info
ALTER TABLE Accounts ADD DiscountTypeId INT NULL;
ALTER TABLE Accounts ADD AccountManagerId INT NULL;

-- Add foreign key constraints
ALTER TABLE Accounts ADD CONSTRAINT FK_Accounts_BillingAddress FOREIGN KEY (BillingAddressId) REFERENCES Addresses(Id);
ALTER TABLE Accounts ADD CONSTRAINT FK_Accounts_BillingContact FOREIGN KEY (BillingContactId) REFERENCES Contacts(Id);
GO

-- Enhance Sites table with additional columns
-- Remove AccountId column (will use junction table instead)
ALTER TABLE Sites DROP COLUMN AccountId;

ALTER TABLE Sites ADD AddressId INT NULL;
ALTER TABLE Sites ADD PrimaryContactId INT NULL;
ALTER TABLE Sites ADD PropertyType INT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD Notes NVARCHAR(MAX) NULL;
ALTER TABLE Sites ADD Latitude DECIMAL(18,15) NULL;
ALTER TABLE Sites ADD Longitude DECIMAL(18,15) NULL;
ALTER TABLE Sites ADD Instructions NVARCHAR(900) NULL;
ALTER TABLE Sites ADD TaxTypeId INT NULL;
ALTER TABLE Sites ADD SalespersonId INT NULL;
ALTER TABLE Sites ADD SiteReferenceNumber NVARCHAR(50) NULL;
ALTER TABLE Sites ADD SendCompletedWoMethod SMALLINT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD SendCompletedWoTo SMALLINT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD Facility INT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD FacilityType INT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD SiteManagerId INT NULL;

-- Add foreign key constraints for Sites
ALTER TABLE Sites ADD CONSTRAINT FK_Sites_Address FOREIGN KEY (AddressId) REFERENCES Addresses(Id);
ALTER TABLE Sites ADD CONSTRAINT FK_Sites_PrimaryContact FOREIGN KEY (PrimaryContactId) REFERENCES Contacts(Id);
ALTER TABLE Sites ADD CONSTRAINT FK_Sites_SiteManager FOREIGN KEY (SiteManagerId) REFERENCES Contacts(Id);
ALTER TABLE Sites ADD CONSTRAINT FK_Sites_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id);
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

    CONSTRAINT FK_AccountSites_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_AccountSites_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id),
    CONSTRAINT UQ_AccountSites_AccountId_SiteId UNIQUE (AccountId, SiteId)
);
GO
