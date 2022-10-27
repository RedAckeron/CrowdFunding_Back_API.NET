/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Role (Name) VALUES
('Admin'),
('Contributor'),
('Owner')

DECLARE @date DATE
DECLARE @email VARCHAR(100)
DECLARE @idUser int
DECLARE @idRole int

SET @date = '1993-09-20'
SET @email = 'm@m.m'
SET @idRole = 3

EXEC RegisterUser 'Sohak', @email, 'test1223', @date
EXEC UserRoleRegister  @email, @idRole




