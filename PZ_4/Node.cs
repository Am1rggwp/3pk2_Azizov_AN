using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_4
{
    internal class Node
    {
        public class DTreeNode // Класс «Узел дихотомического дерева»
        {
            private char info; // информационное поле
            private int key; // поле ключа
            private DTreeNode left; // ссылка на левое поддерево
            private DTreeNode right; // ссылка на правое поддерево
            public char Info { get; set; } // свойства
            public int Key { get; set; }
            public DTreeNode Left { get; set; }
            public DTreeNode Right { get; set; }
            public DTreeNode() { } // конструкторы
            public DTreeNode(char info, int key)
            {
                Info = info; Key = key;
            }


            public DTreeNode(char info, int key, DTreeNode left, DTreeNode right)
            {
                Info = info; Key = key; Left = left; Right = right;
            }

        }
    }
}
