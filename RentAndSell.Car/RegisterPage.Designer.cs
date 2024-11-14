namespace RentAndSell.Car
{
    partial class RegisterPage
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
            txtFirstName = new TextBox();
            groupBox1 = new GroupBox();
            lblMessage = new Label();
            btnLogin = new Button();
            btnSave = new Button();
            txtPasswordAgain = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(19, 22);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Adınız";
            txtFirstName.Size = new Size(155, 23);
            txtFirstName.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMessage);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtPasswordAgain);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 237);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "YeniKayıt";
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(200, 25);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(145, 184);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Message";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(99, 196);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Giriş sayfası";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(19, 196);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPasswordAgain
            // 
            txtPasswordAgain.Location = new Point(19, 167);
            txtPasswordAgain.Name = "txtPasswordAgain";
            txtPasswordAgain.PasswordChar = '*';
            txtPasswordAgain.PlaceholderText = "Şifre tekrarınız";
            txtPasswordAgain.Size = new Size(155, 23);
            txtPasswordAgain.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(19, 138);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Şifreniz";
            txtPassword.Size = new Size(155, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(19, 109);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Kullanıcı adınız";
            txtUserName.Size = new Size(155, 23);
            txtUserName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(19, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Mailiniz";
            txtEmail.Size = new Size(155, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(19, 51);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Soyadınız";
            txtLastName.Size = new Size(155, 23);
            txtLastName.TabIndex = 1;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(groupBox1);
            Name = "RegisterPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterPage";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtFirstName;
        private GroupBox groupBox1;
        private TextBox txtUserName;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtPasswordAgain;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnSave;
        private Label lblMessage;
    }
}