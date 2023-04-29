using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PublicationsLib;
using SingleTonLib;

namespace ProducerLib
{
    public class Producer
    {
        public string _Path { get; set; }

       
        public SingleTon _SingleTon { get; set; }
        public Producer(string path, SingleTon singleTon)
        {
            _Path = path;
            
            _SingleTon = singleTon;
        }

        public void GoProduce(SingleTon singleTon)
        {
            if (File.Exists(singleTon._file_path))
                File.Delete(singleTon._file_path);
            for (uint counter=0;  counter <= 100;counter++)
            {
                using (StreamWriter sr = new StreamWriter(singleTon._file_path,true))
                {
                    string newpub = JsonSerializer.Serialize<Publication>(new Publication($"Publication {counter}", $"Description {counter}", $"Author {counter}"), JsonSerializerOptions.Default);
                    sr.WriteLine(newpub);
                    sr.Close();
                    _SingleTon.serializeconf(counter);
                }
                Thread.Sleep(5000);
            }
        }

        public void RandomPublic() 
        {

        }
    }
}
