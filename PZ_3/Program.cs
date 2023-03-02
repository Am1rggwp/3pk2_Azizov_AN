using PZ_3;

BinaryTree tree = new BinaryTree(5);

double average = tree.AverageArif();
Console.WriteLine($"\nЗадание 1\nСреднее арифметическое значение : {average}");

int positiveCount = tree.Positiv(tree.Root);
int negativeCount = tree.Negative(tree.Root);
Console.WriteLine($"\nЗдаание 2\nКоличество позитивных узлов: {positiveCount}");
Console.WriteLine($"Количество нешативных узлов: {negativeCount}");

Console.Write("\nЗадание 3\nВведите число которое может повторятся:");
int val = Convert.ToInt32(Console.Read());
Console.WriteLine("Повторяющиеся узлы: " + val + ": " + tree.IdenticalNodes(tree.Root, val));

