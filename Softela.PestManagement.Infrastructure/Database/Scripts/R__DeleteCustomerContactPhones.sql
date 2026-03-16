CREATE OR ALTER PROCEDURE [dbo].[DeleteCustomerContactPhones]
    @CustomerContactId INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM CustomerContactPhones
    WHERE CustomerContactId = @CustomerContactId AND TenantId = @TenantId;
END
