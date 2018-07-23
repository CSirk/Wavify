using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavify.Core.Models;

namespace Wavify.Core.Actions
{
    public class WavAction
    {
        public static Wav ConvertFromStreamToWav(Stream stream)
        {
            return CreateWaveFile(stream);
        }

        private static Wav CreateWaveFile(Stream stream)
        {
            //Read filestream into binary reader
            var binaryReader = new BinaryReader(stream);

            // set length for header
            var length = (int)stream.Length - 8;
            stream.Position = 22;

            // set number of channels
            var channels = binaryReader.ReadInt16();
            stream.Position = 24;

            // set sample rate
            var samplerate = binaryReader.ReadInt32();
            stream.Position = 34;

            // set bits per sample
            var bitsPerSample = binaryReader.ReadInt16();

            // set data lenth
            var dataLength = (int)stream.Length - 44;

            // close stream and reader
            binaryReader.Close();
            stream.Close();


            // create wave file with header
            return new Wav
            {
                File = stream,

                Header = new Header
                {
                    Length = length,
                    BitsPerSample = bitsPerSample,
                    Channels = channels,
                    DataLength = dataLength,
                    SampleRate = samplerate,
                }
            };
        }
    }
}
