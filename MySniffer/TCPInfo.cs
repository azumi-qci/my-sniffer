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
            originPortTb.Text = packageAnalizer.getTCPOriginPort();
            originPortNameTb.Text = packageAnalizer.getTCPOriginPortName();
            destinationPortTb.Text = packageAnalizer.getTCPDestinationPort();
            destinationPortNameTb.Text = packageAnalizer.getTCPDestinationPortName();

            sequenceNumberRawTb.Text = packageAnalizer.getTCPSequenceNumberRaw();
            confirmationNumberRawTb.Text = packageAnalizer.getTCPConfirmationNumberRaw();
            sequenceNumberRelativeTb.Text = packageAnalizer.getTCPSequenceNumber().ToString();
            confirmationNumberRelativeTb.Text = packageAnalizer.getTCPConfirmationNumber().ToString();

            headerLengthTb.Text = packageAnalizer.getTCPHeaderLength();
            reservedBitsTb.Text = packageAnalizer.getTCPReservedBits();
            
            // TCP Flags
            tcpFlagsTb.Text = packageAnalizer.getTCPFlags();
            reservedFlagTb.Text = packageAnalizer.getTCPReservedFlag();
            nonceFlagTb.Text = packageAnalizer.getTCPNonceFlag();
            cwrFlagTb.Text = packageAnalizer.getTCPCWRFlag();
            ecnFlagTb.Text = packageAnalizer.getTCPECNFlag();
            urgFlagTb.Text = packageAnalizer.getTCPURGFlag();
            ackFlagTb.Text = packageAnalizer.getTCPACKFlag();
            pshFlagTb.Text = packageAnalizer.getTCPPSHFlag();
            rstFlagTb.Text = packageAnalizer.getTCPRSTFlag();
            synFlagTb.Text = packageAnalizer.getTCPSYNFlag();
            finFlagTb.Text = packageAnalizer.getTCPFINFlag();

            windowSizeTb.Text = packageAnalizer.getTCPWindowSize();
            verifiedChecksumTb.Text = packageAnalizer.getTCPVerifiedChecksum();
            urgentTb.Text = packageAnalizer.getTCPUrgent();
            optionsTb.Text = packageAnalizer.getTCPOptions();
        }
    }
}
