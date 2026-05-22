CREATE OR REPLACE FUNCTION delete_estimate(p_id INT, p_modified_at TIMESTAMPTZ, p_modified_by UUID)
RETURNS VOID AS $$
BEGIN
    UPDATE estimates
    SET is_deleted = TRUE, modified_at = p_modified_at, modified_by = p_modified_by
    WHERE id = p_id;
END;
$$ LANGUAGE plpgsql;
