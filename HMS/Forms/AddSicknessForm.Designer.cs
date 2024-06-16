namespace HMS.Forms
{
    partial class AddSicknessForm
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
            TittleTB = new TextBox();
            AddBtn = new Button();
            SuspendLayout();
            // 
            // TittleTB
            // 
            TittleTB.Location = new Point(22, 22);
            TittleTB.Name = "TittleTB";
            TittleTB.PlaceholderText = "Title";
            TittleTB.Size = new Size(315, 30);
            TittleTB.TabIndex = 0;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(262, 58);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(75, 27);
            AddBtn.TabIndex = 1;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            // 
            // AddSicknessForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 96);
            Controls.Add(AddBtn);
            Controls.Add(TittleTB);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "AddSicknessForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Sickness";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TittleTB;
        private Button AddBtn;
    }
}