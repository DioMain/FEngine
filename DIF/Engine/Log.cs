using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Log
    {
        public static Log? Instance { get; private set; }

        public const string LOGFILENAME = "ENGINE_LOG.log";

        public bool IsReady { get => Stream.BaseStream.CanWrite; }
        public bool DublicateToConsole { get; set; }

        private StreamWriter Stream;

        public Log()
        {
            Stream = new StreamWriter(LOGFILENAME);
            Stream.AutoFlush = true;

            DublicateToConsole = false;
        }

        public void Write(string Message)
        {
            Stream.Write(Message);

            if (DublicateToConsole) Console.Write(Message);
        }
        public void WriteLine(string Message)
        {
            Stream.WriteLine(Message);

            if (DublicateToConsole) Console.WriteLine(Message);
        }

        public static void SWrite(string Message) => Instance?.Write(Message);
        public static void SWriteLine(string Message) => Instance?.WriteLine(Message);

        public static void SetInstance(Log obj)
        {
            if (Instance == null) Instance = obj;
        }

        ~Log()
        {
            Stream.Dispose();
            Stream.Close();
        }
    }
}
