// Student ID: 5317169 - Larry Nguyen
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// Test program for testing the classes



using Program_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog0
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0,
                80.5, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;

            parcels = new List<Parcel>();

            parcels.Add(letter1);
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);

            WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("====================");
            }
        }
    }
}
