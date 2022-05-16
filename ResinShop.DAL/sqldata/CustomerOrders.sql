ALTER PROCEDURE CustomerOrders(
    @CustomerId AS INT
)
AS
BEGIN
    SELECT
    o.OrderId,
    o.OrderDate,
    a.Height,
    a.Width,
    a.Cost,
    a.ArtId
    FROM Art a
    INNER JOIN [Order] o on a.ArtId = o.ArtId
    INNER JOIN Customer c on o.CustomerId = c.CustomerId
    WHERE c.CustomerId = @CustomerId;
END