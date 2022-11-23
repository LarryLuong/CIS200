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
    public abstract class Package : Parcel
    {
        private double _length;
        private double _width;
        private double _height;
        private double _weight;

        public Package(Address originAddress, Address destAddress,
            double pLength, double pWidth, double pHeight, double pWeight)
            : base(originAddress, destAddress)
        {
            Length = pLength;
            Width = pWidth;
            Height = pHeight;
            Weight = pWeight;
        }

        public double Length
        {
            get { return _length; }
            set
            {
                if (value > 0)
                    _length = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Length), value,
                        $"{nameof(Length)} must be > 0");
            }
        }

        public double Width
        {
            // Precon: none
            // Postcon: the package's width has been returned
            get
            {
                return _width;
            }

            // Precon: value > 0   
            // Postcon: the package's width has been set to the specified value
            set
            {
                if (value > 0)
                    _width = value;
                else throw new ArgumentOutOfRangeException(nameof(Width), value,
                    $"{nameof(Width)} must be > 0");
            }
        }

        public double Height
        {
            // Precon: None
            // Postcon: The package's height has been returned
            get
            {
                return _height;
            }

            // Precon: value > 0
            // Postcon: The package's height has been set to the specified value
            set
            {
                if (value > 0)
                    _height = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Height), value,
                        $"{nameof(Height)} must be >0");
            }
        }

        public double Weight
        {
            // Precon: none
            // Postcon: the package's weight has been returned
            get
            {
                return _weight;
            }

            // Precon: value > 0
            // Postcon: The package's weight has been set to teh specified value
            set
            {
                if (value > 0)
                    _weight = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Weight), value,
                        $"{nameof(Weight)} must be >0");
            }
        }

        protected double TotalDimension
        {
            get
            {
                return (Length + Width + Height);
            }
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // Newline shorthand

            return $"Package{NL}{base.ToString()}{NL}Length: {Length:N1}{NL}Width: {Width:N1}{NL}" +
                $"Height: {Height:N1}{NL}Weight: {Weight:N1}";
        }


    }


}