CREATE OR REPLACE FUNCTION get_customers_by_tenant_id(p_tenant_id INT)
RETURNS TABLE (
    id INT,
    tenant_id INT,
    customer_num VARCHAR,
    name VARCHAR,
    customer_type INT,
    is_active BOOLEAN,
    send_invoice BOOLEAN,
    email_invoice BOOLEAN,
    instructions TEXT,
    primary_note TEXT,
    registration_num VARCHAR,
    preferred_contact_method VARCHAR,
    billing_address_street VARCHAR,
    billing_address_city VARCHAR,
    billing_address_state VARCHAR,
    billing_address_zip VARCHAR,
    is_deleted BOOLEAN,
    created_at TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, tenant_id, customer_num, name, customer_type, is_active, send_invoice, email_invoice,
        instructions, primary_note, registration_num, preferred_contact_method,
        billing_address_street, billing_address_city, billing_address_state, billing_address_zip,
        is_deleted, created_at, modified_at, created_by, modified_by
    FROM customers
    WHERE tenant_id = p_tenant_id AND is_deleted = FALSE
    ORDER BY name;
END;
$$ LANGUAGE plpgsql;
