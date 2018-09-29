using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavify.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileAsByteArray = File.ReadAllBytes(@"C:\users\codas\desktop\test\db.wav");

            WavConvert.ConvertWavToMp3(fileAsByteArray);
        }
    }
}
