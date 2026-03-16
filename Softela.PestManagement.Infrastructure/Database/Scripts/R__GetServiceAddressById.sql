CREATE OR ALTER PROCEDURE [dbo].[GetServiceAddressById]
    @Id INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, TenantId, CustomerId, ServiceAddressName, ServiceAddressType,
        Address, City, State, Zip, ContactName, ContactPhone, ContactEmail,
        IsActive, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM ServiceAddresses
    WHERE Id = @Id AND TenantId = @TenantId AND IsDeleted = 0;
END
