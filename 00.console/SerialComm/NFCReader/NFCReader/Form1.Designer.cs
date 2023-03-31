namespace NFCReader2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btClose = new System.Windows.Forms.Button();
            this.tbRead = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(132, 46);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(191, 23);
            this.cbPort.TabIndex = 1;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(329, 45);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 2;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Baud Rate";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(132, 75);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(191, 23);
            this.cbBaudRate.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(329, 74);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbRead
            // 
            this.tbRead.Location = new System.Drawing.Point(133, 120);
            this.tbRead.Name = "tbRead";
            this.tbRead.Size = new System.Drawing.Size(271, 23);
            this.tbRead.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "NFC Read";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 187);
            this.Controls.Add(this.tbRead);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cbPort;
        private Button btOpen;
        private Label label2;
        private ComboBox cbBaudRate;
        private Button btClose;
        private TextBox tbRead;
        private Label label3;
    }
}