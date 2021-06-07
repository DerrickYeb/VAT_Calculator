using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueAddedTaxApi.Controllers;
using VatCalculatorApi.DAL.Contracts;
using VatCalculatorApi.DAL.Models;
using VatCalculatorApi.DAL.Repositories;
using Xunit;

namespace ValueAddedTaxApi.Test.ApiControllers
{
    public class VatControllerTest
    {
        private readonly ICalculateVatRepository _repo;
        private readonly VatController _controller;
        public VatControllerTest()
        {
            _repo = new CalculateVatRepository();
            _controller = new VatController(_repo);
        }

        [Fact]
        public void VatCalculated_Returns_OkObject_Response()
        {
            // UserOutputModel model = new();
            var userInputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 4,
                IsFlatRate = true,
                IsStandardRate = true
            };
            var returnedResponse = _controller.CalculateValueAddedTax(userInputs);
            Assert.IsType<OkObjectResult>(returnedResponse);
        }
        [Fact]
        public void ValidObjectPassed_ReturnedResponse()
        {
            var userInputs = new UserInputsModel
            {
                Amount = 2000,
                Quantity = 20,
                IsFlatRate = true,
                IsStandardRate = true
            };

            var objectPassed = _controller.CalculateValueAddedTax(userInputs) as OkObjectResult;
            var modelItem = objectPassed.Value as UserOutputModel;

            Assert.IsType<UserOutputModel>(modelItem);
           
        }
        [Fact]
        public void Check_InvalidObjectPassed_ReturnsBadRequest()
        {
           
            var missingObject = new UserInputsModel
            {
                Amount = 200,
                IsStandardRate = true
            };
            _controller.ModelState.AddModelError("Quantity", "Required");

            var badResponse = _controller.CalculateValueAddedTax(missingObject);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}
