ALTER TABLE outbox_messages
    ADD COLUMN claim_token UUID NULL;
