CREATE OR REPLACE PROCEDURE UpsertEstimate(
    IN p_id INT,
    IN p_tenant_id INT,
    IN p_service_address_id INT,
    IN p_name VARCHAR,
    IN p_status SMALLINT,
    IN p_service_interest VARCHAR,
    IN p_assigned_sales_rep INT,
    IN p_source SMALLINT,
    IN p_created_at TIMESTAMPTZ,
    IN p_modified_at TIMESTAMPTZ,
    IN p_created_by UUID,
    IN p_modified_by UUID,
    OUT result_id INT
) LANGUAGE plpgsql AS $$
BEGIN
    IF p_id = 0 OR p_id IS NULL THEN
        INSERT INTO Estimates (TenantId, ServiceAddressId, Name, Status, ServiceInterest, AssignedSalesRep, Source,
            CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (p_tenant_id, p_service_address_id, p_name, p_status, p_service_interest, p_assigned_sales_rep, p_source,
            p_created_at, p_modified_at, p_created_by, p_modified_by)
        RETURNING Id INTO result_id;
    ELSE
        UPDATE Estimates
        SET Name = p_name,
            Status = p_status,
            ServiceInterest = p_service_interest,
            AssignedSalesRep = p_assigned_sales_rep,
            Source = p_source,
            ModifiedAt = p_modified_at,
            ModifiedBy = p_modified_by
        WHERE Id = p_id AND TenantId = p_tenant_id;

        result_id := p_id;
    END IF;
END;
$$;
