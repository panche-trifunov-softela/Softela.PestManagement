CREATE OR REPLACE FUNCTION insert_estimate(
    p_tenant_id          INT,
    p_cfg_estimate_id    INT,
    p_service_address_id INT,
    p_status             SMALLINT,
    p_service_interest   VARCHAR,
    p_assigned_sales_rep INT,
    p_source             SMALLINT,
    p_created_at         TIMESTAMPTZ,
    p_modified_at        TIMESTAMPTZ,
    p_created_by         UUID,
    p_modified_by        UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    INSERT INTO ops_estimates (
        tenant_id, cfg_estimate_id, service_address_id, status, service_interest,
        assigned_sales_rep, source, is_deleted, created_at, modified_at, created_by, modified_by
    ) VALUES (
        p_tenant_id, p_cfg_estimate_id, p_service_address_id, p_status, p_service_interest,
        p_assigned_sales_rep, p_source, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by
    )
    RETURNING id INTO v_id;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
