ALTER PROCEDURE OrderDisplayInfo
AS
BEGIN
    SELECT
    o.OrderId,
    o.OrderDate,
    c.FirstName,
    c.LastName,
    a.Height,
    a.Width,
    a.Cost
    FROM Art a
    INNER JOIN [Order] o on a.ArtId = o.ArtId
    INNER JOIN Customer c on o.CustomerId = c.CustomerId;
END