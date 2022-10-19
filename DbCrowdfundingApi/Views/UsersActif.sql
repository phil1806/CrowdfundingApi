CREATE VIEW [dbo].[UsersActif]
	AS	SELECT u.Id,NickName,Birthdate,r.TypeRole AS RoleName,u.Pwd FROM Users as u INNER JOIN Roles as r ON u.IdRole = r.Id WHERE u.IsActive = 1
