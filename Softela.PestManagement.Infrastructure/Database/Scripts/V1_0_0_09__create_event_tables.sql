-- Diagram: tevent
CREATE TABLE Events (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EventTypeId INT NOT NULL,
    ProgramId INT NOT NULL,
    ReleaseDate DATETIME,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    Status SMALLINT NOT NULL,
    PatternInterval SMALLINT,
    IntervalValue INT,
    SkipMonths SMALLINT,
    AssignedTo INT,
    PermInstructions NVARCHAR(MAX),
    OneTimeInstructions NVARCHAR(MAX),
    CancelDate DATETIME,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    SkipDays SMALLINT,
    TaxTypeId INT,
    BaseDate DATETIME,
    ScheduledTime INT,
    TimeOptionId INT,
    SalesPersonId INT,
    CancelReasonId INT,
    Duration INT,
    SaleDate DATETIME,
    StopAfter INT,
    SpecificDay SMALLINT,
    WarrantyId INT,
    WarrantyDate DATETIME,
    CustomerInvoiceNote NVARCHAR(1000),
    CancelledBy NVARCHAR(50),
    CONSTRAINT FK_Events_Program FOREIGN KEY (ProgramId) REFERENCES Programs(Id),
    CONSTRAINT FK_Events_Type FOREIGN KEY (EventTypeId) REFERENCES EventTypes(Id),
    CONSTRAINT FK_Events_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id),
    CONSTRAINT FK_Events_TimeOption FOREIGN KEY (TimeOptionId) REFERENCES TimeOptions(Id),
    CONSTRAINT FK_Events_CancelReason FOREIGN KEY (CancelReasonId) REFERENCES CancelReasons(Id),
    CONSTRAINT FK_Events_Warranty FOREIGN KEY (WarrantyId) REFERENCES Warranties(Id)
);
GO

-- Diagram: teventdays
CREATE TABLE EventDays (
    Counter INT NOT NULL PRIMARY KEY IDENTITY,
    EventId INT NOT NULL,
    Monday BIT NOT NULL DEFAULT 0,
    Tuesday BIT NOT NULL DEFAULT 0,
    Wednesday BIT NOT NULL DEFAULT 0,
    Thursday BIT NOT NULL DEFAULT 0,
    Friday BIT NOT NULL DEFAULT 0,
    Saturday BIT NOT NULL DEFAULT 0,
    Sunday BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_EventDays_Event FOREIGN KEY (EventId) REFERENCES Events(Id)
);
GO

-- Diagram: teventprice
CREATE TABLE EventPrices (
    Counter INT NOT NULL PRIMARY KEY IDENTITY,
    EventId INT NOT NULL,
    BillAmount DECIMAL(18, 2),
    ProdAmount DECIMAL(18, 2),
    SaleAmount DECIMAL(18, 2),
    EffectiveDate DATETIME,
    CreateStamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    GlobalIncrease BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_EventPrices_Event FOREIGN KEY (EventId) REFERENCES Events(Id)
);
GO

-- Diagram: teventskips
CREATE TABLE EventSkips (
    SkipMonths SMALLINT NOT NULL PRIMARY KEY,
    Jan TINYINT NOT NULL DEFAULT 0,
    Feb TINYINT NOT NULL DEFAULT 0,
    Mar TINYINT NOT NULL DEFAULT 0,
    Apr TINYINT NOT NULL DEFAULT 0,
    May TINYINT NOT NULL DEFAULT 0,
    Jun TINYINT NOT NULL DEFAULT 0,
    Jul TINYINT NOT NULL DEFAULT 0,
    Aug TINYINT NOT NULL DEFAULT 0,
    Sep TINYINT NOT NULL DEFAULT 0,
    Oct TINYINT NOT NULL DEFAULT 0,
    Nov TINYINT NOT NULL DEFAULT 0,
    December TINYINT NOT NULL DEFAULT 0,
    SCount TINYINT NOT NULL DEFAULT 0,
    NonSkips TINYINT NOT NULL DEFAULT 0
);
GO
