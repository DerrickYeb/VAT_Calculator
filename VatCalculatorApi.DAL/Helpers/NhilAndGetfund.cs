using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Models;

namespace VatCalculatorApi.DAL.Helpers
{
    public static class NhilAndGetfund
    {
        public static decimal GetfundAndNhilResult(decimal amount,UserOutputModel userOutput)
        {
            decimal result = 0M;
            if (amount != 0)
            {
                result = amount * RateExtensions.GetfundAndNhil;
                userOutput.Nhil = result;
                userOutput.Getfund = result;
                Math.Round(result);
            }
            return result;
        }
        public static decimal GetfundAndNhilResult(decimal amount,UserInputsModel userInputs)
        {
            decimal result = 0M;
            if (amount != 0)
            {
                result = amount * RateExtensions.GetfundAndNhil;
                userInputs.Nhil = result;
                userInputs.Getfund = result;
                Math.Round(result);
            }
            return result;
        }
    }
}
