using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Contracts;
using VatCalculatorApi.DAL.Helpers;
using VatCalculatorApi.DAL.Models;

namespace VatCalculatorApi.DAL.Repositories
{
    public class CalculateVatRepository : ICalculateVatRepository
    {
        public UserOutputModel CalculateValueAddedTax(UserInputsModel inputs)
        {
            UserOutputModel output = new UserOutputModel();
            if (inputs.IsStandardRate == true && inputs.IsFlatRate == true)
            {
                DisplayResult.StandardAndFlatRateVatPayable(output, inputs);
            }
            else if(inputs.IsStandardRate != true && inputs.IsFlatRate != true)
            {
                DisplayResult.OnlyVatResult(output,inputs);
                //DisplayResult.DefaultRateValues(output);
            }
            else if (inputs.IsFlatRate != true)
            {
                DisplayResult.OnlyStandardRateResult(output, inputs);
            }
            else if(inputs.IsStandardRate != true)
            {
                DisplayResult.OnlyFlatRateResult(output, inputs);
            }
            else
            {
                DisplayResult.DefaultRateValues(output);
            }
            NhilAndGetfund.GetfundAndNhilResult(inputs.Amount, output);
            return output;
        }

        public UserInputsModel CalculateValueAddedTaxTest(UserInputsModel inputs)
        {
            if (inputs.IsStandardRate == true && inputs.IsFlatRate == true)
            {
                TestingDisplayResults.StandardAndFlatRateVatPayable(inputs);
            }
            else if (inputs.IsStandardRate != true && inputs.IsFlatRate != true)
            {
                TestingDisplayResults.OnlyVatResult(inputs);
                //DisplayResult.DefaultRateValues(output);
            }
            else if (inputs.IsFlatRate != true)
            {
                TestingDisplayResults.OnlyStandardRateResult(inputs);
            }
            else if (inputs.IsStandardRate != true)
            {
                TestingDisplayResults.OnlyFlatRateResult(inputs);
            }
            else
            {
                TestingDisplayResults.OnlyVatResult(inputs);
            }
            NhilAndGetfund.GetfundAndNhilResult(inputs.Amount,inputs);
            return inputs;
        }
    }
}
