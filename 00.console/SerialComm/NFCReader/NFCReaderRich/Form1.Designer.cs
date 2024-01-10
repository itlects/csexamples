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
            textBoxCardNum16 = new TextBox();
            label6 = new Label();
            btInit = new Button();
            tbSpReadSize = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // cbPort
            // 
            cbPort.FormattingEnabled = true;
            cbPort.Location = new Point(41, 65);
            cbPort.Margin = new Padding(4);
            cbPort.Name = "cbPort";
            cbPort.Size = new Size(337, 28);
            cbPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 1;
            label1.Text = "COM포트설정";
            // 
            // btOpen
            // 
            btOpen.Location = new Point(42, 178);
            btOpen.Margin = new Padding(4);
            btOpen.Name = "btOpen";
            btOpen.Size = new Size(165, 59);
            btOpen.TabIndex = 2;
            btOpen.Text = "연결하기";
            btOpen.UseVisualStyleBackColor = true;
            btOpen.Click += button1_Click;
            // 
            // btClose
            // 
            btClose.Location = new Point(215, 178);
            btClose.Margin = new Padding(4);
            btClose.Name = "btClose";
            btClose.Size = new Size(165, 59);
            btClose.TabIndex = 3;
            btClose.Text = "연결끊기";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(42, 254);
            lbStatus.Margin = new Padding(4, 0, 4, 0);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(69, 20);
            lbStatus.TabIndex = 4;
            lbStatus.Text = "연결상태";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(410, 37);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 5;
            label3.Text = "수신";
            // 
            // richRecived
            // 
            richRecived.Location = new Point(410, 62);
            richRecived.Margin = new Padding(4);
            richRecived.Name = "richRecived";
            richRecived.Size = new Size(583, 498);
            richRecived.TabIndex = 6;
            richRecived.Text = "";
            // 
            // cbBaudrate
            // 
            cbBaudrate.FormattingEnabled = true;
            cbBaudrate.Location = new Point(40, 140);
            cbBaudrate.Margin = new Padding(4);
            cbBaudrate.Name = "cbBaudrate";
            cbBaudrate.Size = new Size(337, 28);
            cbBaudrate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 116);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 8;
            label4.Text = "BaudRate설정";
            // 
            // lbReadSize
            // 
            lbReadSize.AutoSize = true;
            lbReadSize.Location = new Point(42, 358);
            lbReadSize.Margin = new Padding(4, 0, 4, 0);
            lbReadSize.Name = "lbReadSize";
            lbReadSize.Size = new Size(99, 20);
            lbReadSize.TabIndex = 9;
            lbReadSize.Text = "인식문자개수";
            // 
            // tbReadSize
            // 
            tbReadSize.Location = new Point(40, 382);
            tbReadSize.Margin = new Padding(4);
            tbReadSize.Name = "tbReadSize";
            tbReadSize.Size = new Size(338, 27);
            tbReadSize.TabIndex = 10;
            // 
            // textBoxCardNum16
            // 
            textBoxCardNum16.Location = new Point(40, 451);
            textBoxCardNum16.Margin = new Padding(4);
            textBoxCardNum16.Name = "textBoxCardNum16";
            textBoxCardNum16.Size = new Size(338, 27);
            textBoxCardNum16.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 427);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 11;
            label6.Text = "카드인식번호";
            // 
            // btInit
            // 
            btInit.Location = new Point(40, 497);
            btInit.Margin = new Padding(4);
            btInit.Name = "btInit";
            btInit.Size = new Size(338, 59);
            btInit.TabIndex = 13;
            btInit.Text = "회수수신초기";
            btInit.UseVisualStyleBackColor = true;
            btInit.Click += btInit_Click;
            // 
            // tbSpReadSize
            // 
            tbSpReadSize.Location = new Point(40, 317);
            tbSpReadSize.Margin = new Padding(4);
            tbSpReadSize.Name = "tbSpReadSize";
            tbSpReadSize.Size = new Size(337, 27);
            tbSpReadSize.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 293);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(144, 20);
            label7.TabIndex = 14;
            label7.Text = "시리얼포트리딩개수";
            label7.Click += label7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 600);
            Controls.Add(tbSpReadSize);
            Controls.Add(label7);
            Controls.Add(btInit);
            Controls.Add(textBoxCardNum16);
            Controls.Add(label6);
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
            Margin = new Padding(4);
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
        private TextBox textBoxCardNum16;
        private Label label6;
        private Button btInit;
        private TextBox tbSpReadSize;
        private Label label7;
    }
}