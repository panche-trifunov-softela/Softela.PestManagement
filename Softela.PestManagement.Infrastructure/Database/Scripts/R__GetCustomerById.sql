-- Function to return a single customer by id and tenant id
CREATE OR REPLACE FUNCTION get_customer_by_id(p_id INT, p_tenant_id INT)
RETURNS TABLE (
    Id INT,
    TenantId INT,
    CustomerNum VARCHAR,
    Name VARCHAR,
    CustomerType INT,
    IsActive BOOLEAN,
    SendInvoice BOOLEAN,
    EmailInvoice BOOLEAN,
    Instructions TEXT,
    PrimaryNote TEXT,
    RegistrationNum VARCHAR,
    PreferredContactMethod VARCHAR,
    BillingAddressStreet VARCHAR,
    BillingAddressCity VARCHAR,
    BillingAddressState VARCHAR,
    BillingAddressZip VARCHAR,
    IsDeleted BOOLEAN,
    CreatedAt TIMESTAMPTZ,
    ModifiedAt TIMESTAMPTZ,
    CreatedBy UUID,
    ModifiedBy UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT Id, TenantId, CustomerNum, Name, CustomerType, IsActive, SendInvoice, EmailInvoice,
        Instructions, PrimaryNote, RegistrationNum, PreferredContactMethod,
        BillingAddressStreet, BillingAddressCity, BillingAddressState, BillingAddressZip,
        IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Customers
    WHERE Id = p_id AND TenantId = p_tenant_id AND IsDeleted = FALSE;
END;
$$ LANGUAGE plpgsql;

-- Note: callers can use SELECT * FROM get_customer_by_id(p_id, p_tenant_id).

-- Note: Callers should use SELECT * FROM get_customer_by_id(p_id, p_tenant_id) if expecting result sets.
