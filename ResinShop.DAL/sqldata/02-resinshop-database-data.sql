use ResinShop;

SELECT * FROM Temp;

--Customer
SELECT DISTINCT first_name, last_name, email, phone, address, city, zipcode
FROM TEMP;

INSERT INTO Customer (FirstName, LastName, Email, StreetAddress, City, StateName, ZipCode, PhoneNumber)
    SELECT DISTINCT first_name, last_name, email, address, city, state, zipcode, phone
    FROM TEMP;

select * from Customer;

--AdvanceFeature
SELECT DISTINCT adv_feature
from TEMP;

INSERT INTO AdvancedFeature (AdvancedFeatureName)
    SELECT DISTINCT adv_feature
    from TEMP;

select * from AdvancedFeature;

--Art
SELECT DISTINCT t.height, t.width, t.mat_quantity, t.color_quantity, t.cost, af.AdvancedFeatureId
from Temp t 
inner join AdvancedFeature af on t.adv_feature = af.AdvancedFeatureName;

INSERT INTO Art (Height, Width, MaterialQuantity, ColorQuantity, Cost, AdvancedFeatureId)
    SELECT DISTINCT t.height, t.width, t.mat_quantity, t.color_quantity, t.cost, af.AdvancedFeatureId
from Temp t 
inner join AdvancedFeature af on t.adv_feature = af.AdvancedFeatureName;

select * from Art;

--Order
SELECT DISTINCT c.CustomerId, t.order_date, a.ArtId
FROM TEMP t 
inner join Customer c on t.first_name = c.FirstName
left outer join Art a on t.cost = a.Cost;

INSERT INTO [Order] (CustomerId, OrderDate, ArtId)
SELECT DISTINCT c.CustomerId, t.order_date, a.ArtId
FROM TEMP t 
inner join Customer c on t.first_name = c.FirstName
left outer join Art a on t.cost = a.Cost;

SELECT * FROM [Order];

--Material
SELECT DISTINCT material
from TEMP;

INSERT INTO Material (MaterialName)
SELECT DISTINCT material
from TEMP;

SELECT * FROM Material;


--Color 
SELECT DISTINCT color
from TEMP;

INSERT INTO Color (ColorName)
SELECT DISTINCT color
from TEMP;

SELECT * FROM COLOR;

--ARTMATERIAL
SELECT DISTINCT a.ArtId, m.MaterialId
from Temp t
left outer join Art a on t.cost = a.Cost
left outer join Material m on t.material = m.MaterialName;

INSERT INTO ArtMaterial (ArtId, MaterialId)
SELECT DISTINCT a.ArtId, m.MaterialId
from Temp t
left outer join Art a on t.cost = a.Cost
left outer join Material m on t.material = m.MaterialName;

SELECT * FROM ArtMaterial;

--ARTCOLOR
SELECT DISTINCT a.ArtId, c.ColorId
from Temp t
left outer join Art a on t.cost = a.Cost
left outer join Color c on t.color = c.ColorName;

INSERT INTO ArtColor (ArtId, ColorId)
SELECT DISTINCT a.ArtId, c.ColorId
from Temp t
left outer join Art a on t.cost = a.Cost
left outer join Color c on t.color = c.ColorName;

SELECT * FROM ArtColor;