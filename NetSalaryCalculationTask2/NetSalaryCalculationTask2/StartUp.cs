namespace NetSalaryCalculationTask2
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            //const string AdminPass = "AdminPass123";

            var taxes = new List<Tax>()
            {
                new Tax {Name="Income tax", Value = 10, LowLimitSalary=1},
                new Tax {Name="Social contributions", Value = 15, LowLimitSalary=1, UpperLimitSalary=3000}
            };

            //The explanation of how to add new tax to the system is implemented AdminLogic class
            //AdminLogic.AddTaxes(taxes);

            Console.WriteLine("Add your salary");

            var initialSalary = decimal.Parse(Console.ReadLine());

            var salaryWithNoTax = initialSalary <= 1000;

            if (salaryWithNoTax)
            {
                Console.WriteLine($"There is no taxation for any amount lower or equal to 1000");
                return;
            }

            var checkedAmount = initialSalary - 1000;

            decimal currentTax = 0;

            foreach (var tx in taxes)
            {
                var tax = tx.Value;

                var multiplier = CalcualateMultiplier(tax);

                if (tx.LowLimitSalary != 0 && tx.UpperLimitSalary == 0)
                {
                    AmountWithoutRange(ref checkedAmount, ref currentTax, tx, multiplier);
                }
                else if (tx.LowLimitSalary > 0 && tx.UpperLimitSalary > 0)
                {
                    AmountInRange(ref checkedAmount, ref currentTax, tx, multiplier);
                }
            }

            var netSalary = checkedAmount + 1000;

            Console.WriteLine($"Your net income is {netSalary:f2}");
        }

        private static void AmountWithoutRange(ref decimal checkedAmount, ref decimal currentTax, Tax tx, decimal multiplier)
        {
            var currentValue = tx.LowLimitSalary;

            var condition = checkedAmount >= currentValue;

            if (condition)
            {
                currentTax = checkedAmount - (checkedAmount * multiplier);
                checkedAmount = CheckedAmountCalculation(checkedAmount, currentTax);
            }
        }

        private static void AmountInRange(ref decimal checkedAmount, ref decimal currentTax, Tax tx, decimal multiplier)
        {
            var currentValueLower = tx.LowLimitSalary;
            var currentValueUpper = tx.UpperLimitSalary;

            var condition = checkedAmount >= currentValueLower && checkedAmount <= currentValueUpper;

            if (condition)
            {
                var remainder = checkedAmount % 1000;

                var аmountForTaxation = checkedAmount - remainder;

                currentTax = аmountForTaxation - (аmountForTaxation * multiplier);

                checkedAmount = CheckedAmountCalculation(checkedAmount, currentTax);
            }
        }

        private static decimal CheckedAmountCalculation(decimal checkedAmount, decimal currentTax)
        {
            checkedAmount = checkedAmount - currentTax;
            return checkedAmount;
        }

        private static decimal CalcualateMultiplier(decimal value)
        {
            var multiplier = (100 - value) / 100;
            return multiplier;
        }
    }
}
