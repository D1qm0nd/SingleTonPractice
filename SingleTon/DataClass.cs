using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonLib
{
    [Serializable]
    internal class DataClass
    {
        public string FilePath { get; set; }
        public uint Offset { get; set; } 

        public DataClass(string path, uint offset)
        {
            FilePath = path;
            Offset = offset;
        }

        public DataClass()
        {
            FilePath = "";
            Offset= 0;
        }
    }
}
