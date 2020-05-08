using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisParam_Sniim
{
   public class Erythrocyte
    {
        public double id { get; set; }
        public double radius { get; set; }
        public double dielectricConstant { get; set; }
        public double theoreticalPolarization { get; set; }
        public double measuredSpeed { get; set; }
        public double measuredPolarization { get; set; }

        public Erythrocyte(double id, double radius, double dielectricConstant,
            double theoreticalPolarization, double measuredSpeed, double measuredPolarization)
        {
            this.id = id;
            this.radius = radius;
            this.dielectricConstant = dielectricConstant;
            this.theoreticalPolarization = theoreticalPolarization;
            this.measuredSpeed = measuredSpeed;
            this.measuredPolarization = measuredPolarization;
        }

        public Erythrocyte() { }

        public override string ToString()
        {
            return "Average: " + id + radius + dielectricConstant + theoreticalPolarization + measuredPolarization + measuredSpeed;
        }
    }
}
