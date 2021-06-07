using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VatCalculatorApi.DAL.Models
{
    public class UserInputsModel
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        [Display(Name ="Flat Rate")]
        public bool IsFlatRate { get; set; }
        [Display(Name ="Standard Rate")]
        public bool IsStandardRate { get; set; }

        //Output Result
        public decimal TotalVat { get; set; }
        public decimal Nhil { get; set; }
        public decimal Getfund { get; set; }
        public decimal StandardRate { get; set; }
        public decimal FlatRate { get; set; }
        public decimal VAT { get; set; }
    }
}
