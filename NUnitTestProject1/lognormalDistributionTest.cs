using NUnit.Framework;
using VisParam_Sniim;
using System.Collections.Generic;

namespace StatisticalProcessingTests
{
    class lognormalDistributionTest
    {
        public static double[] TestDataList = new double[3];
        double[] trueDispersion = new double[] { 1, 2, 3 };

        [SetUp]
        public void Init()
        {
            TestDataList[0] = 1;
            TestDataList[1] = 2;
            TestDataList[2] = 3;
        }

        [Test]
        public void TestGetDispersion()
        {

            // act
            double[] res = lognormalDistribution.GetlogNormal(TestDataList);

            // assert
            Assert.AreEqual(trueDispersion[0], res[0]);
            Assert.AreEqual(trueDispersion[1], res[1]);
            Assert.AreEqual(trueDispersion[2], res[2]);
            Assert.Pass();
        }
    }
}
