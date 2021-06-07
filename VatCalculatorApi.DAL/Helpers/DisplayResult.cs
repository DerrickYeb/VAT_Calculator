using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Models;
using VatCalculatorApi.DAL.Repositories;

namespace VatCalculatorApi.DAL.Helpers
{
    public static class DisplayResult
    {
        public static decimal StandardAndFlatRateVatPayable(this UserOutputModel userOutput,UserInputsModel inputsModel) 
        {
            decimal totalPrice = inputsModel.Amount * inputsModel.Quantity;
            //decimal vat = totalPrice * (RateExtensions.Getfund + Nhil(inputsModel.Amount));
            decimal totalVat = RateExtensions.VatRate * (totalPrice + Getfund(inputsModel.Amount) + Nhil(inputsModel.Amount)) + OnlyFlatRateResult(userOutput,inputsModel);
            userOutput.TotalVat = Math.Round(totalVat);
            userOutput.VAT = totalVat;
            StandardRateAndFlatRate(inputsModel, userOutput);
            return userOutput.TotalVat;
        }
        public static decimal OnlyStandardRateResult(this UserOutputModel userOutput,UserInputsModel inputsModel)
        {
            decimal totalPrice = (inputsModel.Amount * inputsModel.Quantity);
            userOutput.StandardRate = totalPrice * RateExtensions.StandardRate;
            userOutput.TotalVat = RateExtensions.VatRate * (totalPrice + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount));
            userOutput.VAT = RateExtensions.VatRate * (totalPrice + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount));
            return userOutput.StandardRate;
        }
        public static decimal OnlyFlatRateResult(this UserOutputModel userOutput,UserInputsModel inputsModel)
        {
            userOutput.FlatRate = inputsModel.Amount * inputsModel.Quantity * RateExtensions.FlatRate;
            userOutput.TotalVat = userOutput.FlatRate;
            userOutput.VAT = 0;
            return userOutput.FlatRate;
        }
       public static UserOutputModel DefaultRateValues(UserOutputModel userOutput)
        {
            var defaultRates = new UserOutputModel
            {
                FlatRate = Convert.ToDecimal(3 + "%"),
                StandardRate = Convert.ToDecimal(12.5 + "%"),
            };
            return defaultRates;
        }
        public static decimal OnlyVatResult(UserOutputModel userOutput,UserInputsModel inputsModel)
        {
            decimal totalPrice = inputsModel.Amount * inputsModel.Quantity;
           return userOutput.VAT =  Math.Round(RateExtensions.VatRate * (totalPrice * Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount)),2);
        }
        public static decimal StandardRateAndFlatRate(UserInputsModel inputsModel,UserOutputModel userOutput)
        {
            userOutput.FlatRate = inputsModel.Amount * inputsModel.Quantity * RateExtensions.FlatRate;
           return userOutput.StandardRate = RateExtensions.StandardRate * (inputsModel.Amount * inputsModel.Quantity) + Nhil(inputsModel.Amount) + Getfund(inputsModel.Amount);
            
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
