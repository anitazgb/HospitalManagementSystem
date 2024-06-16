namespace HMS.Forms
{
    partial class AdminForm
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
            ReportBtn = new Button();
            SchedulingBtn = new Button();
            ChatBtn = new Button();
            UserBtn = new Button();
            SuspendLayout();
            // 
            // ReportBtn
            // 
            ReportBtn.Location = new Point(12, 47);
            ReportBtn.Name = "ReportBtn";
            ReportBtn.Size = new Size(245, 29);
            ReportBtn.TabIndex = 3;
            ReportBtn.Text = "Reports";
            ReportBtn.UseVisualStyleBackColor = true;
            // 
            // SchedulingBtn
            // 
            SchedulingBtn.Location = new Point(12, 12);
            SchedulingBtn.Name = "SchedulingBtn";
            SchedulingBtn.Size = new Size(245, 29);
            SchedulingBtn.TabIndex = 2;
            SchedulingBtn.Text = "Appointment Scheduling";
            SchedulingBtn.UseVisualStyleBackColor = true;
            // 
            // ChatBtn
            // 
            ChatBtn.Location = new Point(12, 119);
            ChatBtn.Name = "ChatBtn";
            ChatBtn.Size = new Size(245, 29);
            ChatBtn.TabIndex = 6;
            ChatBtn.Text = "Chat";
            ChatBtn.UseVisualStyleBackColor = true;
            // 
            // UserBtn
            // 
            UserBtn.Location = new Point(12, 82);
            UserBtn.Name = "UserBtn";
            UserBtn.Size = new Size(245, 29);
            UserBtn.TabIndex = 7;
            UserBtn.Text = "Users";
            UserBtn.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 159);
            Controls.Add(UserBtn);
            Controls.Add(ChatBtn);
            Controls.Add(ReportBtn);
            Controls.Add(SchedulingBtn);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            ResumeLayout(false);
        }

        #endregion

        private Button ReportBtn;
        private Button SchedulingBtn;
        private Button ChatBtn;
        private Button UserBtn;
    }
}