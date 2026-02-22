CREATE OR ALTER PROCEDURE [dbo].[GetCustomersByTenantId]
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, TenantId, CustomerNum, Name, CustomerType, IsActive, SendInvoice, EmailInvoice,
        Instructions, PrimaryNote, RegistrationNum, PreferredContactMethod,
        BillingAddressStreet, BillingAddressCity, BillingAddressState, BillingAddressZip,
        IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Customers
    WHERE TenantId = @TenantId AND IsDeleted = 0
    ORDER BY Name;
END
