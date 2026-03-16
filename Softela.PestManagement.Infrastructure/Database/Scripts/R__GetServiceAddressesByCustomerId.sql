CREATE OR ALTER PROCEDURE [dbo].[GetServiceAddressesByCustomerId]
    @CustomerId INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, TenantId, CustomerId, ServiceAddressName, ServiceAddressType,
        Address, City, State, Zip, ContactName, ContactPhone, ContactEmail,
        IsActive, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM ServiceAddresses
    WHERE CustomerId = @CustomerId AND TenantId = @TenantId AND IsDeleted = 0
    ORDER BY ServiceAddressName;
END
