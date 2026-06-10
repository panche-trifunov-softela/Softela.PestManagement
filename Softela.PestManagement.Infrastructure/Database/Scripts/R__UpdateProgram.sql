CREATE OR REPLACE FUNCTION update_program(
    p_id                  INT,
    p_tenant_id           INT,
    p_name                VARCHAR,
    p_status              BOOLEAN,
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
    UPDATE programs
    SET name                = p_name,
        status              = p_status,
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
