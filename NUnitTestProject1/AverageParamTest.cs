using NUnit.Framework;
using VisParam_Sniim;
using System.Collections.Generic;


namespace StatisticalProcessingTests
{
    public class AverageParamTest
    {
        public static List<Erythrocyte> TestDataList = new List<Erythrocyte>();
        StatisticalProcessing calc = new StatisticalProcessing();
        Erythrocyte trueAverage = new Erythrocyte(25322.223333333332, 25322.223333333332, 25322.223333333332, "Среднее арифметическое");

        [SetUp]
        public void Init()
        {
            TestDataList.Add(new Erythrocyte(25500, 25500, 25500));
            TestDataList.Add(new Erythrocyte(26000, 26000, 26000));
            TestDataList.Add(new Erythrocyte(24466.67, 24466.67, 24466.67));
        }

        [Test]
        public void TestGetAverage()
        {

            // act
            var res = StatisticalProcessing.GetAverage(TestDataList);

            // assert
            Assert.AreEqual(trueAverage.radius, res.radius);
            Assert.AreEqual(trueAverage.measuredSpeed, res.measuredSpeed);
            Assert.AreEqual(trueAverage.measuredPolarization, res.measuredPolarization);
            Assert.AreEqual(trueAverage.statisticalParameterName, res.statisticalParameterName);
            Assert.Pass();
        }
    }
}