using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Trader
{
    [DefaultClassOptions, ImageName("BO_Opportunity")]
    [NavigationItem("Bro bot"), XafDisplayName("Индикатор MACD")]
    public partial class Nsi_MacD
    {
        public Nsi_MacD(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public void InitNewInstance()
        {
            Active = true;
            ExpPeriodShort = 12;
            ExpPeriodLong = 26;
            SignalPeriod = 9;
            ModelName = $"MacD {ExpPeriodLong}-{ExpPeriodShort}-{SignalPeriod}";

            Premise = @"Характеристики индикатора

Платформа: любая
Валютные пары: Любые
Таймфрейм: любой, желательно выше Н1
Время торговли: круглосуточно
Тип индикатора: классический трендовый осциллятор

MACD просто вычисляет разницу между быстрой и медленной скользящими средними. Когда MACD находится выше нуля, это говорит о том, что быстрая скользящая средняя выше медленной. Когда ниже нуля – быстрая ниже медленной. Соответственно, рост MACD говорит о нарастающей бычьей тенденции, падение – о медвежьей.";
            Probability = 80;
            Explanation =
                @"Первым делом нам нужно приготовить две экспоненциальные скользящие средние – длинную и короткую, а затем найти их разницу:
MACD=EMA(CLOSE,PL)-EMA(CLOSE,PS), где
EMA –экспоненциальная скользящая средняя;
PL и PS – длинный и короткий периоды экспоненциальной скользящей средней;
Это и есть та линия, которую вы в современном варианте построения индикатора MACD видите, как гистограмму. Она называется быстрой линией MACD, еще с тех времен, когда она была еще линией.
Следующим шагом будет рассчитать сигнальную линию, как простую скользящую среднюю от высчитанной выше разнице двух экспоненциальных скользящих средних:
Signal=SMA(MACD,Pa), где
SMA – простая скользящая средняя;
Pa – период сигнальной линии индикатора.
Вот и получилась та самая красная линия на графике. Называется она медленной линией MACD или сигнальной линией.";
        }
    }

}
