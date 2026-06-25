CREATE OR REPLACE FUNCTION get_cfg_cadence_by_id(p_id INT, p_tenant_id INT)
RETURNS TABLE (
    id          INT,
    tenant_id   INT,
    name        VARCHAR,
    is_deleted  BOOLEAN,
    created_at  TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by  UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT c.id, c.tenant_id, c.name, c.is_deleted,
        c.created_at, c.modified_at, c.created_by, c.modified_by
    FROM cfg_cadences c
    WHERE c.id = p_id AND c.tenant_id = p_tenant_id AND c.is_deleted = FALSE;
END;
$$ LANGUAGE plpgsql;
