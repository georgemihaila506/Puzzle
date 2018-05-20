using Lab1AI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1AI.Repository
{
    class NTree<T>
    {
        public  Node<T> root;
        int size = 0;
        public NTree(T value)
        {
            if (value == null)
                throw new ArgumentNullException("Cannot insert null value!");

            this.Root = new Node<T>(value);
        }
        public NTree(T value, params NTree<T>[] children):this(value)
        {
            //root.Value = value;
            foreach (NTree<T> child in children)
                this.Root.addChild(child.Root);
        }
        private void PrintDFS(Node<T> root, string spaces)
        {
            if (this.root == null)
                return;
            Console.WriteLine(spaces+root.Value);
            Node<T> child = null;
            for (int i = 0; i < root.ChildrensCount; i++)
            {
                child = root.getChild(i);
                PrintDFS(child, spaces+"F");
                size++;
            }
        }
        public void TraverseDFS()
        {
            this.PrintDFS(root, "   ");
        }

        public  Node<T> Root { get => root; set => root = value; }
    }
}
