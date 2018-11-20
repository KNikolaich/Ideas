SET IDENTITY_INSERT [dbo].[Nsi_Advice] ON
INSERT INTO [dbo].[Nsi_Advice] ([ID], [TextAdv], [Explanation], [Probability], [Image], [Signal], [OptimisticLockField], [ModelName], [Premise], [Prediction], [ObjectType], [Depth], [MovAvgType]) VALUES (10, NULL, N'Чаще всего – короткие средние, которые используют трейдеры, это 8 и 21. Длинные скользящие средние – 150, 365, 200.', 0, NULL, NULL, 0, N'Simple moving average (8)', N'Простая скользящая нужна для расчета и помощи', NULL, 1, 8, 0)
INSERT INTO [dbo].[Nsi_Advice] ([ID], [TextAdv], [Explanation], [Probability], [Image], [Signal], [OptimisticLockField], [ModelName], [Premise], [Prediction], [ObjectType], [Depth], [MovAvgType]) VALUES (11, NULL, N'Чаще всего – короткие средние, которые используют трейдеры, это 8 и 30. Длинные скользящие средние – 150, 365, 200.', 0, NULL, NULL, 1, N'Simple moving average (30)', N'Простая скользящая 2 нужна для расчета и помощи', NULL, 1, 30, 0)
INSERT INTO [dbo].[Nsi_Advice] ([ID], [TextAdv], [Explanation], [Probability], [Image], [Signal], [OptimisticLockField], [ModelName], [Premise], [Prediction], [ObjectType], [Depth], [MovAvgType]) VALUES (12, NULL, N'Длинные скользящие средние – 150, 365, 200. Больше 50, уже считаются длинными, и обычно пользуются простыми, потому что на таком расстоянии экпоненциальные считать не имеет смысла.', 0, NULL, NULL, 0, N'Simple moving average (200)', N'Простая скользящая 3 нужна отрисовки тренда', NULL, 1, 200, 0)



INSERT INTO [dbo].[Nsi_Advice] ([ID], [ModelName], [Premise], [Explanation], [Probability], [Image], [OptimisticLockField], [ObjectType]) VALUES (1, N'MACD 26-12-9', N'Характеристики индикатора

Платформа: любая
Валютные пары: Любые
Таймфрейм: любой, желательно выше Н1
Время торговли: круглосуточно
Тип индикатора: классический трендовый осциллятор


 MACD просто вычисляет разницу между быстрой и медленной скользящими средними. Когда MACD находится выше нуля, это говорит о том, что быстрая скользящая средняя выше медленной. Когда ниже нуля – быстрая ниже медленной. Соответственно, рост MACD говорит о нарастающей бычьей тенденции, падение – о медвежьей.', N'Первым делом нам нужно приготовить две экспоненциальные скользящие средние – длинную и короткую, а затем найти их разницу:

MACD=EMA(CLOSE,PL)-EMA(CLOSE,PS), где

EMA –экспоненциальная скользящая средняя;

PL и PS – длинный и короткий периоды экспоненциальной скользящей средней;

Это и есть та линия, которую вы в современном варианте построения индикатора MACD видите, как гистограмму. Она называется быстрой линией MACD, еще с тех времен, когда она была еще линией.

Следующим шагом будет рассчитать сигнальную линию, как простую скользящую среднюю от высчитанной выше разнице двух экспоненциальных скользящих средних:

Signal=SMA(MACD,Pa), где

SMA – простая скользящая средняя;

Pa – период сигнальной линии индикатора.

Вот и получилась та самая красная линия на графике. Называется она медленной линией MACD или сигнальной линией.', 80, 0, 1, 2)
INSERT INTO [dbo].[Nsi_Advice] ([ID], [ModelName], [Premise], [Explanation], [Probability], [Image], [OptimisticLockField], [ObjectType], [Depth], [MovAvgType], [PriceType]) VALUES (2, N'Трендовая SMA (200)', N'Это трендовая линия позволяет посмотреть на перекупленность или перепроданность рынка', N'Считается SMA(200) ', 0, NULL, 1, 1, 200, 0, 0)
SET IDENTITY_INSERT [dbo].[Nsi_Advice] OFF

