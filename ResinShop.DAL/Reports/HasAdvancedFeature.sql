create PROCEDURE [HasAdvancedFeature]
AS
BEGIN

SELECT
    a.ArtId,
    c.FirstName,
    c.LastName,
    af.AdvancedFeatureName
FROM [Order] o
inner join Customer c on o.CustomerId = c.CustomerId
inner join Art a on o.ArtId = a.ArtId
INNER JOIN AdvancedFeature af ON a.AdvancedFeatureId = af.AdvancedFeatureId
WHERE af.AdvancedFeatureId IS NOT NULL
ORDER BY a.ArtId asc;

END
