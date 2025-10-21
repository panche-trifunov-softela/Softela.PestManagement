-- Service and ServiceType Tables Migration
-- Service definitions and customer service agreements

-- ServiceTypes
CREATE TABLE ServiceTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Code NVARCHAR(50),
    ServiceCategoryId INT,

    -- Pricing
    DefaultPrice DECIMAL(10,2),
    DefaultDuration INT,

    -- Settings
    IsActive BIT NOT NULL DEFAULT 1,
    RequiresLicense BIT NOT NULL DEFAULT 0,
    LicenseType NVARCHAR(100),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_ServiceTypes_ServiceCategory FOREIGN KEY (ServiceCategoryId) REFERENCES ServiceCategories(Id)
);
GO

-- Services (Service agreements/programs)
CREATE TABLE Services (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,
    ServiceTypeId INT NOT NULL,

    -- Contract/Program info
    ProgramName NVARCHAR(200),
    SaleDate DATETIME2,
    StartDate DATETIME2,
    EndDate DATETIME2,
    CancelDate DATETIME2,
    PendingCancelDate DATETIME2,

    -- Frequency and scheduling
    FrequencyTypeId INT,
    FrequencyValue INT,
    SchedulePattern NVARCHAR(500),

    -- Pricing
    Price DECIMAL(10,2),
    BillingCycleId INT,

    -- Instructions and notes
    Instructions NVARCHAR(900),
    Notes NVARCHAR(MAX),

    -- Purchase order
    PurchaseOrder NVARCHAR(50),
    POExpirationDate DATETIME2,

    -- Status
    IsActive BIT NOT NULL DEFAULT 1,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Services_Account FOREIGN KEY (AccountId) REFERENCES AccountEntities(Id),
    CONSTRAINT FK_Services_Site FOREIGN KEY (SiteId) REFERENCES SiteEntities(Id),
    CONSTRAINT FK_Services_ServiceType FOREIGN KEY (ServiceTypeId) REFERENCES ServiceTypes(Id),
    CONSTRAINT FK_Services_FrequencyType FOREIGN KEY (FrequencyTypeId) REFERENCES FrequencyTypes(Id)
);
GO
