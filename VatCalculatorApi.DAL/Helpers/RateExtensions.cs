using System;
using System.Collections.Generic;
using System.Text;

namespace VatCalculatorApi.DAL.Helpers
{
    /// <summary>
    /// Rate Extension for Vat App Api
    /// Changes to this rate can only be done here without
    /// altering the repository class
    /// </summary>
    public static class RateExtensions
    {
        public static decimal StandardAndFlatRate => Convert.ToDecimal(0.125 + 0.03);
        public static decimal StandardRate => Convert.ToDecimal(0.125);
        public static decimal FlatRate => Convert.ToDecimal(0.03);
        public static decimal Getfund => Convert.ToDecimal(0.025);
        public static decimal Nhil => Convert.ToDecimal(0.025);
        public static decimal VatRate => Convert.ToDecimal(0.125);
        public static decimal GetfundAndNhil => Convert.ToDecimal(0.025);
    }
}
