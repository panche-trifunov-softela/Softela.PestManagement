INSERT INTO tenants (name, slug, is_active, created_at, modified_at, created_by, modified_by)
VALUES ('Default Tenant', 'default', TRUE, timezone('utc', now()), timezone('utc', now()), '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000');
