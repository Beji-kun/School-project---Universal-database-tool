CREATE TABLE [dbo].[Booking] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [CustomersID] int NULL, 
    [ServiceID] int NULL, 
    [TravelAgencyID] int NULL, 
    [TourID] int NULL, 
    [BookingStartDate] datetime NULL, 
    [BookingEndDate] datetime NULL, 
    [BookingStatus] bit NULL, 
    CONSTRAINT [Booking PK] PRIMARY KEY ([ID])
)
GO
CREATE TABLE [dbo].[Customers] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [FirstName] varchar(150) NULL, 
    [LastName] varchar(150) NULL, 
    [DateNumber] date NULL, 
    [PhoneNumber] varchar(150) NULL, 
    [E-mail] varchar(150) NULL, 
    [City] varchar(150) NULL, 
    [AdressName] varchar(150) NULL, 
    [AdressNumber] varchar(150) NULL, 
    [ZiPCodeID] int NULL, 
    CONSTRAINT [Client PK] PRIMARY KEY ([ID])
)
GO
CREATE TABLE [dbo].[Service] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [HotelName] varchar(150) NULL, 
    [HotelCapacity] int NULL, 
    [RestaurantNumber] varchar(50) NULL, 
    CONSTRAINT [Service PK] PRIMARY KEY ([ID])
)
GO
CREATE TABLE [dbo].[Tour] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [Location] varchar(50) NULL, 
    [TourCode] varchar(20) NULL, 
    [Payments] int NULL, 
    [PaymentsDate] datetime NULL, 
    [NightNumber] int NULL, 
    [TourType] varchar(50) NULL, 
    CONSTRAINT [Tour PK] PRIMARY KEY ([ID])
)
GO
CREATE TABLE [dbo].[TravelAgency] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [Name] varchar(150) NULL, 
    [PhoneNumber] varchar(16) NULL, 
    [WebSites] varchar(150) NULL, 
    CONSTRAINT [TravelAgency PK] PRIMARY KEY ([ID])
)
GO
CREATE TABLE [dbo].[ZipCode] ( 
    [ID] int IDENTITY(1, 1) NOT NULL, 
    [Code] int NULL, 
    CONSTRAINT [PK__ZipCode__3214EC27A9A325DF] PRIMARY KEY ([ID])
)
GO
SET IDENTITY_INSERT [dbo].[Tour] ON
GO
INSERT INTO [dbo].[Tour] ([ID], [Location], [TourCode], [Payments], [PaymentsDate], [NightNumber], [TourType]) VALUES (1, 'Italy', '12541', 25000, '2014-04-02T00:00:00.000', 3, 'Sea')
INSERT INTO [dbo].[Tour] ([ID], [Location], [TourCode], [Payments], [PaymentsDate], [NightNumber], [TourType]) VALUES (2, 'German', '25671', 21000, '2014-02-06T00:00:00.000', 4, 'Winter')

GO
SET IDENTITY_INSERT [dbo].[Tour] OFF
GO
SET IDENTITY_INSERT [dbo].[TravelAgency] ON
GO
INSERT INTO [dbo].[TravelAgency] ([ID], [Name], [PhoneNumber], [WebSites]) VALUES (2, 'Exim', '254125668', 'www.exim.cz')
INSERT INTO [dbo].[TravelAgency] ([ID], [Name], [PhoneNumber], [WebSites]) VALUES (3, 'Toursy0', '269821461', 'www.toursy.cz')
INSERT INTO [dbo].[TravelAgency] ([ID], [Name], [PhoneNumber], [WebSites]) VALUES (4, 'Cedok', '4568468916', 'www.cedok.cz')
INSERT INTO [dbo].[TravelAgency] ([ID], [Name], [PhoneNumber], [WebSites]) VALUES (5, 'StudentAgenc', '124583548', 'www.studentagency.cz')

GO
SET IDENTITY_INSERT [dbo].[TravelAgency] OFF
GO
SET IDENTITY_INSERT [dbo].[ZipCode] ON
GO
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (1, 155000)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (2, 125001)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (3, 122200)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (4, 145000)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (5, 136699)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (6, 126892)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (7, 112222)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (8, 110000)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (9, 122300)
INSERT INTO [dbo].[ZipCode] ([ID], [Code]) VALUES (10, 15550)

GO
SET IDENTITY_INSERT [dbo].[ZipCode] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON
GO
INSERT INTO [dbo].[Booking] ([ID], [CustomersID], [ServiceID], [TravelAgencyID], [TourID], [BookingStartDate], [BookingEndDate], [BookingStatus]) VALUES (2, 1, 1, 2, 1, '2014-07-18T00:00:00.000', '2014-07-25T00:00:00.000', 0)
INSERT INTO [dbo].[Booking] ([ID], [CustomersID], [ServiceID], [TravelAgencyID], [TourID], [BookingStartDate], [BookingEndDate], [BookingStatus]) VALUES (3, 2, 2, 3, 2, '2014-12-18T00:00:00.000', '2014-12-23T00:00:00.000', 1)
INSERT INTO [dbo].[Booking] ([ID], [CustomersID], [ServiceID], [TravelAgencyID], [TourID], [BookingStartDate], [BookingEndDate], [BookingStatus]) VALUES (9, 2, 2, 2, 2, '2014-06-14T00:00:00.000', '2014-06-23T00:00:00.000', 1)

GO
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
GO
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (1, 'Alan', 'Maller', '1987-01-09T00:00:00.000', '736964712', 'AlanMalller@seznam.cz', 'Praha', 'Nobelova', '1245', 1)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (2, 'Ladislav', N'Junovský', '1984-12-29T00:00:00.000', '733659111', 'LadiJun@gmail.com', 'Brno', 'Kopilova', '124', 3)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (3, 'Karel', 'Harold', '1981-09-01T00:00:00.000', '606171364', 'HoraldKarel@email.cz', N'Príbram', N'Alanská', '33', 5)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (4, 'Pepa', N'Nomádský', '1994-06-03T00:00:00.000', '602336964', 'PepNomad@centrum.cz', 'Brno', N'Aplská', '12', 4)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (5, 'Eva', N'Nobliková', '1969-02-24T00:00:00.000', '607698125', 'EvaNobl@gmail.com', 'Praha', N'Junijorská', '9', 1)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (6, 'Alice', N'Kopilová', '1958-11-17T00:00:00.000', '604336842', 'AliceKop@gmail.com', 'Praha', N'Žitná', '3', 2)
INSERT INTO [dbo].[Customers] ([ID], [FirstName], [LastName], [DateNumber], [PhoneNumber], [E-mail], [City], [AdressName], [AdressNumber], [ZiPCodeID]) VALUES (7, N'Ludvík', 'Nemec', '1967-02-22T00:00:00.000', '731221047', 'LudvikNemec@gmail.com', 'Praha', N'Motolská', '21', 10)

GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON
GO
INSERT INTO [dbo].[Service] ([ID], [HotelName], [HotelCapacity], [RestaurantNumber]) VALUES (1, 'Arinda', 15, '3')
INSERT INTO [dbo].[Service] ([ID], [HotelName], [HotelCapacity], [RestaurantNumber]) VALUES (2, 'Arinda', 15, '3')

GO
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
ALTER TABLE [dbo].[Booking] ADD CONSTRAINT [FK_Booking_TravelAgency] FOREIGN KEY ([TravelAgencyID]) REFERENCES [dbo].[TravelAgency]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Booking] ADD CONSTRAINT [FK_Booking_Service] FOREIGN KEY ([ServiceID]) REFERENCES [dbo].[Service]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Booking] ADD CONSTRAINT [FK_Booking_Tour] FOREIGN KEY ([TourID]) REFERENCES [dbo].[Tour]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Booking] ADD CONSTRAINT [FK_Booking_Customers] FOREIGN KEY ([CustomersID]) REFERENCES [dbo].[Customers]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [FK_Customers_ZipCode] FOREIGN KEY ([ZiPCodeID]) REFERENCES [dbo].[ZipCode]([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

	CREATE PROCEDURE dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO

	CREATE PROCEDURE dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO

	CREATE PROCEDURE dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO

	CREATE PROCEDURE dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO

	CREATE PROCEDURE dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO

	CREATE PROCEDURE dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO

	CREATE FUNCTION dbo.fn_diagramobjects() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	