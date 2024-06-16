namespace HMS
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameTB = new TextBox();
            PasswordTB = new TextBox();
            EnterBtn = new Button();
            RegisterBtn = new Button();
            SuspendLayout();
            // 
            // UsernameTB
            // 
            UsernameTB.Location = new Point(14, 22);
            UsernameTB.Margin = new Padding(5);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.PlaceholderText = "Username";
            UsernameTB.Size = new Size(259, 30);
            UsernameTB.TabIndex = 2;
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new Point(14, 60);
            PasswordTB.Margin = new Padding(5);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PlaceholderText = "Password";
            PasswordTB.Size = new Size(259, 30);
            PasswordTB.TabIndex = 3;
            PasswordTB.UseSystemPasswordChar = true;
            // 
            // EnterBtn
            // 
            EnterBtn.Location = new Point(178, 97);
            EnterBtn.Name = "EnterBtn";
            EnterBtn.Size = new Size(95, 33);
            EnterBtn.TabIndex = 1;
            EnterBtn.Text = "Log in";
            EnterBtn.UseVisualStyleBackColor = true;
            // 
            // RegisterBtn
            // 
            RegisterBtn.Location = new Point(77, 97);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(95, 33);
            RegisterBtn.TabIndex = 4;
            RegisterBtn.Text = "Sign up";
            RegisterBtn.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 136);
            Controls.Add(RegisterBtn);
            Controls.Add(EnterBtn);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            Font = new Font("Consolas", 14.25F);
            Margin = new Padding(5);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authorization";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTB;
        private TextBox PasswordTB;
        private Button EnterBtn;
        private Button RegisterBtn;
    }
}
