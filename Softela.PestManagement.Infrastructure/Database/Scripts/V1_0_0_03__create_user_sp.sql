IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'UserId')
BEGIN
    ALTER TABLE Users
    ADD UserId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID();
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'CreatedAt')
BEGIN
    ALTER TABLE Users
    ADD CreatedAt DATETIME2 NOT NULL,
        ModifiedAt DATETIME2 NOT NULL;
END
GO

DROP PROCEDURE IF EXISTS UpsertUser;
GO

CREATE OR ALTER PROCEDURE InsertUser
    @UserId UNIQUEIDENTIFIER,
    @UserName NVARCHAR(256),
    @NormalizedUserName NVARCHAR(256),
    @Email NVARCHAR(256),
    @NormalizedEmail NVARCHAR(256),
    @EmailConfirmed BIT,
    @PasswordHash NVARCHAR(MAX),
    @IsActive BIT,
    @IsDeleted BIT,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Users (UserId, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, IsActive, IsDeleted, CreatedAt, ModifiedAt)
    VALUES (@UserId, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @IsActive, @IsDeleted, @CreatedAt, @ModifiedAt);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
END
GO