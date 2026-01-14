using DataAccessesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBuisnessLayer
{
    public class clsIncomes
    {
        public int IncomesID { get; set; }
        public decimal IncomesAmount { get; set; }

        public int IncomesSourceID { get; set; }

        public int PaymentMethodID { get; set; }

        public int PersonID { get; set; }

        public DateTime IncomeDate { get; set; }

        public string Description_Incomes { get; set; }

        public int CurrencyID { get; set; }

        enum EnMode { Addnew = 0, Update = 1 }

        EnMode Mode = EnMode.Addnew;

        private bool _AddNewIncome()
        {
            this.IncomesID = clsIncomesData.AddNew(this.IncomesAmount, this.IncomeDate, this.IncomesSourceID, this.PaymentMethodID, this.Description_Incomes, this.PersonID, this.CurrencyID);

            return (this.IncomesID != -1);
        }

        private bool _UpdateIncome()
        {

            return clsIncomesData.Update(this.IncomesID, this.IncomesAmount, this.IncomeDate, this.IncomesSourceID, this.PaymentMethodID, this.Description_Incomes, this.PersonID, this.CurrencyID);

        }
        public clsIncomes()
        {
            IncomesID = 0;
            IncomesAmount = 0;
            IncomesSourceID = 0;
            PaymentMethodID = 0;
            PersonID = 0;
            IncomeDate = DateTime.Now;
            Description_Incomes = string.Empty;
            CurrencyID = 0;

            Mode = EnMode.Addnew;

        }

        public clsIncomes(int incomesID, decimal IncomesAmount, int IncomeSource, int PaymentMethod, int PersonID, DateTime IncomeDate, string Description_Incomes,
           int CurrencyID)
        {
            this.IncomesID = incomesID;
            this.IncomesAmount = IncomesAmount;
            this.IncomesSourceID = IncomeSource;
            this.PaymentMethodID = PaymentMethod;
            this.PersonID = PersonID;
            this.IncomeDate = IncomeDate;
            this.Description_Incomes = Description_Incomes;
            this.CurrencyID = CurrencyID;

            Mode = EnMode.Update;

        }


        public static bool DeleteIncome(int IncomeID)
        {
            return clsIncomesData.Delete(IncomeID);
        }

        public static DataTable GetAllIncomesData(int PersonID)
        {
            return clsIncomesData.AllIncomesData(PersonID);
        }

        public static DataTable GetAllRealIncomesData(int PersonID)
        {
            return clsIncomesData.AllIncomesRealData(PersonID);




        }

        public static bool IsExsitIncome(int IncomeID)
        {
            return clsIncomesData.IsExsit(IncomeID);
        }

        public static clsIncomes Find(int IncomeID)
        {
            int IncomesSourceID = 0, PaymentMethodID = 0, PersonID = 0, CurrencyID = 0;
            decimal IncomesAmount = 0;

            DateTime IncomeDate = DateTime.Now;

            string Description_Incomes = string.Empty;



            if (clsIncomesData.GetIncomeByID(ref IncomeID, ref IncomesAmount, ref IncomeDate, ref IncomesSourceID, ref PaymentMethodID, ref Description_Incomes, ref PersonID,
                ref CurrencyID))
            {
                return new clsIncomes(IncomeID, IncomesAmount, IncomesSourceID, PaymentMethodID, PersonID, IncomeDate, Description_Incomes, CurrencyID);
            }
            return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Addnew:
                    if (_AddNewIncome())
                    {
                        Mode = EnMode.Update;
                        return true;
                    }
                    return false;

                case EnMode.Update:

                    return _UpdateIncome();

            }

            return false;
        }

    }
}
