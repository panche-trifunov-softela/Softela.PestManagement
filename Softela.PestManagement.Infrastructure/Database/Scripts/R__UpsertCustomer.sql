CREATE OR REPLACE FUNCTION upsert_customer(
    p_id INT,
    p_tenant_id INT,
    p_customer_num VARCHAR,
    p_name VARCHAR,
    p_customer_type INT,
    p_is_active BOOLEAN,
    p_send_invoice BOOLEAN,
    p_email_invoice BOOLEAN,
    p_instructions TEXT,
    p_primary_note TEXT,
    p_registration_num VARCHAR,
    p_preferred_contact_method VARCHAR,
    p_billing_address_street VARCHAR,
    p_billing_address_city VARCHAR,
    p_billing_address_state VARCHAR,
    p_billing_address_zip VARCHAR,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO customers (tenant_id, customer_num, name, customer_type, is_active, send_invoice, email_invoice,
            instructions, primary_note, registration_num, preferred_contact_method,
            billing_address_street, billing_address_city, billing_address_state, billing_address_zip,
            is_deleted, created_at, modified_at, created_by, modified_by)
        VALUES (p_tenant_id, p_customer_num, p_name, p_customer_type, p_is_active, p_send_invoice, p_email_invoice,
            p_instructions, p_primary_note, p_registration_num, p_preferred_contact_method,
            p_billing_address_street, p_billing_address_city, p_billing_address_state, p_billing_address_zip,
            FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    ELSE
        UPDATE customers
        SET name = p_name,
            customer_type = p_customer_type,
            is_active = p_is_active,
            send_invoice = p_send_invoice,
            email_invoice = p_email_invoice,
            instructions = p_instructions,
            primary_note = p_primary_note,
            registration_num = p_registration_num,
            preferred_contact_method = p_preferred_contact_method,
            billing_address_street = p_billing_address_street,
            billing_address_city = p_billing_address_city,
            billing_address_state = p_billing_address_state,
            billing_address_zip = p_billing_address_zip,
            modified_at = p_modified_at,
            modified_by = p_modified_by
        WHERE id = p_id AND tenant_id = p_tenant_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
