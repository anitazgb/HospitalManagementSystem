namespace HMS.Forms
{
    partial class AdminChatForm
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
            button1 = new Button();
            UserCB = new ComboBox();
            SuspendLayout();
            // 
            // ChatTB
            // 
            ChatTB.Dock = DockStyle.Top;
            ChatTB.Location = new Point(5, 5);
            ChatTB.Multiline = true;
            ChatTB.Name = "ChatTB";
            ChatTB.PlaceholderText = "chat...";
            ChatTB.Size = new Size(501, 604);
            ChatTB.TabIndex = 0;
            // 
            // MessageTB
            // 
            MessageTB.Location = new Point(8, 651);
            MessageTB.Multiline = true;
            MessageTB.Name = "MessageTB";
            MessageTB.PlaceholderText = "Your Message";
            MessageTB.Size = new Size(495, 83);
            MessageTB.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(392, 615);
            button1.Name = "button1";
            button1.Size = new Size(111, 30);
            button1.TabIndex = 2;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            // 
            // UserCB
            // 
            UserCB.FormattingEnabled = true;
            UserCB.Location = new Point(8, 615);
            UserCB.Name = "UserCB";
            UserCB.Size = new Size(378, 30);
            UserCB.TabIndex = 7;
            // 
            // AdminChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 741);
            Controls.Add(UserCB);
            Controls.Add(button1);
            Controls.Add(MessageTB);
            Controls.Add(ChatTB);
            Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "AdminChatForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChatForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ChatTB;
        private TextBox MessageTB;
        private Button button1;
        private ComboBox UserCB;
    }
}