CREATE OR REPLACE FUNCTION delete_customer(p_id INT, p_tenant_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE Customers
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE Id = p_id AND TenantId = p_tenant_id;

    UPDATE CustomerContacts
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE CustomerId = p_id AND TenantId = p_tenant_id;

    UPDATE CustomerContactPhones
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE CustomerContactId IN (
        SELECT Id FROM CustomerContacts WHERE CustomerId = p_id AND TenantId = p_tenant_id
    );
END;
$$ LANGUAGE plpgsql;
