CREATE OR REPLACE FUNCTION delete_customer_contact_phones(p_customer_contact_id INT, p_tenant_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE customer_contact_phones
    SET is_deleted = TRUE, modified_at = p_modified_at, modified_by = p_modified_by
    WHERE customer_contact_id = p_customer_contact_id AND tenant_id = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
