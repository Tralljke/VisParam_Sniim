using NUnit.Framework;
using VisParam_Sniim;
using System.Collections.Generic;

namespace StatisticalProcessingTests
{
    public class VarCoefParamTest
    {
        public static List<Erythrocyte> TestDataList = new List<Erythrocyte>();
        StatisticalProcessing calc = new StatisticalProcessing();
        Erythrocyte trueVarCoef = new Erythrocyte(2.5214082963426381, 2.5214082963426381, 2.5214082963426381, "Коэф Вариации %");

        [SetUp]
        public void Init()
        {
            TestDataList.Add(new Erythrocyte(25500, 25500, 25500));
            TestDataList.Add(new Erythrocyte(26000, 26000, 26000));
            TestDataList.Add(new Erythrocyte(24466.67, 24466.67, 24466.67));
        }

        [Test]
        public void TestGetVarCoef()
        {

            // act
            var res = StatisticalProcessing.GetVarCoef(TestDataList);

            // assert
            Assert.AreEqual(trueVarCoef.radius, res.radius);
            Assert.AreEqual(trueVarCoef.measuredSpeed, res.measuredSpeed);
            Assert.AreEqual(trueVarCoef.measuredPolarization, res.measuredPolarization);
            Assert.AreEqual(trueVarCoef.statisticalParameterName, res.statisticalParameterName);
            Assert.Pass();
        }
    }
}
