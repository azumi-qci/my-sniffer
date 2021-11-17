using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Core;

namespace MySniffer
{
    public partial class SelectInterface : Form
    {
        public int selectedIndex = 0;

        public SelectInterface()
        {
            InitializeComponent();
        }

        private void SelectInterface_Load(object sender, EventArgs e)
        {
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No se encontraron inferfaces");
                return;
            }

            for (int i = 0; i < allDevices.Count; i++)
            {
                LivePacketDevice device = allDevices[i];

                // Add all interfaces to combo box
                interfacesCb.Items.Add(device.Name);
            }
        }

        private void interfacesCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectInterfaceBtn.Enabled)
            {
                selectInterfaceBtn.Enabled = true;
            }
        }

        private void selectInterfaceBtn_Click(object sender, EventArgs e)
        {
            selectedIndex = interfacesCb.SelectedIndex;
            // Open package capture window
            PackageCapture packageCapture = new PackageCapture(this);
            packageCapture.ShowDialog();
        }
    }
}
