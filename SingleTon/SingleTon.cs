using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SingleTonLib
{
    public class SingleTon
    {
        private static SingleTon? instance = null;
        public string _path;
        public string _conf_path = "";
        public string _file_path = "";
        private SingleTon(string path) 
        {
            _path = path;
            _conf_path = path + @"\config.json";
            _file_path = path + @"\info.json";
            serializeconf(0);
        }
        public void serializeconf(uint offset)
        {
            var dc = new DataClass(_path + @"\info.json",offset);
            using (StreamWriter sw = new StreamWriter(_conf_path))
            {
                var res = JsonSerializer.Serialize<DataClass>(dc);
                sw.WriteLine(res);
                sw.Close();
            }
        }

        public uint Deserializeconf()
        {
            DataClass dc;
            using (StreamReader sw = new StreamReader(_conf_path))
            {
                var res = sw.ReadLine();
                dc = JsonSerializer.Deserialize<DataClass>(res!);
                sw.Close();
            }
            return dc.Offset;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static SingleTon GetInstance(string path)
        {
            if (instance == null)
            {
                DataClass? a = null;
                try 
                { 
                    if (File.Exists(path + @"\config.json"))
                        using (StreamReader sr = new StreamReader(path + @"\config.json"))
                        {
                            var rl = sr.ReadToEnd();
                            a = JsonSerializer.Deserialize<DataClass?>(rl!,JsonSerializerOptions.Default);
                            sr.Close();
                        }
                }
                catch { }
                instance = new SingleTon(path);
            }
            return instance;
        }
    }
}