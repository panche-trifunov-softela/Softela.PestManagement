CREATE INDEX ix_programs_tenant_id             ON programs (tenant_id);
CREATE INDEX ix_programs_tenant_id_estimate_id ON programs (tenant_id, estimate_id);
