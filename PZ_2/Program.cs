using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_2
{
    class Program
    {
        public class Graph
        {
            //Задание 1) Определить является ли данный граф связным

            public int Size { get; set; }
            public bool[,] Adjacency { get; set; }
            public bool[] Vector { get; set; }



            public Graph(int size, bool[,] G) // конструктор класса «Графы»
            {
                Adjacency = new bool[size, size]; // инициализация матрицы смежности
                Adjacency = G;
                Vector = new bool[size];
                for (int i = 0; i < size; i++)
                    Vector[i] = false; // иниц-я вектора посещенных вершин
                Size = size;
            }
            public void Depth(int i) //i – вершина, с которой начинается обход
            {
                Vector[i] = true; // отметить вершину i как обработанную

                Console.Write(" {0}" + ' ', i); // распечатать номер посещенной вершины
                for (int k = 0; k < Size; k++) // найти первую встретившуюся ранее
                                               // непосещенную вершину k, смежную с вершиной i
                    if (Adjacency[i, k] && !(Vector[k]))
                        Depth(k); // перейти к обработке вершины k


            }
            static void Main(string[] args)
            {
                bool[,] M = new bool[5, 5]
                {
                    {false, true, true, false,false}, // матрица смежности графа G5
                    {false, false, false, true,false},
                    {false, true, false, false,true},
                    {false, false, true, false,false},
                    {false,false,false,true,false}
                };
                Console.Write("Вершины по которым прошли:");



                Graph graph = new Graph(5, M);
                graph.Depth(0);// Вершина скоторой начинаем, а имеенно 0 нашей первый вершины поскольку к ней мы потом не сможем попасть

                bool allvershin = true; // Создаем булевую переменную все вершины
                for (int i = 0; i < graph.Size; i++)// проверяем метод граф прошел все вершины 
                {
                    if (!graph.Vector[i])// если вершин не хватает то наша булевая переменная становится ложной и наче прерывается условие и переменная не меняется на ложную

                    {
                        allvershin = false;
                        break;
                    }

                }

                if (allvershin)// если она так и осталось истиной что выводит сообщение иначе другое сообщение 
                    Console.WriteLine("- Граф связный.");
                else
                    Console.WriteLine("- Граф не связный.");

                Console.ReadLine();
            
            
            
            
            
            
            
            
            }

        }
    }
}