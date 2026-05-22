CREATE OR REPLACE FUNCTION get_tenants()
RETURNS TABLE (
    id INT,
    name VARCHAR,
    slug VARCHAR,
    is_active BOOLEAN,
    created_at TIMESTAMPTZ,
    modified_at TIMESTAMPTZ,
    created_by UUID,
    modified_by UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT id, name, slug, is_active, created_at, modified_at, created_by, modified_by
    FROM tenants
    ORDER BY name;
END;
$$ LANGUAGE plpgsql;
