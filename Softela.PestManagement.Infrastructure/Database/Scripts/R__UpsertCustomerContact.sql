CREATE OR REPLACE FUNCTION upsert_customer_contact(
    p_id INT,
    p_tenant_id INT,
    p_customer_id INT,
    p_contact_type VARCHAR,
    p_first_name VARCHAR,
    p_middle_name VARCHAR,
    p_last_name VARCHAR,
    p_email VARCHAR,
    p_alternate_emails TEXT,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO customer_contacts (tenant_id, customer_id, contact_type, first_name, middle_name, last_name,
            email, alternate_emails, is_deleted, created_at, modified_at, created_by, modified_by)
        VALUES (p_tenant_id, p_customer_id, p_contact_type, p_first_name, p_middle_name, p_last_name,
            p_email, p_alternate_emails, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    ELSE
        UPDATE customer_contacts
        SET contact_type = p_contact_type,
            first_name = p_first_name,
            middle_name = p_middle_name,
            last_name = p_last_name,
            email = p_email,
            alternate_emails = p_alternate_emails,
            modified_at = p_modified_at,
            modified_by = p_modified_by
        WHERE id = p_id AND tenant_id = p_tenant_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
