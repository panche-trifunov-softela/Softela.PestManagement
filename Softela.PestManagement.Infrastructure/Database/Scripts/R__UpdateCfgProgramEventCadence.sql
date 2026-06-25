CREATE OR REPLACE FUNCTION update_cfg_program_event_cadence(
    p_id             INT,
    p_tenant_id      INT,
    p_cfg_program_id INT,
    p_cfg_event_id   INT,
    p_cfg_cadence_id INT,
    p_interval       NUMERIC,
    p_modified_at    TIMESTAMPTZ,
    p_modified_by    UUID
) RETURNS INT AS $$
BEGIN
    UPDATE cfg_program_event_cadences
    SET cfg_program_id = p_cfg_program_id,
        cfg_event_id   = p_cfg_event_id,
        cfg_cadence_id = p_cfg_cadence_id,
        "interval"     = p_interval,
        modified_at    = p_modified_at,
        modified_by    = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
