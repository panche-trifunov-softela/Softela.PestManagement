ALTER TABLE estimates
    ADD COLUMN tenant_id INT NOT NULL DEFAULT 0;

UPDATE estimates e
SET tenant_id = sa.tenant_id
FROM service_addresses sa
WHERE e.service_address_id = sa.id;

ALTER TABLE estimates ALTER COLUMN tenant_id DROP DEFAULT;

ALTER TABLE estimates
    ADD CONSTRAINT fk_estimates_tenants FOREIGN KEY (tenant_id) REFERENCES tenants(id);
