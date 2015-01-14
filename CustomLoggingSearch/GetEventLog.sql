CREATE DATABASE [SitecoreSystem]
GO
USE [SitecoreSystem]
GO

CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](20) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[GetEventLog]    Script Date: 01/06/2015 15:22:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[GetEventLog]
(
	 @Fromdate Date = '01/03/2015'
	,@ToDate Date= '01/03/2015'
	,@Level varchar(max)  = 'info' 
	,@Message varchar(max)=''            
	,@PageSize int = 10
	,@PageIndex int = 1
	
)
AS
BEGIN
	
	SET @ToDate = DATEADD(D,1,@ToDate)
	DECLARE @PageLowerBound int = @PageSize * (@PageIndex-1)
	DECLARE @PageUpperBound int = @PageSize + @PageLowerBound 
	DECLARE @TotalCount int = 0
	
		
		SELECT 
			ROW_NUMBER() OVER (ORDER BY ID desc) as Id
			,cast(Date as nvarchar(max)) as Date
			,Thread
			,Level
			,Logger
			,Message
			,Exception
		INTO #temp		
		FROM Log 
		WHERE 
			Date BETWEEN @Fromdate AND @ToDate 
		AND
			LEVEL = @LEVEL
		AND 
		Message like (case @Message when '' then Message
		else '%' + @Message + '%'  end)
			
			
		
		SELECT @TotalCount = (SELECT COUNT(0) FROM #temp)  
		
		SELECT 
			cast(Id as nvarchar(max)) as Id
			,Date
			,Thread
			,Level
			,Logger
			,Message
			,Exception  
			,@PageSize as PageSize
			,@PageIndex as PageIndex
			,@TotalCount as TotalRecords
		FROM #temp 
		WHERE 
			ID > @PageLowerBound and ID <= @PageUpperBound
				
			
	DROP TABLE #temp
END



GO


