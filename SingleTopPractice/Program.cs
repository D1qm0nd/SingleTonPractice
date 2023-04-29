using ProducerLib;
using SingleTonLib;

namespace Practice;
public class Program
{
    public static void Main()
    {
        string path = @"C:\Users\Max\source\repos\Practice_CS1\SingleTopPractice\CommonFile";

        SingleTon singleTon = SingleTon.GetInstance(path);
        Producer prod = new Producer(singleTon._path, singleTon);
        prod.GoProduce(singleTon);
    }
}