using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessesLayer;
namespace MyBuisnessLayer
{
   public class clsPaymentMethods
    {
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }

        public static DataTable GetAllPaymentMethods()
        {
            return clsPaymentData.GetAllPaymentMethod();
        }

    }
}
