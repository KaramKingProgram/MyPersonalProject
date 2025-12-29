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
using static System.Net.Mime.MediaTypeNames;

namespace MyPersonalApp
{
    public partial class AddEdit_Incomes : Form
    {
       private clsIncomes incomes;
       private int IncomeID,PersonID;

        enum EnMode {AddNew = 0,Update = 1 };

       private EnMode Mode;
        public AddEdit_Incomes(int IncomeID,int PersonID)
        {

            InitializeComponent();

            this.IncomeID = IncomeID;   
            this.PersonID = PersonID;         
            
            if (IncomeID == -1)
            {
                Mode = EnMode.AddNew;
            }
            else
            {
                Mode = EnMode.Update;
            }

        }
        private void FillIncomeSources()
        {
            DataTable dt = clsIncomeSources.GetIncomeSourceData();
            cbIncomeSources.DataSource = dt;
            cbIncomeSources.DisplayMember = "Name_Source";
            cbIncomeSources.ValueMember = "IncomeSourceID";

            cbIncomeSources.SelectedIndex = 1;

        }

        private void FillPaymentMethodCombo()
        {
            DataTable dt = clsPaymentMethods.GetAllPaymentMethods();

            cbIncomePaymentMethod.DataSource = dt;
            cbIncomePaymentMethod.DisplayMember = "Name_Method";
            cbIncomePaymentMethod.ValueMember = "PaymentMethodID";

            cbIncomePaymentMethod.SelectedIndex = 0;

        }

        private void FillCurrenciesCombo()
        {
            DataTable dt = clsCurrencies.GetAllCurrencyData();

            cbIncomeCurrencyTypes.DataSource = dt;
            cbIncomeCurrencyTypes.DisplayMember = "Currency_Name";
            cbIncomeCurrencyTypes.ValueMember = "CurrencyID";

            cbIncomeCurrencyTypes.SelectedIndex = 0;
        }

        private void DateTimeScreen()
        {
            lblDateTime.Text = DateTime.Now.ToString("g");
            dtpIncome.Value = DateTime.Now;
        }

        private void LoadDataScreen()
        {
            FillIncomeSources();
            FillPaymentMethodCombo();
            FillCurrenciesCombo();
            DateTimeScreen();

            if (Mode == EnMode.AddNew)
            {
                lblAddEditIncomes.Text = "Add New Expense";
                incomes = new clsIncomes();
                return;

            }
            incomes = clsIncomes.Find(IncomeID);

            if (incomes == null)
            {

                MessageBox.Show("This form will be closed because No Incomes with ID = " + IncomeID.ToString(), "Warnning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();

                return;

            }

            lblAddEditIncomes.Text = "Edit Income Screen";
            lblIncomeID.Text = IncomeID.ToString();
            IncomeID = incomes.IncomesID;
            dtpIncome.Value = incomes.IncomeDate;
            txtIncomeDescription.Text = incomes.Description_Incomes;

            txtIncomeAmount.Text = incomes.IncomesAmount.ToString();

            cbIncomeSources.SelectedValue = incomes.IncomesSourceID;
            cbIncomePaymentMethod.SelectedValue = incomes.PaymentMethodID;
            cbIncomeCurrencyTypes.SelectedValue = incomes.CurrencyID;

           


        }

        private void AddEdit_Incomes_Load(object sender, EventArgs e)
        {
            LoadDataScreen();
        }

        private void txtIncomeAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIncomeAmount.Text))
            {

                txtIncomeAmount.Focus();
                errorProvider2.SetError(txtIncomeAmount, "This Item Should Have A Value!!");
            }
            else
            {

                errorProvider2.SetError(txtIncomeAmount, "");
            }
        }

        private void btnIncomeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIncomeSave_Click(object sender, EventArgs e)
        {
            incomes.IncomeDate =  dtpIncome.Value;
           
            incomes.Description_Incomes = txtIncomeDescription.Text;

            if (!decimal.TryParse(txtIncomeAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount");
                return;
            }
            incomes.IncomesAmount = amount;


            incomes.CurrencyID = Convert.ToInt32(cbIncomeCurrencyTypes.SelectedValue);


            incomes.IncomesSourceID = Convert.ToInt32(cbIncomeSources.SelectedValue);


            incomes.PaymentMethodID = Convert.ToInt32(cbIncomePaymentMethod.SelectedValue);


            incomes.PersonID = this.PersonID;


            if (incomes.Save())
            {
                Mode = EnMode.Update;
                MessageBox.Show("Saved Income Operation successfully :)", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.IncomeID = incomes.IncomesID;
                lblIncomeID.Text = this.IncomeID.ToString();
                lblAddEditIncomes.Text = "Edit Incomes Screen";
            }
            else
            {
                MessageBox.Show("Saved Income Operation was Faild :(", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

      
    }
}
