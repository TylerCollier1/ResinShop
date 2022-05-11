create PROCEDURE [OrdersOver5000]
AS
BEGIN

select 
    o.OrderId,
    a.ArtId,
    c.FirstName,
    c.LastName,
    a.Cost

from [Order] o
inner join Customer c on o.CustomerId = c.CustomerId
inner join Art a on o.ArtId = a.ArtId
where a.Cost > 5000
ORDER BY a.Cost desc;

END