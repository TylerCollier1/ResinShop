ALTER PROCEDURE CustomerInfo(
    @CustomerId AS INT
)
AS
BEGIN
    SELECT
    c.*,
    a.*,
    o.OrderDate,
    o.OrderId
    FROM Customer c
    INNER JOIN [Order] o on c.CustomerId = o.CustomerId
    INNER JOIN Art a on o.ArtId = a.ArtId
    WHERE c.CustomerId = @CustomerId;
END
