-- TenantFeatures: add missing CreatedBy / ModifiedBy from BaseEntity
ALTER TABLE TenantFeatures
    ADD COLUMN CreatedBy UUID NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
    ADD COLUMN ModifiedBy UUID NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE TenantFeatures
    ALTER COLUMN CreatedBy DROP DEFAULT,
    ALTER COLUMN ModifiedBy DROP DEFAULT;

-- CustomerContactPhones: tighten nullable CreatedBy / ModifiedBy to NOT NULL
UPDATE CustomerContactPhones
SET CreatedBy  = '00000000-0000-0000-0000-000000000000'
WHERE CreatedBy IS NULL;

UPDATE CustomerContactPhones
SET ModifiedBy = '00000000-0000-0000-0000-000000000000'
WHERE ModifiedBy IS NULL;

ALTER TABLE CustomerContactPhones
    ALTER COLUMN CreatedBy  SET NOT NULL,
    ALTER COLUMN ModifiedBy SET NOT NULL;
