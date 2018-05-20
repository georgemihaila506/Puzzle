using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1AI.Domain
{
    class Node<T>
    {
        private T value;
        private bool hasParent;
        private List<Node<T>> childrens;
        public Node()
        {
            this.childrens = new List<Node<T>>();
        }
        public Node(T val)
        {
            //if (val == null)
              //  throw new ArgumentNullException("Cannot insert null value!");
            this.Value = val;
            this.childrens = new List<Node<T>>();
        }
        public int ChildrensCount
        {
            get { return this.childrens.Count; }
        }
        public T Value { get => value; set => this.value = value; }
        public List<Node<T>> Childrens { get => childrens; set => childrens = value; }
        public void addChild(Node<T> child)
        {
            if (child == null)
            {
                Console.WriteLine("Am");
                //throw new ArgumentNullException("Cannot insert null value!");
                return;
            }
            if (child.hasParent)
                throw new ArgumentException("The node already has a parent!");
            child.hasParent = true;
            this.childrens.Add(child);
        }
        public Node<T> getChild(int index)
        {
            return this.childrens[index];
        }
    }
}
