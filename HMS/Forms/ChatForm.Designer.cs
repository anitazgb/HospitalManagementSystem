namespace HMS.Forms
{
    partial class ChatForm
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
            ChatTB = new TextBox();
            MessageTB = new TextBox();
            SendBtn = new Button();
            SuspendLayout();
            // 
            // ChatTB
            // 
            ChatTB.Dock = DockStyle.Top;
            ChatTB.Location = new Point(5, 5);
            ChatTB.Multiline = true;
            ChatTB.Name = "ChatTB";
            ChatTB.Size = new Size(618, 648);
            ChatTB.TabIndex = 0;
            // 
            // MessageTB
            // 
            MessageTB.Location = new Point(8, 659);
            MessageTB.Multiline = true;
            MessageTB.Name = "MessageTB";
            MessageTB.Size = new Size(495, 75);
            MessageTB.TabIndex = 1;
            // 
            // SendBtn
            // 
            SendBtn.Location = new Point(509, 662);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(111, 72);
            SendBtn.TabIndex = 2;
            SendBtn.Text = "Send";
            SendBtn.UseVisualStyleBackColor = true;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 741);
            Controls.Add(SendBtn);
            Controls.Add(MessageTB);
            Controls.Add(ChatTB);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "ChatForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChatForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ChatTB;
        private TextBox MessageTB;
        private Button SendBtn;
    }
}