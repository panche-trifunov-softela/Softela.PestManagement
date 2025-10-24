-- Diagram: testimate
CREATE TABLE Estimates (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EstimateTypeId INT NOT NULL,
    EstimateName NVARCHAR(75),
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,
    EstimateDate DATETIME,
    ExpirationDate DATETIME,
    RejectedReason INT,
    SoldDate DATETIME,
    EstimateStatus SMALLINT,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    ServiceCenter INT,
    SourceId INT,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Estimates_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_Estimates_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id),
    CONSTRAINT FK_Estimates_Type FOREIGN KEY (EstimateTypeId) REFERENCES EstimateTypes(Id),
    CONSTRAINT FK_Estimates_RejectedReason FOREIGN KEY (RejectedReason) REFERENCES RejectedReasons(Id),
    CONSTRAINT FK_Estimates_ServiceCenter FOREIGN KEY (ServiceCenter) REFERENCES ServiceCenters(Id),
    CONSTRAINT FK_Estimates_Source FOREIGN KEY (SourceId) REFERENCES Sources(Id)
);
GO

-- Diagram: tprogram
CREATE TABLE Programs (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ProgramTypeId INT NOT NULL,
    ProgramName NVARCHAR(75),
    EstimateId INT,
    AccountId INT NOT NULL,
    SiteId INT NOT NULL,
    ProgramStatus SMALLINT,
    StartDate DATETIME,
    EndDate DATETIME,
    CancelDate DATETIME,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    CancelReasonId INT,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Programs_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_Programs_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id),
    CONSTRAINT FK_Programs_Estimate FOREIGN KEY (EstimateId) REFERENCES Estimates(Id),
    CONSTRAINT FK_Programs_Type FOREIGN KEY (ProgramTypeId) REFERENCES ProgramTypes(Id),
    CONSTRAINT FK_Programs_CancelReason FOREIGN KEY (CancelReasonId) REFERENCES CancelReasons(Id)
);
GO
