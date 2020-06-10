using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisParam_Sniim
{
   public class VariableParams
    {
        public int id { get; set; }
        public double radius { get; set; }
        public double measuredSpeed { get; set; }
        public double measuredPolarization { get; set; }
        public double theoreticalPolarization { get; set; }

        public VariableParams(int id, double radius, double theoreticalPolarization, double measuredSpeed, double measuredPolarization)
        {
            this.id = id;
            this.radius = radius;
            this.theoreticalPolarization = theoreticalPolarization;
            this.measuredSpeed = measuredSpeed;
            this.measuredPolarization = measuredPolarization;

        }

        public VariableParams()
        {

        }

        public override string ToString()
        {
            return id + " " + radius + " " + theoreticalPolarization + " " + measuredSpeed + " " + measuredPolarization;
        }
    }
}
