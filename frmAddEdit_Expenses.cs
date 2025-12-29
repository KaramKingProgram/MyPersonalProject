using Guna.UI2.WinForms;
using MyBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPersonalApp
{
    public partial class frmAddEdit_Expenses : Form
    {
        
        public frmAddEdit_Expenses()
        {
           

        }
        clsExpenses _Expenses;

        private int _ExpensesID,_PersonID;

        enum EnMode { AddNew = 0, Update = 1 }
        
        private EnMode _Mode;

       public frmAddEdit_Expenses(int ExpensesID,int PersonID)
        {
            InitializeComponent();

            this._ExpensesID = ExpensesID;

            this._PersonID = PersonID;

            if (ExpensesID != -1) {
          _Mode=EnMode.Update;
            }
            else
            {
                  _Mode = EnMode.AddNew;
            }
            
        }

        private void LoadData()
        {

            DateTimeScreen();

            FillCurrenciesCombo();

            FillPaymentMethodCombo();

            FillExpensesTypeCombo();

            if (_Mode == EnMode.AddNew)
            {
                lblAddEditExpenses.Text = "Add New Expense";
                _Expenses = new clsExpenses();
                return ;

            }
           _Expenses = clsExpenses.Find(_ExpensesID);

            if (_Expenses == null)
            {

                MessageBox.Show("This form will be closed because No Expenses with ID = " + _ExpensesID.ToString(), "Warnning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();

                return;

            }
            lblAddEditExpenses.Text = "Edit Expenses Screen" + _ExpensesID.ToString();
            lblExpensID.Text = _ExpensesID.ToString();
            _ExpensesID = _Expenses.ExpenseID;
             dtpExpenses.Value  = _Expenses.ExpensesDate;
             txtDescription.Text = _Expenses.Description_ex;

         
            txtExpenseName.Text = _Expenses.ExpenseName;
            txtExpensesAmount.Text = _Expenses.Exchgange_Amount.ToString();

            cbExpenseType.SelectedValue = _Expenses.ExpenseType;
            cbPaymentMethod.SelectedValue = _Expenses.PaymentMethod;
            cbCurrencyTypes.SelectedValue = _Expenses.CurrencyID;

          

        }
         
        private void FillExpensesTypeCombo()
        {
            DataTable dt = clsExpensesType.GetAllExpensesType();

            cbExpenseType.DataSource = dt;
            cbExpenseType.DisplayMember = "Name_Type";
            cbExpenseType.ValueMember = "ExpensesTypesID";

            //cbExpenseType.SelectedIndex = 0;

        }
        private void FillPaymentMethodCombo()
        {
            DataTable dt = clsPaymentMethods.GetAllPaymentMethods();

            cbPaymentMethod.DataSource = dt;
            cbPaymentMethod.DisplayMember = "Name_Method";
            cbPaymentMethod.ValueMember = "PaymentMethodID";

            cbPaymentMethod.SelectedIndex = 0;

        }
        private void FillCurrenciesCombo()
        {
            DataTable dt = clsCurrencies.GetAllCurrencyData();

            cbCurrencyTypes.DataSource = dt;
            cbCurrencyTypes.DisplayMember = "Currency_Name";
            cbCurrencyTypes.ValueMember = "CurrencyID";

            cbCurrencyTypes.SelectedIndex = 0;
        }
        private void DateTimeScreen()
        {
            lblDateTime.Text = DateTime.Now.ToString("g");
            dtpExpenses.Value = DateTime.Now;   
        }

      

        private void txtExpenseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
            
                txtExpensesAmount.Focus();

                e.SuppressKeyPress = true;
            }
        }

       
        private void CheckValidatingError(object sender,CancelEventArgs e,Guna2TextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
               
                text.Focus();
                errorProvider1.SetError(text, "This Item Should Have A Value!!");


            }
            else
            {
               
                errorProvider1.SetError(text, "");
            }


        }
       

        private void txtExpensesAmount_Validating(object sender, CancelEventArgs e)
        {
            CheckValidatingError(sender, e,txtExpensesAmount);
        }

        private void frmAddEdit_Expenses_Load_1(object sender, EventArgs e)
        {
         LoadData();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _Expenses.ExpensesDate = dtpExpenses.Value;
            _Expenses.ExpenseName = txtExpenseName.Text.Trim();
            _Expenses.Description_ex = txtDescription.Text;

            if (!decimal.TryParse(txtExpensesAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount");
                return;
            }
            _Expenses.Exchgange_Amount = amount;


            _Expenses.CurrencyID = Convert.ToInt32(cbCurrencyTypes.SelectedValue);


            _Expenses.ExpenseType = Convert.ToInt32(cbExpenseType.SelectedValue);


            _Expenses.PaymentMethod = Convert.ToInt32(cbPaymentMethod.SelectedValue);


            _Expenses.PersonID = this._PersonID;


            if (_Expenses.Save())
            {
                _Mode = EnMode.Update;
                MessageBox.Show("Saved Expenese Operation successfully :)", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ExpensesID = _Expenses.ExpenseID;
                lblExpensID.Text = _ExpensesID.ToString();
                lblAddEditExpenses.Text = "Edit Expenses Screen";
            }
            else
            {
                MessageBox.Show("Saved Expenese Operation was Faild :(", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }







        }
    }
}
