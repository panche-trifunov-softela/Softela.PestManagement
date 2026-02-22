CREATE OR ALTER PROCEDURE [dbo].[UpsertCustomer]
    @Id INT,
    @TenantId INT,
    @CustomerNum NVARCHAR(50),
    @Name NVARCHAR(255),
    @CustomerType INT,
    @IsActive BIT,
    @SendInvoice BIT,
    @EmailInvoice BIT,
    @Instructions NVARCHAR(MAX),
    @PrimaryNote NVARCHAR(MAX),
    @RegistrationNum NVARCHAR(100),
    @PreferredContactMethod NVARCHAR(50),
    @BillingAddressStreet NVARCHAR(255),
    @BillingAddressCity NVARCHAR(255),
    @BillingAddressState NVARCHAR(255),
    @BillingAddressZip NVARCHAR(50),
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        INSERT INTO Customers (TenantId, CustomerNum, Name, CustomerType, IsActive, SendInvoice, EmailInvoice,
            Instructions, PrimaryNote, RegistrationNum, PreferredContactMethod,
            BillingAddressStreet, BillingAddressCity, BillingAddressState, BillingAddressZip,
            IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        OUTPUT INSERTED.Id
        VALUES (@TenantId, @CustomerNum, @Name, @CustomerType, @IsActive, @SendInvoice, @EmailInvoice,
            @Instructions, @PrimaryNote, @RegistrationNum, @PreferredContactMethod,
            @BillingAddressStreet, @BillingAddressCity, @BillingAddressState, @BillingAddressZip,
            0, @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy);
    END
    ELSE
    BEGIN
        UPDATE Customers
        SET Name = @Name,
            CustomerType = @CustomerType,
            IsActive = @IsActive,
            SendInvoice = @SendInvoice,
            EmailInvoice = @EmailInvoice,
            Instructions = @Instructions,
            PrimaryNote = @PrimaryNote,
            RegistrationNum = @RegistrationNum,
            PreferredContactMethod = @PreferredContactMethod,
            BillingAddressStreet = @BillingAddressStreet,
            BillingAddressCity = @BillingAddressCity,
            BillingAddressState = @BillingAddressState,
            BillingAddressZip = @BillingAddressZip,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id AND TenantId = @TenantId;

        SELECT @Id;
    END
END
