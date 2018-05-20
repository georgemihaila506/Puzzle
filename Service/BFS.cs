using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Domain;
using Lab1AI.Repository;

namespace Lab1AI.Service
{
    class BFS : UninformedSearchMethod
    {
        RepoPuzzle repoPuzzle;
        public BFS(RepoPuzzle repoPuzzle)
        {
            this.repoPuzzle = repoPuzzle;
        }
        public override List<Puzzle> search(Puzzle puzzle)
        {
            NTree<Puzzle> tree = new NTree<Puzzle>(puzzle, repoPuzzle.construireTree(puzzle));         
            var allVisited = new List<Puzzle>();
            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(tree.root);
            foreach (var aux in tree.root.Childrens)
                q.Enqueue(aux);
            int i = 0;
            while (q.Count() != 0)
            {
                i++;
                Node<Puzzle> temp = q.Peek();
                q.Dequeue();
                allVisited.Add(temp.Value);
                if (repoPuzzle.isGoal(temp.Value))
                {                 
                    return allVisited;
                }
                NTree<Puzzle>[] noduri = repoPuzzle.construireTree(temp.Value);
                //foreach (var va1 in temp.Childrens)
                    //q.Enqueue(va1);
                if (noduri != null)
                {
                    NTree<Puzzle> temporar = new NTree<Puzzle>(temp.Value, noduri);
                    temp.Childrens = temporar.root.Childrens;
                    foreach (var aux in temporar.root.Childrens)
                    {
                        q.Enqueue(aux);
                    }
                }
                



            }
            tree.TraverseDFS();
            Console.WriteLine("\n");
            Console.WriteLine(i);
            return null;
        }
        public override List<Puzzle> searchFromAnInstance(Puzzle puzzle)
        {
            var visited = new List<Puzzle>();
            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(repoPuzzle.insert().root);
            while (q.Count != 0)
            {
                var nod = q.Dequeue();
                visited.Add(nod.Value);
                if (repoPuzzle.isGoal(nod.Value))
                {
                    return visited;
                }
                foreach (var el in nod.Childrens)
                    q.Enqueue(el);
            }
            return null;
        }
    }
    
}
