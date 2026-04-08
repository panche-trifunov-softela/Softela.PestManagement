-- Converted to PostgreSQL PL/pgSQL function
CREATE OR REPLACE FUNCTION upsert_tenant(
    p_id INT,
    p_name VARCHAR,
    p_slug VARCHAR,
    p_is_active BOOLEAN,
    p_created_at TIMESTAMPTZ,
    p_modified_at TIMESTAMPTZ,
    p_created_by UUID,
    p_modified_by UUID
) RETURNS VOID AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO Tenants (Name, Slug, IsActive, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (p_name, p_slug, p_is_active, p_created_at, p_modified_at, p_created_by, p_modified_by);
    ELSE
        UPDATE Tenants
        SET Name = p_name,
            Slug = p_slug,
            IsActive = p_is_active,
            ModifiedAt = p_modified_at,
            ModifiedBy = p_modified_by
        WHERE Id = p_id;
    END IF;
END;
$$ LANGUAGE plpgsql;
