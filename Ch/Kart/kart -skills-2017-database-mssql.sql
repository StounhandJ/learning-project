	/*CREATE DATABASE Karting */
	USE [Karting]
	GO
	/****** Object:  Table [dbo].[Charity]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Charity](
		[ID_Сharity] [int] IDENTITY(1,1) NOT NULL,
		[Charity_Name] [nvarchar](100) NOT NULL,
		[Charity_Description] [nvarchar](3000) NULL,
		[Charity_Logo] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Charity] PRIMARY KEY CLUSTERED 
	(
		[ID_Сharity] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Country]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Country](
		[ID_Country] [nchar](3) NOT NULL,
		[Country_Name] [varchar](50) NOT NULL,
		[Country_Flag] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_contry] PRIMARY KEY CLUSTERED 
	(
		[ID_Country] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Event]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Event](
		[ID_Event] [int] IDENTITY(1,1) NOT NULL,
		[Event_Name] [nvarchar](50) NOT NULL,
		[ID_EventType] [nchar](5) NOT NULL,
		[ID_Race] [int] NOT NULL,
		[StartDateTime] [datetime] NOT NULL,
		[Cost] [decimal](10, 2) NOT NULL,
		[MaxParticipants] [smallint] NOT NULL,
	 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
	(
		[ID_Event] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Event_Type]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Event_Type](
		[ID_Event_type] [nchar](5) NOT NULL,
		[Event_Type_Name] [varchar](80) NOT NULL,
	 CONSTRAINT [PK_Event_Type_1] PRIMARY KEY CLUSTERED 
	(
		[ID_Event_type] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Gender]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Gender](
		[ID_Gender] [nchar](1) NOT NULL,
		[Gender_Name] [varchar](50) NULL,
	 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
	(
		[ID_Gender] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Race]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Race](
		[ID_Race] [int] IDENTITY(1,1) NOT NULL,
		[Race_Name] [varchar](80) NOT NULL,
		[Sity] [varchar](50) NOT NULL,
		[ID_Country] [nchar](3) NOT NULL,
		[Year_Held] [smallint] NOT NULL,
	 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
	(
		[ID_Race] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Racer]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Racer](
		[ID_Racer] [int] IDENTITY(1,1) NOT NULL,
		[First_Name] [nvarchar](50) NOT NULL,
		[Last_Name] [nvarchar](50) NOT NULL,
		[Gender] [nchar](1) NOT NULL,
		[DateOfBirth] [date] NOT NULL,
		[ID_Country] [nchar](3) NOT NULL,
		[Photo] [nvarchar](255) NULL,
	 CONSTRAINT [PK_Racer] PRIMARY KEY CLUSTERED 
	(
		[ID_Racer] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Registration]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Registration](
		[ID_Registration] [int] IDENTITY(1,1) NOT NULL,
		[ID_Racer] [int] NOT NULL,
		[Registration_Date] [date] NOT NULL,
		[ID_Registration_Status] [int] NOT NULL,
		[Cost] [decimal](10, 2) NOT NULL,
		[ID_Charity] [int] NOT NULL,
		[SponsorshipTarget] [decimal](10, 2) NOT NULL,
	 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
	(
		[ID_Registration] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Registration_Status]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Registration_Status](
		[ID_Registration_Status] [int] IDENTITY(1,1) NOT NULL,
		[Statu_Name] [varchar](80) NOT NULL,
	 CONSTRAINT [PK_Registration_Status] PRIMARY KEY CLUSTERED 
	(
		[ID_Registration_Status] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Result]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Result](
		[ID_Result] [int] IDENTITY(1,1) NOT NULL,
		[ID_Registration] [int] NOT NULL,
		[ID_Event] [int] NOT NULL,
		[BidNumber] [smallint] NOT NULL,
		[RaceTime] [time](7) NOT NULL,
	 CONSTRAINT [PK_RegistrationEvent] PRIMARY KEY CLUSTERED 
	(
		[ID_Result] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Role]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	SET ANSI_PADDING ON
	GO
	CREATE TABLE [dbo].[Role](
		[ID_Role] [nchar](1) NOT NULL,
		[Role_Name] [varchar](50) NULL,
	 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
	(
		[ID_Role] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET ANSI_PADDING OFF
	GO
	/****** Object:  Table [dbo].[Sponsorship]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Sponsorship](
		[ID_Sponsorship] [int] IDENTITY(1,1) NOT NULL,
		[SponsorName] [nvarchar](150) NOT NULL,
		[Amount] [decimal](10, 2) NULL,
	 CONSTRAINT [PK_Sponsorship] PRIMARY KEY CLUSTERED 
	(
		[ID_Sponsorship] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[User]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[User](
		[Email] [nvarchar](100) NOT NULL,
		[Password] [nvarchar](100) NOT NULL,
		[First_Name] [nvarchar](30) NULL,
		[Last_Name] [nvarchar](30) NULL,
		[ID_Role] [nchar](1) NULL
	) ON [PRIMARY]

	GO
	/****** Object:  Table [dbo].[Volunteer]    Script Date: 18.10.2016 22:12:18 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[Volunteer](
		[ID_Volunteer] [nchar](3) NOT NULL,
		[First_Name] [nvarchar](80) NOT NULL,
		[Last_Name] [nvarchar](80) NOT NULL,
		[ID_Country] [nchar](3) NOT NULL,
		[Gender_ID] [nchar](1) NULL,
	 CONSTRAINT [PK_Volunteer] PRIMARY KEY CLUSTERED 
	(
		[ID_Volunteer] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	SET IDENTITY_INSERT [dbo].[Charity] ON 

	INSERT [dbo].[Charity] ([ID_Сharity], [Charity_Name], [Charity_Description], [Charity_Logo]) VALUES (1, N'Bill & Melinda Gates Foundation', N'Bill & Melinda Gates Foundation is the largest private foundation in the world, founded by Bill and Melinda Gates. It was launched in 2000 and is said to be the largest transparently operated private foundation in the world. The primary aims of the foundation are, globally, to enhance healthcare and reduce extreme poverty, and in America, to expand educational opportunities and access to information technology. The foundation, based in Seattle, Washington, is controlled by its three trustees: Bill Gates, Melinda Gates and Warren Buffett. Other principal officers include Co-Chair William H. Gates, Sr. and Chief Executive Officer Susan Desmond-Hellmann.', N'Gayts-Foundation.png')
	INSERT [dbo].[Charity] ([ID_Сharity], [Charity_Name], [Charity_Description], [Charity_Logo]) VALUES (2, N'GAVI', N'GAVI or Global Alliance for Vaccines and Immunization is a public-private global health partnership committed to increasing access to immunisation in poor countries', N'GAVI.png')
	INSERT [dbo].[Charity] ([ID_Сharity], [Charity_Name], [Charity_Description], [Charity_Logo]) VALUES (3, N'The Red Cross', N'Relief in times of crisis, care when it''s needed most and commitment when others turn away. Red Cross is there for people in need, no matter who you are, no matter where you live.

	The Red Cross Red Crescent Movement helps tens of millions of people around the world each year and we also care for local communities in our local country and further afield.

	With millions of volunteers worldwide and thousands of members, volunteers and supporters, we can reach people and places like nobody else.', N'Red-Cross.png')
	INSERT [dbo].[Charity] ([ID_Сharity], [Charity_Name], [Charity_Description], [Charity_Logo]) VALUES (5, N'Oxfam International', N'Oxfam is an international confederation of 17 organizations working together with partners and local communities in more than 90 countries.', N'oxfam-international-logo.png')
	INSERT [dbo].[Charity] ([ID_Сharity], [Charity_Name], [Charity_Description], [Charity_Logo]) VALUES (7, N'Querstadtein Berlin', N'Querstadtein is the first project of Stadtsichten e.V., a registered non-profit association.', N'querstadtein-logo.png')
	SET IDENTITY_INSERT [dbo].[Charity] OFF
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'AND', N'Andorra', N'flag_andorra.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ARG', N'Argentina', N'flag_argentina.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'AUS', N'Australia', N'flag_australia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'AUT', N'Austria', N'flag_austria.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'BEL', N'Belgium', N'flag_belgium.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'BOT', N'Botswana', N'flag_botswana.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'BRA', N'Brazil', N'flag_brazil.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'BUL', N'Bulgaria', N'flag_bulgaria.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CAF', N'Central African Republic', N'flag_central_african_republic.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CAN', N'Canada', N'flag_canada.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CHI', N'Chile', N'flag_chile.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CHN', N'China', N'flag_china.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CIV', N'Ivory Coast', N'flag_ivory_coast.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CMR', N'Cameroon', N'flag_cameroon.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'COL', N'Colombia', N'flag_colombia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CRO', N'Croatia', N'flag_croatia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'CZE', N'Czech Republic', N'flag_czech_republic.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'DEN', N'Denmark', N'flag_denmark.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'DOM', N'Dominican Republic', N'flag_dominican_republic.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ECU', N'Ecuador', N'flag_ecuador.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'EGY', N'Egypt', N'flag_egypt.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ESA', N'El Salvador', N'flag_el_salvador.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ESP', N'Spain', N'flag_spain.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'EST', N'Estonia', N'flag_estonia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'FIN', N'Finland', N'flag_finland.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'FRA', N'France', N'flag_france.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GBR', N'United Kingdom', N'flag_united_kingdom.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GBS', N'Guinea-Bissau', N'flag_guinea.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GEQ', N'Equatorial Guinea', N'flag_equatorial_guinea.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GER', N'Germany', N'flag_germany.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GRE', N'Greece', N'flag_greece.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GUA', N'Guatemala', N'flag_guatemala.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'GUI', N'Guinea', N'flag_guinea-bissau.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'HKG', N'Hong Kong', N'flag_hong_kong.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'HON', N'Honduras', N'flag_honduras.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'HUN', N'Hungary', N'flag_hungary.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'INA', N'Indonesia', N'flag_indonesia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'IND', N'India', N'flag_india.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'IRL', N'Ireland', N'flag_ireland.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ISR', N'Israel', N'flag_israel.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ITA', N'Italy', N'flag_italy.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'JAM', N'Jamaica', N'flag_jamaica.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'JOR', N'Jordan', N'flag_jordan.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'JPN', N'Japan', N'flag_japan.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'KEN', N'Kenya', N'flag_kenya.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'KOR', N'South Korea', N'flag_south_korea.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'KSA', N'Saudi Arabia', N'flag_saudi_arabia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'LAT', N'Latvia', N'flag_latvia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'LIE', N'Liechtenstein', N'flag_liechtenstein.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'LTU', N'Lithuania', N'flag_lithuania.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'LUX', N'Luxembourg', N'flag_luxembourg.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MAC', N'Macau', N'flag_macau.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MAD', N'Madagascar', N'flag_madagascar.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MAS', N'Malaysia', N'flag_malaysia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MDA', N'Moldova', N'flag_moldova.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MEX', N'Mexico', N'flag_mexico.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MKD', N'Macedonia', N'flag_macedonia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MLI', N'Mali', N'flag_mali.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MLT', N'Malta', N'flag_malta.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MNE', N'Montenegro', N'flag_montenegro.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MON', N'Monaco', N'flag_monaco.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'MRI', N'Mauritius', N'flag_mauritius.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'NCA', N'Nicaragua', N'flag_nicaragua.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'NED', N'Netherlands', N'flag_netherlands.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'NIG', N'Niger', N'flag_niger.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'NOR', N'Norway', N'flag_norway.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'NZL', N'New Zealand', N'flag_new_zealand.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'PAN', N'Panama', N'flag_panama.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'PAR', N'Paraguay', N'flag_paraguay.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'PER', N'Peru', N'flag_peru.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'PHI', N'Philippines', N'flag_philippines.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'POL', N'Poland', N'flag_poland.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'POR', N'Portugal', N'flag_portugal.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'PUR', N'Puerto Rico', N'flag_puerto_rico.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'QAT', N'Qatar', N'flag_qatar.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'ROU', N'Romania', N'flag_romania.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'RSA', N'South Africa', N'flag_south_africa.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'RUS', N'Russia', N'flag_russia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'SEN', N'Senegal', N'flag_senegal.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'SIN', N'Singapore', N'flag_singapore.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'SUI', N'Switzerland', N'flag_switzerland.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'SVK', N'Slovakia', N'flag_slovakia.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'SWE', N'Sweden', N'flag_sweden.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'THA', N'Thailand', N'flag_thailand.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'TPE', N'Chinese Taipei', N'flag_chinese_taipei.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'TUR', N'Turkey', N'flag_turkey.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'UAE', N'United Arab Emirates', N'flag_united_arab_emirates.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'URU', N'Uruguay', N'flag_uruguay.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'USA', N'United States', N'flag_usa.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'VAT', N'Vatican', N'flag_vatican.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'VEN', N'Venezuela', N'flag_venezuela.png')
	INSERT [dbo].[Country] ([ID_Country], [Country_Name], [Country_Flag]) VALUES (N'VIE', N'Vietnam', N'flag_vietnam.png')
	SET IDENTITY_INSERT [dbo].[Event] ON 

	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (1, N'Cairo 2.5KM Race', N'2.5KM', 4, CAST(0x0000A45E00000000 AS DateTime), CAST(5000.00 AS Decimal(10, 2)), 15)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (2, N'
	Giza desert 6.5KM Race', N'6.5KM', 4, CAST(0x0000A46600000000 AS DateTime), CAST(8000.00 AS Decimal(10, 2)), 10)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (4, N'Red Send 4KM Race  ', N'4KM  ', 4, CAST(0x0000A45700000000 AS DateTime), CAST(6500.00 AS Decimal(10, 2)), 7)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (5, N'Rio 6.5KM Race', N'6.5KM', 10, CAST(0x0000A38A00000000 AS DateTime), CAST(2700.00 AS Decimal(10, 2)), 10)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (7, N'Rio''s Beach 4KM Race', N'4KM  ', 10, CAST(0x0000A38300000000 AS DateTime), CAST(3500.00 AS Decimal(10, 2)), 6)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (8, N'Carnaval 2.5KM Race', N'2.5KM', 10, CAST(0x0000A38E00000000 AS DateTime), CAST(12000.00 AS Decimal(10, 2)), 15)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (9, N'Around of Paris 6.5KM Race', N'6.5KM', 11, CAST(0x0000A29B00000000 AS DateTime), CAST(4000.00 AS Decimal(10, 2)), 4)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (10, N'Place Carrousel 2.5KM Race', N'2.5KM', 11, CAST(0x0000A29500000000 AS DateTime), CAST(3000.00 AS Decimal(10, 2)), 7)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (13, N'Munich 2.5KM Race', N'2.5KM', 1, CAST(0x0000A10E00000000 AS DateTime), CAST(4500.00 AS Decimal(10, 2)), 8)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (15, N'BMW Factory 4KM Race', N'4KM  ', 1, CAST(0x0000A11500000000 AS DateTime), CAST(7000.00 AS Decimal(10, 2)), 10)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (19, N'Olympiaturm 6.5 KM', N'6.5KM', 1, CAST(0x0000A10700000000 AS DateTime), CAST(3500.00 AS Decimal(10, 2)), 4)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (20, N'Red Race 4KM', N'4KM  ', 14, CAST(0x0000A6A300000000 AS DateTime), CAST(6000.00 AS Decimal(10, 2)), 8)
	INSERT [dbo].[Event] ([ID_Event], [Event_Name], [ID_EventType], [ID_Race], [StartDateTime], [Cost], [MaxParticipants]) VALUES (21, N'Moscow Сity 2.5KM Race', N'2.5KM', 14, CAST(0x0000A6A600000000 AS DateTime), CAST(3500.00 AS Decimal(10, 2)), 6)
	SET IDENTITY_INSERT [dbo].[Event] OFF
	INSERT [dbo].[Event_Type] ([ID_Event_type], [Event_Type_Name]) VALUES (N'2.5KM', N'2.5km Race')
	INSERT [dbo].[Event_Type] ([ID_Event_type], [Event_Type_Name]) VALUES (N'4KM  ', N'4km Race')
	INSERT [dbo].[Event_Type] ([ID_Event_type], [Event_Type_Name]) VALUES (N'6.5KM', N'6.5km Race')
	INSERT [dbo].[Gender] ([ID_Gender], [Gender_Name]) VALUES (N'F', N'Female
	')
	INSERT [dbo].[Gender] ([ID_Gender], [Gender_Name]) VALUES (N'M', N'Male')
	SET IDENTITY_INSERT [dbo].[Race] ON 

	INSERT [dbo].[Race] ([ID_Race], [Race_Name], [Sity], [ID_Country], [Year_Held]) VALUES (1, N'Kart Skills 2012', N'Munich', N'GER', 2012)
	INSERT [dbo].[Race] ([ID_Race], [Race_Name], [Sity], [ID_Country], [Year_Held]) VALUES (4, N'Kart Skills 2013', N'Cairo', N'EGY', 2015)
	INSERT [dbo].[Race] ([ID_Race], [Race_Name], [Sity], [ID_Country], [Year_Held]) VALUES (10, N'Kart Skills 2014', N'Rio de Janeiro', N'BRA', 2014)
	INSERT [dbo].[Race] ([ID_Race], [Race_Name], [Sity], [ID_Country], [Year_Held]) VALUES (11, N'Kars Skills 2015', N'Paris', N'FRA', 2013)
	INSERT [dbo].[Race] ([ID_Race], [Race_Name], [Sity], [ID_Country], [Year_Held]) VALUES (14, N'Kart Skills 2016', N'Moscow', N'RUS', 2016)
	SET IDENTITY_INSERT [dbo].[Race] OFF
	SET IDENTITY_INSERT [dbo].[Racer] ON 

	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (7, N'Liam', N'Jeferson', N'M', CAST(0x3B200B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (8, N'Anna', N'Ivanova', N'F', CAST(0x06190B00 AS Date), N'RUS')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (9, N'Irakly', N'Vahsha', N'M', CAST(0x6E170B00 AS Date), N'ISR')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (10, N'Ernest', N'Huano', N'M', CAST(0xDB110B00 AS Date), N'ESP')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (11, N'Gamlet', N'Sertio', N'M', CAST(0xEA060B00 AS Date), N'ITA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (12, N'Christian', N'Neel', N'M', CAST(0x960E0B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (13, N'Enrice', N'Mussoliny', N'M', CAST(0xB4140B00 AS Date), N'ITA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (16, N'Lui', N'Andersen', N'M', CAST(0x5D050B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (19, N'Enrike', N'Atlandes', N'M', CAST(0xD70F0B00 AS Date), N'ARG')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (20, N'Angela', N'Smith', N'F', CAST(0xC8010B00 AS Date), N'FRA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (21, N'Lucius', N'Marko', N'M', CAST(0x5E120B00 AS Date), N'ESP')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (23, N'Andrey', N'Mishkevich', N'M', CAST(0x79170B00 AS Date), N'CZE')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (26, N'Rita', N'Skitter', N'F', CAST(0xCB120B00 AS Date), N'AUT')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (27, N'Yamato', N'Zi', N'M', CAST(0x3E0F0B00 AS Date), N'JPN')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (28, N'Kuriko', N'Perno', N'F', CAST(0x51120B00 AS Date), N'ESP')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (29, N'Viktor', N'Zulinc', N'M', CAST(0x140D0B00 AS Date), N'CZE')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (30, N'Elen', N'Huso', N'F', CAST(0x2D050B00 AS Date), N'ARG')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (33, N'Ahmad', N'Adkin', N'M', CAST(0xD7020B00 AS Date), N'IRL')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (34, N'Alphonso', N'Allison', N'M', CAST(0xC40C0B00 AS Date), N'SVK')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (36, N'Alfreda', N'BURNHAM', N'F', CAST(0x0B080B00 AS Date), N'MAD')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (37, N'April', N'Bitsuile', N'F', CAST(0xF21D0B00 AS Date), N'CHI')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (40, N'Aron', N'Brooks', N'M', CAST(0xE1130B00 AS Date), N'MEX')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (41, N'Angel', N'Candlish', N'F', CAST(0x89000B00 AS Date), N'CMR')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (42, N'Austin', N'Crews', N'M', CAST(0xBE0F0B00 AS Date), N'GRE')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (43, N'Alisha', N'Conard', N'F', CAST(0x62000B00 AS Date), N'JAM')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (44, N'Anika', N'Crockett', N'F', CAST(0x651A0B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (45, N'Brian', N'Lipke', N'M', CAST(0xF6090B00 AS Date), N'PHI')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (46, N'Bryan', N'Mccoy', N'M', CAST(0x8D060B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (48, N'Chiquita', N'Cline', N'F', CAST(0xE3160B00 AS Date), N'HKG')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (51, N'Cruz', N'Cook', N'F', CAST(0xC20F0B00 AS Date), N'KEN')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (55, N'Charlie', N'Mcknight', N'F', CAST(0x460D0B00 AS Date), N'TPE')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (57, N'Gus', N'Titus', N'M', CAST(0x8D020B00 AS Date), N'AUS')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (58, N'Hugh', N'Bourbon', N'M', CAST(0x25FD0A00 AS Date), N'URU')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (59, N'Robin', N'Carmona', N'M', CAST(0x38090B00 AS Date), N'SIN')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (60, N'Simon', N'Steoud', N'M', CAST(0x59000B00 AS Date), N'KOR')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (61, N'Zora', N'Chapman', N'F', CAST(0x36080B00 AS Date), N'GBR')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (62, N'Waldo', N'Marby', N'M', CAST(0x4B100B00 AS Date), N'MAC')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (63, N'Willy', N'Spears', N'M', CAST(0x3CFE0A00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (64, N'Vera', N'Prado', N'F', CAST(0x2E120B00 AS Date), N'MEX')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (66, N'Valeria', N'Sahagun', N'F', CAST(0xBA020B00 AS Date), N'URU')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (68, N'Raley', N'Steel', N'M', CAST(0xE5060B00 AS Date), N'ESA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (69, N'Harry', N'Miller', N'M', CAST(0x41140B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (70, N'Eva', N'Miller', N'F', CAST(0x83170B00 AS Date), N'USA')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (71, N'Adam', N'Vergon', N'M', CAST(0x45F80A00 AS Date), N'ARG')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (72, N'Vahshee', N'Ahoul', N'M', CAST(0xF6000B00 AS Date), N'IND')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (73, N'Gretta', N'Veljor', N'F', CAST(0x4A010B00 AS Date), N'GER')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (75, N'Arman', N'Durs', N'M', CAST(0x5F0D0B00 AS Date), N'IRL')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (76, N'Uki', N'Cumoto', N'F', CAST(0xE51C0B00 AS Date), N'JPN')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (78, N'Agnus', N'Wert', N'M', CAST(0x2B0D0B00 AS Date), N'TPE')
	INSERT [dbo].[Racer] ([ID_Racer], [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country]) VALUES (79, N'Jerom', N'Votye', N'M', CAST(0x05110B00 AS Date), N'FRA')
	SET IDENTITY_INSERT [dbo].[Racer] OFF
	SET IDENTITY_INSERT [dbo].[Registration] ON 

	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (1, 7, CAST(0x143A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 1, CAST(500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (4, 8, CAST(0x0B3A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 3, CAST(1500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (7, 9, CAST(0x713A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(700.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (8, 10, CAST(0x273A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(863.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (9, 11, CAST(0xD43A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 7, CAST(439.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (12, 12, CAST(0x75390B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 5, CAST(752.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (13, 13, CAST(0xEE390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 7, CAST(600.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (14, 16, CAST(0x833A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 5, CAST(800.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (15, 19, CAST(0x96390B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 1, CAST(420.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (16, 20, CAST(0x80390B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 3, CAST(750.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (18, 21, CAST(0x98390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 3, CAST(500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (19, 23, CAST(0x0C3A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 5, CAST(350.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (21, 26, CAST(0xC03A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(400.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (23, 27, CAST(0xEC390B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 1, CAST(250.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (27, 28, CAST(0x163A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 3, CAST(1000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (28, 29, CAST(0x8D390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 7, CAST(850.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (29, 30, CAST(0xE6390B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (30, 33, CAST(0x9F390B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 2, CAST(150.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (31, 34, CAST(0xD7390B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 1, CAST(650.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (32, 36, CAST(0x423A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 5, CAST(2500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (33, 37, CAST(0x5C3A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 3, CAST(280.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (34, 40, CAST(0xDB3A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 7, CAST(1000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (35, 41, CAST(0xE3390B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 1, CAST(780.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (36, 42, CAST(0x163A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 3, CAST(560.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (37, 43, CAST(0xC3390B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 5, CAST(800.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (39, 44, CAST(0x143A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 2, CAST(580.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (40, 45, CAST(0xA8390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 1, CAST(400.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (41, 46, CAST(0x463A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(1800.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (42, 48, CAST(0xD23A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 7, CAST(4000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (43, 51, CAST(0x8A3A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 2, CAST(100.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (44, 55, CAST(0xDB3A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 3, CAST(600.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (45, 57, CAST(0xF8390B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 5, CAST(400.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (46, 59, CAST(0x343A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 7, CAST(1350.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (48, 60, CAST(0x6B3A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 1, CAST(2100.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (49, 61, CAST(0xE63A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(200.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (50, 62, CAST(0x503A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 5, CAST(180.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (51, 63, CAST(0x2F3A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 3, CAST(1200.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (52, 64, CAST(0x003A0B00 AS Date), 2, CAST(15.00 AS Decimal(10, 2)), 1, CAST(520.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (56, 66, CAST(0xAC3A0B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 7, CAST(100.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (57, 68, CAST(0xFA3A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 3, CAST(280.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (58, 69, CAST(0x343A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 5, CAST(2100.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (59, 70, CAST(0x6F390B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 2, CAST(1100.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (60, 71, CAST(0x153A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 3, CAST(400.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (62, 72, CAST(0x71390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 5, CAST(600.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (63, 73, CAST(0x4E3A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 7, CAST(320.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (64, 75, CAST(0xC5390B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 1, CAST(840.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (65, 76, CAST(0x303A0B00 AS Date), 3, CAST(15.00 AS Decimal(10, 2)), 2, CAST(1900.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (66, 78, CAST(0xC6390B00 AS Date), 1, CAST(15.00 AS Decimal(10, 2)), 3, CAST(1500.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (67, 79, CAST(0x513A0B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 7, CAST(2200.00 AS Decimal(10, 2)))
	INSERT [dbo].[Registration] ([ID_Registration], [ID_Racer], [Registration_Date], [ID_Registration_Status], [Cost], [ID_Charity], [SponsorshipTarget]) VALUES (68, 58, CAST(0x89390B00 AS Date), 4, CAST(15.00 AS Decimal(10, 2)), 1, CAST(280.00 AS Decimal(10, 2)))
	SET IDENTITY_INSERT [dbo].[Registration] OFF
	SET IDENTITY_INSERT [dbo].[Registration_Status] ON 

	INSERT [dbo].[Registration_Status] ([ID_Registration_Status], [Statu_Name]) VALUES (1, N'Registered')
	INSERT [dbo].[Registration_Status] ([ID_Registration_Status], [Statu_Name]) VALUES (2, N'
	Payment Confirmed')
	INSERT [dbo].[Registration_Status] ([ID_Registration_Status], [Statu_Name]) VALUES (4, N'Race Attended')
	SET IDENTITY_INSERT [dbo].[Registration_Status] OFF
	SET IDENTITY_INSERT [dbo].[Result] ON 

	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (1, 1, 1, 1, CAST(0x0700EB5375690000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (2, 4, 1, 12, CAST(0x07808D916E010000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (3, 7, 2, 23, CAST(0x07807BFCB6000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (5, 8, 4, 4, CAST(0x0780D06B75000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (7, 9, 4, 25, CAST(0x0780BCCC96000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (8, 1, 2, 1, CAST(0x07009928BB000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (9, 28, 15, 31, CAST(0x0780BF8882000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (10, 12, 19, 19, CAST(0x07803A2CD7000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (11, 13, 5, 34, CAST(0x0780FFD3CE000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (14, 12, 2, 66, CAST(0x0780FFD3CE000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (16, 13, 10, 9, CAST(0x07002F6859000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (17, 37, 21, 65, CAST(0x07002F6859000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (18, 40, 9, 32, CAST(0x070001B2C4000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (19, 50, 4, 11, CAST(0x0700180D8F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (20, 7, 2, 23, CAST(0x07005ED0B2000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (21, 1, 4, 14, CAST(0x07002F6859000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (22, 68, 2, 15, CAST(0x07005ED0B2000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (23, 34, 7, 16, CAST(0x0700D2496B000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (24, 41, 1, 17, CAST(0x07005ED0B2000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (25, 36, 21, 18, CAST(0x07002F6859000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (26, 37, 20, 19, CAST(0x0700180D8F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (27, 35, 15, 20, CAST(0x0700180D8F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (28, 48, 7, 21, CAST(0x0700371789000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (29, 63, 4, 66, CAST(0x0780734D87000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (30, 60, 9, 54, CAST(0x070001B2C4000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (31, 41, 4, 87, CAST(0x078027128C000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (32, 32, 13, 98, CAST(0x070078E768000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (33, 57, 20, 53, CAST(0x078054438D000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (36, 64, 10, 63, CAST(0x0700180D8F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (37, 63, 19, 96, CAST(0x07802FC1BB000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (38, 39, 21, 42, CAST(0x0780D06B75000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (39, 58, 7, 72, CAST(0x07003D8F60000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (41, 44, 8, 56, CAST(0x07004BB667000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (43, 37, 2, 44, CAST(0x07801B22DD000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (44, 29, 15, 87, CAST(0x0700A5186A000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (45, 27, 21, 89, CAST(0x0700322445000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (46, 8, 15, 49, CAST(0x078095136D000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (47, 9, 20, 54, CAST(0x07802ACE77000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (50, 30, 9, 38, CAST(0x07800DFBD5000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (52, 27, 19, 55, CAST(0x0780EF756F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (54, 41, 10, 1, CAST(0x0780E14E68000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (55, 21, 2, 99, CAST(0x070090F4F7000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (56, 39, 5, 456, CAST(0x0780C737B2000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (57, 40, 1, 693, CAST(0x0700C7DE4F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (58, 29, 8, 12, CAST(0x07801373AD000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (59, 33, 21, 54, CAST(0x078030464F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (60, 7, 10, 66, CAST(0x0700B33F71000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (61, 4, 13, 45, CAST(0x0780AEA58F000000 AS Time))
	INSERT [dbo].[Result] ([ID_Result], [ID_Registration], [ID_Event], [BidNumber], [RaceTime]) VALUES (62, 19, 9, 71, CAST(0x078080EFFA000000 AS Time))
	SET IDENTITY_INSERT [dbo].[Result] OFF
	INSERT [dbo].[Role] ([ID_Role], [Role_Name]) VALUES (N'A', N'Administrator')
	INSERT [dbo].[Role] ([ID_Role], [Role_Name]) VALUES (N'C', N'Coordinator')
	INSERT [dbo].[Role] ([ID_Role], [Role_Name]) VALUES (N'R', N'Racer')
	SET IDENTITY_INSERT [dbo].[Sponsorship] ON 

	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (1, N'Angel Jhons', CAST(180.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (2, N'Uri Kovrov', CAST(25.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (3, N'Asha Timbert', CAST(150.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (4, N'Artur Genby', CAST(1000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (5, N'Gely Brick', CAST(290.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (6, N'Bondy Black', CAST(236.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (7, N'Ban Trick', CAST(8000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (8, N'Oliver Greds', CAST(5200.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (9, N'Grindel Frool', CAST(15000.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (10, N'Emanuel Rick', CAST(50.00 AS Decimal(10, 2)))
	INSERT [dbo].[Sponsorship] ([ID_Sponsorship], [SponsorName], [Amount]) VALUES (11, N'Elena Tvordova', CAST(150.00 AS Decimal(10, 2)))
	SET IDENTITY_INSERT [dbo].[Sponsorship] OFF
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'L.Jeferson@gmail.com', N'$1Qr3%9%r', N'Liam', N'Jeferson', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Ivanova@gmail.com', N'%pO53f', N'Anna', N'Ivanova', N'A')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'I.Vahsha@gmail.com', N'34@7jpG', N'Irakly', N'Vahsha', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'E.Huano@gmail.com', N'72%V876^sE$', N'Ernest', N'Huano', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'G.Sertio@gmail.com', N'!44Qzvg2%!9', N'Gamlet', N'Sertio', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'C.Neel@gmail.com', N'E@AJ#4c#5ad', N'Christian', N'Neel', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'E.Mussoliny@gmail.com', N'!H5N@@$1%@', N'Enrice', N'Mussoliny', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'L.Andersen@gmail.com', N'!pUzeL$^', N'Lui', N'Andersen', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'E.Atlandes@gmail.com', N'$@^3Ul^', N'Enrike', N'Atlandes', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Smith@gmail.com', N'UE$2T5!e$P', N'Angela', N'Smith', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'L.Marko@gmail.com', N'NpRQo$!', N'Lucius', N'Marko', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Mishkevich@gmail.com', N'i1nO5$', N'Andrey', N'Mishkevich', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'R.Skitter@gmail.com', N'GP6oAQ2', N'Rita', N'Skitter', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'Y.Zi@gmail.com', N'o^zQ1!D', N'Yamato', N'Zi', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'K.Perno@gmail.com', N'vXkN9%g', N'Kuriko', N'Perno', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'V.Zulinc@gmail.com', N'Oc#LJH3I', N'Viktor', N'Zulinc', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'E.Huso@gmail.com', N'9uaC410#WL', N'Elen', N'Huso', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Adkin@gmail.com', N'B5ob@@2z', N'Ahmad', N'Adkin', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Allison@gmail.com', N'D10!61!', N'Alphonso', N'Allison', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.BURNHAM@gmail.com', N'o0Xl^%@x%n9', N'Alfreda', N'BURNHAM', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Bitsuile@gmail.com', N'^T%Vl%@s', N'April', N'Bitsuile', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Brooks@gmail.com', N'YE!Xx!4$', N'Aron', N'Brooks', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Candlish@gmail.com', N'Qf7Q#c$19@^', N'Angel', N'Candlish', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Crews@gmail.com', N'L0g$d@cj1R', N'Austin', N'Crews', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Conard@gmail.com', N'^@ujJ1%W3^^', N'Alisha', N'Conard', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Crockett@gmail.com', N'F3ohCd!', N'Anika', N'Crockett', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'B.Lipke@gmail.com', N'I7t515x', N'Brian', N'Lipke', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'B.Mccoy@gmail.com', N'@8$QR^3!c', N'Bryan', N'Mccoy', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'C.Cline@gmail.com', N'T@M$YBa6', N'Chiquita', N'Cline', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'C.Cook@gmail.com', N'SuU@!IC', N'Cruz', N'Cook', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'C.Mcknight@gmail.com', N'55n8mXY!sEB', N'Charlie', N'Mcknight', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'G.Titus@gmail.com', N'Br8Xl!0', N'Gus', N'Titus', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'H.Bourbon@gmail.com', N'49uj!w', N'Hugh', N'Bourbon', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'R.Carmona@gmail.com', N'2836Xqt', N'Robin', N'Carmona', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'S.Steoud@gmail.com', N'%mXS3nK', N'Simon', N'Steoud', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'Z.Chapman@gmail.com', N's9A64@69W1', N'Zora', N'Chapman', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'W.Marby@gmail.com', N'^k#Gi2^#n', N'Waldo', N'Marby', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'W.Spears@gmail.com', N'3%y1pv#H9', N'Willy', N'Spears', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'V.Prado@gmail.com', N'u015D@EK', N'Vera', N'Prado', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'V.Sahagun@gmail.com', N'iupTL%K5', N'Valeria', N'Sahagun', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'R.Steel@gmail.com', N'IY7%#98B6', N'Raley', N'Steel', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'H.Miller@gmail.com', N'yb%7%yq0', N'Harry', N'Miller', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'E.Miller@gmail.com', N'$D5^37V9G!%', N'Eva', N'Miller', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Vergon@gmail.com', N'Qq!vc@4o', N'Adam', N'Vergon', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'V.Ahoul@gmail.com', N'1gM^#5%%t7', N'Vahshee', N'Ahoul', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'G.Veljor@gmail.com', N'fk94j!8^', N'Gretta', N'Veljor', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Durs@gmail.com', N'w2NL$vySH^K', N'Arman', N'Durs', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'U.Cumoto@gmail.com', N'69!bXu', N'Uki', N'Cumoto', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'A.Wert@gmail.com', N'Isq%5IG!n', N'Agnus', N'Wert', N'R')
	INSERT [dbo].[User] ([Email], [Password], [First_Name], [Last_Name], [ID_Role]) VALUES (N'J.Votye@gmail.com', N'^d$23wn7gt', N'Jerom', N'Votye', N'R')
	ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Event_Type1] FOREIGN KEY([ID_EventType])
	REFERENCES [dbo].[Event_Type] ([ID_Event_type])
	GO
	ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Event_Type1]
	GO
	ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Race] FOREIGN KEY([ID_Race])
	REFERENCES [dbo].[Race] ([ID_Race])
	GO
	ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Race]
	GO
	ALTER TABLE [dbo].[Race]  WITH CHECK ADD  CONSTRAINT [FK_Race_Country] FOREIGN KEY([ID_Country])
	REFERENCES [dbo].[Country] ([ID_Country])
	GO
	ALTER TABLE [dbo].[Race] CHECK CONSTRAINT [FK_Race_Country]
	GO
	ALTER TABLE [dbo].[Racer]  WITH CHECK ADD  CONSTRAINT [FK_Racer_Country] FOREIGN KEY([ID_Country])
	REFERENCES [dbo].[Country] ([ID_Country])
	GO
	ALTER TABLE [dbo].[Racer] CHECK CONSTRAINT [FK_Racer_Country]
	GO
	ALTER TABLE [dbo].[Racer]  WITH CHECK ADD  CONSTRAINT [FK_Racer_Gender] FOREIGN KEY([Gender])
	REFERENCES [dbo].[Gender] ([ID_Gender])
	GO
	ALTER TABLE [dbo].[Racer] CHECK CONSTRAINT [FK_Racer_Gender]
	GO
	ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Charity] FOREIGN KEY([ID_Charity])
	REFERENCES [dbo].[Charity] ([ID_Сharity])
	GO
	ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Charity]
	GO
	ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Racer] FOREIGN KEY([ID_Racer])
	REFERENCES [dbo].[Racer] ([ID_Racer])
	GO
	ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Racer]
	GO
	ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Event_Event] FOREIGN KEY([ID_Event])
	REFERENCES [dbo].[Event] ([ID_Event])
	GO
	ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Registration_Event_Event]
	GO
	ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Event_Registration] FOREIGN KEY([ID_Registration])
	REFERENCES [dbo].[Registration] ([ID_Registration])
	GO
	ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Registration_Event_Registration]
	GO
	ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([ID_Role])
	REFERENCES [dbo].[Role] ([ID_Role])
	GO
	ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
	GO
	ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Country] FOREIGN KEY([ID_Country])
	REFERENCES [dbo].[Country] ([ID_Country])
	GO
	ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Country]
	GO
	ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Gender] FOREIGN KEY([Gender_ID])
	REFERENCES [dbo].[Gender] ([ID_Gender])
	GO
	ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Gender]
	GO
