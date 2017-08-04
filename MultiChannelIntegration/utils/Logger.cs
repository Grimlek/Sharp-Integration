using System;
using System.IO;
using System.Text;


namespace MultiChannelIntegration
{
    class Logger
    {
        private static Logger instance = null;
        private static readonly object padlock = new object();
        private static StringBuilder Sb = new StringBuilder();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }


        public void Log(string logMessage, Status status)
        {
            if (status == Status.ERROR)
            {
                WriteError(logMessage);
            }
            else if (status == Status.INFO) {
                WriteInfo(logMessage);
            }
            else if (status == Status.DEBUG)
            {
                WriteDebug(logMessage);
            }
        }

        public void DumpLog()
        {
            System.IO.Directory.CreateDirectory("C:\\Temp");
            using (StreamWriter writer = File.AppendText("C:\\Temp\\Multi_Channel_Integration_Log.txt"))
            {
                Console.WriteLine(Sb.ToString());
                writer.Write(Sb.ToString());
            }
        }

        private void WriteError(string logMessage)
        {
            Sb.Append("\r\n\r\n ERROR Entry : ")
                .Append(DateTime.Now.ToLongTimeString())
                .Append("\r\n")
                .Append(logMessage)
                .Append("-------------------------------\r\n");
        }

        private void WriteInfo(string logMessage)
        {
            Sb.Append("\r\n INFO Entry : ")
                .Append(DateTime.Now.ToLongTimeString())
                .Append(" --------- ")
                .Append(logMessage);
        }

        private void WriteDebug(string logMessage)
        {
            Sb.Append("\r\n DEBUG Entry : ")
                .Append(logMessage)
                .Append("\r\n\r\n");
        }
    }
}
