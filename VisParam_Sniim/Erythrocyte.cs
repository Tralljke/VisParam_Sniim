using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisParam_Sniim
{
   public class Erythrocyte
    {
      
        public double radius { get; set; }
        public double measuredSpeed { get; set; }
        public double measuredPolarization { get; set; }

        public Erythrocyte(double radius, double measuredSpeed, double measuredPolarization)
        {
            this.radius = radius;
            this.measuredSpeed = measuredSpeed;
            this.measuredPolarization = measuredPolarization;
        }

        public Erythrocyte() 
        {

        }

        public override string ToString()
        {
            return radius + " " + measuredPolarization + " " + measuredSpeed;
        }
    }
}
