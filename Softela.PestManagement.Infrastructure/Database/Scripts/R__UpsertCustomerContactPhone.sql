-- Converted to PostgreSQL PL/pgSQL procedure to preserve CALL behavior
CREATE OR REPLACE PROCEDURE UpsertCustomerContactPhone(
    IN p_id INT,
    IN p_tenant_id INT,
    IN p_customer_contact_id INT,
    IN p_phone_type VARCHAR,
    IN p_phone_number VARCHAR,
    IN p_created_at TIMESTAMP,
    IN p_modified_at TIMESTAMP,
    OUT result_id INT
) LANGUAGE plpgsql AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO CustomerContactPhones (TenantId, CustomerContactId, PhoneType, PhoneNumber, IsDeleted, CreatedAt, ModifiedAt)
        VALUES (p_tenant_id, p_customer_contact_id, p_phone_type, p_phone_number, FALSE, p_created_at, p_modified_at)
        RETURNING Id INTO result_id;
    ELSE
        UPDATE CustomerContactPhones
        SET PhoneType = p_phone_type,
            PhoneNumber = p_phone_number,
            ModifiedAt = p_modified_at
        WHERE Id = p_id AND TenantId = p_tenant_id;

        result_id := p_id;
    END IF;
END;
$$;
