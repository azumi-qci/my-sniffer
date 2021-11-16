using System.Windows.Forms;

namespace MySniffer
{
    public partial class TCPInfo : Form
    {
        private PackageAnalizer packageAnalizer;

        public TCPInfo(PackageAnalizer packageAnalizer)
        {
            InitializeComponent();

            // Get package information
            this.packageAnalizer = packageAnalizer;
        }

        private void TCPInfo_Load(object sender, System.EventArgs e)
        {
            originPortTb.Text = this.packageAnalizer.getTCPOriginPort();
            destinationPortTb.Text = this.packageAnalizer.getTCPDestinationPort();

            sequenceNumberRawTb.Text = this.packageAnalizer.getTCPSequenceNumberRaw();
            confirmationNumberRawTb.Text = this.packageAnalizer.getTCPConfirmationNumberRaw();

            headerLengthTb.Text = this.packageAnalizer.getTCPHeaderLength();
            reservedBitsTb.Text = this.packageAnalizer.getTCPReservedBits();

            tcpFlagsTb.Text = this.packageAnalizer.getTCPFlags();
            reservedFlagTb.Text = this.packageAnalizer.getTCPReservedFlag();
            nonceFlagTb.Text = this.packageAnalizer.getTCPNonceFlag();
            cwrFlagTb.Text = this.packageAnalizer.getTCPCWRFlag();
            ecnFlagTb.Text = this.packageAnalizer.getTCPECNFlag();
        }
    }
}
