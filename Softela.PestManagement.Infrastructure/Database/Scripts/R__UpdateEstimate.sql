CREATE OR REPLACE FUNCTION update_estimate(
    p_id                 INT,
    p_tenant_id          INT,
    p_cfg_estimate_id    INT,
    p_service_address_id INT,
    p_status             SMALLINT,
    p_service_interest   VARCHAR,
    p_assigned_sales_rep INT,
    p_source             SMALLINT,
    p_modified_at        TIMESTAMPTZ,
    p_modified_by        UUID
) RETURNS INT AS $$
BEGIN
    UPDATE ops_estimates
    SET cfg_estimate_id    = p_cfg_estimate_id,
        service_address_id = p_service_address_id,
        status             = p_status,
        service_interest   = p_service_interest,
        assigned_sales_rep = p_assigned_sales_rep,
        source             = p_source,
        modified_at        = p_modified_at,
        modified_by        = p_modified_by
    WHERE id = p_id AND tenant_id = p_tenant_id;
    RETURN p_id;
END;
$$ LANGUAGE plpgsql;
