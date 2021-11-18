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

CREATE TABLE dbo.Users
(
	username NVARCHAR(100) PRIMARY KEY,
  PASSWORD NVARCHAR(200) COLLATE Latin1_General_BIN2 
    ENCRYPTED WITH 
    (
       ENCRYPTION_TYPE = DETERMINISTIC, 
       ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
       COLUMN_ENCRYPTION_KEY = CEK_Auto1
    )
);
GO

CREATE TABLE dbo.UserRole
(
	username NVARCHAR(100) PRIMARY KEY,
	ROLE NVARCHAR(100),
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
  @Faculty NVARCHAR(200),
  @Password NVARCHAR(200)

AS
BEGIN
  INSERT dbo.StudentInfo(StudentCode, FullName, IDCardNo, BirthDate, Gender, Mobile, Address, Class, Faculty) 
  SELECT @StudentCode, @FullName, @IDCardNo, @BirthDate, @Gender, @Mobile, @Address, @Class, @Faculty;
  INSERT INTO  dbo.Users (username, PASSWORD) VALUES (@StudentCode, @Password);
  insert into dbo.UserRole (username, ROLE, Faculty) VALUES (@StudentCode, 'SINH VIEN', @Faculty);
END
GO
GO

drop procedure dbo.GetStudentByCode
GO


CREATE PROCEDURE dbo.GetStudentByCode
  @StudentCode NVARCHAR(32) = null,
  @Username NVARCHAR(100),
  @Userrole NVARCHAR(100)  = null,
  @Faculty NVARCHAR(200)  = null
AS
BEGIN
--SET @Userrole = (SELECT ROLE FROM dbo.UserRole WHERE username = @Username)
SELECT @Userrole=[ROLE] , @Faculty =[Faculty] FROM dbo.UserRole WHERE upper(username) = upper(@Username)
  select StudentCode	as 'Mã SV', FullName as 'Họ tên', IDCardNo as 'CMT',	BirthDate as 'Ngày sinh',	
  Gender as 'Giới tính',	Mobile	as 'Số ĐT', Address as 'Địa chỉ',	Class as 'Lớp', Faculty as 'Khoa' 
  from dbo.StudentInfo 
  where case when upper(@Userrole) = 'ADMIN' then 1
  when upper(@Userrole) = 'GIANG VIEN' and Faculty = @Faculty then 1
  when upper(@Userrole) = 'SINH VIEN' and StudentCode = @Username then 1
  else 0 end = 1
  and StudentCode = isnull(@StudentCode,StudentCode)
END
GO

drop procedure dbo.UpdateStudent
GO

CREATE PROCEDURE dbo.UpdateStudent
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
  Update dbo.StudentInfo
  set 
  StudentCode= @StudentCode,
FullName= @FullName      ,
IDCardNo= @IDCardNo      ,
BirthDate= @BirthDate    ,
Gender= @Gender          ,
Mobile= @Mobile          ,
Address= @Address        ,
Class= @Class            ,
Faculty= @Faculty        
where StudentCode = @StudentCode
END
GO


CREATE PROCEDURE dbo.GetUserByUsername
  @Username NVARCHAR(100),
  @Password NVARCHAR(200)
AS
BEGIN
  SELECT a.username, b.ROLE, b.Faculty
  FROM dbo.Users a
  left join dbo.UserRole b
  on a.username = b.username
  WHERE UPPER(a.Username) = UPPER(@Username) and PASSWORD = @Password;
END
GO

DECLARE @rvalue NVARCHAR(200) = 'admin'
INSERT INTO  dbo.Users (username, PASSWORD) VALUES ('admin', @rvalue)
;
DECLARE @rvalue1 NVARCHAR(200) = 'giangvien1'
INSERT INTO  dbo.Users (username, PASSWORD) VALUES ('giangvien1', @rvalue1)
;
DECLARE @rvalue2 NVARCHAR(200) = 'giangvien2'
INSERT INTO  dbo.Users (username, PASSWORD) VALUES ('giangvien2', @rvalue2)
;

insert into dbo.UserRole (username, ROLE, Faculty)
values ('admin', 'ADMIN', null),
('giangvien1', 'GIANG VIEN', 'CNTT'),
('giangvien2', 'GIANG VIEN', 'KINH TE')