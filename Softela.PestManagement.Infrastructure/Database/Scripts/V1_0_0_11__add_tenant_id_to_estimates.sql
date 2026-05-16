ALTER TABLE Estimates
    ADD COLUMN TenantId INT NOT NULL DEFAULT 0;

UPDATE Estimates e
SET TenantId = sa.TenantId
FROM ServiceAddresses sa
WHERE e.ServiceAddressId = sa.Id;

ALTER TABLE Estimates ALTER COLUMN TenantId DROP DEFAULT;

ALTER TABLE Estimates
    ADD CONSTRAINT FK_Estimates_Tenants FOREIGN KEY (TenantId) REFERENCES Tenants(Id);
