using PcapDotNet.Core;
using PcapDotNet.Packets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MySniffer
{
    public partial class PackageCapture : Form
    {
        int packetCount;
        int selectedPacketIndex;
        SelectInterface selectInterface;
        List<Packet> myPackets;
        // My threads
        Thread packetThread;

        public PackageCapture(SelectInterface selectInterface)
        {
            InitializeComponent();

            this.selectInterface = selectInterface;

            // Instanciate values
            selectedPacketIndex = 0;
            packetCount = 0;
            myPackets = new List<Packet>();
        }

        private void PackageCapture_Load(object sender, EventArgs e)
        {
            packetThread = new Thread(new ThreadStart(PacketCapture));

            packetThread.Start();
        }

        private void PacketCapture()
        {
            int selectedInterfaceIndex = selectInterface.selectedIndex;

            Console.WriteLine("Interfaz con indice: " + selectedInterfaceIndex);

            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            PacketDevice selectedDevice = allDevices[selectedInterfaceIndex];

            // Open the device
            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                communicator.ReceivePackets(0, PacketHandler);
            }
        }

        private void PacketHandler(Packet packet)
        {
            // Add packet to list
            myPackets.Add(packet);
            // Show packet in list box
            if (captureLb.InvokeRequired)
            {
                captureLb.Invoke(new MethodInvoker(delegate
                {
                    captureLb.Items.Add(string.Format("{0} \t {1} \t {2} \t {3} \t {4}",
                        packetCount,
                        packet.Ethernet.IpV4.Source,
                        packet.Ethernet.IpV4.Destination,
                        packet.Ethernet.IpV4.Protocol.ToString().ToUpper(),
                        packet.Ethernet.IpV4.Length
                    ));
                }));
            }
            else
            {
                captureLb.Items.Add(string.Format("{0} | {1} ", packetCount, packet.Ethernet.IpV4.Source));
            }

            packetCount++;
        }

        private void PackageCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (packetThread.IsAlive)
            {
                packetThread.Abort();
            }
        }

        private void stopThreadBtn_Click(object sender, EventArgs e)
        {
            if (packetThread.IsAlive)
            {
                packetThread.Abort();
            }

            stopThreadBtn.Enabled = false;
        }

        private void captureLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectPacketBtn.Enabled)
            {
                selectPacketBtn.Enabled = true;
            }

            // Set selected index
            selectedPacketIndex = captureLb.SelectedIndex;
        }

        private void selectPacketBtn_Click(object sender, EventArgs e)
        {
            Packet selectedPacket = myPackets[selectedPacketIndex];

            if (selectedPacket.Ethernet.IpV4.Protocol.ToString().ToUpper() != "TCP")
            {
                MessageBox.Show("El paquete seleccionado no es TCP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
