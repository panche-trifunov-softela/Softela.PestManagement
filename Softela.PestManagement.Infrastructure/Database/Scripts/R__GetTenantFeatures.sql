CREATE OR ALTER PROCEDURE [dbo].[GetTenantFeatures]
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, TenantId, FeatureKey, IsEnabled, CreatedAt, ModifiedAt
    FROM TenantFeatures
    WHERE TenantId = @TenantId;
END
