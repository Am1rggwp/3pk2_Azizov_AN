using System.Collections;
using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        Random rand = new Random();
        int[] array = new int[7560];
        for (int num = 0; num < array.Length; num++)
        {
            array[num] = rand.Next(4315);

        }
        Stopwatch stpWatch = new Stopwatch();
        stpWatch.Start();
            



        stpWatch.Stop();
        Console.WriteLine($"Поиск бинарным способом:\nStopWatch:{stpWatch.Elapsed.ToString()}");

        stpWatch.Restart();
        stpWatch.Start();

        //List<int> list = new List<int>(7560);
        //for (int num = 0; num < list.Count; num++)
        //{ 
        //    list[num] = rand.Next(4315);


        //}
        //Hashtable hash = new Hashtable(7560);
        //for (int num = 0; num < hash.Count; num++)
        //{
        //    int rand1 = rand.Next(4315);


        //    foreach (object key in hash.Keys)
        //        Console.WriteLine(key.ToString() + ":\t" + hash[key].ToString());
        //}
    }
}



