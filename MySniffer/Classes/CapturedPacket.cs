using PcapDotNet.Packets;

namespace MySniffer.Classes
{
    class CapturedPacket
    {
        private Packet myPacket;

        public CapturedPacket(Packet myPacket)
        {
            this.myPacket = myPacket;
        }

        public string getDestinationMAC()
        {
            return myPacket.Ethernet.Destination.ToString();
        }

        public string getSourceMAC()
        {
            return myPacket.Ethernet.Source.ToString();
        }

        public string getService()
        {
            return myPacket.Ethernet.EtherType.ToString();
        }

        public string getIPVersion()
        {
            return myPacket.IpV4.Version.ToString();
        }

        public string getIPHeaderLength()
        {
            return myPacket.IpV4.HeaderLength.ToString();
        }

        public string getIPService()
        {
            return myPacket.IpV4.TypeOfService.ToString();
        }

        public string getPacketLength()
        {
            return myPacket.IpV4.Length.ToString();
        }

        public string getIPIdentification()
        {
            return myPacket.IpV4.Identification.ToString();
        }

        public string getIPTTL()
        {
            return myPacket.IpV4.Ttl.ToString();
        }

        public string getIPProtocol()
        {
            return myPacket.IpV4.Protocol.ToString();
        }

        public string getIPChecksum()
        {
            return myPacket.IpV4.HeaderChecksum.ToString();
        }

        public string getIPDestination()
        {
            return myPacket.IpV4.Destination.ToString();
        }

        public string getIPSource()
        {
            return myPacket.IpV4.Source.ToString();
        }

        public string getTCPSourcePort()
        {
            return myPacket.IpV4.Tcp.SourcePort.ToString();
        }

        public string getTCPDestinationPort()
        {
            return myPacket.IpV4.Tcp.DestinationPort.ToString();
        }

        public string getTCPSequenceNumber()
        {
            return myPacket.IpV4.Tcp.SequenceNumber.ToString();
        }

        public string getTCPAcknowledgmentNumber()
        {
            return myPacket.IpV4.Tcp.AcknowledgmentNumber.ToString();
        }

        public string getTCPHeaderLength()
        {
            return myPacket.IpV4.Tcp.HeaderLength.ToString();
        }

        public string getTCPWindow()
        {
            return myPacket.IpV4.Tcp.Window.ToString();
        }
    }
}
