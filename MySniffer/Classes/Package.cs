using System;
using System.Collections.Generic;
using System.Linq;

namespace MySniffer.Classes
{
    class Package
    {
        private List<string> data = new List<string>();
        private List<string> completeLines = new List<string>();

        public Package(string[] data)
        {
            // Remove the beggining of the line
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].Substring(6);
                this.completeLines.Add(data[i]);

                string[] dividedLine = data[i].Split(' ');

                for (int j = 0; j < dividedLine.Length; j++)
                {
                    this.data.Add(dividedLine[j]);
                }
            }
        }

        public List<string> getFileData()
        {
            return this.completeLines;
        }

        public string getFromMAC()
        {
            return string.Join(":", this.data.Take(6));
        }

        public string getToMAC()
        {
            return string.Join(":", this.data.Skip(6).Take(6));
        }

        public string getService()
        {
            return string.Join("", this.data.Skip(12).Take(2));
        }

        public string getIPVersion()
        {
            return this.data.Skip(14).Take(1).First().Substring(0, 1);
        }

        public int getPackageSize()
        {
            string firstByte = this.data.Skip(14).Take(1).First().Substring(1, 1);

            return int.Parse(firstByte) * 4;
        }

        public string getPackageSizeHexValue()
        {
            return this.data.Skip(14).Take(1).First().Substring(1, 1) + " * 4";
        }

        public string getServiceType()
        {
            string hexValue = this.data.Skip(15).Take(1).First();

            string binaryString = string.Join(string.Empty, hexValue.Select(
               c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(8, '0')
            ));

            return binaryString.Substring(binaryString.Length - 8, 8);
        }

        public int getPackageLength()
        {
            string hexValue = string.Join("", this.data.Skip(17).Take(2));

            return Convert.ToInt32(hexValue, 16);
        }

        public string getPackageLengthHexValue()
        {
            return "0x" + string.Join("", this.data.Skip(17).Take(2));
        }

        public string getPackageIdentification()
        {
            return "0x" + string.Join("", this.data.Skip(19).Take(2));
        }

        public string getFlags(bool returnAllValue = false)
        {
            string hexValue = this.data.Skip(21).Take(1).First();

            string binaryString = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);

            if (returnAllValue)
            {
                return binaryString.PadLeft(8, '0');
            }

            return binaryString.PadLeft(8, '0').Substring(0, 3);
        }

        public string getFragmentation()
        {
            string flags = this.getFlags(true);
            string hexValue = string.Join("", this.data.Skip(22).Take(1));

            string binaryString = string.Join(string.Empty, hexValue.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
            )).PadLeft(12, '0');

            return string.Format("{0}{1}", flags.Substring(3, 1), binaryString);
        }

        public string getLifestampHexValue()
        {
            return "0x" + this.data.Skip(23).Take(1).First();
        }

        public int getLifestamp()
        {
            string hexValue = this.data.Skip(23).Take(1).First();

            string binaryString = Convert.ToString(Convert.ToInt32(hexValue, 16), 10);

            return int.Parse(binaryString);
        }

        public string getProtocol()
        {
            return this.data.Skip(24).Take(1).First();
        }

        public string getChecksum()
        {
            return "0x" + string.Join("", this.data.Skip(25).Take(2));
        }

        public string getCalculatedChecksum()
        {
            // Pseudoheader
            int ipOrigin1 = Convert.ToInt32(string.Join("", this.data.Skip(27).Take(2)), 16);
            int ipOrigin2 = Convert.ToInt32(string.Join("", this.data.Skip(29).Take(2)), 16);
            int ipDestination1 = Convert.ToInt32(string.Join("", this.data.Skip(31).Take(2)), 16);
            int ipDestination2 = Convert.ToInt32(string.Join("", this.data.Skip(33).Take(2)), 16);
            int protocol = Convert.ToInt32("00" + this.getProtocol(), 16);
            int tcpLength = Convert.ToInt32(this.data.Skip(35).Count().ToString(), 10);

            int firstAddition = ~(ipOrigin1 + ipOrigin2 + ipDestination1 + ipDestination2 + protocol + tcpLength);

            // TCP Header
            int tcpAddition = 0;
            int currentByte = 35;

            for (int i = currentByte; i < 58; i += 2)
            {
                string pairOfBytes = string.Join("", this.data.Skip(currentByte).Take(2));

                if (i >= 57)
                {
                    pairOfBytes = pairOfBytes.Remove(2, 2);
                }

                tcpAddition += Convert.ToInt32(pairOfBytes, 16);

                currentByte += 2;
            }

            tcpAddition = ~tcpAddition;

            // Data
            int dataAddition = 0;

            for (int i = currentByte; i < this.data.Count(); i += 2)
            {
                string pairOfBytes = string.Join("", this.data.Skip(currentByte).Take(2));

                tcpAddition += Convert.ToInt32(pairOfBytes, 16);
            }

            dataAddition = ~dataAddition;

            string result = Convert.ToString(firstAddition + tcpAddition + dataAddition, 2);

            return "0x" + Convert.ToString(Convert.ToInt32(result, 2), 16).ToUpper();
        }

        public string getOriginIPHex()
        {
            return string.Join(".", this.data.Skip(27).Take(4));
        }

        public string getDestinationIPHex()
        {
            return string.Join(".", this.data.Skip(31).Take(4));
        }

        public string getOriginIPDec()
        {
            string[] ipDataDec = new string[4];
            string[] ipData = this.data.Skip(27).Take(4).ToArray();

            for (int i = 0; i < ipData.Length; i++)
            {
                ipDataDec[i] = Convert.ToString(Convert.ToInt32(ipData[i], 16), 10);
            }

            return string.Join(".", ipDataDec);
        }

        public string getDestinationIPDec()
        {
            string[] ipDataDec = new string[4];
            string[] ipData = this.data.Skip(31).Take(4).ToArray();

            for (int i = 0; i < ipData.Length; i++)
            {
                ipDataDec[i] = Convert.ToString(Convert.ToInt32(ipData[i], 16), 10);
            }

            return string.Join(".", ipDataDec);
        }

        public string getOriginPortHex()
        {
            return "0x" + string.Join("", this.data.Skip(35).Take(2));
        }

        public string getOriginPortDec()
        {
            string port = string.Join("", this.data.Skip(35).Take(2));

            return Convert.ToString(Convert.ToInt32(port, 16), 10);
        }

        public string getDestinationPortHex()
        {
            return "0x" + string.Join("", this.data.Skip(37).Take(2));
        }

        public string getDestinationPortDec()
        {
            string port = string.Join("", this.data.Skip(37).Take(2));

            return Convert.ToString(Convert.ToInt32(port, 16), 10);
        }

        public string getSequenceNumberHex()
        {
            return "0x" + string.Join("", this.data.Skip(39).Take(4));
        }

        public string getSequenceNumberDec()
        {
            string sequence = string.Join("", this.data.Skip(39).Take(4));

            return Convert.ToString(Convert.ToInt32(sequence, 16), 10);
        }

        public string getConfirmationNumberHex()
        {
            return "0x" + string.Join("", this.data.Skip(43).Take(4));
        }

        public string getConfirmationNumberDec()
        {
            string confirmation = string.Join("", this.data.Skip(43).Take(4));

            return Convert.ToString(Convert.ToInt32(confirmation, 16), 10);
        }

        public string getTCPHeaderLength()
        {
            string hexData = string.Join("", this.data.Skip(47).Take(1));
            string binayData = Convert.ToString(Convert.ToInt32(hexData, 16), 2);

            // Fill with zeroes
            binayData = binayData.PadLeft(8, '0').Substring(0, 4);

            int decData = Convert.ToInt32(binayData, 2);
            int headerLength = decData * 4;

            return string.Format("{0} ({1}x4 = {2} bytes)", binayData, decData, headerLength);
        }

        public string getTCPReservedBits()
        {
            string hexData = string.Join("", this.data.Skip(47).Take(1));
            string binayData = Convert.ToString(Convert.ToInt32(hexData, 16), 2);

            string secondHexData = string.Join("", this.data.Skip(48).Take(1));
            string secondBinaryData = Convert.ToString(Convert.ToInt32(secondHexData, 16), 2);

            // Fill with zeroes
            binayData = binayData.PadLeft(8, '0').Substring(4, 4) + secondBinaryData.PadLeft(8, '0').Substring(0, 2);

            return binayData;
        }
    }
}
