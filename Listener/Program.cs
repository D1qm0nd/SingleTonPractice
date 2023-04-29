using SingleTonLib;

namespace ListenerNameSpace
{
    public class Program
    {
        public static void Main()
        {
            string path = @"C:\Users\Max\source\repos\Practice_CS1\SingleTopPractice\CommonFile";
            SingleTon singleTon = SingleTon.GetInstance(path);
            Listener listener = new Listener(singleTon._path, singleTon);
            listener.GoListen(singleTon);
        }
    }
}