namespace HMS.Forms
{
    partial class IssueForm
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
            ItemCB = new ComboBox();
            PatientCB = new ComboBox();
            label2 = new Label();
            IssueBtn = new Button();
            QuantityTB = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 22);
            label1.TabIndex = 0;
            label1.Text = "Item:";
            // 
            // ItemCB
            // 
            ItemCB.FormattingEnabled = true;
            ItemCB.Location = new Point(14, 34);
            ItemCB.Name = "ItemCB";
            ItemCB.Size = new Size(290, 30);
            ItemCB.TabIndex = 1;
            // 
            // PatientCB
            // 
            PatientCB.FormattingEnabled = true;
            PatientCB.Location = new Point(14, 99);
            PatientCB.Name = "PatientCB";
            PatientCB.Size = new Size(290, 30);
            PatientCB.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 74);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 22);
            label2.TabIndex = 2;
            label2.Text = "Patient:";
            // 
            // IssueBtn
            // 
            IssueBtn.Location = new Point(220, 193);
            IssueBtn.Name = "IssueBtn";
            IssueBtn.Size = new Size(84, 28);
            IssueBtn.TabIndex = 4;
            IssueBtn.Text = "Issue";
            IssueBtn.UseVisualStyleBackColor = true;
            // 
            // QuantityTB
            // 
            QuantityTB.Location = new Point(14, 147);
            QuantityTB.Name = "QuantityTB";
            QuantityTB.PlaceholderText = "Quantity";
            QuantityTB.Size = new Size(290, 30);
            QuantityTB.TabIndex = 5;
            // 
            // IssueForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 233);
            Controls.Add(QuantityTB);
            Controls.Add(IssueBtn);
            Controls.Add(PatientCB);
            Controls.Add(label2);
            Controls.Add(ItemCB);
            Controls.Add(label1);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "IssueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Issue Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox ItemCB;
        private ComboBox PatientCB;
        private Label label2;
        private Button IssueBtn;
        private TextBox QuantityTB;
    }
}