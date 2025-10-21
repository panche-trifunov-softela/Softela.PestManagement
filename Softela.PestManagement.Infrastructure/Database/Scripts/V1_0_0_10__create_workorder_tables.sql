-- WorkOrder Tables Migration
-- Service work orders and related junction tables

-- WorkOrders
CREATE TABLE WorkOrders (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WorkOrderNumber NVARCHAR(50) NOT NULL UNIQUE,
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,
    ServiceTypeId INT,
    TechnicianId INT,

    -- Scheduling
    ScheduledDate DATETIME2,
    ScheduledTime TIME,
    Duration INT,
    TimeRangeId INT,

    -- Status (0=Pending, 1=Scheduled, 2=InProgress, 3=Completed, 4=Cancelled, 5=Skipped)
    Status INT NOT NULL DEFAULT 0,
    CompletedDate DATETIME2,
    CancelledDate DATETIME2,
    CancelReasonId INT,
    CancelReasonDescription NVARCHAR(500),
    SkippedDate DATETIME2,
    SkipReason NVARCHAR(500),

    -- Instructions and notes
    Instructions NVARCHAR(900),
    Notes NVARCHAR(MAX),
    TechnicianNotes NVARCHAR(MAX),

    -- Billing
    EstimatedAmount DECIMAL(10,2),
    CompletedAmount DECIMAL(10,2),
    InvoiceId INT,

    -- Route management
    RouteName NVARCHAR(100),
    RouteOrder INT,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_WorkOrders_Account FOREIGN KEY (AccountId) REFERENCES AccountEntities(Id),
    CONSTRAINT FK_WorkOrders_Site FOREIGN KEY (SiteId) REFERENCES SiteEntities(Id),
    CONSTRAINT FK_WorkOrders_ServiceType FOREIGN KEY (ServiceTypeId) REFERENCES ServiceTypes(Id),
    CONSTRAINT FK_WorkOrders_Technician FOREIGN KEY (TechnicianId) REFERENCES Technicians(Id),
    CONSTRAINT FK_WorkOrders_Invoice FOREIGN KEY (InvoiceId) REFERENCES Invoices(Id)
);
GO

-- Add FK from InvoiceLineItems to WorkOrders
ALTER TABLE InvoiceLineItems
ADD CONSTRAINT FK_InvoiceLineItems_WorkOrder FOREIGN KEY (WorkOrderId) REFERENCES WorkOrders(Id);
GO

-- WorkOrderProducts (Junction table - products/chemicals used in work orders)
CREATE TABLE WorkOrderProducts (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WorkOrderId INT NOT NULL,
    ProductId INT NOT NULL,

    -- Application details
    QuantityUsed DECIMAL(10,2) NOT NULL,
    UnitOfMeasure NVARCHAR(50),
    DilutionRatio DECIMAL(10,2),
    ApplicationMethod NVARCHAR(200),
    ApplicationArea NVARCHAR(500),

    -- Target
    TargetPestId INT,

    -- Notes
    Notes NVARCHAR(MAX),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_WorkOrderProducts_WorkOrder FOREIGN KEY (WorkOrderId) REFERENCES WorkOrders(Id) ON DELETE CASCADE,
    CONSTRAINT FK_WorkOrderProducts_Product FOREIGN KEY (ProductId) REFERENCES Products(Id),
    CONSTRAINT FK_WorkOrderProducts_TargetPest FOREIGN KEY (TargetPestId) REFERENCES Pests(Id)
);
GO

-- WorkOrderPests (Junction table - pests found/treated in work orders)
CREATE TABLE WorkOrderPests (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WorkOrderId INT NOT NULL,
    PestId INT NOT NULL,

    -- Infestation details
    InfestationLevel INT NOT NULL DEFAULT 1,
    LocationFound NVARCHAR(500),
    EstimatedPopulation INT,

    -- Evidence
    LivePestsFound BIT NOT NULL DEFAULT 0,
    DeadPestsFound BIT NOT NULL DEFAULT 0,
    EvidenceOfActivity BIT NOT NULL DEFAULT 0,
    EvidenceDescription NVARCHAR(MAX),

    -- Treatment
    TreatmentApplied BIT NOT NULL DEFAULT 0,
    TreatmentDescription NVARCHAR(MAX),
    TreatmentAreaDescription NVARCHAR(500),

    -- Follow-up
    RequiresFollowUp BIT NOT NULL DEFAULT 0,
    RecommendedFollowUpDate DATETIME2,

    -- Notes
    Notes NVARCHAR(MAX),

    -- Images
    PhotoUrls NVARCHAR(MAX),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_WorkOrderPests_WorkOrder FOREIGN KEY (WorkOrderId) REFERENCES WorkOrders(Id) ON DELETE CASCADE,
    CONSTRAINT FK_WorkOrderPests_Pest FOREIGN KEY (PestId) REFERENCES Pests(Id)
);
GO
