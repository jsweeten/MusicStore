SELECT * FROM UserType;
SELECT * FROM GuitarType;
SELECT * FROM Category;
SELECT * FROM Brand;
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