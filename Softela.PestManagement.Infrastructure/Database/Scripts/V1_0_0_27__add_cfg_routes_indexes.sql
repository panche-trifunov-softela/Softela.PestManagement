CREATE INDEX ix_cfg_routes_tenant_id                 ON cfg_routes (tenant_id)                  WHERE is_deleted = FALSE;
CREATE INDEX ix_cfg_routes_tenant_id_cfg_employee_id ON cfg_routes (tenant_id, cfg_employee_id) WHERE is_deleted = FALSE;
