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

        public PackageAnalizer()
        {
            InitializeComponent();
        }

        private void PackageAnalizer_Load(object sender, EventArgs e)
        {
            if (File.Exists(dumpPath))
            {
                string[] data = File.ReadAllLines(dumpPath);

                package = new Package(data);

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
            }
        }
    }
}
