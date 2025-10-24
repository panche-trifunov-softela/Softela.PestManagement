-- Diagram: taccount
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Sites_Accounts')
    ALTER TABLE Sites DROP CONSTRAINT FK_Sites_Accounts;
GO

ALTER TABLE Accounts DROP COLUMN CreatedAt;
ALTER TABLE Accounts DROP COLUMN ModifiedAt;
ALTER TABLE Accounts DROP COLUMN CreatedBy;
ALTER TABLE Accounts DROP COLUMN ModifiedBy;
GO

ALTER TABLE Accounts ALTER COLUMN IsActive SMALLINT NOT NULL;
ALTER TABLE Accounts ALTER COLUMN IsDeleted BIT NOT NULL;
GO

ALTER TABLE Accounts ADD CompanyId INT NOT NULL DEFAULT 1;
ALTER TABLE Accounts ADD AccountNum NVARCHAR(50) NOT NULL DEFAULT '';
ALTER TABLE Accounts ADD AccountType INT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD BillingAddressId INT;
ALTER TABLE Accounts ADD BillingContactId INT;
ALTER TABLE Accounts ADD BillingCenterId INT;
ALTER TABLE Accounts ADD LocaleId INT;
ALTER TABLE Accounts ADD SendInvoice BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailInvoice BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD SendStatement BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailStatement BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD SendRenewal BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD EmailRenewal BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD MarketingEmail BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD NotificationsMail BIT NOT NULL DEFAULT 0;
ALTER TABLE Accounts ADD Instructions NVARCHAR(900);
ALTER TABLE Accounts ADD PrimaryNote NVARCHAR(200);
ALTER TABLE Accounts ADD SecondaryNote NVARCHAR(200);
ALTER TABLE Accounts ADD MasterAccountId INT;
ALTER TABLE Accounts ADD MasterAccountSubId INT;
ALTER TABLE Accounts ADD RegistrationNum NVARCHAR(15);
ALTER TABLE Accounts ADD DiscountTypeId INT;
ALTER TABLE Accounts ADD AccountManagerId INT;
ALTER TABLE Accounts ADD UtcTimestamp DATETIME NOT NULL DEFAULT GETUTCDATE();
ALTER TABLE Accounts ADD UtcLastChanged DATETIME NOT NULL DEFAULT GETUTCDATE();
ALTER TABLE Accounts ADD LastChangedBy NVARCHAR(50) NOT NULL DEFAULT 'SYSTEM';
GO

ALTER TABLE Accounts
ADD CONSTRAINT FK_Accounts_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id);
GO

ALTER TABLE Accounts
ADD CONSTRAINT FK_Accounts_DiscountType FOREIGN KEY (DiscountTypeId) REFERENCES DiscountTypes(Id);
GO

-- Diagram: tsite
-- Rename ReferenceNumber to SiteReferenceNumber
EXEC sp_rename 'Sites.ReferenceNumber', 'SiteReferenceNumber', 'COLUMN';
GO

-- Drop columns that don't exist in diagram
ALTER TABLE Sites DROP COLUMN CreatedAt;
ALTER TABLE Sites DROP COLUMN ModifiedAt;
ALTER TABLE Sites DROP COLUMN CreatedBy;
ALTER TABLE Sites DROP COLUMN ModifiedBy;
GO

-- Ensure IsDeleted column exists
ALTER TABLE Sites ALTER COLUMN IsDeleted BIT NOT NULL;
GO

-- Add all new columns from diagram
ALTER TABLE Sites ADD AddressId INT;
ALTER TABLE Sites ADD PrimaryContactId INT;
ALTER TABLE Sites ADD PropertyType INT NOT NULL DEFAULT 0;
ALTER TABLE Sites ADD Notes NVARCHAR(MAX);
ALTER TABLE Sites ADD Latitude DECIMAL(18, 15);
ALTER TABLE Sites ADD Longitude DECIMAL(18, 15);
ALTER TABLE Sites ADD Instructions NVARCHAR(900);
ALTER TABLE Sites ADD TaxTypeId INT;
ALTER TABLE Sites ADD UtcTimestamp DATETIME NOT NULL DEFAULT GETUTCDATE();
ALTER TABLE Sites ADD UtcLastChanged DATETIME NOT NULL DEFAULT GETUTCDATE();
ALTER TABLE Sites ADD LastChangedBy NVARCHAR(50) NOT NULL DEFAULT 'SYSTEM';
ALTER TABLE Sites ADD SalesPersonId INT;
ALTER TABLE Sites ADD SendCompletedWoMethod SMALLINT;
ALTER TABLE Sites ADD SendCompletedWoTo SMALLINT;
ALTER TABLE Sites ADD Facility INT;
ALTER TABLE Sites ADD FacilityType INT;
ALTER TABLE Sites ADD SiteManagerId INT;
GO

ALTER TABLE Sites
ADD CONSTRAINT FK_Sites_Address FOREIGN KEY (AddressId) REFERENCES Addresses(Id);
GO

ALTER TABLE Sites
ADD CONSTRAINT FK_Sites_Contact FOREIGN KEY (PrimaryContactId) REFERENCES Contacts(Id);
GO

ALTER TABLE Sites
ADD CONSTRAINT FK_Sites_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id);
GO

ALTER TABLE Sites
ADD CONSTRAINT FK_Sites_PropertyType FOREIGN KEY (PropertyType) REFERENCES PropertyTypes(Id);
GO

ALTER TABLE Sites
ADD CONSTRAINT FK_Sites_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id);
GO

-- Diagram: accountsite
CREATE TABLE AccountsSites (
    Counter INT NOT NULL PRIMARY KEY IDENTITY,
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,
    LastChanged DATETIME NOT NULL,
    ChangedBy NVARCHAR(100) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    CONSTRAINT FK_AccountsSites_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_AccountsSites_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id)
);
GO
