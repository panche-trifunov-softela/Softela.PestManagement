CREATE INDEX ix_ops_estimates_tenant_id                    ON ops_estimates (tenant_id)                     WHERE is_deleted = FALSE;
CREATE INDEX ix_ops_estimates_tenant_id_service_address_id ON ops_estimates (tenant_id, service_address_id) WHERE is_deleted = FALSE;

CREATE INDEX ix_ops_programs_tenant_id                 ON ops_programs (tenant_id)                  WHERE is_deleted = FALSE;
CREATE INDEX ix_ops_programs_tenant_id_ops_estimate_id ON ops_programs (tenant_id, ops_estimate_id) WHERE is_deleted = FALSE;

CREATE INDEX ix_ops_events_tenant_id                ON ops_events (tenant_id)                 WHERE is_deleted = FALSE;
CREATE INDEX ix_ops_events_tenant_id_ops_program_id ON ops_events (tenant_id, ops_program_id) WHERE is_deleted = FALSE;

CREATE INDEX ix_ops_workorders_tenant_id              ON ops_workorders (tenant_id)               WHERE is_deleted = FALSE;
CREATE INDEX ix_ops_workorders_tenant_id_ops_event_id ON ops_workorders (tenant_id, ops_event_id) WHERE is_deleted = FALSE;
