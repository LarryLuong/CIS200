// Larry Nguyen
// 5317169

using System;
using System.Collections.Generic;
using static System.Console;

// 1. Create two TipsPlusHourlyEmployee objects (under base-salaried commission employee
//    Bob Lewis, right under existing lines 21-23).
// 2. Add your two new employees to the the list (in existing lines 26-27).
class PayrollSystemTest
{
   static void Main()
   {
      // create derived-class objects
      var salariedEmployee = new SalariedEmployee("John", "Smith",
          "111-11-1111", 800.00M);
      var hourlyEmployee = new HourlyEmployee("Karen", "Price",
         "222-22-2222", 16.75M, 40.0M);
      var commissionEmployee = new CommissionEmployee("Sue", "Jones",
         "333-33-3333", 10000.00M, .06M);
      var basePlusCommissionEmployee =
         new BasePlusCommissionEmployee("Bob", "Lewis",
         "444-44-4444", 5000.00M, .04M, 300.00M);
      var tipsPlusHourlyEmployee =
         new TipsPlusHourlyEmployee("John", "Doe",
         "555-55-5555", 1000.00M, .10M, 10M, .5M);
        var tipsPlusHourlyEmployee2 =
         new TipsPlusHourlyEmployee("Jane", "Doe",
         "666-66-6666", 1000.00M, .10M, 5M, 1M);

      // create List<Employee> and initialize with employee objects
      var employees = new List<Employee>() {salariedEmployee,
         hourlyEmployee, commissionEmployee, basePlusCommissionEmployee, tipsPlusHourlyEmployee, tipsPlusHourlyEmployee2 };

      WriteLine("Employees processed polymorphically:\n");

      // generically process each element in employees
      foreach (var currentEmployee in employees)
      {
         WriteLine(currentEmployee); // invokes ToString
         WriteLine($"earned: {currentEmployee.Earnings():C}\n");
      }

      // get type name of each object in employees 
      for (int j = 0; j < employees.Count; j++)
      {
         WriteLine($"Employee {j} is a {employees[j].GetType()}");
      }
   }
}


/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/
