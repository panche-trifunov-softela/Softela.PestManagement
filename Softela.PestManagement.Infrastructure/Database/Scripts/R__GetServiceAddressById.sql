CREATE OR REPLACE FUNCTION get_service_address_by_id(p_id INT, p_tenant_id INT)
RETURNS TABLE (
    Id INT,
    TenantId INT,
    CustomerId INT,
    ServiceAddressName VARCHAR,
    ServiceAddressType VARCHAR,
    Address VARCHAR,
    City VARCHAR,
    State VARCHAR,
    Zip VARCHAR,
    ContactName VARCHAR,
    ContactPhone VARCHAR,
    ContactEmail VARCHAR,
    IsActive BOOLEAN,
    IsDeleted BOOLEAN,
    CreatedAt TIMESTAMP,
    ModifiedAt TIMESTAMP,
    CreatedBy UUID,
    ModifiedBy UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT Id, TenantId, CustomerId, ServiceAddressName, ServiceAddressType,
        Address, City, State, Zip, ContactName, ContactPhone, ContactEmail,
        IsActive, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM ServiceAddresses
    WHERE Id = p_id AND TenantId = p_tenant_id AND IsDeleted = FALSE;
END;
$$ LANGUAGE plpgsql;
