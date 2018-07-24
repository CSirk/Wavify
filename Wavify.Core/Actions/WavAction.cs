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
            return CreateWavData(stream);
        }


        public static string CreateWavFile(Wav wavData, string filePathToWrite)
        {
            return WriteWavToFile(wavData, filePathToWrite);
        }

        public static string WriteWavToFile(Wav wavData, string filePathToWrite)
        {
            FileStream wavDataStream = new FileStream(filePathToWrite, FileMode.Create, FileAccess.Write);

            BinaryWriter binaryWriter = new BinaryWriter(wavDataStream);

            binaryWriter.Write(wavData.Header.RiffChunkDescriptor);
            binaryWriter.Write(wavData.Header.Length);
            binaryWriter.Write(wavData.Header.FormatSubChunk);
            binaryWriter.Write((int)16);
            binaryWriter.Write((short)1);
            binaryWriter.Write(wavData.Header.Channels);
            binaryWriter.Write(wavData.Header.SampleRate);
            binaryWriter.Write((int)(wavData.Header.SampleRate * ((wavData.Header.BitsPerSample * wavData.Header.Channels) / 8)));
            binaryWriter.Write((short)((wavData.Header.BitsPerSample * wavData.Header.Channels) / 8));
            binaryWriter.Write(wavData.Header.BitsPerSample);
            binaryWriter.Write(wavData.Header.DataSubChunk);
            binaryWriter.Write(wavData.Header.DataLength);

            wavDataStream.Close();
            binaryWriter.Close();

            return filePathToWrite;
        }

        private static Wav CreateWavData(Stream stream)
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
