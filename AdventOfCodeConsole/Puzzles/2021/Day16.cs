namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day16 : IDay
    {
        private class Packet
        {
            public short Version { get; set; }
            public short Type { get; set; }
            public List<string> LiteralNybles { get; set; } = new List<string>();

            public string Padding { get; set; }
        }

        public long Part1(string input)
        {
            var readPos = 0;
            var bitsRead = 0;

            var binaryString = string.Join(string.Empty,
                input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            string ReadBits(int numBits)
            {
                var bits = binaryString.Substring(readPos, numBits);
                readPos = readPos + numBits;
                bitsRead += numBits;
                return bits;
            }

            int GetPadding()
            {
                var nextByble = (bitsRead / 4 + 1) * 4;
                return nextByble - bitsRead;
            }

            var packet = new Packet();
            packet.Version = Convert.ToInt16(ReadBits(3), 2);
            packet.Type = Convert.ToInt16(ReadBits(3), 2);

            if (packet.Type == 4)
            {
                string fiveBits;
                do
                {
                    fiveBits = ReadBits(5);
                    packet.LiteralNybles.Add(fiveBits[1..]);
                } while (fiveBits[0] != '0');

                packet.Padding = ReadBits(GetPadding());
                bitsRead = 0;
            }



            return 0;
        }
    }
}
