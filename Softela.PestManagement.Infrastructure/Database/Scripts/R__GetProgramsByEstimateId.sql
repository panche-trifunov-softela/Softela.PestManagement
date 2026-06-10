CREATE OR REPLACE FUNCTION get_programs_by_estimate_id(p_estimate_id INT, p_tenant_id INT)
RETURNS TABLE (
    id                  INT,
    tenant_id           INT,
    estimate_id         INT,
    name                VARCHAR,
    status              BOOLEAN,
    notes               TEXT,
    start_date          TIMESTAMPTZ,
    end_date            TIMESTAMPTZ,
    renewal_date        TIMESTAMPTZ,
    canceled_date       TIMESTAMPTZ,
    pending_cancel_date TIMESTAMPTZ,
    frequency           SMALLINT,
    is_deleted          BOOLEAN,
    created_at          TIMESTAMPTZ,
    modified_at         TIMESTAMPTZ,
    created_by          UUID,
    modified_by         UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        p.id, p.tenant_id, p.estimate_id, p.name, p.status, p.notes,
        p.start_date, p.end_date, p.renewal_date, p.canceled_date, p.pending_cancel_date,
        p.frequency, p.is_deleted, p.created_at, p.modified_at, p.created_by, p.modified_by
    FROM programs p
    WHERE p.estimate_id = p_estimate_id AND p.tenant_id = p_tenant_id AND p.is_deleted = FALSE
    ORDER BY p.name;
END;
$$ LANGUAGE plpgsql;
