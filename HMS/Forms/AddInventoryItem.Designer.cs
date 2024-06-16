namespace HMS.Forms
{
    partial class AddInventoryItem
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            AddBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 10);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Title";
            textBox1.Size = new Size(255, 30);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 46);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Start quantity";
            textBox2.Size = new Size(255, 30);
            textBox2.TabIndex = 1;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(212, 82);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(55, 29);
            AddBtn.TabIndex = 2;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // AddInventoryItem
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 118);
            Controls.Add(AddBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 5, 5, 5);
            Name = "AddInventoryItem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Inventory Item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button AddBtn;
    }
}