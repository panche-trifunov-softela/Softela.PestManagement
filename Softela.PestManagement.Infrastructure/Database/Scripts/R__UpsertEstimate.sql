CREATE OR REPLACE FUNCTION upsert_estimate(
    p_id INT,
    p_tenant_id INT,
    p_service_address_id INT,
    p_name VARCHAR,
    p_status SMALLINT,
    p_service_interest VARCHAR,
    p_assigned_sales_rep INT,
    p_source SMALLINT,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO estimates (tenant_id, service_address_id, name, status, service_interest, assigned_sales_rep, source,
            created_at, modified_at, created_by, modified_by)
        VALUES (p_tenant_id, p_service_address_id, p_name, p_status, p_service_interest, p_assigned_sales_rep, p_source,
            p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    ELSE
        UPDATE estimates
        SET name = p_name,
            status = p_status,
            service_interest = p_service_interest,
            assigned_sales_rep = p_assigned_sales_rep,
            source = p_source,
            modified_at = p_modified_at,
            modified_by = p_modified_by
        WHERE id = p_id AND tenant_id = p_tenant_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
