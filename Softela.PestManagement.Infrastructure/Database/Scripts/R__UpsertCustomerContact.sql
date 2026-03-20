-- Converted to PostgreSQL PL/pgSQL procedure to preserve CALL behavior
CREATE OR REPLACE PROCEDURE UpsertCustomerContact(
    IN p_id INT,
    IN p_tenant_id INT,
    IN p_customer_id INT,
    IN p_contact_type VARCHAR,
    IN p_first_name VARCHAR,
    IN p_middle_name VARCHAR,
    IN p_last_name VARCHAR,
    IN p_email VARCHAR,
    IN p_alternate_emails TEXT,
    IN p_created_at TIMESTAMP,
    IN p_modified_at TIMESTAMP,
    IN p_created_by UUID,
    IN p_modified_by UUID,
    OUT result_id INT
) LANGUAGE plpgsql AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO CustomerContacts (TenantId, CustomerId, ContactType, FirstName, MiddleName, LastName,
            Email, AlternateEmails, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (p_tenant_id, p_customer_id, p_contact_type, p_first_name, p_middle_name, p_last_name,
            p_email, p_alternate_emails, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING Id INTO result_id;
    ELSE
        UPDATE CustomerContacts
        SET ContactType = p_contact_type,
            FirstName = p_first_name,
            MiddleName = p_middle_name,
            LastName = p_last_name,
            Email = p_email,
            AlternateEmails = p_alternate_emails,
            ModifiedAt = p_modified_at,
            ModifiedBy = p_modified_by
        WHERE Id = p_id AND TenantId = p_tenant_id;

        result_id := p_id;
    END IF;
END;
$$;
