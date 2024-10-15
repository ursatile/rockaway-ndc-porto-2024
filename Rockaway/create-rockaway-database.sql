PRINT @@VERSION
GO
CREATE DATABASE [rockaway] COLLATE Latin1_General_CI_AI
GO
CREATE LOGIN [rockaway_user] WITH 
	PASSWORD=N'3GX9i0F5YPmsa6', 
	DEFAULT_DATABASE=[rockaway], 
	CHECK_EXPIRATION=OFF, 
	CHECK_POLICY=OFF
GO
USE [rockaway]
GO
PRINT 'Adding user [rockaway_user] to database [rockaway]'
CREATE USER [rockaway_user] FOR LOGIN [rockaway_user]
PRINT 'Done.'
GO
PRINT 'Adding user [rockaway_user] to role [db_owner] in [rockaway] database'
ALTER ROLE [db_owner] ADD MEMBER [rockaway_user]
PRINT 'Done'
GO