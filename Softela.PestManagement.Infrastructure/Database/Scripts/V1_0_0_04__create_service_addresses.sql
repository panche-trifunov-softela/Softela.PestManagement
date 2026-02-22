CREATE TABLE ServiceAddresses (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TenantId INT NOT NULL,
    CustomerId INT NOT NULL,
    ServiceAddressName NVARCHAR(255) NOT NULL,
    ServiceAddressType NVARCHAR(50) NULL,
    Address NVARCHAR(500) NULL,
    City NVARCHAR(255) NULL,
    State NVARCHAR(50) NULL,
    Zip NVARCHAR(20) NULL,
    ContactName NVARCHAR(255) NULL,
    ContactPhone NVARCHAR(50) NULL,
    ContactEmail NVARCHAR(255) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL,
    ModifiedAt DATETIME2 NOT NULL,
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_ServiceAddresses_Tenants FOREIGN KEY (TenantId) REFERENCES Tenants(Id),
    CONSTRAINT FK_ServiceAddresses_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
GO
