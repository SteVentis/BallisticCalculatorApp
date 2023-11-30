using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.BallisticCalculations.Core.Services.Builder.Helper
{
    internal static class BallisticCardValuesFormat
    {
        public static double Rounding(double value)
        {
            return Math.Floor(value);
        }

        public static double RoundingAndConvertToAbsoluteValues(double value)
        {
            return Math.Abs(Math.Floor(value * Math.Pow(10, 2)) / Math.Pow(10, 2));
        }
    }
}
