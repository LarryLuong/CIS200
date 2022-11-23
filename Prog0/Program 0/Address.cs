// Student ID: 5317169
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// Concrete class for address

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    class Address
    {
        public const int MIN_ZIP = 0; // lowest zip
        public const int MAX_ZIP = 99999; // highest zip

        private string _name; 
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private int _zip;

        //PreCon: name, address 1, city, state may not be null, empyty nor all whitespace
        //PostCon: the address us created with the specified values for name, address1, address2, city, state, and zipcode
        public Address(string name, string address1, string address2,
            string city, string state, int zipcode)
        {
            Name = name;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zipcode;
        }

        public Address(string name, string address1, string city,
        string state, int zipcode) : this(name, address1, string.Empty, city, state, zipcode)
        {
            // No body needed
            // Calls previous constructor sending empty string for Address 2
        }

        public string Name
        {
            //Precon: None
            //Postcon: The address' name has been returned
            get { return _name; }

            //Precon: value must not be null, empyty nor all whitespace
            //Postcon: The address' name has been set to the speciifc value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException($"{nameof(Name)}", value, $"{nameof(Name)} must not be empty");
                else
                    _name = value.Trim();
            }
        }

        public string Address1
        {
            //Precon: None
            //Postcon: The address' first address line has been returned
            get
            {
                return _address1;
            }

            //Precon: None
            //Postcon: The address' first address line has been set to
            //         the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException($"{nameof(Address1)}",
                        value, $"{nameof(Address1)} must not be empty");
                else
                    _address1 = value.Trim();
            }
        }

        public string Address2
        {
            //Precon: None
            //Postcon: The address' second address line has been returned
            get
            {
                return _address2;
            }

            //Precon: None
            //Postcon: The address' second address line has been set to
            //         the specified value
            set
            {
                if (value == null) // Just in case
                    value = string.Empty;

                _address2 = value.Trim();
            }
        }

        public string City
        {
            //Precon: None
            //Postcon: The address' city has been returned
            get
            {
                return _city;
            }

            //Precon: Value must not be null, empty nor all whitespace
            //Postcon: The address' city has been set to
            //         the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException($"{nameof(City)}",
                        value, $"{nameof(City)} must not be empty");
                else
                _city = value.Trim();
            }
        }

        public string State
        {
            //Precon: None
            //Postcon: The address' second address line has been returned
            get
            {
                return _state;
            }

            //Precon: None
            //Postcon: The address' second address line has been set to
            //         the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException($"{nameof(State)}",
                        value, $"{nameof(State)} must not be empty");
                else
                    _state = value.Trim();
            }
        }

        public int Zip
        {
            // Precon: None
            // Postcon: The adress' zip code has been returned
            get
            {
                return _zip;
            }
            //Precon: MIN_ZIP <= value <= MAX_ZIP
            //Postcon: The address' zip code has been set to the specified value
            set
            {
                if ((value >= MIN_ZIP) && (value <= MAX_ZIP))
                    _zip = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Zip)}", value,
                        $"{nameof(Zip)} must be U.S. 5 digit zip code");
            }
        }

        public override string ToString()
        {
            string NL = Environment.NewLine;
            string result;

            result = $"{Name}{NL}{Address1}{NL}";

            if (!string.IsNullOrWhiteSpace(Address2)) // is Address2 not null or white space
                result += $"{Address2}{NL}";

            result += $"{City}, {State} {Zip:D5}";

            return result;
        }

    }
}
