CREATE OR ALTER PROCEDURE [dbo].[UpsertCustomerContactPhone]
    @Id INT,
    @TenantId INT,
    @CustomerContactId INT,
    @PhoneType NVARCHAR(50),
    @PhoneNumber NVARCHAR(50),
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        INSERT INTO CustomerContactPhones (TenantId, CustomerContactId, PhoneType, PhoneNumber, IsDeleted, CreatedAt, ModifiedAt)
        OUTPUT INSERTED.Id
        VALUES (@TenantId, @CustomerContactId, @PhoneType, @PhoneNumber, 0, @CreatedAt, @ModifiedAt);
    END
    ELSE
    BEGIN
        UPDATE CustomerContactPhones
        SET PhoneType = @PhoneType,
            PhoneNumber = @PhoneNumber,
            ModifiedAt = @ModifiedAt
        WHERE Id = @Id AND TenantId = @TenantId;

        SELECT @Id;
    END
END
