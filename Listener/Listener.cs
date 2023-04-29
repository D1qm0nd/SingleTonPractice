using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PublicationsLib;
using SingleTonLib;

namespace ListenerNameSpace
{
    public class Listener
    {
        public string _Path { get; set; }
        public SingleTon _SingleTon { get; set; }
        public Listener(string path, SingleTon singleTon)
        {
            _Path = path;
            _SingleTon = singleTon;
        }

        public void GoListen(SingleTon singleTon)
        {
            while (true)
            {
                try
                {
                    var offset = singleTon.Deserializeconf();
                    string JsonLine = File.ReadLines(singleTon._file_path).Skip((int)offset).First();
                    JsonSerializer.Deserialize<Publication>(JsonLine, JsonSerializerOptions.Default).Show();
                    Thread.Sleep(5000);
                }
                catch { }
            }
        }
    }
}
