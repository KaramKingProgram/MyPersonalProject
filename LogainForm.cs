using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MyBuisnessLayer;
using MyPersonalApp;

namespace ExpenseManager
{
    public class LoginForm : Form
    {
        // لعمل زوايا دائرية للنافذة
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        // عناصر التحكم
        private Guna2TextBox txtUsername;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private Guna2CheckBox chkRemember;
        private System.ComponentModel.IContainer components = null;

        public LoginForm()
        {
            // 1. إعدادات النافذة الأساسية
            this.ClientSize = new Size(850, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Text = "تسجيل الدخول";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            // تطبيق الزوايا الدائرية
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // إضافة ظل للنافذة
            Guna2ShadowForm shadow = new Guna2ShadowForm(this);

            // 2. بناء الواجهة
            InitializeComponents();

            // 3. تفعيل السحب
            Guna2DragControl dragControl = new Guna2DragControl(this.components);
            dragControl.TargetControl = this;
        }

        private void InitializeComponents()
        {
            this.components = new System.ComponentModel.Container();

            // --- القسم الأيمن (الشعار والترحيب) ---
            Guna2Panel sidePanel = new Guna2Panel
            {
                Dock = DockStyle.Left,
                Width = 350,
                FillColor = Color.FromArgb(94, 114, 228)
            };

            // إضافة محتوى الـ SidePanel
            Label lblIcon = new Label
            {
                Text = "💰",
                Font = new Font("Segoe UI Emoji", 50, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblIcon.Location = new Point((sidePanel.Width - lblIcon.PreferredWidth) / 2, 120);

            Label lblTitle = new Label
            {
                Text = "إدارة مصاريفك",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblTitle.Location = new Point((sidePanel.Width - lblTitle.PreferredWidth) / 2, 210);

            Label lblDesc = new Label
            {
                Text = "تتبع نفقاتك اليومية وراقب\nميزانيتك بسهولة وأمان",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(240, 240, 255),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblDesc.Location = new Point((sidePanel.Width - lblDesc.PreferredWidth) / 2, 260);

            sidePanel.Controls.Add(lblIcon);
            sidePanel.Controls.Add(lblTitle);
            sidePanel.Controls.Add(lblDesc);

            // --- زر الإغلاق ---
            Guna2ControlBox btnClose = new Guna2ControlBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                FillColor = Color.Transparent,
                IconColor = Color.Gray,
                Location = new Point(Width - 50, 10),
                Size = new Size(45, 29)
            };
            btnClose.HoverState.FillColor = Color.Red;
            btnClose.HoverState.IconColor = Color.White;

            // --- قسم تسجيل الدخول ---
            Panel loginContainer = new Panel
            {
                Size = new Size(400, 430),
                Location = new Point(380, 35),
                BackColor = Color.Transparent
            };

            // عنوان الترحيب
            Label lblWelcome = new Label
            {
                Text = "مرحباً بعودتك!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(0, 20)
            };

            Label lblSubWelcome = new Label
            {
                Text = "سجل دخولك للمتابعة",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(0, 65)
            };

            // حقل اسم المستخدم
            txtUsername = new Guna2TextBox
            {
                PlaceholderText = "البريد الإلكتروني أو اسم المستخدم",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Black,
                Size = new Size(380, 45),
                Location = new Point(0, 130),
                BorderRadius = 8,
                BorderColor = Color.FromArgb(217, 221, 226),
                TextOffset = new Point(5, 0)
            };
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 114, 228);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 114, 228);

            // حقل كلمة المرور
            txtPassword = new Guna2TextBox
            {
                PlaceholderText = "كلمة المرور",
                UseSystemPasswordChar = true,
                Font = new Font("Segoe UI", 11),
                Size = new Size(380, 45),
                Location = new Point(0, 190),
                BorderRadius = 8,
                BorderColor = Color.FromArgb(217, 221, 226),
                TextOffset = new Point(5, 0)
                
                
            };
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 114, 228);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 114, 228);

            // تذكرني
            chkRemember = new Guna2CheckBox
            {
                Text = "تذكرني",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(0, 250),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            chkRemember.CheckedState.BorderColor = Color.FromArgb(94, 114, 228);
            chkRemember.CheckedState.FillColor = Color.FromArgb(94, 114, 228);

            // نسيت كلمة المرور
            Label lblForgot = new Label
            {
                Text = "نسيت كلمة المرور؟",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(94, 114, 228),
                Cursor = Cursors.Hand,
                AutoSize = true
            };
            lblForgot.Location = new Point(380 - lblForgot.PreferredWidth, 252);
            lblForgot.Click += (s, e) => MessageBox.Show("صفحة استعادة كلمة المرور...", "استعادة كلمة المرور");

            // Hover effect لنسيت كلمة المرور
            lblForgot.MouseEnter += (s, e) => lblForgot.ForeColor = Color.FromArgb(60, 80, 180);
            lblForgot.MouseLeave += (s, e) => lblForgot.ForeColor = Color.FromArgb(94, 114, 228);

            // زر الدخول
            btnLogin = new Guna2Button
            {
                Text = "تسجيل الدخول",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FillColor = Color.FromArgb(94, 114, 228),
                ForeColor = Color.White,
                Size = new Size(380, 50),
                Location = new Point(0, 300),
                BorderRadius = 8,
                Cursor = Cursors.Hand
            };
            btnLogin.ShadowDecoration.Enabled = true;
            btnLogin.ShadowDecoration.Depth = 10;
            btnLogin.ShadowDecoration.Color = Color.FromArgb(94, 114, 228);
            btnLogin.Click += BtnLogin_Click;

            // مستخدم جديد
            Label lblNewUserText = new Label
            {
                Text = "ليس لديك حساب؟",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblSignupLink = new Label
            {
                Text = "سجل الآن",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(94, 114, 228),
                Cursor = Cursors.Hand,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // حساب المواقع للتوسيط
            int totalWidth = lblNewUserText.PreferredWidth + lblSignupLink.PreferredWidth + 5;
            int startX = (380 - totalWidth) / 2;

            lblNewUserText.Location = new Point(startX, 370);
            lblSignupLink.Location = new Point(startX + lblNewUserText.PreferredWidth + 5, 370);

            // Hover effect للرابط
            lblSignupLink.MouseEnter += (s, e) => lblSignupLink.ForeColor = Color.FromArgb(60, 80, 180);
            lblSignupLink.MouseLeave += (s, e) => lblSignupLink.ForeColor = Color.FromArgb(94, 114, 228);

            lblSignupLink.Click += (s, e) =>
            {
                MessageBox.Show("سيتم فتح صفحة التسجيل...", "تسجيل حساب جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // هنا تفتح Form التسجيل
                  RegisterForm registerForm = new RegisterForm();
                  registerForm.Show();
                  this.Hide();
            };

            // إضافة العناصر للحاوية
            loginContainer.Controls.Add(lblWelcome);
            loginContainer.Controls.Add(lblSubWelcome);
            loginContainer.Controls.Add(txtUsername);
            loginContainer.Controls.Add(txtPassword);
            loginContainer.Controls.Add(chkRemember);
            loginContainer.Controls.Add(lblForgot);
            loginContainer.Controls.Add(btnLogin);
            loginContainer.Controls.Add(lblNewUserText);
            loginContainer.Controls.Add(lblSignupLink);

            // إضافة كل شيء للنافذة الرئيسية
            this.Controls.Add(loginContainer);
            this.Controls.Add(sidePanel);
            this.Controls.Add(btnClose);
        }
     private   string UserName;
     private   string Password;
      
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (chkRemember.Checked) {
                txtUsername.Text = "Karam";
                txtPassword.Text = "Karam123";
            }
            // تحقق من الحقول الفارغة
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم المستخدم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("الرجاء إدخال كلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
        bool IsUserExsit()
        {
            if (clsUsers.IsUserExsit(txtUsername.Text, txtPassword.Text))
                {
                    this.UserName = txtUsername.Text;
                    this.Password = txtPassword.Text;
                    return true;
                }
            return false;

        }
        
            int GetPerson()
            {
                return clsPerson.GetPersonID(txtUsername.Text, txtPassword.Text);
            }
            // التحقق من بيانات الدخول
            if (IsUserExsit())
            {
                MessageBox.Show("تم تسجيل الدخول بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int PersonID = GetPerson(); 
                // هنا تفتح النافذة الرئيسية
                MainForm form = new MainForm(PersonID);
               form.ShowDialog();
               this.Hide();
               this.Close();
               
            }
            else
            {
                MessageBox.Show("بيانات الدخول غير صحيحة\nالرجاء المحاولة مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}