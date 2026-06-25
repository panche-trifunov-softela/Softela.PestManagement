CREATE OR REPLACE FUNCTION insert_cfg_program_event_cadence(
    p_tenant_id      INT,
    p_cfg_program_id INT,
    p_cfg_event_id   INT,
    p_cfg_cadence_id INT,
    p_interval       NUMERIC,
    p_created_at     TIMESTAMPTZ,
    p_modified_at    TIMESTAMPTZ,
    p_created_by     UUID,
    p_modified_by    UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    INSERT INTO cfg_program_event_cadences (
        tenant_id, cfg_program_id, cfg_event_id, cfg_cadence_id, "interval",
        is_deleted, created_at, modified_at, created_by, modified_by
    ) VALUES (
        p_tenant_id, p_cfg_program_id, p_cfg_event_id, p_cfg_cadence_id, p_interval,
        FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by
    )
    RETURNING id INTO v_id;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
