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
       
        public List<MyParams> result = new List<MyParams>(3);

        public static Erythrocyte GetAverage(List<Erythrocyte> list)
        {
            Erythrocyte averageErythrocyte = new Erythrocyte();
           
            for (int i = 0; i < list.Count; i++ )
            {
                averageErythrocyte.id += (list[i].id/list.Count);
                averageErythrocyte.radius += (list[i].radius / list.Count);
                averageErythrocyte.dielectricConstant += (list[i].dielectricConstant / list.Count);
                averageErythrocyte.theoreticalPolarization += (list[i].theoreticalPolarization / list.Count);
                averageErythrocyte.measuredSpeed += (list[i].measuredSpeed / list.Count);
                averageErythrocyte.measuredPolarization += (list[i].measuredPolarization / list.Count);
            }

           return averageErythrocyte;
        }

        public static Tuple<double, double, double, double, double, double> GetDispersion(List<Erythrocyte> list)
        {
            double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
            for (int i = 0; i < list.Count; i++)
            {
                a += (Math.Pow(list[i].id,2) / list.Count);
                b += (Math.Pow(list[i].radius,2) / list.Count);
                c += (Math.Pow(list[i].dielectricConstant,2) / list.Count);
                d += (Math.Pow(list[i].theoreticalPolarization,2) / list.Count);
                e += (Math.Pow(list[i].measuredSpeed,2) / list.Count);
                f += (Math.Pow(list[i].measuredPolarization,2) / list.Count);
            }
            return Tuple.Create(a, b, c, d, e, f);
        }

        public static void Down(double a, double c, double d, double e,
            double f, double g)
        {
            
            MessageBox.Show(Convert.ToString(a + c + d + e + f + g));
        }

        

        //public static void GetAverage(List<RowsData> list) 

        //{
        //   double Average;
        //    double a = MainWindow.DataList[0].id;
        //   average = Average ;
        //   MessageBox.Show(Average.ToString());
        //   double x = 0; //Сумма всех квадратов (/n)
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //       var v = Convert.ToDouble((Math.Pow(list[i], 2))/list.Count);
        //        x += v;
        //    }
        //   Z = x - Math.Pow(average,2); // DISPERSIYA!!!!!!!!!!
        //   C = Math.Sqrt(Z);
        //   MessageBox.Show("Дисперсия равна: " + Z.ToString());

        //    list.Clear();
        
        //}
     
       // public static void ShowA()
        //{
          //  MessageBox.Show(average.ToString());
        //}


    
        public class RowsAverage
        {
            private double id = 0;
            private double raduis = 0;
            private double dielectricConstant = 0;
            private double theoreticalPolarization = 0;
            private double measuredSpeed = 0;
            private double measuredPolarization = 0;

            public double AveId {
                get { return id; } 
                set { id += value; } }
            public double AveRadius
            {
                get { return raduis; }
                set { raduis += value; }
            }
            public double AveDielectricConstant
            {
                get { return dielectricConstant; }
                set { dielectricConstant += value; }
            }
            public double AveTheoreticalPolarization
            {
                get { return theoreticalPolarization; }
                set { theoreticalPolarization += value; }
            }
            public double AveMeasuredSpeed
            {
                get { return id; }
                set { id += value; }
            }
            public double AveMeasuredPolarization
            {
                get { return id; }
                set { id += value; }
            }

            public RowsAverage()
            {
              
            }

        }

        //public void AddDataRows (List<RowsData> DataList)
        //{
        //    DataList.Add(new RowsData());
        //}
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
