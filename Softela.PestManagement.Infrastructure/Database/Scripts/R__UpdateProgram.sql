-- Parameter p_status was renamed to p_is_active; CREATE OR REPLACE cannot rename input parameters, so drop the old signature first.
DROP FUNCTION IF EXISTS update_program(INT, INT, INT, INT, BOOLEAN, TEXT, TIMESTAMPTZ, TIMESTAMPTZ, TIMESTAMPTZ, TIMESTAMPTZ, TIMESTAMPTZ, SMALLINT, TIMESTAMPTZ, UUID);

CREATE OR REPLACE FUNCTION update_program(
    p_id                  INT,
    p_tenant_id           INT,
    p_ops_estimate_id     INT,
    p_cfg_program_id      INT,
    p_is_active           BOOLEAN,
    p_notes               TEXT,
    p_start_date          TIMESTAMPTZ,
    p_end_date            TIMESTAMPTZ,
    p_renewal_date        TIMESTAMPTZ,
    p_canceled_date       TIMESTAMPTZ,
    p_pending_cancel_date TIMESTAMPTZ,
    p_frequency           SMALLINT,
    p_modified_at         TIMESTAMPTZ,
    p_modified_by         UUID
) RETURNS INT AS $$
BEGIN
    UPDATE ops_programs
    SET cfg_program_id      = p_cfg_program_id,
        ops_estimate_id     = p_ops_estimate_id,
        is_active           = p_is_active,
        notes               = p_notes,
        start_date          = p_start_date,
        end_date            = p_end_date,
        renewal_date        = p_renewal_date,
        canceled_date       = p_canceled_date,
        pending_cancel_date = p_pending_cancel_date,
        frequency           = p_frequency,
        modified_at         = p_modified_at,
        modified_by         = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
