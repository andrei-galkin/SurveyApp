CREATE TABLE [dbo].[SurveyQuestions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [nvarchar](max) NOT NULL,
	[question_type] [smallint] NOT NULL,
 CONSTRAINT [PK_SurveyQuestions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[SurveyQuestionsInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NOT NULL,
	[data] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_SurveyQuestionsInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[SurveyResponses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[creation_date] [datetime] NOT NULL CONSTRAINT [DF_SurveyRespnses_creation_date]  DEFAULT (getdate()),
	[question_id] [int] NOT NULL,
	[data] [nvarchar](150) NOT NULL,
	[user_data] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SurveyRespnses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SurveyQuestionsInfo]  WITH CHECK ADD  CONSTRAINT [FK_SurveyQuestionsInfo_SurveyQuestionsInfo] FOREIGN KEY([id])
REFERENCES [dbo].[SurveyQuestionsInfo] ([id])
GO

ALTER TABLE [dbo].[SurveyQuestionsInfo] CHECK CONSTRAINT [FK_SurveyQuestionsInfo_SurveyQuestionsInfo]
GO
