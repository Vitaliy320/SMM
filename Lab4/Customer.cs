using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Customer
    {
        private string message;

        const string path = @"C:\Users\Evgentus\Desktop\SmmLogs\messages\logs.csv";
        const string finalPath = @"C:\Users\Evgentus\Desktop\SmmLogs\finalMessages\finalLog.txt";

        static object locker = new object();


        public string Name { get; set; }

        static Customer()
        {
            using (File.Create(path)) { }
            using (File.Create(finalPath)) { }
        }

        public Customer(string name)
        {
            Name = name;
            message = $"{name}, ";
        }

        public void CreateMessage(string mes)
        {
            message += $"{mes}, ";
        }

        public void WriteToFile(string message)
        {
            lock (locker)
            {
                using(StreamWriter file = File.AppendText(path))
                {
                    var mes = $"{Name}, {message}";
                    file.WriteLine(mes);
                }
            }
        }

        public void WriteFinalMessage()
        {
            using (StreamWriter file = File.AppendText(finalPath))
            {
                message = message.Substring(0, message.Length - 2);
                file.WriteLine(message);
            }
        }
    }
}
