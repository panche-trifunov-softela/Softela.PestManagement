CREATE OR REPLACE FUNCTION delete_customer_contact_phones(p_customer_contact_id INT, p_tenant_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE CustomerContactPhones
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE CustomerContactId = p_customer_contact_id AND TenantId = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
