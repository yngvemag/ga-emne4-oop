using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 customerNumber,checkNumber,paymentDate,amount
    103,HQ336336,2004-10-19,6066.78
 */
namespace ClassicModelsLibrary.model
{
    public class Payment
    {
        public int CustomerId { get; set; }
        public string CheckNumber { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"CustomerId:{CustomerId}, CheckNumber:{CheckNumber}, " +
                $"PaymentDate:{PaymentDate.ToShortDateString()}, Amount:{Amount}";
        }
    }
}
