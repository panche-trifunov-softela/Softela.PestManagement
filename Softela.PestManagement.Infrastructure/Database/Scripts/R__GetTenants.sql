CREATE OR REPLACE FUNCTION get_tenants()
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
    ORDER BY Name;
END;
$$ LANGUAGE plpgsql;
