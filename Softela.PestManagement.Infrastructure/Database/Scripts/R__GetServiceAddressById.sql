CREATE OR REPLACE FUNCTION get_service_address_by_id(p_id INT, p_tenant_id INT)
RETURNS TABLE (
    id INT,
    tenant_id INT,
    customer_id INT,
    service_address_name VARCHAR,
    service_address_type VARCHAR,
    address VARCHAR,
    city VARCHAR,
    state VARCHAR,
    zip VARCHAR,
    contact_name VARCHAR,
    contact_phone VARCHAR,
    contact_email VARCHAR,
    is_active BOOLEAN,
    is_deleted BOOLEAN,
    created_at TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, tenant_id, customer_id, service_address_name, service_address_type,
        address, city, state, zip, contact_name, contact_phone, contact_email,
        is_active, is_deleted, created_at, modified_at, created_by, modified_by
    FROM service_addresses
    WHERE id = p_id AND tenant_id = p_tenant_id AND is_deleted = FALSE;
END;
$$ LANGUAGE plpgsql;
