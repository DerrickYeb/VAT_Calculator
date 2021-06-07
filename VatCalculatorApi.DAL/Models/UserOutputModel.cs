using System;
using System.Collections.Generic;
using System.Text;

namespace VatCalculatorApi.DAL.Models
{
    public class UserOutputModel
    {
        public decimal TotalVat { get; set; }
        public decimal Nhil { get; set; }
        public decimal Getfund { get; set; }
        public decimal StandardRate { get; set; }
        public decimal FlatRate { get; set; }
        public decimal VAT { get; set; }
    }
}
