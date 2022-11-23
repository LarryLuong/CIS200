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
    public class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver }

        private Delivery _deliveryType;

        public TwoDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, Delivery delType)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
        {
            DeliveryType = _deliveryType;
        }

        public Delivery DeliveryType
        {
            get
            {
                return _deliveryType;
            }

            set
            {
                if (Enum.IsDefined(typeof(Delivery), value))
                {
                    _deliveryType = value;
                }

                else
                    throw new ArgumentOutOfRangeException(nameof(DeliveryType), value,
                        $"{nameof(DeliveryType)} must be {nameof(Delivery.Early)} " +
                        $"or {nameof(Delivery.Saver)}");
            }
        }

        public override decimal CalcCost()
        {
            const double DIM_FACTOR = .10;          // Dimension coefficient in cost equation
            const double WEIGHT_FACTOR = .2;        // Weight coeffecient in cost equation
            const decimal DISCOUNT_FACTOR = .15M;    // Discount factor in cost equation

            decimal cost;
            cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight);

            if (DeliveryType==Delivery.Saver)
            {
                cost *= (1 - DISCOUNT_FACTOR);
            }

            return cost;
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // Newline shorthand

            return $"TwoDay{base.ToString()}{NL}Delivery Type: {DeliveryType}";
        }

    }
}
