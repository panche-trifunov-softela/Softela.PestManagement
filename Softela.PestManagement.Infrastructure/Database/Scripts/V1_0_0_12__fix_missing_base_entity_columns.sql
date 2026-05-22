-- tenant_features: add missing created_by / modified_by from BaseEntity
ALTER TABLE tenant_features
    ADD COLUMN created_by UUID NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
    ADD COLUMN modified_by UUID NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE tenant_features
    ALTER COLUMN created_by DROP DEFAULT,
    ALTER COLUMN modified_by DROP DEFAULT;

-- customer_contact_phones: tighten nullable created_by / modified_by to NOT NULL
UPDATE customer_contact_phones
SET created_by  = '00000000-0000-0000-0000-000000000000'
WHERE created_by IS NULL;

UPDATE customer_contact_phones
SET modified_by = '00000000-0000-0000-0000-000000000000'
WHERE modified_by IS NULL;

ALTER TABLE customer_contact_phones
    ALTER COLUMN created_by  SET NOT NULL,
    ALTER COLUMN modified_by SET NOT NULL;
