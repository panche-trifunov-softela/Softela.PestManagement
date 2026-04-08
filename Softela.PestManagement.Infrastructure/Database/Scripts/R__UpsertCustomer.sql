-- Converted to PostgreSQL PL/pgSQL procedure to preserve CALL behavior
CREATE OR REPLACE PROCEDURE UpsertCustomer(
    IN p_id INT,
    IN p_tenant_id INT,
    IN p_customer_num VARCHAR,
    IN p_name VARCHAR,
    IN p_customer_type INT,
    IN p_is_active BOOLEAN,
    IN p_send_invoice BOOLEAN,
    IN p_email_invoice BOOLEAN,
    IN p_instructions TEXT,
    IN p_primary_note TEXT,
    IN p_registration_num VARCHAR,
    IN p_preferred_contact_method VARCHAR,
    IN p_billing_address_street VARCHAR,
    IN p_billing_address_city VARCHAR,
    IN p_billing_address_state VARCHAR,
    IN p_billing_address_zip VARCHAR,
    IN p_created_at TIMESTAMPTZ,
    IN p_modified_at TIMESTAMPTZ,
    IN p_created_by UUID,
    IN p_modified_by UUID,
    OUT result_id INT
) LANGUAGE plpgsql AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO Customers (TenantId, CustomerNum, Name, CustomerType, IsActive, SendInvoice, EmailInvoice,
            Instructions, PrimaryNote, RegistrationNum, PreferredContactMethod,
            BillingAddressStreet, BillingAddressCity, BillingAddressState, BillingAddressZip,
            IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (p_tenant_id, p_customer_num, p_name, p_customer_type, p_is_active, p_send_invoice, p_email_invoice,
            p_instructions, p_primary_note, p_registration_num, p_preferred_contact_method,
            p_billing_address_street, p_billing_address_city, p_billing_address_state, p_billing_address_zip,
            FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING Id INTO result_id;
    ELSE
        UPDATE Customers
        SET Name = p_name,
            CustomerType = p_customer_type,
            IsActive = p_is_active,
            SendInvoice = p_send_invoice,
            EmailInvoice = p_email_invoice,
            Instructions = p_instructions,
            PrimaryNote = p_primary_note,
            RegistrationNum = p_registration_num,
            PreferredContactMethod = p_preferred_contact_method,
            BillingAddressStreet = p_billing_address_street,
            BillingAddressCity = p_billing_address_city,
            BillingAddressState = p_billing_address_state,
            BillingAddressZip = p_billing_address_zip,
            ModifiedAt = p_modified_at,
            ModifiedBy = p_modified_by
        WHERE Id = p_id AND TenantId = p_tenant_id;

        result_id := p_id;
    END IF;
END;
$$;
