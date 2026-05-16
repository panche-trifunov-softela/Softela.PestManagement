CREATE OR REPLACE FUNCTION get_estimates_by_service_address_id(p_service_address_id INT, p_tenant_id INT)
RETURNS TABLE (
    Id INT,
    TenantId INT,
    ServiceAddressId INT,
    Name VARCHAR,
    Status SMALLINT,
    ServiceInterest VARCHAR,
    AssignedSalesRep INT,
    Source SMALLINT,
    IsDeleted BOOLEAN,
    CreatedAt TIMESTAMPTZ,
    ModifiedAt TIMESTAMPTZ,
    CreatedBy UUID,
    ModifiedBy UUID
) AS $$
BEGIN
    RETURN QUERY
    SELECT e.Id, e.TenantId, e.ServiceAddressId, e.Name, e.Status, e.ServiceInterest,
        e.AssignedSalesRep, e.Source, e.IsDeleted, e.CreatedAt, e.ModifiedAt,
        e.CreatedBy, e.ModifiedBy
    FROM Estimates e
    WHERE e.ServiceAddressId = p_service_address_id AND e.TenantId = p_tenant_id AND e.IsDeleted = FALSE
    ORDER BY e.Name;
END;
$$ LANGUAGE plpgsql;
