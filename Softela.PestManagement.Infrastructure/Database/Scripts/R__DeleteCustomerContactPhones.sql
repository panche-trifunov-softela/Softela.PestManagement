CREATE OR REPLACE FUNCTION delete_customer_contact_phones(p_customer_contact_id INT, p_tenant_id INT)
RETURNS VOID AS $$
BEGIN
    DELETE FROM CustomerContactPhones
    WHERE CustomerContactId = p_customer_contact_id AND TenantId = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
