﻿CREATE TABLE BankingProductV4 (
    ProductId VARCHAR(255),
    EffectiveFrom DATETIME,
    EffectiveTo DATETIME,
    LastUpdated DATETIME,
    ProductCategory INT,
    Name VARCHAR(255),
    Description VARCHAR(255),
    Brand VARCHAR(255),
    BrandName VARCHAR(255),
    ApplicationUri VARCHAR(255),
    IsTailored BIT,
    AdditionalInformationId VARCHAR(255),
    AdditionalInfo1 VARCHAR(255),
    AdditionalInfo2 VARCHAR(255),
    Title VARCHAR(255),
    ImageUri VARCHAR(255),
    PRIMARY KEY(ProductId)
);