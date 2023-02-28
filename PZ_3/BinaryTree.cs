using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_3
{
    internal class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree(int n)
        {
            Root = CreateBalancedTree(n);
        }

        public Node CreateBalancedTree(int n) // Методо куда мы будем вводить вершины
        {
            int text; 
            Node root;

            if (n == 0) //проверка если мы введем 0
                root = null;
            else
            {
                Console.WriteLine("Введите узел древа () >>");
                text = Convert.ToInt32(Console.ReadLine()); //Вводим 5 вершин 

                root = new Node(text); //помещаем наши введенные узлы в объект root для состовления сбалансированного древа
                root.Left = CreateBalancedTree(n / 2); // слевой стороны долшно быть меньше
                root.Right = CreateBalancedTree(n - n / 2 - 1); // справой должно быть больше взвисимости от родителя
            }

            return root;
        }
        //1 задание идет подчет суммы и потом количество вершин а далее последний метод который считает среднее арифметическое 
        public int CountNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            return CountNodes(root.Left) + 1 + CountNodes(root.Right);//метод вызывает себя рекурсивно для левого и правого поддеревьев root,
                                                                      //и добавляет 1 к результату каждого рекурсивного вызова, чтобы
                                                                      //учесть текущий узел root.
                                                                      //Результатом работы метода является общее количество узлов в дереве.
        }

        public int SumNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            return SumNodes(root.Left) + root.Info + SumNodes(root.Right);//так же как и сверху только не 1 а root.Info
                                                                          //и результат сумма значений всех узлов в дереве,
                                                                          //начиная с заданного корневого узла

        }

        public double AverageArif()
        {
            int count = CountNodes(Root);//Метод вычисляет среднее арифметическое число и передает данные переменным
                                         //cont количество узлов а sum сумму узлов и делит и возвращает в метод
            int sum = SumNodes(Root);
            if (count == 0)
            {
                return 0;
            }
            return (double)sum / count;
            
        }
        //Задание 2
        public int Positiv(Node root)//метод подсчитывает количество положительных значений в заданном двоичном дереве,
                                     //начиная с корневого узла root
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Info > 0)// Если положительный узел то,
                              // метод добавляет 1 к результату каждого рекурсивного вызова,
                              // чтобы учесть текущий узел и продолжает обход поддеревьев.
                              // Если узел отрицательный или равно нулю, метод продолжает обход поддеревьев
                              // без добавления текущего узла к результату.
            {
                return Positiv(root.Left) + 1 + Positiv(root.Right);
            }
            else
            {
                return Positiv(root.Left) + Positiv(root.Right);
            }
        }

        public int Negative(Node root) // так же как и спозитивныйм но наоборот 
        {
            if (root == null)
            {
                return 0;
            }
            if (root.Info < 0)
            {
                return Negative(root.Left) + 1 + Negative(root.Right);
            }
            else
            {
                return Negative(root.Left) + Negative(root.Right);
            }
        }
        // задание 3  сам метод готов но вывести как пока не дадумался если вы это читаете значит я не успел сделать 
        public int IdenticalNodes(Node root, int value)
        {
            if (root == null)
            {
                return 0;
            }
            int count = 0;
            if (root.Info == value)
            {
                count++;
            }
            count += IdenticalNodes(root.Left, value);
            count += IdenticalNodes(root.Right, value);
            return count;

        }



    }
}
