CREATE OR ALTER PROCEDURE [dbo].[DeleteCustomer]
    @Id INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Customers
    SET IsDeleted = 1, ModifiedAt = GETUTCDATE()
    WHERE Id = @Id AND TenantId = @TenantId;

    UPDATE CustomerContacts
    SET IsDeleted = 1, ModifiedAt = GETUTCDATE()
    WHERE CustomerId = @Id AND TenantId = @TenantId;

    UPDATE CustomerContactPhones
    SET IsDeleted = 1, ModifiedAt = GETUTCDATE()
    WHERE CustomerContactId IN (
        SELECT Id FROM CustomerContacts WHERE CustomerId = @Id AND TenantId = @TenantId
    );
END
