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
    public class StatisticalProcessing
    {
        public static double average, C, Z;
        public List<MyParams> result = new List<MyParams>(3);



        public static void GetAverage(List<double> list) 

        {
           double Average = list.Average();
           average = Average ;
           MessageBox.Show(Average.ToString());
           double x = 0; //Сумма всех квадратов (/n)
            for (int i = 0; i < list.Count; i++)
            {
               var v = Convert.ToDouble((Math.Pow(list[i], 2))/list.Count);
                x += v;
            }
           Z = x - Math.Pow(average,2); // DISPERSIYA!!!!!!!!!!
           C = Math.Sqrt(Z);
           MessageBox.Show("Дисперсия равна: " + Z.ToString());

            list.Clear();
        
        }
     
        public static void ShowA()
        {
            MessageBox.Show(average.ToString());
        }

        public void AddParams(List<MyParams> list1) {
            list1.Add(new MyParams(average, Z, C));
            list1.Add(new MyParams(average, Z, C));
            list1.Add(new MyParams(average, Z, C));
        }

        public class MyParams
        {
            public MyParams (double Ave, double Dispersion, double Kef)
            {
                this.average = Ave;
                this.dispersion = Dispersion;
                this.kef = Kef;
            }
            public double average { get; set; }
            public double dispersion { get; set; }
            public double kef { get; set; }

        }
    }
}
