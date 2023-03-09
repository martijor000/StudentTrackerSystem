USE [StudentTracker System]
GO

/****** Object:  Table [dbo].[Zipcode]    Script Date: 3/9/2023 11:25:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Zipcode](
	[Id] [int] NOT NULL,
	[Zip] [int] NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Zipcode] PRIMARY KEY CLUSTERED 
(
	[Zip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Zipcode]  WITH CHECK ADD  CONSTRAINT [FK_Zipcode_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO

ALTER TABLE [dbo].[Zipcode] CHECK CONSTRAINT [FK_Zipcode_States]
GO


