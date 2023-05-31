SELECT * FROM UserType;
SELECT * FROM GuitarType;
SELECT * FROM Category;
SELECT * FROM Brand;
SELECT * FROM Guitar;
SELECT up.Id, FirstName, LastName, Email, FirebaseUserId, ut.Name
FROM UserProfile up
JOIN UserType ut ON UserTypeId = ut.Id

set identity_insert [Category] on
insert into [Category] ([Id], [Name]) VALUES
	(1, 'Guitar'),
	(2, 'Bass'),
	(3, 'Keyboard'),
	(4, 'Percussion'),
	(5, 'Amplifier'),
	(6, 'Live Audio'),
	(7, 'Accessory')
set identity_insert [Category] off


set identity_insert [UserType] on
insert into [UserType] ([Id], [Name]) VALUES
	(0, 'user'),
	(1, 'admin')
set identity_insert [UserType] off

set identity_insert [UserProfile] on
insert into [UserProfile] ([Id], [FirebaseUserId], [FirstName], [LastName], [Email], [UserTypeId]) VALUES
	(1, 'uKXetU6Yp4aNkh4qGktM59cSaqv2', 'Justin', 'Sweeten', 'jtsweeten@gmail.com', 1)
set identity_insert [UserProfile] off


set identity_insert [GuitarType] on
insert into [GuitarType] ([Id], [Name]) VALUES
	(1, 'Electric'),
	(2, 'Acoustic'),
	(3, 'Resonator'),
	(4, 'Cigar Box')
set identity_insert [GuitarType] off

insert into [Guitar] ([Id], [Name], BrandId,) VALUES
	(1, 'Electric'),
	(2, 'Acoustic'),
	(3, 'Resonator'),
	(4, 'Cigar Box')

set identity_insert [Brand] on
insert into [Brand] ([Id], [Name], Logo) VALUES
(1, 'C.F. Martin & Co.', '/data/brand-logos/Martin_guitar_logo.png'),
(2, 'Gibson'),
(3, 'Fender'),
(4, 'Taylor'),
(5, 'Ibanez'),
(6, 'Epiphone'),
(7, 'Takamine'),
(8, 'Breedlove'),
(9, 'Alvarez'),
(10, 'Seagull'),
(11, 'Jackson'),
(12, 'B.C. Rich'),
(13, 'Schecter'),
(14, 'Gretsch'),
(15, 'Rickenbacker'),
(16, 'Paul Reed Smith'),
(17, 'Yamaha'),
(18, 'ESP'),
(19, 'Squier'),
(20, 'Gretsch'),
(21, 'Washburn'),
(22, 'Ernie Ball'),
(23, 'G&L'),
(24, 'Line 6'),
(25, 'Ovation')
set identity_insert [Brand] off

set identity_insert [Guitar] on
insert into [Guitar] ([Id], [Name], BrandId, GuitarTypeId, CategoryId, Strings, NumFrets, Price, ImagePath, Used) VALUES
(1, 'Martin Grand Performance Cutaway 15ME with Performing Artist Neck', 1, 2, 1, 6, 22, 2099.99, '/data/brand-logos/Martin_guitar_logo.png', 0)
set identity_insert [Guitar] off

SELECT * FROM Guitar;