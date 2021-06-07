using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Contracts;
using VatCalculatorApi.DAL.Helpers;
using VatCalculatorApi.DAL.Models;
using VatCalculatorApi.DAL.Repositories;
using Xunit;

namespace VatCalculatorDAL.Test
{
    
    public class CalculateVatTest
    {
        CalculateVatRepository repository = new CalculateVatRepository();

        UserOutputModel userOutput = new UserOutputModel();
        [Fact]
        public void CalculateFinalVat()
        {
            
            var userInputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 20,
                IsFlatRate = true,
                IsStandardRate = true
            };
            var result = repository.CalculateValueAddedTax(userInputs);
            
            Assert.Equal(6212,result.TotalVat);
        }
        [Fact]
        public void CalculateNhilAndGetFund()
        {
            var userInputs = new UserInputsModel
            {
                Amount = 2000
            };
            var nhil = NhilAndGetfund.GetfundAndNhilResult(userInputs.Amount,userOutput);
            Assert.Equal(50, nhil);
        }
        [Fact]
        public void CalculateVatOnly()
        {
            var inputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 20,
                IsFlatRate = false,
                IsStandardRate = false
            };
            var vatOnly = DisplayResult.OnlyVatResult(userOutput, inputs);
            userOutput.VAT = vatOnly;
            Assert.Equal(Convert.ToDecimal(250006.25), userOutput.VAT);
        }
        [Fact]
        public void CalculateStandardRateOnly()
        {
            var inputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 20,
                IsFlatRate = false,
                IsStandardRate = true
            };
            var vatOnly = DisplayResult.OnlyStandardRateResult(userOutput, inputs);
            userOutput.VAT = vatOnly;
            Assert.Equal(5000, Math.Round(userOutput.StandardRate),2);
        }
        [Fact]
        public void CalculateFlatRateOnly()
        {
            var inputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 20,
                IsFlatRate = true,
                IsStandardRate = false
            };
            var vatOnly = DisplayResult.OnlyFlatRateResult(userOutput, inputs);
            userOutput.VAT = vatOnly;
            Assert.Equal(1200, Math.Round(userOutput.FlatRate),2);
        }
    }
}
