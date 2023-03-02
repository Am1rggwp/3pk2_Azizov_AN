using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PZ_4.Node;

namespace PZ_4
{
    internal class SearchTree
    {
        //Задание 1
        public static DTreeNode Insert(DTreeNode node, char info, int key)//Метод вставки нового узла в двоичное дерево поиска.
        {
            if (node == null)
                return new DTreeNode(info, key);
            else if (key < node.Key)
                node.Left = Insert(node.Left, info, key);
            else
                node.Right = Insert(node.Right, info, key);
            return node;
        }

        public static int Sum(DTreeNode node)
        {
            if (node == null)
                return 0;
            return node.Key + Sum(node.Left) + Sum(node.Right);//сумма ключа текущего узла
        }
        //Задание 2
        public static int CountInternalNodes(DTreeNode node)
        {
            if (node == null)
                return 0;
            else if (node.Left == null && node.Right == null) 
                return 0;
            else
                return 1 + CountInternalNodes(node.Left) + CountInternalNodes(node.Right);//текущий узел считается
                                                                                          //внутренним узлом, затем
                                                                                          //рекурсивно вызывается метод
                                                                                          //CountInternalNodes для левого
                                                                                          //и правого поддеревьев текущего
                                                                                          //узла и результаты суммируются.
        }
        //Задание 3
        public static List<int> GetNegativeValues(DTreeNode node) 
        {
            
            List<int> result = new List<int>(); // создаем пустой список для хранения отрицательных значений

            if (node == null)
                return result;
            
            
            if (node.Key < 0) // если значение информационного поля отрицательное, добавляем его в список
            {
                result.Add(node.Key);
                Console.WriteLine($"Узел: {node.Info}, Количество отрицательный: {result.Count}: {node.Key} ");

            }
            else
            {
                Console.WriteLine($"Узел: {node.Info}, Количество отрицательный: {result.Count}: {node.Key} ");
                
            }
            // обходим левое и правое поддеревья и добавляем в список все отрицательные значения
            
            result.AddRange(GetNegativeValues(node.Left));
            result.AddRange(GetNegativeValues(node.Right));

            return result;
        }

    }

}


