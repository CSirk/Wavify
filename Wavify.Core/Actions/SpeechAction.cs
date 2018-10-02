using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Wavify.Core.Actions
{
    public class SpeechAction
    {
        public static void ConvertSpeechSynthPromptToMp3File(PromptBuilder prompt, string outputFileLocation, string voiceName = "", int volume = 100, int rate = 1)
        {
            var writeStream = new MemoryStream();
            var synth = new SpeechSynthesizer() { Volume = volume, Rate = rate };
            if(!String.IsNullOrEmpty(voiceName))
            {
                synth.SelectVoice(voiceName);
            }
            synth.SetOutputToWaveStream(writeStream);
            synth.Speak(prompt);
            byte[] synthContentArray = writeStream.ToArray();
            WaveAction.ConvertWaveStreamToMp3File(synthContentArray, outputFileLocation);
        }
    }
}
