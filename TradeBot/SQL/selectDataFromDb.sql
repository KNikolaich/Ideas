/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT [Id]
,DATEADD(S, CONVERT(int,LEFT(CloseTime, 10)), '1970-01-01 03:00:00') as CloseDateTime
      --,[OpenTime]
      --,[CloseTime]
      ,[Open]
      ,[Close]
      ,[High]
      ,[Low]
      ,[Volume]
      ,[Advice]
      ,[VectorSMA]
  FROM [HystoryBinance].[dbo].[Candlesticks]
  where advice = -1 or advice = 1