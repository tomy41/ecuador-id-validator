using System;
using System.Collections.Generic;
using System.Linq;

namespace ecuador.id.validator.Validators
{
    internal class Module10Validator : ModuleValidator
    {
        public Module10Validator()
        {
            int[] module10coeficients = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            coeficients = module10coeficients;
            moduleBase = 10;
        }

        protected override int CalculateModuleResult(int moduleSum)
        {
            var moduleSumNextHighest10 = (int)(Math.Ceiling(moduleSum / 10.0d) * 10);
            return moduleSumNextHighest10 - moduleSum;
        }

        protected override int DigitModuleResult(int coeficient, int digit)
        {
            var result = coeficient * digit;
            if (result < 10)
                return result;

            return result.ToString().Sum(c => c - '0');
        }
    }

    internal class Module11Validator : ModuleValidator
    {
        public Module11Validator(int[] moduleCoeficients)
        {
            coeficients = moduleCoeficients;
            moduleBase = 11;
        }

        protected override int CalculateModuleResult(int moduleSum)
        {
            var remainder = moduleSum % moduleBase;
            return remainder == 0 ? 0 : moduleBase - remainder;
        }

        protected override int DigitModuleResult(int coeficient, int digit)
        {
            return coeficient * digit;
        }
    }

    internal abstract class ModuleValidator : IModuleValidator
    {
        protected int[] coeficients;
        protected int moduleBase;

        public int CalculateModule(string document)
        {
            int[] documentDigits = document.ToCharArray()
                .Select(digit => int.Parse(digit.ToString()))
                .ToArray();

            var moduleResults = new List<int>();
            for (int operationIndex = 0; operationIndex < coeficients.Length; operationIndex++)
            {
                moduleResults.Add(
                    DigitModuleResult(coeficients[operationIndex], documentDigits[operationIndex]));
            }

            var moduleSum = moduleResults.Sum();
            return CalculateModuleResult(moduleSum);
        }

        protected abstract int CalculateModuleResult(int moduleSum);

        protected abstract int DigitModuleResult(int coeficient, int digit);
    }
}