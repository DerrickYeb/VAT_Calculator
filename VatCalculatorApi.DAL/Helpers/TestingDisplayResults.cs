using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Models;

namespace VatCalculatorApi.DAL.Helpers
{
    public static class TestingDisplayResults
    {
        public static decimal StandardAndFlatRateVatPayable(UserInputsModel inputsModel)
        {
            decimal totalPrice = inputsModel.Amount * inputsModel.Quantity;
            //decimal vat = totalPrice * (RateExtensions.Getfund + Nhil(inputsModel.Amount));
            decimal totalVat = RateExtensions.VatRate * (totalPrice + Getfund(inputsModel.Amount) + Nhil(inputsModel.Amount)) + OnlyFlatRateResult(inputsModel);
            inputsModel.TotalVat = Math.Round(totalVat);
            inputsModel.VAT = totalVat;
            StandardRateAndFlatRate(inputsModel);
            return inputsModel.TotalVat;
        }
        public static decimal OnlyStandardRateResult(UserInputsModel inputsModel)
        {
            decimal totalPrice = (inputsModel.Amount * inputsModel.Quantity);
            inputsModel.StandardRate = totalPrice * RateExtensions.StandardRate;
            inputsModel.TotalVat = RateExtensions.VatRate * (totalPrice + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount));
            inputsModel.VAT = RateExtensions.VatRate * (totalPrice + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount));
            return inputsModel.StandardRate;
        }
        public static decimal OnlyFlatRateResult(UserInputsModel inputsModel)
        {
            inputsModel.FlatRate = inputsModel.Amount * inputsModel.Quantity * RateExtensions.FlatRate;
            inputsModel.TotalVat = inputsModel.FlatRate;
            inputsModel.VAT = 0;
            return inputsModel.FlatRate;
        }
        
        public static decimal OnlyVatResult(UserInputsModel inputsModel)
        {
            decimal totalPrice = inputsModel.Amount * inputsModel.Quantity;
            return inputsModel.VAT = RateExtensions.VatRate * (totalPrice * Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount));
        }
        public static decimal StandardRateAndFlatRate(UserInputsModel inputsModel)
        {
            inputsModel.FlatRate = inputsModel.Amount * inputsModel.Quantity * RateExtensions.FlatRate;
            return inputsModel.StandardRate = RateExtensions.StandardRate * (inputsModel.Amount * inputsModel.Quantity) + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount);

        }
        public static decimal Nhil(decimal amount)
        {
            return RateExtensions.Nhil * amount;
        }
        public static decimal Getfund(decimal amount)
        {
            return RateExtensions.Getfund * amount;
        }
    }
}
