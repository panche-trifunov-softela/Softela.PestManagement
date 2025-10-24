-- Site Stored Procedures Migration
-- Creates stored procedures for Site CRUD operations

-- Get Site by ID
CREATE OR ALTER PROCEDURE GetSiteById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites WHERE Id = @Id AND IsDeleted = 0;
END
GO

-- Get Sites by Account ID
CREATE OR ALTER PROCEDURE GetSitesByAccountId
    @AccountId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites
    WHERE AccountId = @AccountId AND IsDeleted = 0
    ORDER BY SiteReferenceNumber;
END
GO

-- Get All Sites
CREATE OR ALTER PROCEDURE GetAllSites
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Sites
    WHERE IsDeleted = 0
    ORDER BY SiteReferenceNumber;
END
GO

-- Delete Site (Soft Delete)
CREATE OR ALTER PROCEDURE DeleteSite
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Sites
    SET IsDeleted = 1, UtcLastChanged = GETUTCDATE()
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

-- Upsert Site (Create or Update)
CREATE OR ALTER PROCEDURE UpsertSite
    @Id INT = NULL,
    @AccountId INT,
    @AddressId INT = NULL,
    @PrimaryContactId INT = NULL,
    @PropertyType INT,
    @Notes NVARCHAR(MAX) = NULL,
    @Latitude DECIMAL(18, 15) = NULL,
    @Longitude DECIMAL(18, 15) = NULL,
    @Instructions NVARCHAR(900) = NULL,
    @TaxTypeId INT = NULL,
    @SalesPersonId INT = NULL,
    @SiteReferenceNumber NVARCHAR(255),
    @SendCompletedWoMethod SMALLINT = NULL,
    @SendCompletedWoTo SMALLINT = NULL,
    @Facility INT = NULL,
    @FacilityType INT = NULL,
    @SiteManagerId INT = NULL,
    @IsDeleted BIT,
    @CreatedBy NVARCHAR(50),
    @LastChangedBy NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id IS NOT NULL AND @Id > 0 AND EXISTS (SELECT 1 FROM Sites WHERE Id = @Id)
    BEGIN
        -- Update existing site
        UPDATE Sites SET
            AccountId = @AccountId,
            AddressId = @AddressId,
            PrimaryContactId = @PrimaryContactId,
            PropertyType = @PropertyType,
            Notes = @Notes,
            Latitude = @Latitude,
            Longitude = @Longitude,
            Instructions = @Instructions,
            TaxTypeId = @TaxTypeId,
            SalesPersonId = @SalesPersonId,
            SiteReferenceNumber = @SiteReferenceNumber,
            SendCompletedWoMethod = @SendCompletedWoMethod,
            SendCompletedWoTo = @SendCompletedWoTo,
            Facility = @Facility,
            FacilityType = @FacilityType,
            SiteManagerId = @SiteManagerId,
            IsDeleted = @IsDeleted,
            UtcLastChanged = GETUTCDATE(),
            LastChangedBy = @LastChangedBy
        WHERE Id = @Id;

        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        -- Insert new site
        INSERT INTO Sites (
            AccountId, AddressId, PrimaryContactId, PropertyType, Notes,
            Latitude, Longitude, Instructions, TaxTypeId, SalesPersonId,
            SiteReferenceNumber, SendCompletedWoMethod, SendCompletedWoTo,
            Facility, FacilityType, SiteManagerId, IsDeleted,
            UtcTimestamp, CreatedBy, UtcLastChanged, LastChangedBy
        ) VALUES (
            @AccountId, @AddressId, @PrimaryContactId, @PropertyType, @Notes,
            @Latitude, @Longitude, @Instructions, @TaxTypeId, @SalesPersonId,
            @SiteReferenceNumber, @SendCompletedWoMethod, @SendCompletedWoTo,
            @Facility, @FacilityType, @SiteManagerId, @IsDeleted,
            GETUTCDATE(), @CreatedBy, GETUTCDATE(), @LastChangedBy
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
END
GO
