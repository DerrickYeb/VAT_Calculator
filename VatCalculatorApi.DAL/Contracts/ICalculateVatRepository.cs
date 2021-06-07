using System;
using System.Collections.Generic;
using System.Text;
using VatCalculatorApi.DAL.Models;

namespace VatCalculatorApi.DAL.Contracts
{
    public interface ICalculateVatRepository
    {
        UserOutputModel CalculateValueAddedTax(UserInputsModel inputs);
        UserInputsModel CalculateValueAddedTaxTest(UserInputsModel inputs);
    }
}
