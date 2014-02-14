USE cmd_vols;
GO
CREATE PROCEDURE dbo.insertCmdVols

		@FirstName varchar(50),
		@LastName varchar(50),
		@Phone varchar(50),
		@Mail varchar(50),
		@Address varchar(50),
		@PostalCode varchar(50),
		@City varchar(50),
		@Country varchar(50),
		@Vols_name varchar(50),
		@Vols_from varchar(50),
		@Vols_to varchar(50),
		@Vols_category varchar(50),
		@Vols_DateStart datetime,
		@Vols_DateEnd datetime,
		@Vols_Price money
AS

BEGIN
INSERT INTO cmd_vols ([client_firstname],[client_lastname],[client_phone],[client_mail],[client_address],[client_postal_code],
[client_city],[client_country],[vol_name],[vol_from],[vol_to],[vol_category],[vol_dateStart],[vol_dateEnd],[vol_price])
VALUES (@FirstName,@LastName,@Phone,@Mail,@Address,@PostalCode,@City,@Country,@Vols_name,@Vols_from,@Vols_to,@Vols_category,@Vols_DateStart, @Vols_DateEnd, @Vols_Price);
END
GO