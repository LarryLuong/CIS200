// Student ID: 5317169 - Larry Nguyen
// Program 0
// Due Date: 9/10/22
// Course Section: CIS 200-75
// Test program for testing the classes



using Program_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog0
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and reports gnereated using LINQ
        static void Main(string[] args)
        {
            // Verbose Setting - true means complete output of parcel data
            //                   false means only relevant data output
            bool Verbose = false;

            //Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("John Doe", "111 Market St.",
                "Jeffersonville", "IN", 47130); // Test Address 5
            Address a6 = new Address("Jane Smith", "55 Hollywood Blvd.", "Apt. 9",
                "Los Angeles", "CA", 90212); // Test Address 6
            Address a7 = new Address("Captain Robertr Crunch", "21 Cereal Rd.", "Room 987",
                "Bethesda", "MD", 20810); // Test Address 7
            Address a8 = new Address("Vlad Dracula", "6543 Vampire Way", "Apt. 1",
                "Bloodsucker City", "TN", 37210); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                             // Letter test object
            Letter letter2 = new Letter(a3, a4, 4.25M);                             // Letter test object
            GroundPackage gp1 = new GroundPackage(a5, a6, 14, 10, 5, 12.5);         // Ground test object
            GroundPackage gp2 = new GroundPackage(a7, a8, 8.5, 9.5, 6.5, 2.5);      // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,     // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a3, a5, 9.5, 6.0, 5.5,  // Next Day test object
                5.25, 5.25M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a2, a7, 10.5, 6.5, 9.5,  // Next Day test object
                15.5, 5.00M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a5, a7, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a1, 15.0, 9.5, 6.5,   // Two Day test object
                75.5, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a6, a4, 12.0, 12.0, 6.0,  // Two Day test object
                5.5, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;       // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);

            WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("====================");
            }
            Pause();

            // Parcels by destination zip (desc:");
            var parcelsByDestZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            WriteLine("Parcels by Destination Zip (desc):");
            WriteLine("====================");

            foreach (Parcel p in parcelsByDestZip)
            {
                if (Verbose)
                {
                    WriteLine(p);
                    WriteLine("====================");
                }
                else
                    WriteLine($"{p.DestinationAddress.Zip:D5}");
            }
            Pause();

            // Parcels by cost
            var parcelsByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;

            WriteLine("Parcels by Cost:");
            WriteLine("====================");
            foreach (Parcel p in parcelsByCost)
            {
                if (Verbose)
                {
                    WriteLine(p);
                    WriteLine("====================");
                }
                else
                    WriteLine($"{p.CalcCost(),8:C}");
            }
            Pause();

            // Parcels by type and cost (desc)
            var parcelsByTypeCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            WriteLine("Parcels by Type and Cost (desc):");
            WriteLine("====================");
            foreach (Parcel p in parcelsByTypeCost)
            {
                if (Verbose)
                {
                    WriteLine(p);
                    WriteLine("====================");
                }
                else
                    WriteLine($"{p.GetType().ToString(),-17} {p.CalcCost(),8:C}");
            }
            Pause();

            // Heavy AirPackages by Weight (desc)
            var heavyAirPackagesByWeight =
                from p in parcels
                let ap = p as AirPackage // Downcast if Airpackage, null otherwise
                where (ap != null) && ap.IsHeavy() // Safe because of short- cirtucit
                orderby ap.Weight descending
                select ap;

            // Alternate solutions

            //var heavyAirPackagesByWeight = 
            //    from p in parcels
            //    where (p is AirPackage) && ((AirPackage)p).IsHeavy() // Safe downcast
            //    orderby ((Airpackage)p). Weight descending           // Safe downcast
            //    select p;

            // AirPackages first
            //var airPackages =
            //  from p in parcels
            //  where p is AirPackage
            //  select (AirPackage)p;

            // Filter from AirPackages
            //var heavyAirPackagesByWeight =
            //  from ap in AirPackages
            //  where ap.IsHeavy()
            //  orderby ap.Weight descending
            //  select ap;

            WriteLine("Heavy Airpackages by Weight (desc):");
            WriteLine("====================");
            foreach (AirPackage ap in heavyAirPackagesByWeight)
            {
                if (Verbose)
                {
                    WriteLine(ap);
                    WriteLine("====================");
                }
                else
                    WriteLine("{0,-17} {1,4:F1}", ap.GetType().ToString(),
                        ap.Weight);

            }
        }

    // Precondition: None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Clear(); // Clear screen
        }
    }
}
