﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavify.Core.Actions;
using Wavify.Core.Models;

namespace Wavify
{
    public class Wavify
    {
        /// <summary>
        /// Converts a stream to a Wav object
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Wav object representation of stream</returns>
        public Wav ConvertStreamToWavData(Stream stream)
        {
            return WavAction.ConvertFromStreamToWav(stream);
        }

        /// <summary>
        /// Converts .wav file at the given path to a Wav object
        /// </summary>
        /// <param name="FilePath">The path of the .wav file to read from</param>
        /// <returns>Wav object representation of file contents</returns>
        public Wav ConvertWavFileToWavData(string FilePath)
        {
            return new Wav();
        }

        /// <summary>
        /// Converts a given Wav object to a .wav file at the optional path
        /// </summary>
        /// <param name="wav">The Wav object to create a .wav file from</param>
        /// <param name="filePathToWrite">The optional path to create the .wav file at. Defaults to current directory</param>
        /// <returns>Path to saved file</returns>
        public string ConvertWavDataToWavFile(Wav wav, string filePathToWrite = "")
        {
            return "";
        }

        /// <summary>
        /// Merge two Wav objects together forming a new wav object.
        /// </summary>
        /// <param name="wav1">Base Wav object to append second Wav object to</param>
        /// <param name="wav2">Additional Wav object which is appended to base Wav object</param>
        /// <returns>Wav object concatination of wav2 onto the end of wav1</returns>
        public Wav MergeWavs(Wav wav1, Wav wav2)
        {
            return new Wav();
        }
    }
}
