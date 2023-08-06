namespace WinFormsAppLoadDynamicButtonArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += DynamicButton_Load;
        }

        private void DynamicButton_Load(object? sender, EventArgs e)
        {
            DybanucButton();
        }

        private void DybanucButton()
        {
            Control[] Btn = new Control[10];
            FlowLayoutPanel flp = new FlowLayoutPanel();

            for(int i=0;i<10; i++)
            {
                Btn[i] = new Button();
                Btn[i].Name =i.ToString();
                Btn[i].Parent = this;
                Btn[i].Size = new Size(90, 30);
                int j = i + 1;
                Btn[i].Text = "Dynamic_" + j.ToString();
                this.Width += 80;
                this.Height += 30;
                flp.Controls.Add(Btn[i]);

            }
            this.Controls.Add(flp);
            flp.Dock = DockStyle.Fill;
        }
    }
}