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
                averageErythrocyte.radius += (list[i].radius / list.Count);
                averageErythrocyte.measuredSpeed += (list[i].measuredSpeed / list.Count);
                averageErythrocyte.measuredPolarization += (list[i].measuredPolarization / list.Count);
            }
           return averageErythrocyte;
        }

        public static Erythrocyte GetDispersion(List<Erythrocyte> list)
        {
            Erythrocyte average = GetAverage(list);
            Erythrocyte dispersionErythrocyte = new Erythrocyte();

            for (int i = 0; i < list.Count; i++)
            {
                dispersionErythrocyte.radius += (Math.Pow((list[i].radius - average.radius),2)/list.Count);
                dispersionErythrocyte.measuredSpeed += (Math.Pow((list[i].measuredSpeed - average.measuredSpeed), 2) / list.Count);
                dispersionErythrocyte.measuredPolarization += (Math.Pow((list[i].measuredPolarization - average.measuredPolarization), 2) / list.Count);
            }
            return dispersionErythrocyte;
        }

        //public static Erythrocyte GetDispersion2(List<Erythrocyte> list)
        //{
        //    Erythrocyte average = GetAverage(list);
        //    Erythrocyte dispersionErythrocyte = new Erythrocyte();
        //    Erythrocyte dispEry = new Erythrocyte();

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        dispersionErythrocyte.radius += (Math.Pow((list[i].radius), 2) / list.Count);
        //        dispersionErythrocyte.measuredSpeed += (Math.Pow((list[i].measuredSpeed), 2) / list.Count);
        //        dispersionErythrocyte.measuredPolarization += (Math.Pow((list[i].measuredPolarization), 2) / list.Count);
        //    }
        //    dispEry.radius = dispersionErythrocyte.radius - Math.Pow(average.radius,2);
        //    dispEry.measuredSpeed = dispersionErythrocyte.measuredSpeed - Math.Pow(average.radius, 2);
        //    dispEry.measuredPolarization = dispersionErythrocyte.measuredPolarization - Math.Pow(average.radius, 2);

        //    return dispEry;
        //}

        public class RowsAverage
        {
            private double _raduis = 0;
            private double _measuredSpeed = 0;
            private double _measuredPolarization = 0;
 
            public double AveRadius
            {
                get { return _raduis; }
                set { _raduis += value; }
            }
                       
            public double AveMeasuredSpeed
            {
                get { return _measuredSpeed; }
                set { _measuredSpeed += value; }
            }

            public double AveMeasuredPolarization
            {
                get { return _measuredPolarization; }
                set { _measuredPolarization += value; }
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
