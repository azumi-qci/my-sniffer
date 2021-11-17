using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Core;

namespace MySniffer
{
    public partial class SelectInterface : Form
    {
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

                Console.WriteLine("Nombre: " + device.Name);
            }
        }
    }
}
