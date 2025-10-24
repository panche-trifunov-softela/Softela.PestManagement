-- Diagram: Missing
CREATE TABLE Locales (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    LocaleName NVARCHAR(100) NOT NULL,
    LocaleCode NVARCHAR(10),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Countries (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CountryName NVARCHAR(100) NOT NULL,
    CountryCode NVARCHAR(3),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE TaxTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TaxTypeName NVARCHAR(50) NOT NULL,
    FederalPercent DECIMAL(9, 8),
    StatePercent DECIMAL(9, 8),
    LocalPercent DECIMAL(9, 8),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Salutations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    SalutationName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE EstimateTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EstimateTypeName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE ProgramTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ProgramTypeName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE EventTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EventTypeName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE PropertyTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    PropertyTypeName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE CancelReasons (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CancelReasonName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Warranties (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WarrantyName NVARCHAR(100) NOT NULL,
    WarrantyDays INT,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE TimeRanges (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TimeRangeName NVARCHAR(50) NOT NULL,
    StartTime INT,
    EndTime INT,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE TimeOptions (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TimeOptionName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Sources (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    SourceName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE RejectedReasons (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    RejectedReasonName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE ServiceCenters (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ServiceCenterName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Employees (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(250),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE AccountPeriods (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    PeriodName NVARCHAR(50) NOT NULL,
    StartDate DATETIME,
    EndDate DATETIME,
    IsClosed BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0
);
GO

-- Diagram: Missing
CREATE TABLE Releases (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ReleaseName NVARCHAR(100) NOT NULL,
    ReleaseDate DATETIME,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE TargetTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TargetTypeName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE TargetCategories (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    TargetCategoryName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Observations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ObservationText NVARCHAR(500) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Recommendations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    RecommendationText NVARCHAR(500) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE InventoryItems (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ItemNumber NVARCHAR(50) NOT NULL,
    ItemDescription NVARCHAR(250),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Equipments (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EquipmentName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE Locations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    LocationName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE ApplicationMethods (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    AppMethodName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE LocationTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    LocationTypeName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO

-- Diagram: Missing
CREATE TABLE DiscountTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    DiscountTypeName NVARCHAR(50) NOT NULL,
    DiscountPercent DECIMAL(5, 2),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL
);
GO
