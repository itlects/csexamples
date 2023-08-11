namespace NFCReaderRich
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
            cbPort = new ComboBox();
            label1 = new Label();
            btOpen = new Button();
            btClose = new Button();
            lbStatus = new Label();
            label3 = new Label();
            richRecived = new RichTextBox();
            cbBaudrate = new ComboBox();
            label4 = new Label();
            lbReadSize = new Label();
            tbReadSize = new TextBox();
            SuspendLayout();
            // 
            // cbPort
            // 
            cbPort.FormattingEnabled = true;
            cbPort.Location = new Point(32, 69);
            cbPort.Name = "cbPort";
            cbPort.Size = new Size(263, 23);
            cbPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 48);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "COM포트설정";
            // 
            // btOpen
            // 
            btOpen.Location = new Point(33, 154);
            btOpen.Name = "btOpen";
            btOpen.Size = new Size(128, 44);
            btOpen.TabIndex = 2;
            btOpen.Text = "연결하기";
            btOpen.UseVisualStyleBackColor = true;
            btOpen.Click += button1_Click;
            // 
            // btClose
            // 
            btClose.Location = new Point(167, 154);
            btClose.Name = "btClose";
            btClose.Size = new Size(128, 44);
            btClose.TabIndex = 3;
            btClose.Text = "연결끊기";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(33, 211);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(55, 15);
            lbStatus.TabIndex = 4;
            lbStatus.Text = "연결상태";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 48);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "수신";
            // 
            // richRecived
            // 
            richRecived.Location = new Point(319, 67);
            richRecived.Name = "richRecived";
            richRecived.Size = new Size(454, 344);
            richRecived.TabIndex = 6;
            richRecived.Text = "";
            // 
            // cbBaudrate
            // 
            cbBaudrate.FormattingEnabled = true;
            cbBaudrate.Location = new Point(31, 125);
            cbBaudrate.Name = "cbBaudrate";
            cbBaudrate.Size = new Size(263, 23);
            cbBaudrate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 107);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 8;
            label4.Text = "BaudRate설정";
            // 
            // lbReadSize
            // 
            lbReadSize.AutoSize = true;
            lbReadSize.Location = new Point(33, 265);
            lbReadSize.Name = "lbReadSize";
            lbReadSize.Size = new Size(79, 15);
            lbReadSize.TabIndex = 9;
            lbReadSize.Text = "인식문자개수";
            // 
            // tbReadSize
            // 
            tbReadSize.Location = new Point(33, 283);
            tbReadSize.Name = "tbReadSize";
            tbReadSize.Size = new Size(262, 23);
            tbReadSize.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbReadSize);
            Controls.Add(lbReadSize);
            Controls.Add(label4);
            Controls.Add(cbBaudrate);
            Controls.Add(richRecived);
            Controls.Add(label3);
            Controls.Add(lbStatus);
            Controls.Add(btClose);
            Controls.Add(btOpen);
            Controls.Add(label1);
            Controls.Add(cbPort);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPort;
        private Label label1;
        private Button btOpen;
        private Button btClose;
        private Label label2;
        private Label label3;
        private RichTextBox richRecived;
        private ComboBox cbBaudrate;
        private Label label4;
        private Label lbStatus;
        private Label label5;
        private Label lbReadSize;
        private TextBox tbReadSize;
    }
}