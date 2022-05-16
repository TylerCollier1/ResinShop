CREATE PROCEDURE [SetKnownGoodState]
AS
BEGIN
    ALTER TABLE Art DROP CONSTRAINT fk_Art_AdvancedFeatureId
    ALTER TABLE [Order] DROP CONSTRAINT fk_Order_ArtId
    ALTER TABLE [Order] DROP CONSTRAINT fk_Order_CustomerId    
    ALTER TABLE ArtColor DROP CONSTRAINT fk_ArtColor_ArtId
    ALTER TABLE ArtColor DROP CONSTRAINT fk_ArtColor_ColorId
    ALTER TABLE ArtMaterial DROP CONSTRAINT fk_ArtMaterial_MaterialId
    ALTER TABLE ArtMaterial DROP CONSTRAINT fk_ArtMaterial_ArtId

    TRUNCATE TABLE ArtMaterial;
    TRUNCATE TABLE ArtColor;
    TRUNCATE TABLE [Order];
    TRUNCATE TABLE Color;
    TRUNCATE TABLE Material;
    TRUNCATE TABLE Art;
    TRUNCATE TABLE AdvancedFeature;
    TRUNCATE TABLE Customer;

    ALTER TABLE Art ADD CONSTRAINT fk_Art_AdvancedFeatureId
        foreign key(AdvancedFeatureId)
        references AdvancedFeature(AdvancedFeatureId)
    ALTER TABLE [Order] ADD CONSTRAINT fk_Order_CustomerId
        foreign key(CustomerId)
         references Customer(CustomerId)
    ALTER TABLE [Order] ADD CONSTRAINT fk_Order_ArtId
        foreign key(ArtId)
        references Art(ArtId)
    ALTER TABLE ArtMaterial ADD CONSTRAINT fk_ArtMaterial_ArtId
        foreign key(ArtId)
         references Art(ArtId)
    ALTER TABLE ArtMaterial ADD CONSTRAINT fk_ArtMaterial_MaterialId
        foreign key(MaterialId)
         references Material(MaterialId)
    ALTER TABLE ArtColor ADD CONSTRAINT fk_ArtColor_ArtId
        foreign key(ArtId)
         references Art(ArtId)
    ALTER TABLE ArtColor ADD CONSTRAINT fk_ArtColor_ColorId
        foreign key(ColorId)
         references Color(ColorId)


--Customer
INSERT INTO Customer (FirstName, LastName, Email, StreetAddress, City, StateName, ZipCode, PhoneNumber)
    VALUES
    ('Adeline', 'Fulcher', 'afulcher4@tiny.cc', '58164 Algoma Hill', 'Cleveland', 'OH', 44105, 2164319017),
    ('Allix', 'Brett', 'abrett5@marriott.com', '7533 Truax Alley', 'Flushing', 'NY', 11388, 3476959606),
    ('Bastien', 'Pusill', 'bpusillj@dion.ne.jp', '404 Trailsway Circle',	'Sacramento', 'CA',	9581391, 66977842);

--Adv Feature
INSERT INTO AdvancedFeature (AdvancedFeatureName)
    VALUES
    ('2-piece'),
    ('3-piece'),
    ('floating gem'),
    ('none');

--Art
INSERT INTO Art (Height, Width, MaterialQuantity, ColorQuantity, AdvancedFeatureId, Cost)
    VALUES
    (15.00, 23.00, 1, 1, 1, 948.75),
    (35.00, 53.00, 1, 1, 2, 5101.25),
    (55.00, 36.00, 1, 1, 3, 5445.00);

--Order
INSERT INTO [Order] (CustomerId, ArtId, OrderDate)
    VALUES
    (1, 1, '2021-07-02'),
    (2, 2, '2021-08-03'),
    (3, 3, '2021-09-04');

--Material
INSERT INTO Color (ColorName)
    VALUES 
    ('Red'),
    ('Pink'),
    ('White'),
    ('Gold');

--Color
INSERT INTO Material (MaterialId, MaterialName)
    VALUES
    ('Glass'),
    ('Gem'),
    ('Shimmer'),
    ('Stone');


--ArtColor
INSERT INTO ArtColor (ArtId, ColorId)
    VALUES 
    (1, 3),
    (2,	2),
    (3,	1);

--ArtMaterial
INSERT INTO ArtMaterial (ArtId, MaterialId)
    VALUES
    (1, 3),
    (2,	2),
    (3,	1);


END