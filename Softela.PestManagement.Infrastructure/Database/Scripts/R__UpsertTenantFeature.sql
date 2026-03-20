-- Converted to PostgreSQL PL/pgSQL procedure to preserve CALL behavior
CREATE OR REPLACE PROCEDURE UpsertTenantFeature(
    IN p_tenant_id INT,
    IN p_feature_key VARCHAR,
    IN p_is_enabled BOOLEAN,
    IN p_created_at TIMESTAMP,
    IN p_modified_at TIMESTAMP
) LANGUAGE plpgsql AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM TenantFeatures WHERE TenantId = p_tenant_id AND FeatureKey = p_feature_key) THEN
        UPDATE TenantFeatures
        SET IsEnabled = p_is_enabled,
            ModifiedAt = p_modified_at
        WHERE TenantId = p_tenant_id AND FeatureKey = p_feature_key;
    ELSE
        INSERT INTO TenantFeatures (TenantId, FeatureKey, IsEnabled, CreatedAt, ModifiedAt)
        VALUES (p_tenant_id, p_feature_key, p_is_enabled, p_created_at, p_modified_at);
    END IF;
END;
$$;
