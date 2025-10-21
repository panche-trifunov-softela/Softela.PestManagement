-- Site Stored Procedures Migration
-- Creates stored procedures for Site CRUD operations

-- Upsert Site (Create or Update)
CREATE OR ALTER PROCEDURE UpsertSite
    @Id INT = NULL,
    @AddressId INT = NULL,
    @PrimaryContactId INT = NULL,
    @PropertyType INT,
    @Notes NVARCHAR(MAX) = NULL,
    @Latitude DECIMAL(18,15) = NULL,
    @Longitude DECIMAL(18,15) = NULL,
    @Instructions NVARCHAR(900) = NULL,
    @TaxTypeId INT = NULL,
    @SalespersonId INT = NULL,
    @SiteReferenceNumber NVARCHAR(50) = NULL,
    @SendCompletedWoMethod SMALLINT,
    @SendCompletedWoTo SMALLINT,
    @Facility INT,
    @FacilityType INT,
    @SiteManagerId INT = NULL,
    @ReferenceNumber NVARCHAR(50),
    @IsDeleted SMALLINT,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id IS NOT NULL AND EXISTS (SELECT 1 FROM Sites WHERE Id = @Id)
    BEGIN
        -- Update existing site
        UPDATE Sites SET
            AddressId = @AddressId,
            PrimaryContactId = @PrimaryContactId,
            PropertyType = @PropertyType,
            Notes = @Notes,
            Latitude = @Latitude,
            Longitude = @Longitude,
            Instructions = @Instructions,
            TaxTypeId = @TaxTypeId,
            SalespersonId = @SalespersonId,
            SiteReferenceNumber = @SiteReferenceNumber,
            SendCompletedWoMethod = @SendCompletedWoMethod,
            SendCompletedWoTo = @SendCompletedWoTo,
            Facility = @Facility,
            FacilityType = @FacilityType,
            SiteManagerId = @SiteManagerId,
            ReferenceNumber = @ReferenceNumber,
            IsDeleted = @IsDeleted,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id;

        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        -- Insert new site
        INSERT INTO Sites (
            AddressId, PrimaryContactId, PropertyType, Notes, Latitude, Longitude,
            Instructions, TaxTypeId, SalespersonId, SiteReferenceNumber,
            SendCompletedWoMethod, SendCompletedWoTo, Facility, FacilityType,
            SiteManagerId, ReferenceNumber, IsDeleted,
            CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
        ) VALUES (
            @AddressId, @PrimaryContactId, @PropertyType, @Notes, @Latitude, @Longitude,
            @Instructions, @TaxTypeId, @SalespersonId, @SiteReferenceNumber,
            @SendCompletedWoMethod, @SendCompletedWoTo, @Facility, @FacilityType,
            @SiteManagerId, @ReferenceNumber, @IsDeleted,
            @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
END
GO

-- Get All Sites
CREATE OR ALTER PROCEDURE GetSites
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites
    WHERE IsDeleted = 0
    ORDER BY ReferenceNumber;
END
GO

-- Get Site by ID
CREATE OR ALTER PROCEDURE GetSiteById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites
    WHERE Id = @Id AND IsDeleted = 0;
END
GO

-- Get Site by Reference Number
CREATE OR ALTER PROCEDURE GetSiteByReferenceNumber
    @ReferenceNumber NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites
    WHERE ReferenceNumber = @ReferenceNumber AND IsDeleted = 0;
END
GO

-- Get Sites by Account ID
CREATE OR ALTER PROCEDURE GetSitesByAccountId
    @AccountId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT s.* FROM Sites s
    INNER JOIN AccountSites acs ON s.Id = acs.SiteId
    WHERE acs.AccountId = @AccountId AND s.IsDeleted = 0
    ORDER BY s.ReferenceNumber;
END
GO

-- Delete Site (Soft Delete)
CREATE OR ALTER PROCEDURE DeleteSite
    @Id INT,
    @ModifiedAt DATETIME2,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Sites SET
        IsDeleted = 1,
        ModifiedAt = @ModifiedAt,
        ModifiedBy = @ModifiedBy
    WHERE Id = @Id;
END
GO

-- Check if Site Exists
CREATE OR ALTER PROCEDURE CheckSiteExists
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CAST(CASE WHEN EXISTS(SELECT 1 FROM Sites WHERE Id = @Id AND IsDeleted = 0) THEN 1 ELSE 0 END AS BIT) AS [Exists];
END
GO

-- Check if Site Reference Number Exists
CREATE OR ALTER PROCEDURE CheckSiteReferenceNumberExists
    @ReferenceNumber NVARCHAR(50),
    @ExcludeId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CAST(CASE WHEN EXISTS(
        SELECT 1 FROM Sites
        WHERE ReferenceNumber = @ReferenceNumber
        AND IsDeleted = 0
        AND (@ExcludeId IS NULL OR Id != @ExcludeId)
    ) THEN 1 ELSE 0 END AS BIT) AS [Exists];
END
GO
