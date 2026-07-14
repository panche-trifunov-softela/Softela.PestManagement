CREATE OR REPLACE FUNCTION insert_cfg_employee(
    p_tenant_id            INT,
    p_name                 VARCHAR,
    p_certification_number VARCHAR,
    p_employee_number      VARCHAR,
    p_role                 SMALLINT,
    p_is_active            BOOLEAN,
    p_created_at           TIMESTAMPTZ,
    p_modified_at          TIMESTAMPTZ,
    p_created_by           UUID,
    p_modified_by          UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    INSERT INTO cfg_employees (
        tenant_id, name, certification_number, employee_number, role, is_active,
        is_deleted, created_at, modified_at, created_by, modified_by
    ) VALUES (
        p_tenant_id, p_name, p_certification_number, p_employee_number, p_role, p_is_active,
        FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by
    )
    RETURNING id INTO v_id;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
