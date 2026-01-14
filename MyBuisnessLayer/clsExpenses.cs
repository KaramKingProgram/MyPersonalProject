using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessesLayer;
namespace MyBuisnessLayer
{
    public class clsExpenses
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode Mode = enMode.AddNew;
        public int ExpenseID { get; set; }

        public int ExpenseType { get; set; }

        public string ExpenseName { get; set; }

        public decimal Exchgange_Amount { get; set; }

        public DateTime ExpensesDate { get; set; } = DateTime.Now;

        public int PaymentMethod { get; set; }

        public string Description_ex { get; set; }

        public int PersonID { get; set; }

        public int CurrencyID { get; set; }

         
        public clsExpenses()
        {
            
            this.ExpenseID = 0;
            this.ExpenseType = 0;
            this.ExpenseName = string.Empty;
            this.Exchgange_Amount = 0;
            this.ExpensesDate = DateTime.Now;
            this.PaymentMethod = 0;
            this.Description_ex = string.Empty;
            this.PersonID = 0;
            this.CurrencyID = 0;

            Mode = enMode.AddNew;
        }

        public clsExpenses(int ExpensesID, int ExpenseType, string ExpensesName, decimal Exchgange_Amount, DateTime ExchgangeDate,
            int PaymentMethod, string Description, int PersonID, int CurrencyID)
        {
            this.ExpenseID = ExpensesID;
            this.ExpenseType = ExpenseType;
            this.ExpenseName = ExpensesName;
            this.Exchgange_Amount = Exchgange_Amount;
            this.ExpensesDate = ExchgangeDate;
            this.PaymentMethod = PaymentMethod;
            this.Description_ex = Description;
            this.PersonID = PersonID;
            this.CurrencyID = CurrencyID;

            Mode = enMode.Update;

        }

        private bool _AddNewExpenses()
        {

            this.ExpenseID = (clsExspensesData.AddNew(this.ExpenseName, this.Exchgange_Amount, this.ExpensesDate, this.ExpenseType, this.PaymentMethod, this.Description_ex, this.PersonID, this.CurrencyID));
            
            return (this.ExpenseID != -1);

            
        }

        private bool _UpdateExpenses()
        {
            return (clsExspensesData.UpdateExpenses(this.ExpenseID, this.ExpenseName, this.Exchgange_Amount, this.ExpensesDate, this.ExpenseType, this.PaymentMethod, this.Description_ex, this.PersonID, this.CurrencyID));
                 
        }

        public static bool DeleteExpense(int ExpensesID) {

            return (clsExspensesData.DeleteExpenses(ExpensesID));


        
        } 

        public static clsExpenses Find(int ExpensesID)
        {

            int ExpenseType = 0, PersonID = 0, CurrencyID = 0, PaymentMethod = 0;
            decimal ExchgangeAmount = 0;
            DateTime ExpensesDate = DateTime.Now;
            string Description = string.Empty, ExpensesName = string.Empty;


            if (clsExspensesData.GetExpensesInfoByID(ref ExpensesID, ref ExpensesName, ref ExchgangeAmount, ref ExpensesDate, ref ExpenseType,
               ref PaymentMethod, ref Description, ref PersonID, ref CurrencyID))
            {
                return new clsExpenses(ExpensesID, ExpenseType, ExpensesName, ExchgangeAmount, ExpensesDate, PaymentMethod, Description,
                     PersonID, CurrencyID);
            }


            return null;



        }

        public static clsExpenses Find(string ExpensesName)
        {

            int ExpensesID = 0,ExpenseType = 0, PersonID = 0, CurrencyID = 0, PaymentMethod = 0;
            decimal ExchgangeAmount = 0;
            DateTime ExpensesDate = DateTime.Now;
            string Description = string.Empty;


            if (clsExspensesData.GetExpensesInfoByID(ref ExpensesID, ref ExpensesName, ref ExchgangeAmount, ref ExpensesDate, ref ExpenseType,
               ref PaymentMethod, ref Description, ref PersonID, ref CurrencyID))
            {
                return new clsExpenses(ExpensesID, ExpenseType, ExpensesName, ExchgangeAmount, ExpensesDate, PaymentMethod, Description,
                     PersonID, CurrencyID);
            }


            return null;



        }

        public static DataTable GetAllData(int PersonID)
        {
          return clsExspensesData.GetAllExpenses(PersonID);
        }

        public static DataTable GetAllExpensesData(int PersonID)
        {
            return clsExspensesData.GetAllExpensesData(PersonID );
        }


        public static bool IsExpense(int ExpenseID){
        
            return clsExspensesData.IsExist(ExpenseID);
        
        }

        public bool Save()
        {
        
            switch (Mode)
            {
                case enMode.AddNew:
                  if (_AddNewExpenses())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    

                case enMode.Update:

                    return _UpdateExpenses();
                   
               
            }

            return false;
        }


    }
}
