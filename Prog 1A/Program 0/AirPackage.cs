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
    public abstract class AirPackage : Package
    {
        public const double HEAVY_THRESHOLD = 75; // Min weight of heavy package
        public const double LARGE_THRESHOLD = 100; // Min dimensions of large package

        public AirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
        {
            // all work done in base ctor
        }

        public bool IsHeavy()
        {
            return (Weight >= HEAVY_THRESHOLD);
        }

        public bool IsLarge()
        {
            return (TotalDimension >= LARGE_THRESHOLD);
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // Newline shorthand

            return $"Air{base.ToString()}{NL}Heavy: {IsHeavy()}{NL}Large: {IsLarge()}";
        }
    }
}
