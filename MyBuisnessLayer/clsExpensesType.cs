using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessesLayer;
namespace MyBuisnessLayer
{
    public class clsExpensesType
    {
        public int ExpensesTypeId { get; set; } 

        public string ExpensesTypeName { get; set; } = string.Empty;

        public static DataTable GetAllExpensesType()
        {
            return ClsExpensesTypeData.GetAllExpensesTypeData();
        }

    }
}
