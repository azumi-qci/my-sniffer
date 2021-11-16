using System.Collections.Generic;

namespace MySniffer.Globals
{
    public static class MySnifferGlobals
    {
        public static Dictionary<string, string> serviceTypes = new Dictionary<string, string>()
        {
            { "0800", "Internet Protocol version 4 (IPv4)" },
            { "0806", "Address Resolution Protocol (ARP)" },
            { "0842", "Wake-on-LAN'" },
            { "22F3", "IETF TRILL Protocol" },
            { "6003", "DECnet Phase IV" },
            { "8035", "Resverse Address Resolution Protocol" },
            { "809B", "AppleTalk (Ethertalk)" },
            { "80F3", "AppleTalk Address Resolution Protocol (AARP)" },
            { "8100", "VLAN-tagged frame (IEEE 802.1Q) and Shortest Path Bridging IEEE 802.1aq" },
            { "8137", "IPX" },
            { "68DD", "Internet Protocol Version 6 (IPv6)" },
            { "8808", "Ethernet flow control" },
            { "8819", "CobraNet" },
            { "8847", "MPLS unicast" },
            { "8848", "MPLS multicast" },
            { "8863", "PPPoE Discovery Stage" },
            { "8864", "PPPoE Session Stage" },
            { "8870", "Jumbo Frames (proposed)" },
            { "887B", "HomePlug 1.0 MME" },
            { "888E", "EAP over LAN (IEEE 802.1X)" },
            { "8892", "PROFINET Protocol" },
            { "889A", "HyperSCSI (SCSI over Etherner)" },
            { "88A2", "ATA over Ethernet" },
            { "88A4", "EtherCAT Protocol" },
            { "88A8", "Provider Bridging (IEEE 802.1ad) & Shortest Path Brigging IEEE 802.1aq" },
            { "88AB", "Ethernet Powerlink" },
            { "88CC", "Link Layer Discovery Protocol (LLDP)" },
            { "88CD", "SERCOS III" },
            { "88E1", "HomePlug AV MME" },
            { "88E3", "Media Redudancy Protocol (IEC622439-2)" },
            { "88E5", "MAC security (IEEE 802.1AE)" },
            { "88E7", "Provider Backbone Bridges (PBB) (IEEE 802.1ah)" },
            { "88F7", "Precision Time Protocol (PTP) over Ethernet (IEEE 1588)" },
            { "8902", "IEEE 802.1ag Connectivity Fault Management" },
            { "8906", "Fibre Channel over Ethernet (FCoE)" },
            { "8914", "FCoE Initialization Protocol" },
            { "8915", "RDMA over Converged Ethernet (RoCE)" },
            { "891D", "TTEthernet Protocol Control Frame (TTE)" },
            { "892F", "High-availability Seamless Redudancy (HSR)" },
            { "9000", "Ethernet Configuration Testing Protocol" }
        };

        public static Dictionary<string, string> precedence = new Dictionary<string, string>()
        {
            { "000", "Rutina" },
            { "001", "Prioridad" },
            { "010", "Inmediato" },
            { "011", "Flash" },
            { "100", "Flash override" },
            { "101", "Crítico" },
            { "110", "Control de red (Internetwork control)" },
            { "111", "Control de red (Network control)" }
        };

        public static Dictionary<string, string> tosService = new Dictionary<string, string>()
        {
            { "1000", "Minimizar retardo" },
            { "0100", "Maximizar la densidad de flujo" },
            { "0010", "Maximizar la fiabilidad" },
            { "0001", "Minimizar el coste monetario" },
            { "0000", "Servicio normal" }
        };

        public static Dictionary<int, string> protocols = new Dictionary<int, string>()
        {
            { 0, "Reservado" },
            { 1, "ICMP (Internet Control Massage Protocol)" },
            { 2, "IGMP (Internet Group Management Protocol)" },
            { 3, "GPP (Gateway-to-Gateway Protocol" },
            { 4, "IP (IP encapsulation)" },
            { 5, "Flujo (Stream)" },
            { 6, "TCP (Transmission Control Protocol)" },
            { 8, "EGP (Exterior Gateway Protocol)" },
            { 9, "PIRP (Private Interior Routing Protocol)" },
            { 17, "UDP (User Datagram)" },
            { 89, "OSPF (Open Shortest Path First)" }
        };

        public static Dictionary<string, string> setFlags = new Dictionary<string, string>()
        {
            { "0", "Sin establecer" },
            { "1", "Establecido" }
        };
    }
}
