using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBuisnessLayer;


namespace MyPersonalApp
{
    public partial class MainForm : Form
    {


       



    private object defaultStyle;
       private int PersonID;
        private bool _IsdgvExpensesHasData()
        {
            return (dgvExpenses.Rows.Count > 0);
        }

        private void RefreshExpensesData()
        {
            dgvExpenses.DataSource = clsExpenses.GetAllExpensesData(this.PersonID);

            if (_IsdgvExpensesHasData())
            {
                lblNoData.Visible = false;
            }
            else
            {
                lblNoData.Visible = true;
            }

            defaultStyle = dgvExpenses.RowsDefaultCellStyle.Clone();

        }


        private bool _IsdgvDashboardHasData()
        {
            return (dgvDashboard.Rows.Count > 0);
        }

    

        private void PercentageExpenseTypes()
        {
            DataTable dataTable = clsDashboards.GetAllExpensesTypePerc(PersonID);

            pbFood.Value = 0;
            pbGym.Value = 0;
            pbEntertainment.Value = 0;
            pbEducation.Value = 0;
            pbOthers.Value = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                string typeName = row["Name_Type"].ToString();
                int perc = row["TypesPerc"] != DBNull.Value
                    ? Convert.ToInt32(Math.Round(Convert.ToDecimal(row["TypesPerc"])))
                    : 0;

                switch (typeName)
                {
                    case "Food":
                        pbFood.Value = perc;
                        pbFood.ProgressColor = Color.Green;
                        break;

                    case "Gym":
                        pbGym.Value = perc;
                        pbGym.ProgressColor = Color.Orange;
                        break;

                    case "Entertainment":
                        pbEntertainment.Value = perc;
                        pbEntertainment.ProgressColor = Color.SkyBlue;
                        break;

                    case "Education":
                        pbEducation.Value = perc;
                        pbEducation .ProgressColor = Color.GreenYellow;
                        break;

                    default:
                        pbOthers.Value += perc;
                        pbOthers .ProgressColor = Color.Red;  
                        break;
                }
            }
        }
        private void RefreshDashboardData()
        {
            dgvDashboard.DataSource = clsDashboards.GetAllDashboardData(this.PersonID);
            LoadDashboardData();
            PercentageExpenseTypes();
            if (_IsdgvDashboardHasData())
            {
                lblNoDataDashboards.Visible = false;  
            }
            else
            {
                lblNoDataDashboards.Visible = true;

            }

            defaultStyle = dgvDashboard.RowsDefaultCellStyle.Clone();

        }

        private void LoadDashboardData()
        {
            lblAmountToDay.Text = clsDashboards.ExpensesAmountThisDay(PersonID).ToString();
            lblExpensesThisMonth.Text = clsDashboards.ExpensesAmountThisMonth(PersonID).ToString();
            lblIncomesAmountThisMonth.Text = clsDashboards.IncomesAmountThisMonth(PersonID).ToString();

            lblTotalExpenses.Text = clsDashboards.TotalExpenseAmount(PersonID).ToString();
            lblTotalIncomes.Text = clsDashboards.TotalIncomeAmount(PersonID).ToString();

            
            if (clsDashboards.TotalBalanceAmount(PersonID) > 0)
            {
                lblNetBalance.ForeColor = Color.Chartreuse;
               
            }
            else
            {
                lblNetBalance.ForeColor= Color.Red;
            }

            lblNetBalance.Text  = clsDashboards.TotalBalanceAmount(PersonID).ToString();
        }


        private void LoadData()
        {

            RefreshExpensesData();
            RefreshIncomeData();
            RefreshDashboardData();

        }
        public MainForm(int PersonID)
        {
            InitializeComponent();

           this.PersonID = PersonID;

        }

        private void FillExpensesTypeCombo()
        {
            DataTable dt = clsExpensesType.GetAllExpensesType();

            cbExpensesType.DataSource = dt;
            cbExpensesType.DisplayMember = "Name_Type";
            cbExpensesType.ValueMember = "ExpensesTypesID";

            //cbExpenseType.SelectedIndex = 0;

        }
        private void FillIncomeSources()
        {
            DataTable dt = clsIncomeSources.GetIncomeSourceData();

            cbIncomeSources.DataSource = dt;
            cbIncomeSources.DisplayMember = "Name_Source";
            cbIncomeSources.ValueMember = "IncomeSourceID";

            cbIncomeSources.SelectedIndex = 0;

        }
        private void CheckSearchExpenses()
        {
            if (chkSearch.Checked)
            {
                gbSearch.Enabled = true;

                FillExpensesTypeCombo();

            }
            else
            {
                gbSearch.Enabled = false;
            }

        }


        private void CheckTransExpenses()
        {
            if (chkTrans.Checked)
            {

                gbTrans.Enabled = true;

            }
            else
            {
                gbTrans.Enabled = false;

            }

        }




        private void chkTrans_CheckedChanged(object sender, EventArgs e)
        {
            CheckTransExpenses();
        }




        private void chkSearchIncome_CheckedChanged(object sender, EventArgs e)
        {
            CheckSearchIncomes();
        }


        private void AddNewExpenses()
        {
            frmAddEdit_Expenses frmAddEdit = new frmAddEdit_Expenses(-1,this.PersonID);

            frmAddEdit.ShowDialog();

            LoadData();

        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            AddNewExpenses();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void DeleteEpenses()
        {
            if (MessageBox.Show("Are you sure you want to delete Expenses [" + dgvExpenses.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {


                //Perform Delele and refresh
                if (clsExpenses.DeleteExpense((int)dgvExpenses.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Expense(s) Deleted Successfully.");

                    RefreshExpensesData();
                }

                else
                    MessageBox.Show("Expense(s) is not deleted.");



            }
        }
        private void btnDeleteExpenses_Click(object sender, EventArgs e)
        {
            DeleteEpenses();
        }

        private void EditExpenses()
        {
            if (dgvExpenses.SelectedCells.Count > 0)
            {

                int ExpensesID = (int)dgvExpenses.CurrentRow.Cells[0].Value;

                frmAddEdit_Expenses frmAddEdit = new frmAddEdit_Expenses(ExpensesID,this.PersonID);

                frmAddEdit.ShowDialog();

                RefreshExpensesData();

            }

        }
        private void btnUpdateExpenses_Click(object sender, EventArgs e)
        {
            EditExpenses();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewExpenses();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEpenses();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditExpenses();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshExpensesData();
        }


        private void SearchDataByDate()
        {
            DataView dv = clsExpenses.GetAllExpensesData(PersonID).DefaultView;
            DateTime date = dtpSearchExpenses.Value.Date;
            dv.RowFilter = $"ExpenseDate = '{date}'";
            if (dv.Count > 0)
            {

                dgvExpenses.DataSource = dv;
                return;
            }
            MessageBox.Show("There Is No Data Within Date = [" + date.ToString("D") + "]", "Date Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExpensesDateSearch_Click(object sender, EventArgs e)
        {
            SearchDataByDate();
        }

        private void SearchDataByExpensesType()
        {

            DataView dv = clsExpenses.GetAllExpensesData(PersonID).DefaultView;

            string Type = $"{cbExpensesType.Text.Trim()}";
            dv.RowFilter = $"ExpenseType = '{Type}'";

            if (dv.Count > 0)
            {


                dgvExpenses.DataSource = dv;
                return;

            }

            MessageBox.Show("There Is No Data With This Expenses Type = [" + Type + "]", "Type Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnExpensesTypeSearch_Click(object sender, EventArgs e)
        {
            SearchDataByExpensesType();
        }

        private void CheckSearchIncomes()
        {
            if (chkSearchIncome.Checked)
            {
                gbSearchIncome.Enabled = true;
                FillIncomeSources();
            }
            else
            {
                gbSearchIncome.Enabled = false;
            }

        }
        private void CheckTransIncomes()
        {
            if (chkTransIncome.Checked)
            {

                gbTransIncomes.Enabled = true;
                
            }
            else
            {
                gbTransIncomes.Enabled = false;

            }

        }
        private void chkSearch_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckSearchExpenses();
        }

        private void chkTransIncome_CheckedChanged(object sender, EventArgs e)
        {
            CheckTransIncomes();
        }

        private bool _IsdgvIncomesHasData()
        {
            return (dgvIncomesData.Rows.Count > 0);
        }
        private void RefreshIncomeData()
        {
            dgvIncomesData.DataSource = clsIncomes.GetAllRealIncomesData(this.PersonID);

            if (_IsdgvIncomesHasData())
            {
                lblDgvIncomeData.Visible = false;
            }
            else
            {
                lblDgvIncomeData.Visible = true;

            }

        }



        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RefreshIncomeData();
        }

       
        private void AddNewIncome()
        {
            AddEdit_Incomes incomes = new AddEdit_Incomes(-1, this.PersonID);

            incomes.ShowDialog();

            RefreshIncomeData();
        }
        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            AddNewIncome();
        }

        private void EditIncomesData()
        {
            if (dgvIncomesData.SelectedCells.Count > 0)
            {

                int IncomeID = (int)dgvIncomesData.CurrentRow.Cells[0].Value;

                AddEdit_Incomes frmAddEdit = new AddEdit_Incomes(IncomeID, this.PersonID);

                frmAddEdit.ShowDialog();

                RefreshIncomeData();

            }
        }
        private void btnUpdateIncome_Click(object sender, EventArgs e)
        {
            EditIncomesData();
        }

        private void DeleteIncomes()
        {
            if (MessageBox.Show("Are you sure you want to delete Incomes [" + dgvIncomesData.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {


                //Perform Delele and refresh
                if (clsIncomes.DeleteIncome((int)dgvIncomesData.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Income(s) Deleted Successfully.");

                    RefreshIncomeData();
                }

                else
                    MessageBox.Show("Income(s) is not deleted.");



            }
        }
        private void btnDeleteIncome_Click(object sender, EventArgs e)
        {
            DeleteIncomes();
        }


        private void SearchIncomeDataByDate()
        {
            DataView dv = clsIncomes.GetAllRealIncomesData(PersonID).DefaultView;
            DateTime date = dtpSearchIncome.Value.Date;
            dv.RowFilter = $"IncomeDate = '{date}'";
            if (dv.Count > 0)
            {

                dgvIncomesData.DataSource = dv;
                return;
            }
            MessageBox.Show("There Is No Data Within Date = [" + date.ToString("D") + "]", "Date Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void SearchDataByIncomeSource()
        {

            DataView dv = clsIncomes.GetAllRealIncomesData(PersonID).DefaultView;

            string Type = $"{cbIncomeSources.Text.Trim()}";
            dv.RowFilter = $"Name_Source = '{Type}'";

            if (dv.Count > 0)
            {


                dgvExpenses.DataSource = dv;
                return;

            }

            MessageBox.Show("There Is No Data With This Income Source = [" + Type + "]", "Source Type Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void btnSearchIncomeDate_Click(object sender, EventArgs e)
        {
            SearchIncomeDataByDate();
        }

        private void btnSearchIncomeSource_Click(object sender, EventArgs e)
        {
            SearchDataByIncomeSource();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewIncome();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteIncomes();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            EditIncomesData();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RefreshDashboardData();
        }

        
    }
    }
