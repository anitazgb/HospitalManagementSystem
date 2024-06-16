namespace HMS.Forms
{
    partial class PatientManagmentForm
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
            PatientsCB = new ComboBox();
            label1 = new Label();
            ReportTB = new TextBox();
            SaveReception = new Button();
            label2 = new Label();
            SicknessCB = new ComboBox();
            AddSicknessBtn = new Button();
            SuspendLayout();
            // 
            // PatientsCB
            // 
            PatientsCB.FormattingEnabled = true;
            PatientsCB.Location = new Point(12, 34);
            PatientsCB.Name = "PatientsCB";
            PatientsCB.Size = new Size(370, 30);
            PatientsCB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 22);
            label1.TabIndex = 1;
            label1.Text = "Patient:";
            // 
            // ReportTB
            // 
            ReportTB.Location = new Point(11, 139);
            ReportTB.Multiline = true;
            ReportTB.Name = "ReportTB";
            ReportTB.PlaceholderText = "Doctors`s report";
            ReportTB.Size = new Size(370, 354);
            ReportTB.TabIndex = 2;
            // 
            // SaveReception
            // 
            SaveReception.Location = new Point(291, 499);
            SaveReception.Name = "SaveReception";
            SaveReception.Size = new Size(90, 30);
            SaveReception.TabIndex = 3;
            SaveReception.Text = "Save";
            SaveReception.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(100, 22);
            label2.TabIndex = 4;
            label2.Text = "Sickness:";
            // 
            // SicknessCB
            // 
            SicknessCB.FormattingEnabled = true;
            SicknessCB.Location = new Point(12, 92);
            SicknessCB.Name = "SicknessCB";
            SicknessCB.Size = new Size(336, 30);
            SicknessCB.TabIndex = 5;
            // 
            // AddSicknessBtn
            // 
            AddSicknessBtn.Location = new Point(354, 92);
            AddSicknessBtn.Name = "AddSicknessBtn";
            AddSicknessBtn.Size = new Size(28, 30);
            AddSicknessBtn.TabIndex = 6;
            AddSicknessBtn.Text = "+";
            AddSicknessBtn.UseVisualStyleBackColor = true;
            // 
            // PatientManagmentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 536);
            Controls.Add(AddSicknessBtn);
            Controls.Add(SicknessCB);
            Controls.Add(label2);
            Controls.Add(SaveReception);
            Controls.Add(ReportTB);
            Controls.Add(label1);
            Controls.Add(PatientsCB);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "PatientManagmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient Managment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox PatientsCB;
        private Label label1;
        private TextBox ReportTB;
        private Button SaveReception;
        private Label label2;
        private ComboBox SicknessCB;
        private Button AddSicknessBtn;
    }
}