// Student ID: 5317169
// Program 1a
// Due Date: 9/26/22
// Course Section: CIS 200-75

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    public class GroundPackage : Package
    {
        public GroundPackage(Address originAddress, Address destAddress,
            double pLength, double pWidth, double pHeight, double pWeight)
            : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
        {
            // All work done in the base constructor
        }

        public int ZoneDistance
        {
            get
            {
                const int FIRST_DIGIT_FACTOR = 10000; // Demoninator to extract 1st digit
                int dist;                             // Calculated zone distance

                dist = Math.Abs((OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR));

                return dist;
            }
        }

        public override decimal CalcCost()
        {
            const double DIM_FACTOR = .15;      // Dimension coefficient in cost equation
            const double WEIGHT_FACTOR = .07;   // Weight coefficient in cost equation

            return (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * (ZoneDistance + 1) * Weight);
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // Newline shorthand

            return $"Ground{base.ToString()}{NL}Zone Distance: {ZoneDistance}";
        }
    }
}
