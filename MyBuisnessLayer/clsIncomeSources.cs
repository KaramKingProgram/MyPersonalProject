using DataAccessesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuisnessLayer
{
    public class clsIncomeSources
    {
      public int SourceID { get; set; }
      public string SourceName { get; set; } 
       
        public static DataTable GetIncomeSourceData()
        {
            return clsIncomeSourceData.GetIncomeSources();
        }

    }
}
