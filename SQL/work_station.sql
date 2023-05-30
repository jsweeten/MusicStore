SELECT * FROM Guitar;
SELECT * FROM Category;
SELECT * FROM GuitarType;

SELECT g.[Id], b.[Name] AS Brand, g.[Name], it.[Name] AS 'Type', c.[Name] AS 'Category', Strings, NumFrets, Price, Used, ImagePath
FROM Guitar g
LEFT JOIN Brand b ON b.Id = g.BrandId
LEFT JOIN InstrumentType gt ON gt.Id = g.GuitarTypeId
LEFT JOIN Category c ON c.Id = g.CategoryId;

SELECT * FROM UserProfile;