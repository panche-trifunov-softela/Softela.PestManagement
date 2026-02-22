CREATE OR ALTER PROCEDURE [dbo].[UpsertTenantFeature]
    @TenantId INT,
    @FeatureKey NVARCHAR(100),
    @IsEnabled BIT,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM TenantFeatures WHERE TenantId = @TenantId AND FeatureKey = @FeatureKey)
    BEGIN
        UPDATE TenantFeatures
        SET IsEnabled = @IsEnabled,
            ModifiedAt = @ModifiedAt
        WHERE TenantId = @TenantId AND FeatureKey = @FeatureKey;
    END
    ELSE
    BEGIN
        INSERT INTO TenantFeatures (TenantId, FeatureKey, IsEnabled, CreatedAt, ModifiedAt)
        VALUES (@TenantId, @FeatureKey, @IsEnabled, @CreatedAt, @ModifiedAt);
    END
END
