using PZ_4;
using static PZ_4.Node;

internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        DTreeNode root = null;
        //Задание 1
        for (int i = 0; i < 10; i++)
        {
            int key = random.Next(-1000, 1001);
            root = SearchTree.Insert(root, (char)('A' + i), key);
            
        }

        Console.WriteLine("Задание 1\nСумма значений дерева: " + SearchTree.Sum(root));

        //Задание 2
        Console.WriteLine("\nЗадание 2\nКоличество внутренних узлов дерева: " + SearchTree.CountInternalNodes(root)+ "\n \nЗадание 3");
        

        //Задание 3 
        List<int> negativeValues = SearchTree.GetNegativeValues(root);
        Console.WriteLine("\nОтрицательные значения информационных полей дерева:"+ negativeValues.Count);
        foreach (var value in negativeValues)
        {
            Console.Write($"{value}, ");
        }
        Console.ReadLine();


    }
}