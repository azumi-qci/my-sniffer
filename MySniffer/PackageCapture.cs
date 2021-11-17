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
        SelectInterface selectInterface;
        // My threads
        Thread packetThread;

        public PackageCapture(SelectInterface selectInterface)
        {
            InitializeComponent();

            this.selectInterface = selectInterface;
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

        private static void PacketHandler(Packet packet)
        {
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);
        }

        private void PackageCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (packetThread.IsAlive)
            {
                packetThread.Abort();
            }
        }
    }
}
