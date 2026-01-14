using DataAccessesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBuisnessLayer
{
    public class clsDashboards
    {
        public static DataTable GetAllDashboardData(int PersonID)
        {
            return clsDashboardData.GetAllDashboardData(PersonID);
        }

        public static DataTable GetAllExpensesTypePerc(int PersonID)
        {
            return clsDashboardData.GetExpenseTypesPerc(PersonID);
        }

        public static decimal IncomesAmountThisMonth(int PersonID)
        {
            return clsDashboardData.GetIncomesThisMonth(PersonID);
        }
        public static decimal ExpensesAmountThisMonth(int PersonID)
        {
            return clsDashboardData.GetExpensesThisMonth(PersonID);
        }

        public static decimal ExpensesAmountThisDay(int PersonID)
        {
            return (clsDashboardData.GetExpensesInThisDay(PersonID));
        }

        public static decimal TotalIncomeAmount(int PersonID)
        {
            return clsDashboardData.GetTotalIncomes(PersonID);
        }

        public static decimal TotalExpenseAmount(int PersonID)
        {
            return clsDashboardData.GetTotalExpenses(PersonID);
        }

        public static decimal TotalBalanceAmount(int PersonID)
        {
            return (TotalIncomeAmount(PersonID) - TotalExpenseAmount(PersonID));    
        }

    }
}
