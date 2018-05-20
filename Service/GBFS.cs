using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Domain;
using Lab1AI.Repository;

namespace Lab1AI.Service
{
    class GBFS : InformedSearchMethod
    {
        private RepoPuzzle repoPuzzle;
        public GBFS(RepoPuzzle repoPuzzle)
        {
            this.repoPuzzle = repoPuzzle;
        }
        public override List<Puzzle> search(Puzzle puzzle)
        {
            NTree<Puzzle> tree = new NTree<Puzzle>(puzzle, repoPuzzle.construireTree(puzzle));
            var allVisited = new List<Puzzle>();
            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(tree.root);
            while (q.Count() != 0)
            {
                Node<Puzzle> temp = q.Peek();
                Node<Puzzle> node = null;
                int dife = 0;
                q.Dequeue();
                //
                allVisited.Add(temp.Value);
                if (repoPuzzle.isGoal(temp.Value))
                {
                    return allVisited;
                }
                NTree<Puzzle>[] noduri = repoPuzzle.construireTree(temp.Value);
                if (temp.ChildrensCount == 0 && noduri.Count() != 0)
                {
                    if (noduri.Count() != 0)
                    {
                        NTree<Puzzle> temporar = new NTree<Puzzle>(temp.Value, noduri);
                        temp.Childrens = temporar.root.Childrens;
                        foreach (var el in temporar.root.Childrens)
                        {
                            int auxD = repoPuzzle.checkDiferences(el.Value);
                            auxD = auxD + el.ChildrensCount;
                            if (auxD > dife)
                            {
                                node = el;
                                dife = auxD;
                            }                     
                        }
                        if (node != null)
                            q.Enqueue(node);
                    }
                }
                //
                else
                {
                    foreach (var va1 in temp.Childrens)
                        q.Enqueue(va1);

                }

            }
            return null;
        }

        public override List<Puzzle> searchFromAnInstance(Puzzle puzzle)
        {
            var visited = new List<Puzzle>();
            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(repoPuzzle.insert().root);
            while (q.Count != 0)
            {
                Node<Puzzle> node = null;
                int dife = 0;
                var nod = q.Dequeue();
                visited.Add(nod.Value);
                if (repoPuzzle.isGoal(nod.Value))
                {
                    return visited;
                }
                foreach (var el in nod.Childrens)
                {
                    int auxD = repoPuzzle.checkDiferences(el.Value);
                    auxD = auxD + el.ChildrensCount;
                    if (auxD > dife)
                    {
                        Console.WriteLine(auxD);
                        node = el;
                        dife = auxD;
                    }
                }
                if (node != null)
                    q.Enqueue(node);
            }
            return visited;
        }
    }
}
