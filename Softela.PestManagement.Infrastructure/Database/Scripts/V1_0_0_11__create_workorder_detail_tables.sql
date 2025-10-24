-- Diagram: tworkorderlabor
CREATE TABLE WorkOrderLabors (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoEventId INT NOT NULL,
    BatchId INT,
    EmployeeId INT NOT NULL,
    LaborDate DATETIME,
    LaborMinutes DECIMAL(9, 3),
    TimeIn NVARCHAR(30),
    TimeOut NVARCHAR(30),
    Invoiced BIT NOT NULL DEFAULT 0,
    InvoiceAmount MONEY,
    FedTaxAmount MONEY,
    StateTaxAmount MONEY,
    LocalTaxAmount MONEY,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    TaxTypeName NVARCHAR(50),
    TaxFedPercent DECIMAL(9, 8),
    TaxStatePercent DECIMAL(9, 8),
    TaxLocalPercent DECIMAL(9, 8),
    IsPrimary SMALLINT,
    TaxTypeId INT,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderLabors_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id),
    CONSTRAINT FK_WorkOrderLabors_Batch FOREIGN KEY (BatchId) REFERENCES Batches(Id),
    CONSTRAINT FK_WorkOrderLabors_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    CONSTRAINT FK_WorkOrderLabors_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id)
);
GO

-- Diagram: tworkordermaterial
CREATE TABLE WorkOrderMaterials (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoEventId INT NOT NULL,
    BatchId INT,
    MaterialDate DATETIME,
    ItemId INT,
    ItemNum NVARCHAR(50),
    ItemDescription NVARCHAR(50),
    PricePerUnit MONEY,
    MaterialQuantity DECIMAL(9, 4),
    Invoiced BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    InvoiceAmount MONEY,
    TaxTypeName NVARCHAR(50),
    TaxFedPercent DECIMAL(9, 8),
    TaxStatePercent DECIMAL(9, 8),
    TaxLocalPercent DECIMAL(9, 8),
    FedTaxAmount MONEY,
    StateTaxAmount MONEY,
    LocalTaxAmount MONEY,
    CreatedBy NVARCHAR(100) NOT NULL,
    TaxTypeId INT,
    InspectionPointHistoryId INT,
    EquipmentId INT,
    LocationId INT,
    CustomLocation NVARCHAR(500),
    UsageUom NVARCHAR(50),
    ActiveIngredient NVARCHAR(200),
    TreatmentNotes VARCHAR(750),
    ApplicationRate VARCHAR(100),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderMaterials_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id),
    CONSTRAINT FK_WorkOrderMaterials_Batch FOREIGN KEY (BatchId) REFERENCES Batches(Id),
    CONSTRAINT FK_WorkOrderMaterials_Item FOREIGN KEY (ItemId) REFERENCES InventoryItems(Id),
    CONSTRAINT FK_WorkOrderMaterials_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id),
    CONSTRAINT FK_WorkOrderMaterials_Equipment FOREIGN KEY (EquipmentId) REFERENCES Equipments(Id),
    CONSTRAINT FK_WorkOrderMaterials_Location FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);
GO

-- Diagram: tworkorderactiveingredient
CREATE TABLE WorkOrderActiveIngredients (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoMaterialId INT NOT NULL,
    ActiveIngredient NVARCHAR(200),
    ActivePct DECIMAL(12, 8),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderActiveIngredients_Material FOREIGN KEY (WoMaterialId) REFERENCES WorkOrderMaterials(Id)
);
GO

-- Diagram: tworkordermaterialequipment
CREATE TABLE WorkOrderMaterialEquipments (
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
    WorkOrderMaterialId BIGINT NOT NULL,
    EquipmentId INT NOT NULL
);
GO

-- Diagram: tworkordermateriallocation
CREATE TABLE WorkOrderMaterialLocations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoMaterialId INT NOT NULL,
    LocationId INT,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    WoEventId INT NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderMaterialLocations_Material FOREIGN KEY (WoMaterialId) REFERENCES WorkOrderMaterials(Id),
    CONSTRAINT FK_WorkOrderMaterialLocations_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id)
);
GO

-- Diagram: tworkordertarget
CREATE TABLE WorkOrderTargets (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoEventId INT NOT NULL,
    TargetTypeId INT NOT NULL,
    NumberFound INT,
    InspectionPointHistoryId INT,
    WoMaterialId INT,
    TargetCategoryId INT,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsPrimary BIT NOT NULL DEFAULT 0,
    ActivityLevel INT,
    WarrantyId INT,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderTargets_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id),
    CONSTRAINT FK_WorkOrderTargets_Material FOREIGN KEY (WoMaterialId) REFERENCES WorkOrderMaterials(Id),
    CONSTRAINT FK_WorkOrderTargets_TargetType FOREIGN KEY (TargetTypeId) REFERENCES TargetTypes(Id),
    CONSTRAINT FK_WorkOrderTargets_TargetCategory FOREIGN KEY (TargetCategoryId) REFERENCES TargetCategories(Id),
    CONSTRAINT FK_WorkOrderTargets_Warranty FOREIGN KEY (WarrantyId) REFERENCES Warranties(Id)
);
GO

-- Diagram: tworkorderobservation
CREATE TABLE WorkOrderObservations (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    WoEventId INT NOT NULL,
    ObservationId INT,
    CustomObservationText NVARCHAR(500),
    RecommendationId INT,
    CustomRecommendationText NVARCHAR(500),
    EntityResponsible SMALLINT,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    CustomLocationText NVARCHAR(500),
    ResolvedDate DATETIME,
    ZoneId INT,
    InspectionPointHistoryId INT,
    ImageName VARCHAR(300),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_WorkOrderObservations_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id),
    CONSTRAINT FK_WorkOrderObservations_Observation FOREIGN KEY (ObservationId) REFERENCES Observations(Id),
    CONSTRAINT FK_WorkOrderObservations_Recommendation FOREIGN KEY (RecommendationId) REFERENCES Recommendations(Id)
);
GO

-- Diagram: tobservationrecommendation
CREATE TABLE ObservationRecommendations (
    ObservationId INT NOT NULL,
    RecommendationId INT NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    PRIMARY KEY (ObservationId, RecommendationId)
);
GO
