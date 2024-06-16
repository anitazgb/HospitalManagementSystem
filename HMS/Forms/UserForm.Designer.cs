namespace HMS.Forms
{
    partial class UserForm
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
            DGV = new DataGridView();
            UsernameTB = new TextBox();
            RoleCB = new ComboBox();
            AddBtn = new Button();
            DeleteBtn = new Button();
            PasswordTB = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // DGV
            // 
            DGV.BackgroundColor = Color.Gainsboro;
            DGV.BorderStyle = BorderStyle.None;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(12, 12);
            DGV.Name = "DGV";
            DGV.RowHeadersVisible = false;
            DGV.Size = new Size(405, 482);
            DGV.TabIndex = 4;
            // 
            // UsernameTB
            // 
            UsernameTB.Location = new Point(423, 16);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.PlaceholderText = "Username";
            UsernameTB.Size = new Size(214, 30);
            UsernameTB.TabIndex = 5;
            // 
            // RoleCB
            // 
            RoleCB.FormattingEnabled = true;
            RoleCB.Items.AddRange(new object[] { "doctor", "nurse", "admin", "patient" });
            RoleCB.Location = new Point(423, 88);
            RoleCB.Name = "RoleCB";
            RoleCB.Size = new Size(214, 30);
            RoleCB.TabIndex = 6;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(562, 124);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(75, 31);
            AddBtn.TabIndex = 7;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(473, 124);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(83, 31);
            DeleteBtn.TabIndex = 8;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new Point(423, 52);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PlaceholderText = "Password";
            PasswordTB.Size = new Size(214, 30);
            PasswordTB.TabIndex = 9;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 506);
            Controls.Add(PasswordTB);
            Controls.Add(DeleteBtn);
            Controls.Add(AddBtn);
            Controls.Add(RoleCB);
            Controls.Add(UsernameTB);
            Controls.Add(DGV);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Form";
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV;
        private TextBox UsernameTB;
        private ComboBox RoleCB;
        private Button AddBtn;
        private Button DeleteBtn;
        private TextBox PasswordTB;
    }
}