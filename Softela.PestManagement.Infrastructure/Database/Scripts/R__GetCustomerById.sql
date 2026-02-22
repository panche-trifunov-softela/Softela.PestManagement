CREATE OR ALTER PROCEDURE [dbo].[GetCustomerById]
    @Id INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, TenantId, CustomerNum, Name, CustomerType, IsActive, SendInvoice, EmailInvoice,
        Instructions, PrimaryNote, RegistrationNum, PreferredContactMethod,
        BillingAddressStreet, BillingAddressCity, BillingAddressState, BillingAddressZip,
        IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Customers
    WHERE Id = @Id AND TenantId = @TenantId AND IsDeleted = 0;
END
