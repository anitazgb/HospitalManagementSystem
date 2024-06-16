namespace HMS.Forms
{
    partial class ReportForm
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
            label1 = new Label();
            StartDTP = new DateTimePicker();
            EndDTP = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            TypeCB = new ComboBox();
            CreateBtn = new Button();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(120, 22);
            label1.TabIndex = 2;
            label1.Text = "Start Date:";
            // 
            // StartDTP
            // 
            StartDTP.Location = new Point(12, 34);
            StartDTP.Name = "StartDTP";
            StartDTP.Size = new Size(253, 30);
            StartDTP.TabIndex = 3;
            // 
            // EndDTP
            // 
            EndDTP.Location = new Point(275, 34);
            EndDTP.Name = "EndDTP";
            EndDTP.Size = new Size(253, 30);
            EndDTP.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 9);
            label2.Name = "label2";
            label2.Size = new Size(100, 22);
            label2.TabIndex = 4;
            label2.Text = "End Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 77);
            label3.Name = "label3";
            label3.Size = new Size(130, 22);
            label3.TabIndex = 6;
            label3.Text = "Report Type:";
            // 
            // TypeCB
            // 
            TypeCB.FormattingEnabled = true;
            TypeCB.Items.AddRange(new object[] { "Patients visits", "Common sickness", "Medication utilization" });
            TypeCB.Location = new Point(12, 102);
            TypeCB.Name = "TypeCB";
            TypeCB.Size = new Size(514, 30);
            TypeCB.TabIndex = 7;
            // 
            // CreateBtn
            // 
            CreateBtn.Location = new Point(438, 138);
            CreateBtn.Name = "CreateBtn";
            CreateBtn.Size = new Size(88, 27);
            CreateBtn.TabIndex = 8;
            CreateBtn.Text = "Create";
            CreateBtn.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 171);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(516, 359);
            textBox2.TabIndex = 9;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 542);
            Controls.Add(textBox2);
            Controls.Add(CreateBtn);
            Controls.Add(TypeCB);
            Controls.Add(label3);
            Controls.Add(EndDTP);
            Controls.Add(label2);
            Controls.Add(StartDTP);
            Controls.Add(label1);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ReceptionReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker StartDTP;
        private DateTimePicker EndDTP;
        private Label label2;
        private Label label3;
        private ComboBox TypeCB;
        private Button CreateBtn;
        private TextBox textBox2;
    }
}