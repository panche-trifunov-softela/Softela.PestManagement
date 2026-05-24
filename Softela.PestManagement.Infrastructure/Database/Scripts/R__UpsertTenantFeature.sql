CREATE OR REPLACE FUNCTION upsert_tenant_feature(
    p_tenant_id INT,
    p_feature_key VARCHAR,
    p_is_enabled BOOLEAN,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF EXISTS (SELECT 1 FROM tenant_features WHERE tenant_id = p_tenant_id AND feature_key = p_feature_key) THEN
        UPDATE tenant_features
        SET is_enabled   = p_is_enabled,
            modified_at  = p_modified_at,
            modified_by  = p_modified_by
        WHERE tenant_id = p_tenant_id AND feature_key = p_feature_key
        RETURNING id INTO v_id;
    ELSE
        INSERT INTO tenant_features (tenant_id, feature_key, is_enabled, created_at, modified_at, created_by, modified_by)
        VALUES (p_tenant_id, p_feature_key, p_is_enabled, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
