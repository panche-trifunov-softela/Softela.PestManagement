CREATE OR REPLACE FUNCTION upsert_program(
    p_id                  INT,
    p_tenant_id           INT,
    p_estimate_id         INT,
    p_name                VARCHAR,
    p_status              BOOLEAN,
    p_notes               TEXT,
    p_start_date          TIMESTAMPTZ,
    p_end_date            TIMESTAMPTZ,
    p_renewal_date        TIMESTAMPTZ,
    p_canceled_date       TIMESTAMPTZ,
    p_pending_cancel_date TIMESTAMPTZ,
    p_frequency           SMALLINT,
    p_created_at          TIMESTAMPTZ,
    p_modified_at         TIMESTAMPTZ,
    p_created_by          UUID,
    p_modified_by         UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO programs (
            tenant_id, estimate_id, name, status, notes,
            start_date, end_date, renewal_date, canceled_date, pending_cancel_date,
            frequency, is_deleted, created_at, modified_at, created_by, modified_by
        ) VALUES (
            p_tenant_id, p_estimate_id, p_name, p_status, p_notes,
            p_start_date, p_end_date, p_renewal_date, p_canceled_date, p_pending_cancel_date,
            p_frequency, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by
        )
        RETURNING id INTO v_id;
    ELSE
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
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
