namespace HMS.Forms
{
    partial class PatientForm
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
            SchedulingBtn = new Button();
            ChatBtn = new Button();
            HistoryBtn = new Button();
            ChatHistory = new Button();
            SuspendLayout();
            // 
            // SchedulingBtn
            // 
            SchedulingBtn.Location = new Point(12, 12);
            SchedulingBtn.Name = "SchedulingBtn";
            SchedulingBtn.Size = new Size(245, 29);
            SchedulingBtn.TabIndex = 3;
            SchedulingBtn.Text = "Make an appointment";
            SchedulingBtn.UseVisualStyleBackColor = true;
            // 
            // ChatBtn
            // 
            ChatBtn.Location = new Point(13, 82);
            ChatBtn.Name = "ChatBtn";
            ChatBtn.Size = new Size(245, 29);
            ChatBtn.TabIndex = 7;
            ChatBtn.Text = "New Chat";
            ChatBtn.UseVisualStyleBackColor = true;
            // 
            // HistoryBtn
            // 
            HistoryBtn.Location = new Point(13, 47);
            HistoryBtn.Name = "HistoryBtn";
            HistoryBtn.Size = new Size(245, 29);
            HistoryBtn.TabIndex = 8;
            HistoryBtn.Text = "Appointment history";
            HistoryBtn.UseVisualStyleBackColor = true;
            // 
            // ChatHistory
            // 
            ChatHistory.Location = new Point(12, 117);
            ChatHistory.Name = "ChatHistory";
            ChatHistory.Size = new Size(245, 29);
            ChatHistory.TabIndex = 9;
            ChatHistory.Text = "Chat History";
            ChatHistory.UseVisualStyleBackColor = true;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 155);
            Controls.Add(ChatHistory);
            Controls.Add(HistoryBtn);
            Controls.Add(ChatBtn);
            Controls.Add(SchedulingBtn);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "PatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientForm";
            ResumeLayout(false);
        }

        #endregion

        private Button SchedulingBtn;
        private Button ChatBtn;
        private Button HistoryBtn;
        private Button ChatHistory;
    }
}