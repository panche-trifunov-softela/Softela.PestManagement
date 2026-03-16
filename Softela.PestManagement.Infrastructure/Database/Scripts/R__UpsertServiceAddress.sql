CREATE OR ALTER PROCEDURE [dbo].[UpsertServiceAddress]
    @Id INT,
    @TenantId INT,
    @CustomerId INT,
    @ServiceAddressName NVARCHAR(255),
    @ServiceAddressType NVARCHAR(50),
    @Address NVARCHAR(500),
    @City NVARCHAR(255),
    @State NVARCHAR(50),
    @Zip NVARCHAR(20),
    @ContactName NVARCHAR(255),
    @ContactPhone NVARCHAR(50),
    @ContactEmail NVARCHAR(255),
    @IsActive BIT,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        INSERT INTO ServiceAddresses (TenantId, CustomerId, ServiceAddressName, ServiceAddressType,
            Address, City, State, Zip, ContactName, ContactPhone, ContactEmail,
            IsActive, IsDeleted, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        OUTPUT INSERTED.Id
        VALUES (@TenantId, @CustomerId, @ServiceAddressName, @ServiceAddressType,
            @Address, @City, @State, @Zip, @ContactName, @ContactPhone, @ContactEmail,
            @IsActive, 0, @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy);
    END
    ELSE
    BEGIN
        UPDATE ServiceAddresses
        SET ServiceAddressName = @ServiceAddressName,
            ServiceAddressType = @ServiceAddressType,
            Address = @Address,
            City = @City,
            State = @State,
            Zip = @Zip,
            ContactName = @ContactName,
            ContactPhone = @ContactPhone,
            ContactEmail = @ContactEmail,
            IsActive = @IsActive,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id AND TenantId = @TenantId;

        SELECT @Id;
    END
END
