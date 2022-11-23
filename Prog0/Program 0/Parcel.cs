// Student ID: 5317169
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// Public abstract class for parcels

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    internal abstract class Parcel
    {
        private Address _originAddress; // where parcel was sent from
        private Address _destAddress; // where parel is sent to


        public Parcel(Address originAddress, Address destAddress)
        {
            OriginAddress = originAddress; 
            DestinationAddress = destAddress;
        }

        public Address OriginAddress
        {
            // precond: none
            // postcond: parcel origin address has been returned
            get { return _originAddress; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(OriginAddress)}",
                        value, $"{nameof(OriginAddress)} must not be null");
                }
                else
                    _originAddress = value;

            }
        }


        public Address DestinationAddress
        {


            // Precond: none
            // Postcond: The parcel's destination address has been returned
            get
            {
                return _destAddress;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(DestinationAddress)}",
                        value, $"{nameof(DestinationAddress)} must nto be null");
                }
                else
                    _destAddress = value;
            }
        }
        
        //Precon: none
        //Postcon: parcel cost is returned

        public abstract decimal CalcCost();

        //Precon: none
        //Postcon: string returned with parcel data
        public override string ToString()
        {
            string NL = Environment.NewLine; // newline

            return $"Origin Address: {NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
                $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
        }

    }
    
}
