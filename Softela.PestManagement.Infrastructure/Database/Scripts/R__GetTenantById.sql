CREATE OR REPLACE FUNCTION get_tenant_by_id(p_id INT)
RETURNS TABLE (
    Id INT,
    Name VARCHAR,
    Slug VARCHAR,
    IsActive BOOLEAN,
    CreatedAt TIMESTAMP,
    ModifiedAt TIMESTAMP,
    CreatedBy UUID,
    ModifiedBy UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT Id, Name, Slug, IsActive, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Tenants
    WHERE Id = p_id;
END;
$$ LANGUAGE plpgsql;
