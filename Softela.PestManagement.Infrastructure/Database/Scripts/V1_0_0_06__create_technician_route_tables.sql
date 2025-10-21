-- Technician and Route Tables Migration
-- Employee/technician management and service routes

-- Technicians
CREATE TABLE Technicians (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    EmployeeNumber NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,

    -- Contact info
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Mobile NVARCHAR(20),

    -- Employment
    HireDate DATETIME2,
    TerminationDate DATETIME2,
    IsActive BIT NOT NULL DEFAULT 1,

    -- Licensing and certifications
    LicenseNumber NVARCHAR(50),
    LicenseExpirationDate DATETIME2,
    CertificationNumbers NVARCHAR(500),
    Certifications NVARCHAR(MAX),

    -- Work info
    DefaultRouteId INT,
    BranchId INT,
    Territory NVARCHAR(100),

    -- Settings
    CanSchedule BIT NOT NULL DEFAULT 0,
    CanInvoice BIT NOT NULL DEFAULT 0,
    UserId INT,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Technicians_User FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Routes
CREATE TABLE Routes (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Code NVARCHAR(50),

    -- Route details
    DefaultTechnicianId INT,
    BranchId INT,
    Territory NVARCHAR(100),

    -- Schedule
    DaysOfWeek NVARCHAR(50),
    StartTime TIME,
    EndTime TIME,

    -- Status
    IsActive BIT NOT NULL DEFAULT 1,
    Color NVARCHAR(20),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Routes_DefaultTechnician FOREIGN KEY (DefaultTechnicianId) REFERENCES Technicians(Id)
);
GO

-- Add FK from Technicians to Routes
ALTER TABLE Technicians
ADD CONSTRAINT FK_Technicians_DefaultRoute FOREIGN KEY (DefaultRouteId) REFERENCES Routes(Id);
GO
