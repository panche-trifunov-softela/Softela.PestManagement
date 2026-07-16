CREATE OR REPLACE FUNCTION update_cfg_route(
    p_id              INT,
    p_tenant_id       INT,
    p_cfg_employee_id INT,
    p_name            VARCHAR,
    p_is_active       BOOLEAN,
    p_note            TEXT,
    p_modified_at     TIMESTAMPTZ,
    p_modified_by     UUID
) RETURNS INT AS $$
BEGIN
    UPDATE cfg_routes
    SET cfg_employee_id = p_cfg_employee_id,
        name            = p_name,
        is_active       = p_is_active,
        note            = p_note,
        modified_at     = p_modified_at,
        modified_by     = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
