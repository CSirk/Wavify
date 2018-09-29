using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wavify.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var writeStream = new MemoryStream();

            var speechInfo = new SpeechAudioFormatInfo(8000, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);

            var synth = new SpeechSynthesizer() { Volume = 100, Rate = 1 };

            synth.SetOutputToWaveStream(writeStream);

            var prompt = new PromptBuilder();
            prompt.AppendText("The number of reps is");
            prompt.AppendBreak(new TimeSpan(0, 0, 2));
            prompt.AppendText("70 reps.");

            synth.Speak(prompt);
            var byteArray = writeStream.ToArray();

            WaveConvert.ConvertWaveAsBytesToMp3File(byteArray, "");
        }
    }
}
