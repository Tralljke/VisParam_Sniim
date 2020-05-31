using NUnit.Framework;
using VisParam_Sniim;
using System.Collections.Generic;

namespace StatisticalProcessingTests
{
    public class DispersionParamTest
    {
        public static List<Erythrocyte> TestDataList = new List<Erythrocyte>();
        StatisticalProcessing calc = new StatisticalProcessing();
        Erythrocyte trueDispersion = new Erythrocyte(0.5221, 0.5221, 0.5221, "Дисперсия");

        [SetUp]
        public void Init()
        {
            TestDataList.Add(new Erythrocyte(7.1, 7.1, 7.1));
            TestDataList.Add(new Erythrocyte(6.3, 6.3, 6.3));
            TestDataList.Add(new Erythrocyte(6.2, 6.2, 6.2));
            TestDataList.Add(new Erythrocyte(5.8, 5.8, 5.8));
            TestDataList.Add(new Erythrocyte(7.7, 7.7, 7.7));
            TestDataList.Add(new Erythrocyte(6.8, 6.8, 6.8));
            TestDataList.Add(new Erythrocyte(6.7, 6.7, 6.7));
            TestDataList.Add(new Erythrocyte(5.9, 5.9, 5.9));
            TestDataList.Add(new Erythrocyte(5.7, 5.7, 5.7));
            TestDataList.Add(new Erythrocyte(5.1, 5.1, 5.1));
        }

        [Test]
        public void TestGetDispersion()
        {

            // act
            var res = StatisticalProcessing.GetDispersion(TestDataList);

            // assert
            Assert.AreEqual(trueDispersion.radius, res.radius);
            Assert.AreEqual(trueDispersion.measuredSpeed, res.measuredSpeed);
            Assert.AreEqual(trueDispersion.measuredPolarization, res.measuredPolarization);
            Assert.AreEqual(trueDispersion.statisticalParameterName, res.statisticalParameterName);
            Assert.Pass();
        }
    }
}
