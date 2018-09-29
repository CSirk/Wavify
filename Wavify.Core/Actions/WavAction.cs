using NAudio.Lame;
using NAudio.Wave;
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
        public static Wav CreateWavDataFromWaveFile(string filePathToRead)
        {
            var wav = new Wav();
            
            List<short> leftDataList = new List<short>(); //data for left channel (16bit 2 channel)
            List<short> rightDataList = new List<short>(); //data for right channel (16bit 2 channel)

            using (FileStream fs = new FileStream(@"C:\users\codas\desktop\test\silence.wav", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                try
                {
                    wav.Header.riffID = br.ReadBytes(4);
                    wav.Header.size = br.ReadInt32();
                    wav.Header.wavID = br.ReadBytes(4);
                    wav.Header.fmtID = br.ReadBytes(4);
                    wav.Header.fmtSize = br.ReadInt32();
                    wav.Header.format = br.ReadInt16();
                    wav.Header.channels = br.ReadInt16();
                    wav.Header.sampleRate = br.ReadInt32();
                    wav.Header.bytePerSec = br.ReadInt32();
                    wav.Header.blockSize = br.ReadInt16();
                    wav.Header.bit = br.ReadInt16();
                    wav.Header.dataID = br.ReadBytes(4);
                    wav.Header.dataSize = br.ReadInt32();

                    for (int i = 0; i < wav.Header.dataSize / wav.Header.blockSize; i++)
                    {
                        leftDataList.Add((short)br.ReadUInt16());
                        rightDataList.Add((short)br.ReadUInt16());
                    }

                }
                finally
                {
                    if (br != null)
                    {
                        br.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }

            return wav;
        }

        public static Wav ConvertFromStreamToWav(Stream stream)
        {
            return CreateWavData(stream);
        }


        public static string CreateWavFile(Wav wavData, string filePathToWrite)
        {
            return WriteWavDataToWavFile(wavData, filePathToWrite);
        }

        public static string WriteWavDataToWavFile(Wav wavData, string filePathToWrite)
        {
            return "";
            //FileStream wavDataStream = new FileStream(filePathToWrite, FileMode.Create, FileAccess.Write);

            //BinaryWriter binaryWriter = new BinaryWriter(wavDataStream);

            //binaryWriter.Write(wavData.Header.RiffChunkDescriptor);
            //binaryWriter.Write(wavData.Header.Length);
            //binaryWriter.Write(wavData.Header.FormatSubChunk);
            //binaryWriter.Write((int)16);
            //binaryWriter.Write((short)1);
            //binaryWriter.Write(wavData.Header.Channels);
            //binaryWriter.Write(wavData.Header.SampleRate);
            //binaryWriter.Write((int)(wavData.Header.SampleRate * ((wavData.Header.BitsPerSample * wavData.Header.Channels) / 8)));
            //binaryWriter.Write((short)((wavData.Header.BitsPerSample * wavData.Header.Channels) / 8));
            //binaryWriter.Write(wavData.Header.BitsPerSample);
            //binaryWriter.Write(wavData.Header.DataSubChunk);
            //binaryWriter.Write(wavData.Header.DataLength);

            //wavDataStream.Close();
            //binaryWriter.Close();

            //return filePathToWrite;

        }

        public static void ConvertWavToMp3(byte[] wavFile)
        {

            using (var retMs = new MemoryStream())
            using (var ms = new MemoryStream(wavFile))
            using (var rdr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
            {
                rdr.CopyTo(wtr);
                var byteArray = retMs.ToArray();

                File.WriteAllBytes(@"C:\users\codas\desktop\test\newnew.mp3", byteArray);
            }

        }

        private static Wav CreateWavData(Stream stream)
        {
            ////Read filestream into binary reader
            //var binaryReader = new BinaryReader(stream);

            //// set length for header
            //var length = (int)stream.Length - 8;
            //stream.Position = 22;

            //// set number of channels
            //var channels = binaryReader.ReadInt16();
            //stream.Position = 24;

            //// set sample rate
            //var samplerate = binaryReader.ReadInt32();
            //stream.Position = 34;

            //// set bits per sample
            //var bitsPerSample = binaryReader.ReadInt16();

            //// set data lenth
            //var dataLength = (int)stream.Length - 44;

            //// close stream and reader
            //binaryReader.Close();
            //stream.Close();


            //// create wave file with header
            //return new Wav
            //{
            //    File = stream,

            //    Header = new Header
            //    {
            //        Length = length,
            //        BitsPerSample = bitsPerSample,
            //        Channels = channels,
            //        DataLength = dataLength,
            //        SampleRate = samplerate,
            //    }
            //};
            return new Wav();
        }
    }
}
