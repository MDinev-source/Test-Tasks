using System;
using System.Collections.Generic;

namespace NetSalaryCalculationTask2
{
    public static class AdminLogic
    {
        private const string AdminPass = "AdminPass123";

        public static void AddTaxes(ICollection<Tax> taxes)
        {
            Console.WriteLine("Are you admin or not. If you are, add your pass, else add (No)!");

            var input = Console.ReadLine();

            if (input == AdminPass)
            {
                while (true)
                {
                    Console.WriteLine("If you want to add taxes add (Yes), else add (No)!");

                    var conditionAdd = Console.ReadLine();

                    if (conditionAdd.ToLower() == "yes")
                    {
                        string name, ifRange;
                        decimal taxPersent;

                        Inputs(out name, out taxPersent, out ifRange);

                        if (ifRange.ToLower() == "yes")
                        {
                            RangeRequirment(taxes, name, taxPersent);
                        }
                        else
                        {
                            NonRangeRequirment(taxes, name, taxPersent);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Password incorrect!");
            }

        }

        private static void Inputs(out string name, out decimal taxPersent, out string ifRange)
        {
            Console.WriteLine("Add tax name");
            name = Console.ReadLine();

            Console.WriteLine("Аdd the tax in percentages");
            taxPersent = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Аdd (Yes) for range requirement, else add (No)");
            ifRange = Console.ReadLine();
        }

        private static void NonRangeRequirment(ICollection<Tax> taxes, string name, decimal taxPersent)
        {
            decimal number = 0;

            while (true)
            {
                Console.WriteLine("Add a number for the lower limit");
                number = decimal.Parse(Console.ReadLine());
                if (number <= 1000)
                {
                    Console.WriteLine("Add number, greather than 1000!");
                }
                else
                {
                    break;
                }
            }

            taxes.Add(new Tax { Name = name, Value = taxPersent, LowLimitSalary = number - 1000 });
        }

        private static void RangeRequirment(ICollection<Tax> taxes, string name, decimal taxPersent)
        {
            Console.WriteLine("Add a number for the lower limit");
            decimal lowerNumber = 0;

            while (true)
            {
                Console.WriteLine("Add a number for the lower limit");
                lowerNumber = decimal.Parse(Console.ReadLine());
                if (lowerNumber <= 1000)
                {
                    Console.WriteLine("Add number, greather than 1000!");
                }
                else
                {
                    break;
                }
            }

            decimal upperNumber = 0;

            while (true)
            {
                Console.WriteLine("Add a number for the upper limit");
                upperNumber = decimal.Parse(Console.ReadLine());
                if (upperNumber <= lowerNumber)
                {
                    Console.WriteLine("Add number, greather than lower limit number!");
                }
                else
                {
                    break;
                }
            }

            taxes.Add(new Tax { Name = name, Value = taxPersent, LowLimitSalary = lowerNumber - 1000, UpperLimitSalary = upperNumber });
        }
    }
}
