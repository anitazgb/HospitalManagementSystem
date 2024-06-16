namespace HMS.Forms
{
    partial class DoctorForm
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
            PatientBtn = new Button();
            MedicalBtn = new Button();
            SuspendLayout();
            // 
            // PatientBtn
            // 
            PatientBtn.Location = new Point(12, 12);
            PatientBtn.Name = "PatientBtn";
            PatientBtn.Size = new Size(209, 29);
            PatientBtn.TabIndex = 0;
            PatientBtn.Text = "Patient Management";
            PatientBtn.UseVisualStyleBackColor = true;
            // 
            // MedicalBtn
            // 
            MedicalBtn.Location = new Point(12, 47);
            MedicalBtn.Name = "MedicalBtn";
            MedicalBtn.Size = new Size(209, 29);
            MedicalBtn.TabIndex = 1;
            MedicalBtn.Text = "Medical Management";
            MedicalBtn.UseVisualStyleBackColor = true;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 87);
            Controls.Add(MedicalBtn);
            Controls.Add(PatientBtn);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "DoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doctor Form";
            ResumeLayout(false);
        }

        #endregion

        private Button PatientBtn;
        private Button MedicalBtn;
    }
}