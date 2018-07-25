using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavify.Core.Models
{
    public class Wav
    {
        public Stream File { get; set; }
        public Header Header { get; set; } = new Header();

        public Wav() { }

        //public Wav(Stream stream)
        //{
        //    var binaryReader = new BinaryReader(stream);

        //    Header.Length = (int)stream.Length - 8;
        //    stream.Position = 22;
        //    Header.Channels = binaryReader.ReadInt16();
        //    stream.Position = 24;
        //    Header.SampleRate = binaryReader.ReadInt32();
        //    stream.Position = 34;

        //    Header.BitsPerSample = binaryReader.ReadInt16();
        //    Header.DataLength = (int)stream.Length - 44;
        //    binaryReader.Close();
        //}

    }

    public class Header
    {
        //public Int16 BitsPerSample { get; set; }
        //public int DataLength { get; set; }
        //public int Length { get; set; }
        //public Int16 Channels { get; set; }
        //public int SampleRate { get; set; }

        //// The format (Wave in this case) chunk descriptor which requires Format and Data sub chunk
        //public char[] RiffChunkDescriptor { get; } = new char[4] { 'R', 'I', 'F', 'F' };

        //// The format Sub Chunk
        //public char[] FormatSubChunk { get; } = new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' };

        //// The data Sub Chunk
        //public char[] DataSubChunk { get; } = new char[4] { 'd', 'a', 't', 'a' };

        public byte[] riffID; // RIFF
        public int size;  // Size of file
        public byte[] wavID;  // WAVE
        public byte[] fmtID;  // FMT 
        public int fmtSize; // Size of Format
        public short format; // Format
        public short channels; // Number of Channels
        public int sampleRate; // Sample Rate
        public int bytePerSec; // Bytes Per Second
        public short blockSize; // Block Size
        public short bit;  // Bit
        public byte[] dataID; // DATA
        public int dataSize; // Size of Data

    }
}
