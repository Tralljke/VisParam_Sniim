using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisParam_Sniim
{
    public class LognormalDistribution
    {

        public static double[] GetlogNormal(double[] list)
        {
            double averageValue = new double();
            double dispersionValue = new double();
            double averageLognormValue = new double();
            double dispersionLognormValue = new double();
            //Считаем среднее арифметическое
            for (int i = 0; i < list.Length; i++)
                {
                    averageValue += (list[i] / list.Length);
                }

            //Считаем дисперсию
            for (int i = 0; i < list.Length; i++)
                {
                    dispersionValue += (Math.Pow((list[i] - averageValue), 2) / list.Length);
                }
            //Считаем  среднее арифметическое для lognorm
            for (int i = 0; i < list.Length; i++)
            {

            }
            return list;
        }
    }
}
