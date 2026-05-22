CREATE OR REPLACE FUNCTION upsert_tenant_feature(
    p_tenant_id INT,
    p_feature_key VARCHAR,
    p_is_enabled BOOLEAN,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ
) RETURNS VOID AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM tenant_features WHERE tenant_id = p_tenant_id AND feature_key = p_feature_key) THEN
        UPDATE tenant_features
        SET is_enabled = p_is_enabled,
            modified_at = p_modified_at
        WHERE tenant_id = p_tenant_id AND feature_key = p_feature_key;
    ELSE
        INSERT INTO tenant_features (tenant_id, feature_key, is_enabled, created_at, modified_at)
        VALUES (p_tenant_id, p_feature_key, p_is_enabled, p_created_at, p_modified_at);
    END IF;
END;
$$ LANGUAGE plpgsql;
