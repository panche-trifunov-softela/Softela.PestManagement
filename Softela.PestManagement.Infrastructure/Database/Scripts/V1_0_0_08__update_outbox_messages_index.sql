DROP INDEX IF EXISTS ix_outbox_messages_unprocessed;

CREATE INDEX ix_outbox_messages_unprocessed
    ON outbox_messages (occurred_at)
    WHERE processed_at IS NULL
      AND error IS NULL
      AND claimed_at IS NULL;

CREATE INDEX ix_outbox_messages_stale_claimed
    ON outbox_messages (claimed_at, occurred_at)
    WHERE processed_at IS NULL
      AND error IS NULL
      AND claimed_at IS NOT NULL;
