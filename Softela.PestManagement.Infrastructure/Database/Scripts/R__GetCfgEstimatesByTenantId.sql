CREATE OR REPLACE FUNCTION get_cfg_estimates_by_tenant_id(p_tenant_id INT)
RETURNS TABLE (
    id          INT,
    tenant_id   INT,
    name        VARCHAR,
    description TEXT,
    is_deleted  BOOLEAN,
    created_at  TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by  UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT c.id, c.tenant_id, c.name, c.description, c.is_deleted,
        c.created_at, c.modified_at, c.created_by, c.modified_by
    FROM cfg_estimates c
    WHERE c.tenant_id = p_tenant_id AND c.is_deleted = FALSE
    ORDER BY c.name;
END;
$$ LANGUAGE plpgsql;
