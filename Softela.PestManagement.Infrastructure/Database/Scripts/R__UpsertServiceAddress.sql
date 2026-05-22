CREATE OR REPLACE FUNCTION upsert_service_address(
    p_id INT,
    p_tenant_id INT,
    p_customer_id INT,
    p_service_address_name VARCHAR,
    p_service_address_type VARCHAR,
    p_address VARCHAR,
    p_city VARCHAR,
    p_state VARCHAR,
    p_zip VARCHAR,
    p_contact_name VARCHAR,
    p_contact_phone VARCHAR,
    p_contact_email VARCHAR,
    p_is_active BOOLEAN,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO service_addresses (tenant_id, customer_id, service_address_name, service_address_type,
            address, city, state, zip, contact_name, contact_phone, contact_email,
            is_active, is_deleted, created_at, modified_at, created_by, modified_by)
        VALUES (p_tenant_id, p_customer_id, p_service_address_name, p_service_address_type,
            p_address, p_city, p_state, p_zip, p_contact_name, p_contact_phone, p_contact_email,
            p_is_active, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    ELSE
        UPDATE service_addresses
        SET service_address_name = p_service_address_name,
            service_address_type = p_service_address_type,
            address = p_address,
            city = p_city,
            state = p_state,
            zip = p_zip,
            contact_name = p_contact_name,
            contact_phone = p_contact_phone,
            contact_email = p_contact_email,
            is_active = p_is_active,
            modified_at = p_modified_at,
            modified_by = p_modified_by
        WHERE id = p_id AND tenant_id = p_tenant_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
