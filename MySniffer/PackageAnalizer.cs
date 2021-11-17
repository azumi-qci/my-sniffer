using System;
using System.IO;
using System.Windows.Forms;
using MySniffer.Classes;
using MySniffer.Globals;

namespace MySniffer
{
    public partial class PackageAnalizer : Form
    {
        private string dumpPath = "tramaenhexdump.txt";
        private Package package;

        private PackageCapture packageCapture;

        public PackageAnalizer(PackageCapture packageCapture = null)
        {
            InitializeComponent();

            this.packageCapture = packageCapture;
        }

        private void PackageAnalizer_Load(object sender, EventArgs e)
        {

            if (File.Exists(dumpPath))
            {
                string[] data;

                if (packageCapture != null)
                {
                    data = new string[] { packageCapture.selectedPacketData };
                }
                else
                {
                    data = File.ReadAllLines(dumpPath);
                }

                package = new Package(data, packageCapture != null);

                // Show data in the form
                packageTb.Lines = package.getFileData().ToArray();
                fromMACtb.Text = package.getFromMAC();
                toMACtb.Text = package.getToMAC();

                string serviceType = package.getService();
                string serviceName;

                try
                {
                    serviceName = MySnifferGlobals.serviceTypes[serviceType];
                }
                catch
                {
                    serviceName = "Desconocido";
                }


                serviceTypeTb.Text = string.Format("0x{0} - {1}", serviceType, serviceName);

                if (serviceType != "0800")
                {
                    // Ignore the rest of the info
                    return;
                }

                // IPv4 data
                ipVersionTb.Text = package.getIPVersion();
                packageSizeTb.Text = string.Format("{0} = {1} bytes", package.getPackageSizeHexValue(), package.getPackageSize());

                // Service type
                string typeBinary = package.getServiceType();

                string precedenceBinary = typeBinary.Substring(0, 3);
                string tosServiceBinary = typeBinary.Substring(3, 4);
                string mbzBinary = typeBinary.Substring(6, 1);

                string precedenceName;
                string tosServiceName;

                try
                {
                    precedenceName = MySnifferGlobals.precedence[precedenceBinary];
                }
                catch
                {
                    precedenceName = "Desconocido";
                }

                try
                {
                    tosServiceName = MySnifferGlobals.tosService[tosServiceBinary];
                }
                catch
                {
                    tosServiceName = "Desconocido";
                }

                ipServiceTypeTb.Text = typeBinary;
                precedenceTb.Text = string.Format("{0} - {1}", precedenceBinary, precedenceName);
                tosServiceTb.Text = string.Format("{0} - {1}", tosServiceBinary, tosServiceName);
                mbzTb.Text = string.Format("{0} - Reservado", mbzBinary);

                packageLengthTb.Text = string.Format("{0} = {1} bytes", package.getPackageLengthHexValue(), package.getPackageLength());
                packageIdentificationTb.Text = package.getPackageIdentification();

                // Flags
                string flagsBinary = package.getFlags();
                string flagOne = flagsBinary.Substring(0, 1);
                string flagTwo = flagsBinary.Substring(1, 1);
                string flagThree = flagsBinary.Substring(2, 1);

                flagsTb.Text = flagsBinary;
                reservedTb.Text = string.Format("{0} - Reservado", flagOne);
                dontFragmentTb.Text = string.Format("DF: {0} - {1}", flagTwo, flagTwo == "0" ? "Fragmentar" : "No fragmentar");
                moreFragmentsTb.Text = string.Format("MF: {0} - {1}", flagThree, flagThree == "0" ? "Último fragmento" : "Más fragmentos");

                fragmentationTb.Text = package.getFragmentation() + " - No hay desplazamiento";
                lifetimeTb.Text = string.Format("{0} = {1} segundos", package.getLifestampHexValue(), package.getLifestamp());

                // Protocol
                string protocol = package.getProtocol();
                string protocolName;

                try
                {
                    protocolName = MySnifferGlobals.protocols[int.Parse(protocol)];
                }
                catch
                {
                    protocolName = "Desconocido";
                }

                protocolTb.Text = string.Format("0x{0} - {1}", protocol, protocolName);

                // Checksum
                checksumVerifiedTb.Text = package.getChecksum();
                checksumCalculatedTb.Text = package.getCalculatedChecksum();

                if (checksumVerifiedTb.Text.Equals(checksumCalculatedTb.Text))
                {
                    checksumResultTb.Text = "CORRECTO";
                }
                else
                {
                    checksumResultTb.Text = "INCORRECTO";
                }

                // IPs
                ipOriginHexTb.Text = package.getOriginIPHex() + " (HEX)";
                ipDestinationHexTb.Text = package.getDestinationIPHex() + " (HEX)";
                ipOriginDecTb.Text = package.getOriginIPDec() + " (DEC)";
                ipDestinationDecTb.Text = package.getDestinationIPDec() + " (DEC)";

                // Active TCP button
                showTCPInfoBtn.Enabled = true;
            }
        }

        private void showTCPInfoBtn_Click(object sender, EventArgs e)
        {
            TCPInfo tcpInfo = new TCPInfo(this);
            tcpInfo.ShowDialog();
        }

        /* TCP methods */

        public string getTCPOriginPort()
        {
            return package.getOriginPortHex() + " - " + package.getOriginPortDec();
        }

        public string getTCPOriginPortName()
        {
            string value;

            if (MySnifferGlobals.mostCommonPorts.TryGetValue(package.getOriginPortDec(), out value))
            {
                return value;
            }
            else
            {
                return "Desconocido";
            }
        }

        public string getTCPDestinationPort()
        {
            return package.getDestinationPortHex() + " - " + package.getDestinationPortDec();
        }

        public string getTCPDestinationPortName()
        {
            string value;

            if (MySnifferGlobals.mostCommonPorts.TryGetValue(package.getDestinationPortDec(), out value))
            {
                return value;
            }
            else
            {
                return "Desconocido";
            }
        }

        public string getTCPSequenceNumberRaw()
        {
            return package.getSequenceNumberHex() + " - " + package.getSequenceNumberDec();
        }

        public string getTCPConfirmationNumberRaw()
        {
            return package.getConfirmationNumberHex() + " - " + package.getConfirmationNumberDec();
        }

        public string getTCPHeaderLength()
        {
            return package.getTCPHeaderLength();
        }

        public string getTCPReservedBits()
        {
            return package.getTCPReservedBits();
        }

        public string getTCPFlags()
        {
            return "0x" + package.getTCPFlags() + " - " + package.getTCPFlags(true);
        }

        public string getTCPReservedFlag()
        {
            return package.getTCPReservedFlag();
        }

        public string getTCPNonceFlag()
        {
            string value = package.getTCPNonceFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPCWRFlag()
        {
            string value = package.getTCPCWRFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPECNFlag()
        {
            string value = package.getTCPECNFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPURGFlag()
        {
            string value = package.getTCPURGFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPACKFlag()
        {
            string value = package.getTCPACKFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPPSHFlag()
        {
            string value = package.getTCPPSHFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPRSTFlag()
        {
            string value = package.getTCPRSTFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPSYNFlag()
        {
            string value = package.getTCPSYNFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPFINFlag()
        {
            string value = package.getTCPFINFlag();

            return string.Format("{0} ({1})", value, MySnifferGlobals.setFlags[value]);
        }

        public string getTCPWindowSize()
        {
            return package.getTCPWindowSize();
        }

        public string getTCPVerifiedChecksum()
        {
            return package.getTCPVerifiedChecksum();
        }

        public int getTCPSequenceNumber()
        {
            return package.getTCPSequenceNumberData();
        }

        public int getTCPConfirmationNumber()
        {
            return package.getTCPConfirmationNumberData();
        }

        public string getTCPUrgent()
        {
            string data = package.getTCPUrgent();

            int urgent = Convert.ToInt32(data, 16);

            if (urgent > 0)
            {
                return string.Format("{0} - Urgente", data);
            }

            return string.Format("{0} - No urgente", data);
        }

        public string getTCPOptions()
        {
            return package.getTCPOptions();
        }
    }
}
