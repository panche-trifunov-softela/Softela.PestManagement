CREATE OR REPLACE FUNCTION update_cfg_employee(
    p_id                   INT,
    p_tenant_id            INT,
    p_name                 VARCHAR,
    p_certification_number VARCHAR,
    p_employee_number      VARCHAR,
    p_role                 SMALLINT,
    p_is_active            BOOLEAN,
    p_modified_at          TIMESTAMPTZ,
    p_modified_by          UUID
) RETURNS INT AS $$
BEGIN
    UPDATE cfg_employees
    SET name                 = p_name,
        certification_number = p_certification_number,
        employee_number      = p_employee_number,
        role                 = p_role,
        is_active            = p_is_active,
        modified_at          = p_modified_at,
        modified_by          = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
