CREATE OR REPLACE FUNCTION get_cfg_employee_by_id(p_id INT, p_tenant_id INT)
RETURNS TABLE (
    id                   INT,
    tenant_id            INT,
    name                 VARCHAR,
    certification_number VARCHAR,
    employee_number      VARCHAR,
    role                 SMALLINT,
    is_active            BOOLEAN,
    is_deleted           BOOLEAN,
    created_at           TIMESTAMPTZ,
    modified_at          TIMESTAMPTZ,
    created_by           UUID,
    modified_by          UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT c.id, c.tenant_id, c.name, c.certification_number, c.employee_number, c.role, c.is_active,
        c.is_deleted, c.created_at, c.modified_at, c.created_by, c.modified_by
    FROM cfg_employees c
    WHERE c.id = p_id AND c.tenant_id = p_tenant_id AND c.is_deleted = FALSE;
END;
$$ LANGUAGE plpgsql;
