DROP INDEX IF EXISTS IX_OutboxMessages_Unprocessed;

CREATE INDEX IX_OutboxMessages_Unprocessed
    ON OutboxMessages (OccurredAt)
    WHERE ProcessedAt IS NULL
      AND Error IS NULL
      AND ClaimedAt IS NULL;

CREATE INDEX IX_OutboxMessages_StaleClaimed
    ON OutboxMessages (ClaimedAt, OccurredAt)
    WHERE ProcessedAt IS NULL
      AND Error IS NULL
      AND ClaimedAt IS NOT NULL;
