CREATE OR REPLACE FUNCTION upsert_customer_contact_phone(
    p_id INT,
    p_tenant_id INT,
    p_customer_contact_id INT,
    p_phone_type VARCHAR,
    p_phone_number VARCHAR,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO customer_contact_phones (tenant_id, customer_contact_id, phone_type, phone_number, is_deleted, created_at, modified_at)
        VALUES (p_tenant_id, p_customer_contact_id, p_phone_type, p_phone_number, FALSE, p_created_at, p_modified_at)
        RETURNING id INTO v_id;
    ELSE
        UPDATE customer_contact_phones
        SET phone_type = p_phone_type,
            phone_number = p_phone_number,
            modified_at = p_modified_at
        WHERE id = p_id AND tenant_id = p_tenant_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
