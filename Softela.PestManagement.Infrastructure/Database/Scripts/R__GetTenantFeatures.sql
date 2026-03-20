CREATE OR REPLACE FUNCTION get_tenant_features(p_tenant_id INT)
RETURNS TABLE (
    Id INT,
    TenantId INT,
    FeatureKey VARCHAR,
    IsEnabled BOOLEAN,
    CreatedAt TIMESTAMP,
    ModifiedAt TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT Id, TenantId, FeatureKey, IsEnabled, CreatedAt, ModifiedAt
    FROM TenantFeatures
    WHERE TenantId = p_tenant_id;
END;
$$ LANGUAGE plpgsql;
