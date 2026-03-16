CREATE OR ALTER PROCEDURE [dbo].[UpsertCustomerContact]
    @Id INT,
    @TenantId INT,
    @CustomerId INT,
    @ContactType NVARCHAR(50),
    @FirstName NVARCHAR(255),
    @MiddleName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @Email NVARCHAR(255),
    @AlternateEmails NVARCHAR(MAX),
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        INSERT INTO CustomerContacts (TenantId, CustomerId, ContactType, FirstName, MiddleName, LastName,
            Email, AlternateEmails, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        OUTPUT INSERTED.Id
        VALUES (@TenantId, @CustomerId, @ContactType, @FirstName, @MiddleName, @LastName,
            @Email, @AlternateEmails, 0, @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy);
    END
    ELSE
    BEGIN
        UPDATE CustomerContacts
        SET ContactType = @ContactType,
            FirstName = @FirstName,
            MiddleName = @MiddleName,
            LastName = @LastName,
            Email = @Email,
            AlternateEmails = @AlternateEmails,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id AND TenantId = @TenantId;

        SELECT @Id;
    END
END
