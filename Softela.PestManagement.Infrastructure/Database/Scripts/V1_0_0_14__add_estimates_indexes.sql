CREATE INDEX ix_estimates_tenant_id                    ON estimates (tenant_id);
CREATE INDEX ix_estimates_tenant_id_service_address_id ON estimates (tenant_id, service_address_id);
