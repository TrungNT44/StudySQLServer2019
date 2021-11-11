drop table dbo.StudentInfo
GO

CREATE TABLE dbo.StudentInfo
(
  ID INT IDENTITY(1,1) PRIMARY KEY,
  StudentCode NVARCHAR(32),
  FullName NVARCHAR(500) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
    
  IDCardNo NVARCHAR(30) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = RANDOMIZED, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
	BirthDate NVARCHAR(32) COLLATE Latin1_General_BIN2 
	ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
	Gender NVARCHAR(20),
	Mobile NVARCHAR(30) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC,
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
	Address NVARCHAR(1000) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
	Class NVARCHAR(200),
	Faculty NVARCHAR(200)
);
GO

drop procedure dbo.AddStudent
GO

CREATE PROCEDURE dbo.AddStudent
  @StudentCode NVARCHAR(32),
  @FullName NVARCHAR(500),
  @IDCardNo  NVARCHAR(30),
  @BirthDate NVARCHAR(32),
  @Gender NVARCHAR(20),
  @Mobile NVARCHAR(30),
  @Address NVARCHAR(1000),
  @Class NVARCHAR(200),
  @Faculty NVARCHAR(200)

AS
BEGIN
  INSERT dbo.StudentInfo(StudentCode, FullName, IDCardNo, BirthDate, Gender, Mobile, Address, Class, Faculty) 
  SELECT @StudentCode, @FullName, @IDCardNo, @BirthDate, @Gender, @Mobile, @Address, @Class, @Faculty;
END
GO

drop procedure dbo.GetStudentByCode
GO

CREATE PROCEDURE dbo.GetStudentByCode
  @StudentCode NVARCHAR(32)
AS
BEGIN
  SELECT *
  FROM dbo.StudentInfo
  WHERE StudentCode = @StudentCode;
END
GO

---
drop table  dbo.Users
go

CREATE TABLE dbo.Users
(
	username NVARCHAR(100) PRIMARY KEY,
  PASSWORD NVARCHAR(200) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    ),
	ROLE NVARCHAR(100)
);
GO

drop procedure dbo.GetUserByUsername
go 

CREATE PROCEDURE dbo.GetUserByUsername
  @Username NVARCHAR(100),
  @Password NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM dbo.Users
  WHERE UPPER(Username) = UPPER(@Username) and PASSWORD = @Password;
END
GO

DECLARE @rvalue NVARCHAR(200) = 'admin'
INSERT INTO  dbo.Users (username, PASSWORD, ROLE) VALUES ('admin', @rvalue,  'ADMIN')
;