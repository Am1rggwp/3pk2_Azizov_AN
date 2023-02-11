using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            //Задание 2) метод Дейкстра
            class Dijkstra
            {
                static int[] DijkstraAlgorithm(int[,] graph1, int startNode)
                {
                    int n = graph1.GetLength(0); //создаем строку которая вычисляет количество узлов в графике, получая длину первого измерения матрицы смежности.
                    int[] distance = new int[n];//создаем массив "distance" для хранения минимальных расстояний от начального узла до всех остальных узлов графика
                    bool[] used = new bool[n]; //создаем массив "used" для отслеживания узлов, которые были обработаны.

                    for (int i = 0; i < n; i++)//Данный цикл инициализирует расстояния и статус "используется" для всех узлов
                    {
                        distance[i] = int.MaxValue;// устанавливает расстояние до каждого узла в большое значение, представляющее, что узел еще не был обработан.
                        used[i] = false;//устанавливает статус "используется" для каждого узла в значение false, что означает, что узел еще не был обработан
                    }

                    distance[startNode] = 0;//Устонавливается начальную вершину

                    for (int i = 0; i < n - 1; i++)//основной метод Дейкстра
                    {
                        int minDistance = int.MaxValue;//: строки инициализируют две переменные для хранения
                                                       //минимального расстояния и узла с минимальным расстоянием, который еще не был обработан.
                        int minNode = 0;

                        for (int j = 0; j < n; j++)
                        {
                            if (!used[j] && distance[j] < minDistance)// проверяет, не был ли узел "j" еще обработан и меньше ли его расстояние текущего минимального расстояния.
                            {
                                minDistance = distance[j];//Если оператор if имеет значение true, эти две строки обновляют минимальное расстояние и узел с минимальным расстоянием.
                                minNode = j;
                            }
                        }

                        used[minNode] = true;//устанавливает статус "используется" узла с минимальным расстоянием в true, указывая, что он был обработан.   

                        for (int j = 0; j < n; j++)
                        {
                            if (!used[j] && graph1[minNode, j] != 0 && distance[minNode] != int.MaxValue && distance[minNode] + graph1[minNode, j] < distance[j])// проверка, является ли узел "j" еще не обработан и если есть ребро между узлом с минимальным расстоянием и узлом "j".
                                                                                                                                                                 //Он также проверяет, не является ли расстояние до узла с минимальным расстоянием большим значением и если сумма расстояния до узла с минимальным расстоянием и веса ребра меньше текущего расстояния до узла "j"
                            {
                                distance[j] = distance[minNode] + graph1[minNode, j];//обновляет кратчайшее расстояние до узла j как сумму текущего кратчайшего расстояния до minNode и веса ребра между minNode и j
                            }
                        }
                    }

                    return distance; // после чего возврощанет значение
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


                    Console.WriteLine("Второе задание\n");
                    int[,] graph1 = new int[,] //Создание двухмерного массива с весом для поиска методом Дейкстра
                    {
                        { 0, 4, 0, 0, 4},
                        { 4, 0, 8, 0, 0},
                        { 0, 8, 0, 7, 0 },
                        { 0, 0, 7, 0, 9},
                        { 4, 0, 0, 9, 0 },
                    
                    };

                    int startNode = 0;// Начальная вершина через который начинается поиск 

                    int[] distance = DijkstraAlgorithm(graph1, startNode); //функция возвращает массив расстояний от каждого узла графика до начального узла.
                                                                           //Возвращаемый массив сохраняется в переменной distance.

                    Console.WriteLine("Вершина\t Расстояние от источника"); // вывод крайтяйщей суммы пути к вершине
                    for (int i = 0; i < distance.Length; i++)
                    {
                        Console.WriteLine("{0}\t\t {1}", i, distance[i]);
                    }

                    Console.ReadLine();



                }
            
            
            
            
            
            }

        }
    }
}