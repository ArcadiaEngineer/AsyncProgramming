namespace ResponsiveTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Text = "BanaTikla";
            button.AutoSize = true;
            button.Location = new Point(50,50);
            button.Visible = true;

        }
    }
}