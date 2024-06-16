namespace HMS.Forms
{
    partial class MedicalInventoryManagementForm
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
            DeleteBtn = new Button();
            AddBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // DGV
            // 
            DGV.BackgroundColor = Color.Gainsboro;
            DGV.BorderStyle = BorderStyle.None;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(15, 15);
            DGV.Name = "DGV";
            DGV.RowHeadersVisible = false;
            DGV.Size = new Size(658, 428);
            DGV.TabIndex = 4;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(481, 449);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(93, 28);
            DeleteBtn.TabIndex = 7;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(580, 449);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(93, 28);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // MedicalInventoryManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 484);
            Controls.Add(DeleteBtn);
            Controls.Add(AddBtn);
            Controls.Add(DGV);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "MedicalInventoryManagementForm";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medical Inventory Management";
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV;
        private Button DeleteBtn;
        private Button AddBtn;
    }
}