namespace SerialTest
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
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkSndHexa = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chkRecHexa = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboPortName
            // 
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.Location = new System.Drawing.Point(129, 37);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.Size = new System.Drawing.Size(121, 23);
            this.cboPortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(260, 38);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(260, 73);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkSndHexa
            // 
            this.chkSndHexa.AutoSize = true;
            this.chkSndHexa.Location = new System.Drawing.Point(532, 117);
            this.chkSndHexa.Name = "chkSndHexa";
            this.chkSndHexa.Size = new System.Drawing.Size(78, 19);
            this.chkSndHexa.TabIndex = 7;
            this.chkSndHexa.Text = "Snd Hexa";
            this.chkSndHexa.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chkRecHexa
            // 
            this.chkRecHexa.AutoSize = true;
            this.chkRecHexa.Location = new System.Drawing.Point(529, 283);
            this.chkRecHexa.Name = "chkRecHexa";
            this.chkRecHexa.Size = new System.Drawing.Size(76, 19);
            this.chkRecHexa.TabIndex = 10;
            this.chkRecHexa.Text = "Rec Hexa";
            this.chkRecHexa.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(532, 381);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "CLear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(129, 73);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(121, 23);
            this.txtBaudRate.TabIndex = 12;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(62, 113);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(464, 132);
            this.txtSend.TabIndex = 13;
            // 
            // txtRec
            // 
            this.txtRec.Location = new System.Drawing.Point(62, 281);
            this.txtRec.Multiline = true;
            this.txtRec.Name = "txtRec";
            this.txtRec.Size = new System.Drawing.Size(464, 132);
            this.txtRec.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRec);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chkRecHexa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkSndHexa);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPortName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboPortName;
        private Label label1;
        private Button btnOpen;
        private Label label2;
        private Button btnClose;
        private CheckBox chkSndHexa;
        private Button button3;
        private CheckBox chkRecHexa;
        private Button button4;
        private TextBox txtBaudRate;
        private TextBox txtSend;
        private TextBox txtRec;
    }
}