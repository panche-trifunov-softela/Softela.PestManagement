CREATE OR REPLACE FUNCTION insert_cfg_estimate(
    p_tenant_id   INT,
    p_name        VARCHAR,
    p_description TEXT,
    p_created_at  TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by  UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    INSERT INTO cfg_estimates (
        tenant_id, name, description, is_deleted, created_at, modified_at, created_by, modified_by
    ) VALUES (
        p_tenant_id, p_name, p_description, FALSE, p_created_at, p_modified_at, p_created_by, p_modified_by
    )
    RETURNING id INTO v_id;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
