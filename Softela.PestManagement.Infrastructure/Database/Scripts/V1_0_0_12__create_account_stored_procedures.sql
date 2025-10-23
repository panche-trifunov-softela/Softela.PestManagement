-- Account Stored Procedures Migration
-- Creates stored procedures for Account CRUD operations

-- Get Account by ID
CREATE OR ALTER PROCEDURE GetAccountById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Accounts WHERE Id = @Id;
END
GO

-- Get Account by Account Number
CREATE OR ALTER PROCEDURE GetAccountByAccountNum
    @AccountNum NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Accounts WHERE AccountNum = @AccountNum;
END
GO

-- Get All Accounts by Company ID
CREATE OR ALTER PROCEDURE GetAllAccounts
    @CompanyId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Accounts
    WHERE CompanyId = @CompanyId
    ORDER BY AccountNum;
END
GO

-- Search Accounts
CREATE OR ALTER PROCEDURE SearchAccounts
    @CompanyId INT,
    @SearchTerm NVARCHAR(50) = NULL,
    @IsActive SMALLINT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Accounts
    WHERE CompanyId = @CompanyId
    AND (@SearchTerm IS NULL OR AccountNum LIKE '%' + @SearchTerm + '%')
    AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY AccountNum;
END
GO

-- Delete Account
CREATE OR ALTER PROCEDURE DeleteAccount
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Accounts WHERE Id = @Id;
END
GO

-- Check if Account Exists
CREATE OR ALTER PROCEDURE CheckAccountExists
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CAST(CASE WHEN EXISTS(SELECT 1 FROM Accounts WHERE Id = @Id) THEN 1 ELSE 0 END AS BIT) AS [Exists];
END
GO

-- Check if Account Number Exists
CREATE OR ALTER PROCEDURE CheckAccountNumExists
    @AccountNum NVARCHAR(50),
    @CompanyId INT,
    @ExcludeId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CAST(CASE WHEN EXISTS(
        SELECT 1 FROM Accounts
        WHERE AccountNum = @AccountNum
        AND CompanyId = @CompanyId
        AND (@ExcludeId IS NULL OR Id != @ExcludeId)
    ) THEN 1 ELSE 0 END AS BIT) AS [Exists];
END
GO

-- Upsert Account (Create or Update)
CREATE OR ALTER PROCEDURE UpsertAccount
    @Id INT = NULL,
    @CompanyId INT,
    @AccountNum NVARCHAR(50),
    @AccountType INT,
    @BillingAddressId INT = NULL,
    @BillingContactId INT = NULL,
    @BillingCenterId INT,
    @LocaleId INT,
    @SendInvoice BIT,
    @EmailInvoice BIT,
    @SendStatement BIT,
    @EmailStatement BIT,
    @SendRenewal BIT,
    @EmailRenewal BIT,
    @MarketingEmail BIT,
    @NotificationsMail BIT,
    @Instructions NVARCHAR(900) = NULL,
    @PrimaryNote NVARCHAR(200) = NULL,
    @SecondaryNote NVARCHAR(200) = NULL,
    @Name NVARCHAR(100),
    @IsActive SMALLINT,
    @IsDeleted SMALLINT,
    @MasterAccountId INT = NULL,
    @MasterAccountSubId INT = NULL,
    @RegistrationNum NVARCHAR(15) = NULL,
    @DiscountTypeId INT = NULL,
    @AccountManagerId INT = NULL,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id IS NOT NULL AND EXISTS (SELECT 1 FROM Accounts WHERE Id = @Id)
    BEGIN
        -- Update existing account
        UPDATE Accounts SET
            CompanyId = @CompanyId,
            AccountNum = @AccountNum,
            AccountType = @AccountType,
            BillingAddressId = @BillingAddressId,
            BillingContactId = @BillingContactId,
            BillingCenterId = @BillingCenterId,
            LocaleId = @LocaleId,
            SendInvoice = @SendInvoice,
            EmailInvoice = @EmailInvoice,
            SendStatement = @SendStatement,
            EmailStatement = @EmailStatement,
            SendRenewal = @SendRenewal,
            EmailRenewal = @EmailRenewal,
            MarketingEmail = @MarketingEmail,
            NotificationsMail = @NotificationsMail,
            Instructions = @Instructions,
            PrimaryNote = @PrimaryNote,
            SecondaryNote = @SecondaryNote,
            Name = @Name,
            IsActive = @IsActive,
            IsDeleted = @IsDeleted,
            MasterAccountId = @MasterAccountId,
            MasterAccountSubId = @MasterAccountSubId,
            RegistrationNum = @RegistrationNum,
            DiscountTypeId = @DiscountTypeId,
            AccountManagerId = @AccountManagerId,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id;

        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        -- Insert new account
        INSERT INTO Accounts (
            CompanyId, AccountNum, AccountType, BillingAddressId, BillingContactId,
            BillingCenterId, LocaleId,
            SendInvoice, EmailInvoice, SendStatement, EmailStatement,
            SendRenewal, EmailRenewal, MarketingEmail, NotificationsMail,
            Instructions, PrimaryNote, SecondaryNote,
            Name, IsActive, IsDeleted, MasterAccountId, MasterAccountSubId, RegistrationNum,
            DiscountTypeId, AccountManagerId,
            CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
        ) VALUES (
            @CompanyId, @AccountNum, @AccountType, @BillingAddressId, @BillingContactId,
            @BillingCenterId, @LocaleId,
            @SendInvoice, @EmailInvoice, @SendStatement, @EmailStatement,
            @SendRenewal, @EmailRenewal, @MarketingEmail, @NotificationsMail,
            @Instructions, @PrimaryNote, @SecondaryNote,
            @Name, @IsActive, @IsDeleted, @MasterAccountId, @MasterAccountSubId, @RegistrationNum,
            @DiscountTypeId, @AccountManagerId,
            @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
END
GO
