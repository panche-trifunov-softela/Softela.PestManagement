CREATE OR REPLACE FUNCTION update_cfg_program(
    p_id          INT,
    p_tenant_id   INT,
    p_name        VARCHAR,
    p_modified_at TIMESTAMPTZ,
    p_modified_by UUID
) RETURNS INT AS $$
BEGIN
    UPDATE cfg_programs
    SET name        = p_name,
        modified_at = p_modified_at,
        modified_by = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
