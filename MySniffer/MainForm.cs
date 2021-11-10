using System.Windows.Forms;

namespace MySniffer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void packageBtn_Click(object sender, System.EventArgs e)
        {
            PackageAnalizer packageAnalizer = new PackageAnalizer();
            packageAnalizer.ShowDialog();
        }
    }
}
