CREATE OR REPLACE FUNCTION get_cfg_program_event_cadences_by_program_id(p_cfg_program_id INT, p_tenant_id INT)
RETURNS TABLE (
    id             INT,
    tenant_id      INT,
    cfg_program_id INT,
    cfg_event_id   INT,
    cfg_cadence_id INT,
    "interval"     NUMERIC,
    is_deleted     BOOLEAN,
    created_at     TIMESTAMPTZ,
    modified_at    TIMESTAMPTZ,
    created_by     UUID,
    modified_by    UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT c.id, c.tenant_id, c.cfg_program_id, c.cfg_event_id, c.cfg_cadence_id, c."interval",
        c.is_deleted, c.created_at, c.modified_at, c.created_by, c.modified_by
    FROM cfg_program_event_cadences c
    WHERE c.cfg_program_id = p_cfg_program_id AND c.tenant_id = p_tenant_id AND c.is_deleted = FALSE
    ORDER BY c.id;
END;
$$ LANGUAGE plpgsql;
