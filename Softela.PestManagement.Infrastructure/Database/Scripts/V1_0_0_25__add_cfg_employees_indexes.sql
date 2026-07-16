CREATE INDEX ix_cfg_employees_tenant_id ON cfg_employees (tenant_id) WHERE is_deleted = FALSE;
