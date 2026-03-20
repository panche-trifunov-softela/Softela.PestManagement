CREATE OR REPLACE FUNCTION delete_service_address(p_id INT, p_tenant_id INT)
RETURNS VOID AS $$
BEGIN
    UPDATE ServiceAddresses
    SET IsDeleted = TRUE, ModifiedAt = CURRENT_TIMESTAMP
    WHERE Id = p_id AND TenantId = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
