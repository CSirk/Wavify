using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavify.Core.Actions;
using Wavify.Core.Models;

namespace Wavify
{
    public class WaveConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Wave ConvertStreamToWaveData(Stream stream)
        {
            return WaveAction.ConvertFromStreamToWave(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Wave ConvertWaveFileToWavData(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return WaveAction.ConvertFromStreamToWave(fileStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="filePathToWrite"></param>
        /// <returns></returns>
        public static string ConvertWavDataToWavFile(Wave wave, string filePathToWrite = "")
        {
            filePathToWrite = (filePathToWrite == "") ? Environment.CurrentDirectory : filePathToWrite;

            return WaveAction.WriteWaveDataToWaveFile(wave, filePathToWrite);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wave1"></param>
        /// <param name="wave2"></param>
        /// <returns></returns>
        public static Wave MergeWavs(Wave wave1, Wave wave2)
        {
            return new Wave();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveFile"></param>
        /// <param name="outputFileLocation"></param>
        public static void ConvertWaveAsBytesToMp3File(byte[] waveFile, string outputFileLocation)
        {
            WaveAction.ConvertWaveStreamToMp3File(waveFile, outputFileLocation);
            //SpeechAction.ConvertWaveStreamToMp3(waveFile, outputFileLocation);
        }
    }
}
