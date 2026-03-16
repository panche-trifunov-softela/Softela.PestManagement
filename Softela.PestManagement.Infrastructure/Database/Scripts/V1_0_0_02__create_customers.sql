CREATE TABLE Customers (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TenantId INT NOT NULL,
    CustomerNum NVARCHAR(50) NULL,
    Name NVARCHAR(255) NOT NULL,
    CustomerType INT NOT NULL DEFAULT 1,
    IsActive BIT NOT NULL DEFAULT 1,
    SendInvoice BIT NOT NULL DEFAULT 0,
    EmailInvoice BIT NOT NULL DEFAULT 0,
    Instructions NVARCHAR(MAX) NULL,
    PrimaryNote NVARCHAR(MAX) NULL,
    RegistrationNum NVARCHAR(100) NULL,
    PreferredContactMethod NVARCHAR(50) NULL,
    BillingAddressStreet NVARCHAR(255) NULL,
    BillingAddressCity NVARCHAR(255) NULL,
    BillingAddressState NVARCHAR(255) NULL,
    BillingAddressZip NVARCHAR(50) NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL,
    ModifiedAt DATETIME2 NOT NULL,
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Customers_Tenants FOREIGN KEY (TenantId) REFERENCES Tenants(Id)
);
GO

CREATE TABLE CustomerContacts (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TenantId INT NOT NULL,
    CustomerId INT NOT NULL,
    ContactType NVARCHAR(50) NOT NULL DEFAULT 'Billing',
    FirstName NVARCHAR(255) NULL,
    MiddleName NVARCHAR(255) NULL,
    LastName NVARCHAR(255) NULL,
    Email NVARCHAR(255) NULL,
    AlternateEmails NVARCHAR(MAX) NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL,
    ModifiedAt DATETIME2 NOT NULL,
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_CustomerContacts_Tenants FOREIGN KEY (TenantId) REFERENCES Tenants(Id),
    CONSTRAINT FK_CustomerContacts_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
GO

CREATE TABLE CustomerContactPhones (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TenantId INT NOT NULL,
    CustomerContactId INT NOT NULL,
    PhoneType NVARCHAR(50) NULL,
    PhoneNumber NVARCHAR(50) NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL,
    ModifiedAt DATETIME2 NOT NULL,
    CONSTRAINT FK_CustomerContactPhones_Tenants FOREIGN KEY (TenantId) REFERENCES Tenants(Id),
    CONSTRAINT FK_CustomerContactPhones_CustomerContacts FOREIGN KEY (CustomerContactId) REFERENCES CustomerContacts(Id)
);
GO
