ALTER TABLE customer_contact_phones
ADD COLUMN IF NOT EXISTS modified_by UUID;

ALTER TABLE customer_contact_phones
ADD COLUMN IF NOT EXISTS created_by UUID;
