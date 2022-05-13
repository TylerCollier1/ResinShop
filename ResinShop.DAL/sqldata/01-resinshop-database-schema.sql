USE master;
GO

drop database if exists ResinShop;
GO

CREATE DATABASE ResinShop;
GO

USE ResinShop;
GO

Create TABLE Customer (
    CustomerId int primary key identity(1,1),
    FirstName nvarchar(25) not null,
    LastName nvarchar(25) not null,
    Email nvarchar(50) not null,
    StreetAddress nvarchar(50) not null,
    City nvarchar(50) not null,
    StateName nvarchar(25) not null,
    ZipCode nvarchar(15) not null,
    PhoneNumber nvarchar(25) not null
)
GO

Create TABLE AdvancedFeature (
    AdvancedFeatureId int primary key identity(1,1),
    AdvancedFeatureName varchar(50) not null
)
GO

Create TABLE Art (
    ArtId int primary key identity(1,1),
    Height decimal(5,2) not null,
    Width decimal(5,2) not null,
    MaterialQuantity int not null,
    ColorQuantity int not null,
    Cost decimal(10,2) not null,
    AdvancedFeatureId int not null,
        CONSTRAINT fk_Art_AdvancedFeatureId
        foreign key(AdvancedFeatureId)
        references AdvancedFeature(AdvancedFeatureId)
)
GO

Create Table [Order] (
    OrderId int primary key identity(1,1),
    OrderDate datetime2 not null,
    CustomerId int not null,
        CONSTRAINT fk_Order_CustomerId
        foreign key(CustomerId)
         references Customer(CustomerId),
    ArtId int not null,
        CONSTRAINT fk_Order_ArtId
        foreign key(ArtId)
        references Art(ArtId)
)
GO

Create TABLE Material (
    MaterialId int primary key identity(1,1),
    MaterialName varchar(50) not null
)
GO

Create TABLE Color (
    ColorId int primary key identity(1,1),
    ColorName varchar(50) not null
)
GO

Create TABLE ArtMaterial (
    ArtId int not null, 
    CONSTRAINT fk_ArtMaterial_ArtId
        foreign key(ArtId)
         references Art(ArtId),
    MaterialId int not null,
    CONSTRAINT fk_ArtMaterial_MaterialId
        foreign key(MaterialId)
         references Material(MaterialId),
    CONSTRAINT pk_ArtMaterial primary key(ArtId, MaterialId)
)
GO

Create TABLE ArtColor (
    ArtId int not null,
    CONSTRAINT fk_ArtColor_ArtId
        foreign key(ArtId)
         references Art(ArtId),
    ColorId int not null, 
    CONSTRAINT fk_ArtColor_ColorId
        foreign key(ColorId)
         references Color(ColorId),
    CONSTRAINT pk_ArtColor primary key(ArtId, ColorId)
)
GO