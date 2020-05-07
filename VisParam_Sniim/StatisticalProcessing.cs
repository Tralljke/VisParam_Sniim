using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web.UI.DataVisualization.Charting;

namespace VisParam_Sniim
{
    class StatisticalProcessing
    {
        static double average;   
        public static void GetAverage(List<double> list) 
        {
           double Average = list.Average();
           StatisticalProcessing.average = Average ;
           MessageBox.Show(Average.ToString());
           double x = 0; //Сумма всех квадратов (/n)
            for (int i = 0; i < list.Count; i++)
            {
               var v = Convert.ToDouble((Math.Pow(list[i], 2))/list.Count);
                x += v;
            }
           double Z = x - Math.Pow(average,2); // DISPERSIYA!!!!!!!!!!
           double C = Math.Sqrt(Z);
           MessageBox.Show("Дисперсия равна: " + Z.ToString());
           MessageBox.Show("Коэффициент вариации равен: " + C.ToString());
           list.Clear();
        
        }

        public static void ShowA()
        {
            MessageBox.Show(average.ToString());
        }

    }
}
