CREATE OR REPLACE FUNCTION delete_estimate(p_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE Estimates
    SET IsDeleted = TRUE, ModifiedAt = p_modified_at, ModifiedBy = p_modified_by
    WHERE Id = p_id;
END;
$$ LANGUAGE plpgsql;
