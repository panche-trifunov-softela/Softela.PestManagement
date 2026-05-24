CREATE OR REPLACE FUNCTION get_estimates_by_service_address_id(p_service_address_id INT, p_tenant_id INT)
RETURNS TABLE (
    id INT,
    tenant_id INT,
    service_address_id INT,
    name VARCHAR,
    status SMALLINT,
    service_interest VARCHAR,
    assigned_sales_rep INT,
    source SMALLINT,
    is_deleted BOOLEAN,
    created_at TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT e.id, e.tenant_id, e.service_address_id, e.name, e.status, e.service_interest,
        e.assigned_sales_rep, e.source, e.is_deleted, e.created_at, e.modified_at,
        e.created_by, e.modified_by
    FROM estimates e
    WHERE e.service_address_id = p_service_address_id AND e.tenant_id = p_tenant_id AND e.is_deleted = FALSE
    ORDER BY e.name;
END;
$$ LANGUAGE plpgsql;
