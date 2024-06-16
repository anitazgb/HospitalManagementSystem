namespace HMS.Forms
{
    partial class RegistrationForm
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
            UsernameTB = new TextBox();
            PasswordTB = new TextBox();
            RegisterBtn = new Button();
            SuspendLayout();
            // 
            // UsernameTB
            // 
            UsernameTB.Location = new Point(14, 14);
            UsernameTB.Margin = new Padding(5);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.PlaceholderText = "Username";
            UsernameTB.Size = new Size(356, 30);
            UsernameTB.TabIndex = 0;
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new Point(14, 54);
            PasswordTB.Margin = new Padding(5);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PlaceholderText = "Password";
            PasswordTB.Size = new Size(356, 30);
            PasswordTB.TabIndex = 1;
            // 
            // RegisterBtn
            // 
            RegisterBtn.BackColor = Color.Gainsboro;
            RegisterBtn.FlatAppearance.BorderSize = 0;
            RegisterBtn.FlatStyle = FlatStyle.System;
            RegisterBtn.Location = new Point(269, 100);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(101, 33);
            RegisterBtn.TabIndex = 4;
            RegisterBtn.Text = "Register";
            RegisterBtn.UseVisualStyleBackColor = false;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(378, 144);
            Controls.Add(RegisterBtn);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTB;
        private TextBox PasswordTB;
        private Button RegisterBtn;
    }
}