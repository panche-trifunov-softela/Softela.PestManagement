ALTER TABLE outbox_messages
    ADD COLUMN claimed_at TIMESTAMPTZ NULL;
