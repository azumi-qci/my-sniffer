using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MySniffer.Classes
{
    class Package
    {
        private List<string> data = new List<string>();
        private List<string> completeLines = new List<string>();

        public Package(string[] data, bool isRaw = false)
        {
            int debugIndex = 1;
            // Remove the beggining of the line
            for (int i = 0; i < data.Length; i++)
            {
                if (!isRaw)
                {
                    data[i] = data[i].Substring(6);
                }

                completeLines.Add(data[i]);

                string[] dividedLine = data[i].Split(' ');


                for (int j = 0; j < dividedLine.Length; j++)
                {
                    if (string.IsNullOrWhiteSpace(dividedLine[j]))
                    {
                        continue;
                    }

                    debugIndex++;

                    this.data.Add(dividedLine[j]);
                }
            }
        }

        public List<string> getFileData()
        {
            return completeLines;
        }

        public string getFromMAC()
        {
            return string.Join(":", data.Take(6));
        }

        public string getToMAC()
        {
            return string.Join(":", data.Skip(6).Take(6));
        }

        public string getService()
        {
            return string.Join("", data.Skip(12).Take(2));
        }

        public string getIPVersion()
        {
            return data.Skip(14).Take(1).First().Substring(0, 1);
        }

        public int getPackageSize()
        {
            string firstByte = data.Skip(14).Take(1).First().Substring(1, 1);

            return int.Parse(firstByte) * 4;
        }

        public string getPackageSizeHexValue()
        {
            return data.Skip(14).Take(1).First().Substring(1, 1) + " * 4";
        }

        public string getServiceType()
        {
            string hexValue = data.Skip(15).Take(1).First();

            string binaryString = string.Join(string.Empty, hexValue.Select(
               c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(8, '0')
            ));

            return binaryString.Substring(binaryString.Length - 8, 8);
        }

        public int getPackageLength()
        {
            string hexValue = string.Join("", data.Skip(16).Take(2));

            return Convert.ToInt32(hexValue, 16);
        }

        public string getPackageLengthHexValue()
        {
            return "0x" + string.Join("", data.Skip(16).Take(2));
        }

        public string getPackageIdentification()
        {
            return "0x" + string.Join("", data.Skip(18).Take(2));
        }

        public string getFlags(bool returnAllValue = false)
        {
            string hexValue = data.Skip(20).Take(1).First();

            string binaryString = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);

            if (returnAllValue)
            {
                return binaryString.PadLeft(8, '0');
            }

            return binaryString.PadLeft(8, '0').Substring(0, 3);
        }

        public string getFragmentation()
        {
            string flags = getFlags(true);
            string hexValue = string.Join("", data.Skip(21).Take(1));

            string binaryString = string.Join(string.Empty, hexValue.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
            )).PadLeft(12, '0');

            return string.Format("{0}{1}", flags.Substring(3, 1), binaryString);
        }

        public string getLifestampHexValue()
        {
            return "0x" + data.Skip(22).Take(1).First();
        }

        public int getLifestamp()
        {
            string hexValue = data.Skip(22).Take(1).First();

            string binaryString = Convert.ToString(Convert.ToInt32(hexValue, 16), 10);

            return int.Parse(binaryString);
        }

        public string getProtocol()
        {
            return data.Skip(23).Take(1).First();
        }

        public string getChecksum()
        {
            return "0x" + string.Join("", data.Skip(24).Take(2));
        }

        public string getCalculatedChecksum()
        {
            // Pseudoheader
            int partOne1 = Convert.ToInt32(string.Join("", data.Skip(14).Take(2)), 16);
            int partOne2 = Convert.ToInt32(string.Join("", data.Skip(16).Take(2)), 16);
            int partOne3 = Convert.ToInt32(string.Join("", data.Skip(18).Take(2)), 16);
            int partOne4 = Convert.ToInt32(string.Join("", data.Skip(20).Take(2)), 16);
            int partOne5 = Convert.ToInt32(string.Join("", data.Skip(22).Take(2)), 16);

            int firstAddition = (partOne1 + partOne2 + partOne3 + partOne4 + partOne5);

            int partTwo1 = Convert.ToInt32(string.Join("", data.Skip(26).Take(2)), 16);
            int partTwo2 = Convert.ToInt32(string.Join("", data.Skip(28).Take(2)), 16);
            int partTwo3 = Convert.ToInt32(string.Join("", data.Skip(30).Take(2)), 16);
            int partTwo4 = Convert.ToInt32(string.Join("", data.Skip(32).Take(2)), 16);

            int secondAddition = (partTwo1 + partTwo2 + partTwo3 + partTwo4);

            string partialResultText = Convert.ToString(firstAddition + secondAddition, 16);

            int partialResult = Convert.ToInt32(partialResultText.Substring(1), 16) + Convert.ToInt32(partialResultText.Substring(0, 1));

            char[] dividedPartialResult = Convert.ToString(partialResult, 2).PadLeft(16, '0').ToArray();
            char[] dividedResult = new char[dividedPartialResult.Length];

            for (int i = 0; i < dividedPartialResult.Length; i++)
            {
                if (dividedPartialResult[i] == '0')
                {
                    dividedResult[i] = '1';
                }
                else
                {
                    dividedResult[i] = '0';
                }
            }

            int result = Convert.ToInt32(new string(dividedResult), 2);

            string hexResult = Convert.ToString(result, 16).ToUpper();

            return string.Format("0x{0}", hexResult);
        }

        public string getOriginIPHex()
        {
            return string.Join(".", data.Skip(26).Take(4));
        }

        public string getDestinationIPHex()
        {
            return string.Join(".", data.Skip(30).Take(4));
        }

        public string getOriginIPDec()
        {
            string[] ipDataDec = new string[4];
            string[] ipData = data.Skip(26).Take(4).ToArray();

            for (int i = 0; i < ipData.Length; i++)
            {
                ipDataDec[i] = Convert.ToString(Convert.ToInt32(ipData[i], 16), 10);
            }

            return string.Join(".", ipDataDec);
        }

        public string getDestinationIPDec()
        {
            string[] ipDataDec = new string[4];
            string[] ipData = data.Skip(30).Take(4).ToArray();

            for (int i = 0; i < ipData.Length; i++)
            {
                ipDataDec[i] = Convert.ToString(Convert.ToInt32(ipData[i], 16), 10);
            }

            return string.Join(".", ipDataDec);
        }

        public string getOriginPortHex()
        {
            return "0x" + string.Join("", data.Skip(34).Take(2));
        }

        public string getOriginPortDec()
        {
            string port = string.Join("", data.Skip(34).Take(2));

            return Convert.ToString(Convert.ToInt32(port, 16), 10);
        }

        public string getDestinationPortHex()
        {
            return "0x" + string.Join("", data.Skip(36).Take(2));
        }

        public string getDestinationPortDec()
        {
            string port = string.Join("", data.Skip(36).Take(2));

            return Convert.ToString(Convert.ToInt32(port, 16), 10);
        }

        public string getSequenceNumberHex()
        {
            return "0x" + string.Join("", data.Skip(38).Take(4));
        }

        public string getSequenceNumberDec()
        {
            string sequence = string.Join("", data.Skip(38).Take(4));

            return Convert.ToString(Convert.ToInt32(sequence, 16), 10);
        }

        public string getConfirmationNumberHex()
        {
            return "0x" + string.Join("", data.Skip(42).Take(4));
        }

        public string getConfirmationNumberDec()
        {
            string confirmation = string.Join("", data.Skip(42).Take(4));

            return Convert.ToString(Convert.ToInt32(confirmation, 16), 10);
        }

        public string getTCPHeaderLength()
        {
            string hexData = string.Join("", data.Skip(46).Take(1));
            string binayData = Convert.ToString(Convert.ToInt32(hexData, 16), 2);

            // Fill with zeroes
            binayData = binayData.PadLeft(8, '0').Substring(0, 4);

            int decData = Convert.ToInt32(binayData, 2);
            int headerLength = decData * 4;

            return string.Format("{0} - {1}x4 = {2} bytes", binayData, decData, headerLength);
        }

        public string getTCPReservedBits()
        {
            string hexData = string.Join("", data.Skip(46).Take(1));
            string binayData = Convert.ToString(Convert.ToInt32(hexData, 16), 2);

            string secondHexData = string.Join("", data.Skip(47).Take(1));
            string secondBinaryData = Convert.ToString(Convert.ToInt32(secondHexData, 16), 2);

            // Fill with zeroes
            binayData = binayData.PadLeft(8, '0').Substring(4, 4) + secondBinaryData.PadLeft(8, '0').Substring(0, 2);

            return binayData;
        }

        public string getTCPFlags(bool inBinary = false)
        {
            string hexData = string.Join("", data.Skip(46).Take(2));

            string realData = hexData.Substring(1);

            if (inBinary)
            {
                string binaryData = Convert.ToString(Convert.ToInt32(realData, 16), 2);

                return binaryData.PadLeft(12, '0');
            }

            return realData;
        }

        public string getTCPReservedFlag()
        {
            return getTCPFlags(true).Substring(0, 3);
        }

        public string getTCPNonceFlag()
        {
            return getTCPFlags(true).Substring(3, 1);
        }

        public string getTCPCWRFlag()
        {
            return getTCPFlags(true).Substring(4, 1);
        }

        public string getTCPECNFlag()
        {
            return getTCPFlags(true).Substring(5, 1);
        }

        public string getTCPURGFlag()
        {
            return getTCPFlags(true).Substring(6, 1);
        }

        public string getTCPACKFlag()
        {
            return getTCPFlags(true).Substring(7, 1);
        }

        public string getTCPPSHFlag()
        {
            return getTCPFlags(true).Substring(8, 1);
        }

        public string getTCPRSTFlag()
        {
            return getTCPFlags(true).Substring(9, 1);
        }

        public string getTCPSYNFlag()
        {
            return getTCPFlags(true).Substring(10, 1);
        }

        public string getTCPFINFlag()
        {
            return getTCPFlags(true).Substring(11, 1);
        }

        public string getTCPWindowSize()
        {
            string hexData = string.Join("", data.Skip(48).Take(2));

            string decimalData = Convert.ToString(Convert.ToInt32(hexData, 16), 10);

            return string.Format("0x{0} - {1}", hexData, decimalData);
        }

        public string getTCPVerifiedChecksum()
        {
            string hexData = string.Join("", data.Skip(50).Take(2));

            return string.Format("0x{0}", hexData);
        }

        public string getTCPCalculatedChecksum()
        {
            int pseudoHeader1 = Convert.ToInt32(string.Join("", data.Skip(26).Take(2)), 16);
            int pseudoHeader2 = Convert.ToInt32(string.Join("", data.Skip(28).Take(2)), 16);
            int pseudoHeader3 = Convert.ToInt32(string.Join("", data.Skip(30).Take(2)), 16);
            int pseudoHeader4 = Convert.ToInt32(string.Join("", data.Skip(32).Take(2)), 16);
            int pseudoHeader5 = Convert.ToInt32(string.Join("", data.Skip(34).Take(2)), 16);
            int pseudoHeader6 = 6 + Convert.ToInt32(data.Skip(46).ToArray().Length);

            int pseudoHeaderResult = (pseudoHeader1 + pseudoHeader2 + pseudoHeader3 + pseudoHeader4 + pseudoHeader5 + pseudoHeader6) + 1;

            int header12, header13, header14;

            int header1 = Convert.ToInt32(string.Join("", data.Skip(34).Take(2)), 16);
            int header2 = Convert.ToInt32(string.Join("", data.Skip(36).Take(2)), 16);
            int header3 = Convert.ToInt32(string.Join("", data.Skip(38).Take(2)), 16);
            int header4 = Convert.ToInt32(string.Join("", data.Skip(40).Take(2)), 16);
            int header5 = Convert.ToInt32(string.Join("", data.Skip(42).Take(2)), 16);
            int header6 = Convert.ToInt32(string.Join("", data.Skip(44).Take(2)), 16);
            int header7 = Convert.ToInt32(string.Join("", data.Skip(46).Take(2)), 16);
            int header8 = Convert.ToInt32(string.Join("", data.Skip(46).Take(2)), 16);
            int header9 = Convert.ToInt32(string.Join("", data.Skip(48).Take(2)), 16);
            int header10 = Convert.ToInt32(string.Join("", data.Skip(50).Take(2)), 16);
            int header11 = Convert.ToInt32(string.Join("", data.Skip(52).Take(2)), 16);
            try { header12 = Convert.ToInt32(string.Join("", data.Skip(54).Take(2)), 16); } catch { header12 = 0; }
            try { header13 = Convert.ToInt32(string.Join("", data.Skip(56).Take(2)), 16); } catch { header13 = 0; }
            try { header14 = Convert.ToInt32(string.Join("", data.Skip(58).Take(2)), 16); } catch { header14 = 0; }

            int headerResult = (header1 +
                header2 +
                header3 +
                header4 +
                header5 +
                header6 +
                header7 +
                header7 +
                header8 +
                header9 +
                header10 +
                header11 +
                header12 +
                header13 +
                header14) + 1;

            int dataResult = 0;

            for (int i = 57; i < data.Count; i += 2)
            {
                string hexNumber = "";

                try
                {
                    hexNumber += data.Skip(i - 1).Take(1).First();
                    hexNumber += data.Skip(i).Take(1).First();
                }
                catch
                {
                    hexNumber = hexNumber.PadLeft(4, '0');
                }

                dataResult += Convert.ToInt32(hexNumber, 16);
            }

            int tempResult = pseudoHeaderResult + headerResult + dataResult;

            char[] dividedPartialResult = Convert.ToString(tempResult, 2).PadLeft(16, '0').ToArray();
            char[] dividedResult = new char[dividedPartialResult.Length];

            for (int i = 0; i < dividedPartialResult.Length; i++)
            {
                if (dividedPartialResult[i] == '0')
                {
                    dividedResult[i] = '1';
                }
                else
                {
                    dividedResult[i] = '0';
                }
            }

            int result = Convert.ToInt32(new string(dividedResult), 2);

            string hexResult = Convert.ToString(result, 16).ToUpper();

            return string.Format("0x{0}", hexResult);
        }

        public int getTCPSequenceNumberData()
        {
            string sequence = getSequenceNumberHex().Substring(2, 1);
            string synFlag = getTCPSYNFlag();

            try
            {
                if (synFlag == "1")
                {
                    return Convert.ToInt32(sequence) + 1;
                }

                return Convert.ToInt32(sequence);
            }
            catch
            {
                return 0;
            }
        }

        public int getTCPConfirmationNumberData()
        {
            string confirmation = getConfirmationNumberHex().Substring(2, 1);
            string ackFlag = getTCPACKFlag();

            try
            {
                if (ackFlag == "1")
                {
                    return Convert.ToInt32(confirmation) + 1;
                }

                return Convert.ToInt32(confirmation);
            }
            catch
            {
                return 0;
            }
        }

        public string getTCPUrgent()
        {
            string urgentPoint = string.Join("", data.Skip(52).Take(2));

            return string.Format("0x{0}", urgentPoint);
        }

        public string getTCPOptions()
        {
            string options = string.Join(" ", data.Skip(54).Take(3));

            return options;
        }

        public void exportPacket()
        {
            int currentLine = 0;
            string path = "./export.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                int currentIndex = 0;
                bool ended = false;

                while (true)
                {
                    sw.Write(string.Format("{0}  ", Convert.ToString(currentLine).PadLeft(4, '0')));

                    for (int i = 0; i < 16; i++)
                    {
                        try
                        {
                            sw.Write(string.Format("{0} ", data[currentIndex]));
                            currentIndex++;
                        }
                        catch
                        {
                            ended = true;
                            break;
                        }
                    }

                    sw.WriteLine("");
                    currentLine += 10;

                    if (ended)
                    {
                        break;
                    }
                }

                sw.Close();
            }
        }
    }
}
