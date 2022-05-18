CREATE PROCEDURE [LargeArtPieces]
AS 
BEGIN

SELECT
    a.ArtId,
    c.FirstName,
    c.LastName,
    a.Height,
    a.Width
FROM [Order] o
inner join Customer c on o.CustomerId = c.CustomerId
inner join Art a on o.ArtId = a.ArtId
WHERE a.Height > 24 AND a.Width > 30
ORDER BY a.Height desc, a.Width desc;


END