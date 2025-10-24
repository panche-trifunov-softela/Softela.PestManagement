-- Diagram: tfacilitytemplatetype
CREATE TABLE FacilityTemplateTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    CompanyId INT NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    IpTypeId INT,
    CONSTRAINT FK_FacilityTemplateTypes_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);
GO

-- Diagram: tfacility
CREATE TABLE Facilities (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    SiteId INT NOT NULL,
    FacilityName NVARCHAR(50),
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsActive INT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FacilityTemplateTypeId INT,
    CONSTRAINT FK_Facilities_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id),
    CONSTRAINT FK_Facilities_Template FOREIGN KEY (FacilityTemplateTypeId) REFERENCES FacilityTemplateTypes(Id)
);
GO

-- Diagram: tzonetemplatetype
CREATE TABLE ZoneTemplateTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    CompanyId INT NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    IpCategoryId INT,
    LocationTypeId INT,
    CONSTRAINT FK_ZoneTemplateTypes_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);
GO

-- Diagram: tzone
CREATE TABLE Zones (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    FacilityId INT NOT NULL,
    ZoneName NVARCHAR(50),
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    IsActive INT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    RoomNumber INT,
    ZoneTemplateTypeId INT,
    CONSTRAINT FK_Zones_Facility FOREIGN KEY (FacilityId) REFERENCES Facilities(Id),
    CONSTRAINT FK_Zones_Template FOREIGN KEY (ZoneTemplateTypeId) REFERENCES ZoneTemplateTypes(Id)
);
GO

-- Diagram: tinspectionpointtypecategory
CREATE TABLE InspectionPointTypeCategories (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    CategoryText NVARCHAR(500) NOT NULL,
    IsActive INT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedBy NVARCHAR(250) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(250) NOT NULL,
    CONSTRAINT FK_InspectionPointTypeCategories_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id)
);
GO

-- Diagram: tinspectionpointtype
CREATE TABLE InspectionPointTypes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    TypeText NVARCHAR(50) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    IpCategoryId INT,
    IsMonitoring BIT NOT NULL DEFAULT 0,
    AppMethodId INT,
    EquipmentId INT,
    IpLocationId INT,
    CONSTRAINT FK_InspectionPointTypes_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id),
    CONSTRAINT FK_InspectionPointTypes_Category FOREIGN KEY (IpCategoryId) REFERENCES InspectionPointTypeCategories(Id),
    CONSTRAINT FK_InspectionPointTypes_AppMethod FOREIGN KEY (AppMethodId) REFERENCES ApplicationMethods(Id),
    CONSTRAINT FK_InspectionPointTypes_Equipment FOREIGN KEY (EquipmentId) REFERENCES Equipments(Id),
    CONSTRAINT FK_InspectionPointTypes_Location FOREIGN KEY (IpLocationId) REFERENCES LocationTypes(Id)
);
GO

-- Diagram: tinspectionpoint
CREATE TABLE InspectionPoints (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ZoneId INT NOT NULL,
    InspectionPointName NVARCHAR(100),
    Number DECIMAL(10, 2),
    Barcode NVARCHAR(50),
    TypeId INT,
    Notes NVARCHAR(900),
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    InventoryItemId INT,
    TargetTypeId INT,
    EventId INT,
    CustomLocation NVARCHAR(100),
    Removed INT NOT NULL DEFAULT 0,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_InspectionPoints_Zone FOREIGN KEY (ZoneId) REFERENCES Zones(Id),
    CONSTRAINT FK_InspectionPoints_Type FOREIGN KEY (TypeId) REFERENCES InspectionPointTypes(Id),
    CONSTRAINT FK_InspectionPoints_Item FOREIGN KEY (InventoryItemId) REFERENCES InventoryItems(Id),
    CONSTRAINT FK_InspectionPoints_TargetType FOREIGN KEY (TargetTypeId) REFERENCES TargetTypes(Id),
    CONSTRAINT FK_InspectionPoints_Event FOREIGN KEY (EventId) REFERENCES Events(Id)
);
GO

-- Diagram: tinspectionpointhistory
CREATE TABLE InspectionPointHistories (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    InspectionPointId INT NOT NULL,
    ZoneId INT NOT NULL,
    HistoryDate DATETIME NOT NULL,
    HistoryActionId INT NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    WoEventId INT,
    ActivityLevel INT,
    ScanLatitude DECIMAL(18, 15),
    ScanLongitude DECIMAL(18, 15),
    StationScaned BIT NOT NULL DEFAULT 0,
    MonitoredDate DATE,
    InstallDate DATE,
    RemoveDate DATE,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_InspectionPointHistories_Point FOREIGN KEY (InspectionPointId) REFERENCES InspectionPoints(Id),
    CONSTRAINT FK_InspectionPointHistories_Zone FOREIGN KEY (ZoneId) REFERENCES Zones(Id),
    CONSTRAINT FK_InspectionPointHistories_WoEvent FOREIGN KEY (WoEventId) REFERENCES WorkOrderEvents(Id)
);
GO

ALTER TABLE WorkOrderMaterials
ADD CONSTRAINT FK_WorkOrderMaterials_IpHistory FOREIGN KEY (InspectionPointHistoryId) REFERENCES InspectionPointHistories(Id);
GO

ALTER TABLE WorkOrderTargets
ADD CONSTRAINT FK_WorkOrderTargets_IpHistory FOREIGN KEY (InspectionPointHistoryId) REFERENCES InspectionPointHistories(Id);
GO

ALTER TABLE WorkOrderObservations
ADD CONSTRAINT FK_WorkOrderObservations_Zone FOREIGN KEY (ZoneId) REFERENCES Zones(Id);
GO

ALTER TABLE WorkOrderObservations
ADD CONSTRAINT FK_WorkOrderObservations_IpHistory FOREIGN KEY (InspectionPointHistoryId) REFERENCES InspectionPointHistories(Id);
GO

ALTER TABLE ZoneTemplateTypes
ADD CONSTRAINT FK_ZoneTemplateTypes_LocationType FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(Id);
GO
