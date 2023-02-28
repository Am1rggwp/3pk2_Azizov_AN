using PZ_3;

BinaryTree tree = new BinaryTree(5);

double average = tree.AverageArif();
Console.WriteLine($"\nЗадание 1\nСреднее арифметическое значение : {average}");

int positiveCount = tree.Positiv(tree.Root);
int negativeCount = tree.Negative(tree.Root);
Console.WriteLine($"\nЗдаание 2\nКоличество позитивных узлов: {positiveCount}");
Console.WriteLine($"Количество нешативных узлов: {negativeCount}");

int count = tree.IdenticalNodes(tree.Root);
Console.WriteLine("Nodes count with value " + value + ": " + count);

