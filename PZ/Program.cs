using System.Collections;
using System.Diagnostics;
internal class Program
{
    internal class Timing
    {
        TimeSpan duration;//хранение результата измерения
        TimeSpan[] threads;// значения времени для всех потоков процесса
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().Threads.Count];
        }
        public void StartTime()//инициализация массива threads после вызова сборщика мусора
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime()//повторный запрос текущего времени и выбирается тот, у которого результат отличается от
                              //предыдущего
        {
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    static int SimpleSerch(int[] a, int x)// создоем метод для прямого поиска
    {
        int i = 0;
        // проверка за выход массива за границу
        while (i < a.Length && a[i] != x)
            i++;
        if (i < a.Length)
        {
            //если найден, возрощаем индекс 
            return i;
        }
        else
        {
            //если не нашел 
            return -1;
        }
    }
    static int SearchBinary(int[] a, int x)//создоем метод для бинарного поиска
    {
        int middle, left = 0, right = a.Length - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Length)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((a[middle] != x) && (left <= right));
        if (a[middle] == x)
            return middle;

        else
            return -1;
    }


    static int SimpleSearch_list(List<int> a, int x)// создаем метод для списака прямого поиска
    {
        int i = 0;
        while (i < a.Count && a[i] != x) i++;
        if (i < a.Count)
        {
            return i;
        }
        else
        {
            return -1;
        }
    }
    static int SearchBinary_list(List<int> a, int x)// создаем метод для списака бинарного поиска
    {
        int middle, left = 0, right = a.Count - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Count)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((a[middle] != x) && (left <= right));
        if (a[middle] == x)
            return middle;

        else
            return -1;
    }


    static int SimpleSearch_hash(Hashtable a, int x)//создаем метод для хэш таблиц прямого поиска
    {
        int i = 0;
        while (i < a.Count && Convert.ToInt32(a[i]) != x) i++;
        if (i < a.Count)
        {
            return i;
        }
        else
        {
            return -1;
        }
    }
    static int SearchBinary_hash(Hashtable a, int x)//создаем метод для хэш таблиц бинарного поиска
    {
        int middle, left = 0, right = a.Count - 1;
        do
        {
            middle = (left + right) / 2;
            if (x > a.Count)
                left = middle + 1;
            else
                right = middle - 1;
        }
        while ((Convert.ToInt32(a[middle]) != x) && (left <= right));
        if (Convert.ToInt32(a[middle]) == x)
            return middle;

        else
            return -1;
    }
    private static void Main(string[] args)
    {
        int a = -1; // переменные которые нужны для записи поиска
        int b = -1;
        Random rand = new Random();
        int[] array = new int[7560];
        for (int num = 0; num < array.Length; num++)
        {
            array[num] = rand.Next(1, 4315);

        }
        List<int> list = new List<int>(7560);
        for (int j = 0; j < 5000; j++)
        {
            list.Add(rand.Next(1, 4315));
        }

        Hashtable hash = new Hashtable();

        for (int i = 0; i < 7560; i++)
        {
            hash.Add(i, rand.Next(1, 4315));
        }

        Stopwatch stpWatch = new Stopwatch();
        Timing timing = new Timing();
        stpWatch.Start();


        Console.WriteLine("Поиск по массивам\n");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSerch(array, 56); // переменная где вызывается метод и подстоаляет свои параметры в скобках

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SearchBinary(array, 56);
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");
        //Вывод: Stopwatch прямым способом ищет быстрее нежели чем бинарным
        //Timing почемуто работает через раз поэтому может быть или не быть результата


        Console.WriteLine("Поиск по спискам\n");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSearch_list(list, 56);

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SearchBinary_list(list, 56);
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");
        //Вывод поиск бинарном способом в списках будет производится быстрее
        //Timing выдает такой же результат что и при поиске с масивами

        Console.WriteLine("Поиск по хэш таблицам\n");

        stpWatch.Start();
        timing.StartTime();

        a = SimpleSearch_hash(hash, 56);

        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск прямым способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();
        stpWatch.Start();
        timing.StartTime();

        b = SimpleSearch_hash(hash, 56); ;
        stpWatch.Stop();
        timing.StopTime();

        Console.WriteLine("Поиск бинарным способом: " + $"Stopwatch: {stpWatch.Elapsed} " + $"Timing: {timing.Result()}");
        stpWatch.Reset();

        Console.WriteLine(" ");
        //Вывод поиск бинарном способом в хэш таблицах будет производится быстрее
        //Timing выдает такой же результат что и при поиске с масивами






    }
}



