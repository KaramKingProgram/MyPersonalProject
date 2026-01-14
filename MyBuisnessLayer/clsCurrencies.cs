using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessesLayer;
namespace MyBuisnessLayer
{
   public class clsCurrencies
    {
        public int CurrencyID { get; set; }    
        public string CurrencyName { get; set; } = string.Empty;

        public string Code { get; set; }

        public string Symbol { get; set; }

        public string IsBase { get; set; }


        public static DataTable GetAllCurrencyData()
        {
            return clsCurrencyData.GetAllData();
        }

    }
}
