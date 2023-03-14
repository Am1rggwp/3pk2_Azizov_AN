using PZ_5;
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nICloneable\n ");
        //ICloneable
        DateTime birthday = new DateTime(1999, 08, 25, 0, 0, 0);
        DateTime birthday1 = new DateTime(2004, 04, 07, 0, 0, 0);

        var original = new Human("Felex", 23, birthday, new Car("Таёта"));
        Console.WriteLine(original);

        var clone = (Human)original.Clone();

        clone.Age = 32;
        clone.name_car.Name = "Мазда";
        Console.WriteLine("\n" + clone);

        Console.WriteLine("\nIComparable\n ");
        //IComparable
        var Human34 = new Human2("Олег", 50, "Разработка мобилки");
        var Human24 = new Human2("Сергей", 1990, "Видео монтаж");
        var Human14 = new Human2("Амир", 999999, "Директор ОКЭИ");

        Human2[] works_name = { Human34, Human24, Human14 };
        Array.Sort(works_name);
        foreach (Human2 human2 in works_name)
        {
          Console.WriteLine($"У человека {human2.Name} на кошелке: {human2.Money} и он работает на{human2.Work}");
            
        }


        Console.ReadLine();
    }
}