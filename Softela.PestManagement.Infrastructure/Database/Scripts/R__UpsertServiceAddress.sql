-- Converted to PostgreSQL PL/pgSQL procedure to preserve CALL behavior
CREATE OR REPLACE PROCEDURE UpsertServiceAddress(
    IN p_id INT,
    IN p_tenant_id INT,
    IN p_customer_id INT,
    IN p_service_address_name VARCHAR,
    IN p_service_address_type VARCHAR,
    IN p_address VARCHAR,
    IN p_city VARCHAR,
    IN p_state VARCHAR,
    IN p_zip VARCHAR,
    IN p_contact_name VARCHAR,
    IN p_contact_phone VARCHAR,
    IN p_contact_email VARCHAR,
    IN p_is_active BOOLEAN,
    IN p_created_at TIMESTAMP,
    IN p_modified_at TIMESTAMP,
    IN p_created_by UUID,
    IN p_modified_by UUID,
    OUT result_id INT
) LANGUAGE plpgsql AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO ServiceAddresses (TenantId, CustomerId, ServiceAddressName, ServiceAddressType,
            Address, City, State, Zip, ContactName, ContactPhone, ContactEmail,
            IsActive, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (p_tenant_id, p_customer_id, p_service_address_name, p_service_address_type,
            p_address, p_city, p_state, p_zip, p_contact_name, p_contact_phone, p_contact_email,
            p_is_active, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING Id INTO result_id;
    ELSE
        UPDATE ServiceAddresses
        SET ServiceAddressName = p_service_address_name,
            ServiceAddressType = p_service_address_type,
            Address = p_address,
            City = p_city,
            State = p_state,
            Zip = p_zip,
            ContactName = p_contact_name,
            ContactPhone = p_contact_phone,
            ContactEmail = p_contact_email,
            IsActive = p_is_active,
            ModifiedAt = p_modified_at,
            ModifiedBy = p_modified_by
        WHERE Id = p_id AND TenantId = p_tenant_id;

        result_id := p_id;
    END IF;
END;
$$;
