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
            double averageValue = 0;
            double dispersionValue = 0;
            double averageLognormValue = 0;
            double dispersionLognormValue = 0;
            double[] logNormalDistribution = new double[list.Length];
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
            averageLognormValue = Math.Exp(averageValue + (dispersionValue/2));
            //Считаем дисперсию для lognorm
            dispersionLognormValue = Math.Exp(2 * averageValue + dispersionValue) * (Math.Exp(dispersionValue) - 1);
            //Считаем плотность вероятности распределение
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > 0 && dispersionLognormValue !=0)
                    logNormalDistribution[i] = ((Math.Exp(-(Math.Pow((Math.Log10(list[i]) - averageLognormValue) / ( Math.Sqrt(dispersionLognormValue)),2))/2)) / (list[i] * (Math.Sqrt(dispersionLognormValue)) * (Math.Sqrt(2 * Math.PI))));
                else
                    logNormalDistribution[i] = 0;
            }
            return logNormalDistribution;
        }
    }
}
