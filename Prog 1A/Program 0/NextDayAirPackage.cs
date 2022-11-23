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
    public class NextDayAirPackage : AirPackage
    {
        private decimal _expressFee;

        public NextDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, decimal expFee)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
        {
            ExpressFee = expFee;
        }

        public decimal ExpressFee
        {
            get { return _expressFee; }
            private set
            {
                if (value >= 0)
                    _expressFee = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(ExpressFee), value,
                        $"{nameof(ExpressFee)} must be >= 0");
            }
        }

        public override decimal CalcCost()
        {
            const double DIM_FACTOR = .35;      // Dimension coefficient in cost equation
            const double WEIGHT_FACTOR = .25;   // Weight coefficient in cost equation
            const double HEAVY_FACTOR = .2;     // Heavy coefficient in cost equation
            const double LARGE_FACTOR = .22;    // Large coefficient in cost equation

            decimal cost;

            cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight) + ExpressFee;

            if (IsHeavy())
            {
                cost += (decimal)(HEAVY_FACTOR * Weight);
            }

            if (IsLarge())
            {
                cost += (decimal)(LARGE_FACTOR * TotalDimension);
            }


            return cost;

        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // Newline shorthand

            return $"NextDay{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
        }

    }
}
