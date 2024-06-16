namespace HMS.Forms
{
    partial class AddAppointment
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
            DTP = new DateTimePicker();
            label2 = new Label();
            DoctorCB = new ComboBox();
            label3 = new Label();
            PatientsCB = new ComboBox();
            AddBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 22);
            label1.TabIndex = 0;
            label1.Text = "Date:";
            // 
            // DTP
            // 
            DTP.Location = new Point(12, 34);
            DTP.Name = "DTP";
            DTP.Size = new Size(253, 30);
            DTP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(80, 22);
            label2.TabIndex = 2;
            label2.Text = "Doctor:";
            // 
            // DoctorCB
            // 
            DoctorCB.FormattingEnabled = true;
            DoctorCB.Location = new Point(12, 92);
            DoctorCB.Name = "DoctorCB";
            DoctorCB.Size = new Size(253, 30);
            DoctorCB.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 125);
            label3.Name = "label3";
            label3.Size = new Size(90, 22);
            label3.TabIndex = 4;
            label3.Text = "Patient:";
            // 
            // PatientsCB
            // 
            PatientsCB.FormattingEnabled = true;
            PatientsCB.Location = new Point(12, 150);
            PatientsCB.Name = "PatientsCB";
            PatientsCB.Size = new Size(253, 30);
            PatientsCB.TabIndex = 5;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(190, 186);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(75, 27);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 220);
            Controls.Add(AddBtn);
            Controls.Add(PatientsCB);
            Controls.Add(label3);
            Controls.Add(DoctorCB);
            Controls.Add(label2);
            Controls.Add(DTP);
            Controls.Add(label1);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "AddAppointment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker DTP;
        private Label label2;
        private ComboBox DoctorCB;
        private Label label3;
        private ComboBox PatientsCB;
        private Button AddBtn;
    }
}