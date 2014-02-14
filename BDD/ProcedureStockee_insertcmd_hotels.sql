USE cmd_hotels;
GO
CREATE PROCEDURE dbo.insertCmdHotels
		@FirstName varchar(50),
		@LastName varchar(50), 
		@Phone varchar(50),
		@Mail varchar(50),
		@Address varchar(50),
		@PostalCode varchar(50),
		@City varchar(50),
		@Country varchar(50),
		@Hotels_name varchar(50),
		@Hotels_stars tinyint,
		@Hotels_address varchar(50),
		@Hotels_city varchar(50),
		@Hotels_country varchar(50),
		@Hotels_price money,
		@Hotels_dateStart datetime,
		@Hotels_dateEnd datetime
AS

BEGIN
INSERT INTO cmd_hotels([client_firstname],[client_lastname],[client_address],[client_postal_code],
[client_city],[client_country],[hotel_name],[hotel_stars],[hotel_address],[hotel_city],[hotel_country],[hotel_price],[hotel_dateStart],[hotel_dateEnd])
VALUES (@FirstName,@LastName,@Address,@PostalCode,@City,@Country,@Hotels_name,@Hotels_stars,@Hotels_address,@Hotels_city,@Hotels_country,@Hotels_price,@Hotels_dateStart, @Hotels_dateEnd);
END


GO