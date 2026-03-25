CREATE OR REPLACE FUNCTION delete_service_address(p_id INT, p_tenant_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE ServiceAddresses
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE Id = p_id AND TenantId = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
