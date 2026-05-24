CREATE OR REPLACE FUNCTION get_tenant_features(p_tenant_id INT)
RETURNS TABLE (
    id INT,
    tenant_id INT,
    feature_key VARCHAR,
    is_enabled BOOLEAN,
    created_at TIMESTAMPTZ,
    modified_at TIMESTAMPTZ
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, tenant_id, feature_key, is_enabled, created_at, modified_at
    FROM tenant_features
    WHERE tenant_id = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
