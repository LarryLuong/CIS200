// Student ID: 5317169
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// public abstract class derived from parcel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    internal class Letter : Parcel
    {
        private decimal _fixedCost; 

        public Letter(Address originAddress, Address destAddress, decimal cost) : base(originAddress, destAddress)
        {
            _fixedCost = cost;
        }

        public decimal FixedCost
        {
            get { return _fixedCost; }
            // Precond value >= 0
            // Post cond : the letter's fixed cost has been set to the specified value
            set
                // Precon value >= 0
                // Postcon: the letters fixed cost has been set to value
            {

                if (value >= 0)
                {
                    _fixedCost = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(FixedCost)}", value,
                        $"{nameof(FixedCost)} must be >= 0");
                }
            }
        }

        //precon: None
        //postcon: cost returned
        public override decimal CalcCost()
        {
            return FixedCost;
        }

        // precon: None
        // postcon: string returned with letter data
        public override string ToString()
        {
            string NL = Environment.NewLine; // newline shortcut

            return $"Letter{NL}{base.ToString()}";
        }
    }
}
