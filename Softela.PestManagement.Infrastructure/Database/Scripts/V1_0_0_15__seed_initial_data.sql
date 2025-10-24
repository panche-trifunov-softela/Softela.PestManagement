-- Seed Initial Test Data
-- This script inserts default records for testing purposes

-- Check and insert default Locale if not exists
IF NOT EXISTS (SELECT 1 FROM Locales WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Locales ON;

    INSERT INTO Locales (Id, LocaleName, LocaleCode, UtcTimestamp, CreatedBy, UtcLastChanged, LastChangedBy, IsDeleted)
    VALUES (1, 'English (United States)', 'en-US', GETUTCDATE(), 'SYSTEM', GETUTCDATE(), 'SYSTEM', 0);

    SET IDENTITY_INSERT Locales OFF;
END
GO

-- Check and insert default Company if not exists
IF NOT EXISTS (SELECT 1 FROM Companies WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Companies ON;

    INSERT INTO Companies (Id, CompanyName, LocaleId, UtcTimestamp, CreatedBy, UtcLastChanged, LastChangedBy, IsActive, IsDeleted)
    VALUES (1, 'Default Company', 1, GETUTCDATE(), 'SYSTEM', GETUTCDATE(), 'SYSTEM', 1, 0);

    SET IDENTITY_INSERT Companies OFF;
END
GO
