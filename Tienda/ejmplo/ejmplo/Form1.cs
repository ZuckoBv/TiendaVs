namespace ejmplo
{
    public partial class frmMain : Form
    {
        frmAgregarProducto frmAgregarProd;
        public class frmAgregarProducto : frmMain
        {
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarProd.Show();
            this.Hide();
        }
    }
}
