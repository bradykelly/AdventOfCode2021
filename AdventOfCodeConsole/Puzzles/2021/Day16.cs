namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day16 : IDay
    {
        private class BitString
        {
            public int ReadPos { get; private set; } = 0;
            public string Bits { get; set; }

            public BitString(string bits)
            {
                Bits = bits;
            }

            public string ReadBits(int numBits)
            {
                var bits = Bits.Substring(ReadPos, numBits);
                ReadPos += numBits;
                return bits;
            }

        }

        private class Packet
        {
            public short Version { get; set; }
            public short Type { get; set; }
            public short LengthType { get; set; }
            public int SubPacketsLength { get; set; }
            public List<string> LiteralNybles { get; set; } = new List<string>();

            public string Padding { get; set; }
        }

        private static void ProcessPackets(BitString bitString, ref int versionSum, bool iterating = false)
        {
            while (bitString.ReadPos < bitString.Bits.Length - 10)
            {
                var packet = new Packet();
                packet.Version = Convert.ToInt16(bitString.ReadBits(3), 2);
                packet.Type = Convert.ToInt16(bitString.ReadBits(3), 2);
                versionSum += packet.Version;

                switch (packet.Type)
                {
                    case 4:
                        {
                            string fiveBits;
                            do
                            {
                                fiveBits = bitString.ReadBits(5);
                                packet.LiteralNybles.Add(fiveBits[1..]);
                            } while (fiveBits[0] != '0');
                            break;
                        }

                    default:
                        {
                            packet.LengthType = short.Parse(bitString.ReadBits(1));
                            if (packet.LengthType == 0)
                            {
                                var len = Convert.ToInt32(bitString.ReadBits(15), 2);
                                var nextBitString = new BitString(bitString.ReadBits(len));
                                ProcessPackets(nextBitString, ref versionSum, false);
                            } else if (packet.LengthType == 1)
                            {
                                var count = Convert.ToInt32(bitString.ReadBits(11), 2);
                                for (var c = 0; c < count; c++)
                                {
                                    ProcessPackets(bitString, ref versionSum, true);
                                }
                            }
                            break;
                        }
                }
                if (iterating)
                    return;
            }
        }

        public long Part1(string input)
        {
            var binaryString = string.Join(string.Empty, input
                .Where(c => c != '\n')
                .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            var bitString = new BitString(binaryString);

            var versionSum = 0;
            ProcessPackets(bitString, ref versionSum, false);

            return versionSum;
        }
    }
}
