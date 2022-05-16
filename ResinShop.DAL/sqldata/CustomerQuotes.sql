ALTER PROCEDURE CustomerQuotes(
    @CustomerId AS INT
)
AS
BEGIN
    SELECT
    a.*
    FROM Art a
    INNER JOIN [Order] o on a.ArtId = o.ArtId
    INNER JOIN Customer c on o.CustomerId = c.CustomerId
    WHERE c.CustomerId = @CustomerId;
END