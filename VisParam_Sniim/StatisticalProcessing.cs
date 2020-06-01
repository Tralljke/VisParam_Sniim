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
       
        public List<Erythrocyte> result = new List<Erythrocyte>(3);

        public static Erythrocyte GetAverage(List<Erythrocyte> list)
        {
            Erythrocyte averageErythrocyte = new Erythrocyte();
           
            for (int i = 0; i < list.Count; i++ )
            {
                averageErythrocyte.radius += (list[i].radius / list.Count);
                averageErythrocyte.measuredSpeed += (list[i].measuredSpeed / list.Count);
                averageErythrocyte.measuredPolarization += (list[i].measuredPolarization / list.Count);
            }
            averageErythrocyte.statisticalParameterName = "Среднее арифметическое";
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
            dispersionErythrocyte.statisticalParameterName = "Дисперсия";
            dispersionErythrocyte.radius = (dispersionErythrocyte.measuredPolarization);
            dispersionErythrocyte.measuredSpeed = (dispersionErythrocyte.measuredSpeed);
            dispersionErythrocyte.measuredPolarization = (dispersionErythrocyte.radius);
            return dispersionErythrocyte;
        }

        public static Erythrocyte GetVarCoef(List<Erythrocyte> list)
        {
            Erythrocyte average = GetAverage(list);
            Erythrocyte VarCoef = new Erythrocyte();
            Erythrocyte VarCoefErythrocyte = new Erythrocyte();
            for (int i = 0; i < list.Count; i++)
            {
                VarCoef.radius += (Math.Pow((list[i].radius - average.radius), 2) / (list.Count));
                VarCoef.measuredSpeed += (Math.Pow((list[i].measuredSpeed - average.measuredSpeed), 2) / (list.Count));
                VarCoef.measuredPolarization += (Math.Pow((list[i].measuredPolarization - average.measuredPolarization), 2) / (list.Count)) ;
            }

            VarCoefErythrocyte.radius = (((Math.Sqrt((VarCoef.radius)))/average.radius) * 100);
            VarCoefErythrocyte.measuredSpeed = (((Math.Sqrt(VarCoef.measuredSpeed)) / average.measuredSpeed) * 100);
            VarCoefErythrocyte.measuredPolarization = (((Math.Sqrt(VarCoef.measuredPolarization)) / average.measuredPolarization) * 100);
        
            VarCoefErythrocyte.statisticalParameterName = "Коэф Вариации %";
          
            return VarCoefErythrocyte;
        }

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

    }
}
