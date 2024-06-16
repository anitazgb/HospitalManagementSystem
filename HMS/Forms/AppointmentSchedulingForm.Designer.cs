namespace HMS.Forms
{
    partial class AppointmentSchedulingForm
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
            label2 = new Label();
            DGV = new DataGridView();
            AddBtn = new Button();
            DeleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 7);
            label2.Name = "label2";
            label2.Size = new Size(140, 22);
            label2.TabIndex = 2;
            label2.Text = "Appointments:";
            // 
            // DGV
            // 
            DGV.BackgroundColor = Color.Gainsboro;
            DGV.BorderStyle = BorderStyle.None;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(20, 32);
            DGV.Name = "DGV";
            DGV.RowHeadersVisible = false;
            DGV.Size = new Size(636, 394);
            DGV.TabIndex = 3;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(560, 432);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(93, 28);
            AddBtn.TabIndex = 4;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(461, 432);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(93, 28);
            DeleteBtn.TabIndex = 5;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // AppointmentSchedulingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 473);
            Controls.Add(DeleteBtn);
            Controls.Add(AddBtn);
            Controls.Add(DGV);
            Controls.Add(label2);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "AppointmentSchedulingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Appointment Scheduling";
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private DataGridView DGV;
        private Button AddBtn;
        private Button DeleteBtn;
    }
}