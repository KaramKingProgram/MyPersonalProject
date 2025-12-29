namespace MyPersonalApp
{
    partial class frmAddEdit_Expenses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEdit_Expenses));
            this.lblAddEditExpenses = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblExpensID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtExpenseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtExpensesAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpExpenses = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbExpenseType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbCurrencyTypes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDateTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddEditExpenses
            // 
            this.lblAddEditExpenses.BackColor = System.Drawing.Color.Transparent;
            this.lblAddEditExpenses.Font = new System.Drawing.Font("Segoe Print", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditExpenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddEditExpenses.Location = new System.Drawing.Point(300, 30);
            this.lblAddEditExpenses.Name = "lblAddEditExpenses";
            this.lblAddEditExpenses.Size = new System.Drawing.Size(268, 52);
            this.lblAddEditExpenses.TabIndex = 0;
            this.lblAddEditExpenses.Text = "Add New Expense";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(70, 116);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(117, 28);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Expenses ID";
            // 
            // lblExpensID
            // 
            this.lblExpensID.BackColor = System.Drawing.Color.Transparent;
            this.lblExpensID.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpensID.Location = new System.Drawing.Point(280, 116);
            this.lblExpensID.Name = "lblExpensID";
            this.lblExpensID.Size = new System.Drawing.Size(39, 28);
            this.lblExpensID.TabIndex = 2;
            this.lblExpensID.Text = "????";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(70, 195);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(153, 28);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "Expenses Name";
            // 
            // txtExpenseName
            // 
            this.txtExpenseName.Animated = true;
            this.txtExpenseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExpenseName.DefaultText = "......";
            this.txtExpenseName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtExpenseName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtExpenseName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpenseName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpenseName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpenseName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtExpenseName.ForeColor = System.Drawing.Color.Black;
            this.txtExpenseName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.errorProvider1.SetIconAlignment(this.txtExpenseName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtExpenseName.Location = new System.Drawing.Point(280, 191);
            this.txtExpenseName.Margin = new System.Windows.Forms.Padding(5);
            this.txtExpenseName.Name = "txtExpenseName";
            this.txtExpenseName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtExpenseName.PlaceholderText = "";
            this.txtExpenseName.SelectedText = "";
            this.txtExpenseName.Size = new System.Drawing.Size(239, 37);
            this.txtExpenseName.TabIndex = 0;
            this.txtExpenseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpenseName_KeyDown);
            // 
            // txtExpensesAmount
            // 
            this.txtExpensesAmount.Animated = true;
            this.txtExpensesAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExpensesAmount.DefaultText = "120";
            this.txtExpensesAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtExpensesAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtExpensesAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpensesAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpensesAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpensesAmount.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtExpensesAmount.ForeColor = System.Drawing.Color.Black;
            this.txtExpensesAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpensesAmount.Location = new System.Drawing.Point(280, 265);
            this.txtExpensesAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtExpensesAmount.Name = "txtExpensesAmount";
            this.txtExpensesAmount.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtExpensesAmount.PlaceholderText = "";
            this.txtExpensesAmount.SelectedText = "";
            this.txtExpensesAmount.Size = new System.Drawing.Size(239, 37);
            this.txtExpensesAmount.TabIndex = 1;
            this.txtExpensesAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtExpensesAmount_Validating);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(70, 269);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(173, 28);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "Expenses Amount";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(70, 346);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(141, 28);
            this.guna2HtmlLabel4.TabIndex = 8;
            this.guna2HtmlLabel4.Text = "Expenses Date";
            // 
            // dtpExpenses
            // 
            this.dtpExpenses.Animated = true;
            this.dtpExpenses.AutoRoundedCorners = true;
            this.dtpExpenses.BackColor = System.Drawing.Color.Transparent;
            this.dtpExpenses.Checked = true;
            this.dtpExpenses.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dtpExpenses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenses.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpExpenses.Location = new System.Drawing.Point(280, 346);
            this.dtpExpenses.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpExpenses.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpExpenses.Name = "dtpExpenses";
            this.dtpExpenses.ShowUpDown = true;
            this.dtpExpenses.Size = new System.Drawing.Size(239, 34);
            this.dtpExpenses.TabIndex = 2;
            this.dtpExpenses.Value = new System.DateTime(2025, 12, 17, 14, 42, 37, 378);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(70, 422);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(143, 28);
            this.guna2HtmlLabel5.TabIndex = 10;
            this.guna2HtmlLabel5.Text = "Expenses Type";
            // 
            // cbExpenseType
            // 
            this.cbExpenseType.AutoCompleteCustomSource.AddRange(new string[] {
            "Others..."});
            this.cbExpenseType.AutoRoundedCorners = true;
            this.cbExpenseType.BackColor = System.Drawing.Color.Transparent;
            this.cbExpenseType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExpenseType.FillColor = System.Drawing.Color.FloralWhite;
            this.cbExpenseType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbExpenseType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbExpenseType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExpenseType.ForeColor = System.Drawing.Color.Black;
            this.cbExpenseType.ItemHeight = 30;
            this.cbExpenseType.Location = new System.Drawing.Point(280, 420);
            this.cbExpenseType.Name = "cbExpenseType";
            this.cbExpenseType.Size = new System.Drawing.Size(234, 36);
            this.cbExpenseType.TabIndex = 3;
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.AutoCompleteCustomSource.AddRange(new string[] {
            "Others..."});
            this.cbPaymentMethod.AutoRoundedCorners = true;
            this.cbPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FillColor = System.Drawing.Color.FloralWhite;
            this.cbPaymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPaymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cbPaymentMethod.ItemHeight = 30;
            this.cbPaymentMethod.Location = new System.Drawing.Point(280, 498);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(234, 36);
            this.cbPaymentMethod.TabIndex = 4;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(70, 501);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(169, 28);
            this.guna2HtmlLabel6.TabIndex = 12;
            this.guna2HtmlLabel6.Text = "Payment Method";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(70, 571);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(151, 28);
            this.guna2HtmlLabel7.TabIndex = 14;
            this.guna2HtmlLabel7.Text = "Currency Name";
            // 
            // cbCurrencyTypes
            // 
            this.cbCurrencyTypes.AutoCompleteCustomSource.AddRange(new string[] {
            "Others..."});
            this.cbCurrencyTypes.AutoRoundedCorners = true;
            this.cbCurrencyTypes.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrencyTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCurrencyTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrencyTypes.FillColor = System.Drawing.Color.FloralWhite;
            this.cbCurrencyTypes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCurrencyTypes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCurrencyTypes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrencyTypes.ForeColor = System.Drawing.Color.Black;
            this.cbCurrencyTypes.ItemHeight = 30;
            this.cbCurrencyTypes.Location = new System.Drawing.Point(280, 568);
            this.cbCurrencyTypes.Name = "cbCurrencyTypes";
            this.cbCurrencyTypes.Size = new System.Drawing.Size(234, 36);
            this.cbCurrencyTypes.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Animated = true;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "Description";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(280, 636);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(414, 91);
            this.txtDescription.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtDescription.TabIndex = 6;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(70, 640);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(197, 28);
            this.guna2HtmlLabel8.TabIndex = 16;
            this.guna2HtmlLabel8.Text = "Expense Description";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe Script", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(12, 30);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(49, 33);
            this.lblDateTime.TabIndex = 17;
            this.lblDateTime.Text = "Date";
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.AutoRoundedCorners = true;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnCancel.Location = new System.Drawing.Point(564, 562);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 37);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderThickness = 2;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnSave.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnSave.Location = new System.Drawing.Point(723, 562);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 37);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.RosyBrown;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(752, 30);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(80, 69);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 18;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // frmAddEdit_Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(869, 731);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.cbCurrencyTypes);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.cbPaymentMethod);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.cbExpenseType);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.dtpExpenses);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.txtExpensesAmount);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.txtExpenseName);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.lblExpensID);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblAddEditExpenses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddEdit_Expenses";
            this.Text = "frmAdd/Edit_Expenses";
            this.Load += new System.EventHandler(this.frmAddEdit_Expenses_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblAddEditExpenses;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblExpensID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtExpenseName;
        private Guna.UI2.WinForms.Guna2TextBox txtExpensesAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpExpenses;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ComboBox cbExpenseType;
        private Guna.UI2.WinForms.Guna2ComboBox cbPaymentMethod;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2ComboBox cbCurrencyTypes;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDateTime;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}