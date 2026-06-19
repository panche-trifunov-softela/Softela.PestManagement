CREATE INDEX ix_cfg_estimates_tenant_id ON cfg_estimates (tenant_id) WHERE is_deleted = FALSE;
CREATE INDEX ix_cfg_programs_tenant_id  ON cfg_programs  (tenant_id) WHERE is_deleted = FALSE;
CREATE INDEX ix_cfg_events_tenant_id    ON cfg_events    (tenant_id) WHERE is_deleted = FALSE;
CREATE INDEX ix_cfg_cadences_tenant_id  ON cfg_cadences  (tenant_id) WHERE is_deleted = FALSE;

CREATE INDEX ix_cfg_program_event_cadences_tenant_id                ON cfg_program_event_cadences (tenant_id)                 WHERE is_deleted = FALSE;
CREATE INDEX ix_cfg_program_event_cadences_tenant_id_cfg_program_id ON cfg_program_event_cadences (tenant_id, cfg_program_id) WHERE is_deleted = FALSE;
