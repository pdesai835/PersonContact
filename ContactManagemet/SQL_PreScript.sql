USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [test]    Script Date: 8/18/2018 3:29:33 PM ******/
CREATE LOGIN [test] WITH PASSWORD=N'ðh"ð<Ý¯+ifÂØí±2Î9JWQj@ È=U', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [test] ENABLE
GO


USE [PersonContactDB]
GO

/****** Object:  User [dbo]    Script Date: 8/18/2018 3:46:06 PM ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO



USE PersonContactDB;  
GRANT CONTROL ON DATABASE::PersonContactDB TO [test];  
GO 
