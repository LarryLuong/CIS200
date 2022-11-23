// Student ID: 5317169 - Larry Nguyen
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// Test program for testing the classes



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_0
{
    class Program
    {
        //Precondition: None
        //Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "  123 Any Street  ", " Apt. 45  ",
                "  Louisville   ", "  KY   ", 40202);  //Test address 1
            Address a2 = new Address("Jane Doe", "  987 Main St.",
                "Beverly Hills", "CA", 90210);  // Test address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901);  // Test address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", " Apt. 7",
                "Portland", "ME", 04101);  // Test address 4

            Letter l1 = new Letter(a1, a3, 0.50M); // Test letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test letter 3

            List<Parcel> parcels = new List<Parcel> { l1, l2, l3 }; // Test list of parcels

            WriteLine("Program 0 - List of Parcels\n");

            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("--------------------");
            }
        }
    }
}
