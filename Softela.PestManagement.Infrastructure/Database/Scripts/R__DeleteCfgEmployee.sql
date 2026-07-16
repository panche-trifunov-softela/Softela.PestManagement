CREATE OR REPLACE FUNCTION delete_cfg_employee(
    p_id          INT,
    p_tenant_id   INT,
    p_modified_at TIMESTAMPTZ,
    p_modified_by UUID
) RETURNS VOID AS $$
BEGIN
    UPDATE cfg_employees
    SET is_deleted  = TRUE,
        modified_at = p_modified_at,
        modified_by = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id AND is_deleted = FALSE;
END;
$$ LANGUAGE plpgsql;
