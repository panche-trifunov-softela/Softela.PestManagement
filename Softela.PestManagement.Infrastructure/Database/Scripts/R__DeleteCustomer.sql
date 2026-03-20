CREATE OR REPLACE FUNCTION delete_customer(p_id INT, p_tenant_id INT)
RETURNS VOID AS $$
BEGIN
    UPDATE Customers
    SET IsDeleted = TRUE, ModifiedAt = CURRENT_TIMESTAMP
    WHERE Id = p_id AND TenantId = p_tenant_id;

    UPDATE CustomerContacts
    SET IsDeleted = TRUE, ModifiedAt = CURRENT_TIMESTAMP
    WHERE CustomerId = p_id AND TenantId = p_tenant_id;

    UPDATE CustomerContactPhones
    SET IsDeleted = TRUE, ModifiedAt = CURRENT_TIMESTAMP
    WHERE CustomerContactId IN (
        SELECT Id FROM CustomerContacts WHERE CustomerId = p_id AND TenantId = p_tenant_id
    );
END;
$$ LANGUAGE plpgsql;
