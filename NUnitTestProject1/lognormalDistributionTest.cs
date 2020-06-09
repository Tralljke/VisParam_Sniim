using NUnit.Framework;
using VisParam_Sniim;
using System.Collections.Generic;

namespace StatisticalProcessingTests
{
    class LognormalDistributionTest
    {
        public static double[] TestDataList = new double[1];
        double[] trueDispersion = new double[] {0,0005069};

        [SetUp]
        public void Init()
        {
            TestDataList[0] = 2.5;
        }

        [Test]
        public void TestGetDispersion()
        {

            // act
            double[] res = LognormalDistribution.GetlogNormal(TestDataList);

            // assert
            Assert.AreEqual(trueDispersion[0], res[0]);
            Assert.Pass();
        }
    }
}

