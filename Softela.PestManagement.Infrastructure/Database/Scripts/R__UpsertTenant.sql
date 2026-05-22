CREATE OR REPLACE FUNCTION upsert_tenant(
    p_id INT,
    p_name VARCHAR,
    p_slug VARCHAR,
    p_is_active BOOLEAN,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS INT AS $$
DECLARE
    v_id INT;
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO tenants (name, slug, is_active, created_at, modified_at, created_by, modified_by)
        VALUES (p_name, p_slug, p_is_active, p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING id INTO v_id;
    ELSE
        UPDATE tenants
        SET name = p_name,
            slug = p_slug,
            is_active = p_is_active,
            modified_at = p_modified_at,
            modified_by = p_modified_by
        WHERE id = p_id;
        v_id := p_id;
    END IF;
    RETURN v_id;
END;
$$ LANGUAGE plpgsql;
