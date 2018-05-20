using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Repository;
using Lab1AI.Domain;

namespace Lab1AI.Service
{
    class ServicePuzzle
    {
        private RepoPuzzle repo;
        public ServicePuzzle(RepoPuzzle repo)
        {
            this.repo = repo;
        }
        public List<Puzzle> BFS()
        {
            var visited = new List<Puzzle>(); 

            //if ()
            // return visited;

            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(repo.insert().root);
            while (q.Count!=0)
            {               
                var nod = q.Dequeue();
                visited.Add(nod.Value);
                if (repo.isGoal(nod.Value))
                {
                    return visited;
                }
                foreach (var el in nod.Childrens)
                    q.Enqueue(el);
            }
            return visited;
        }
        public List<Puzzle> GBFS()
        {
            var visited = new List<Puzzle>();          

            //if ()
            // return visited;

            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(repo.insert().root);
            while (q.Count != 0)
            {
                Node<Puzzle> node = null;
                int dife = 0;
                var nod = q.Dequeue();
                visited.Add(nod.Value);
                if (repo.isGoal(nod.Value))
                {
                    return visited;
                }
                foreach (var el in nod.Childrens)
                {
                    int auxD = repo.checkDiferences(el.Value);
                    auxD = auxD+el.ChildrensCount;
                    if (auxD > dife)
                    {
                        Console.WriteLine(auxD);
                        node = el;
                        dife = auxD;
                    }
                }
                if(node!=null)
                    q.Enqueue(node);
            }
            return visited;
        }
    }
}
