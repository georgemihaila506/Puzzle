using Lab1AI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1AI.Repository
{
    class RepoPuzzle
    {
        public NTree<Puzzle> tree;
        //public Dictionary<Tuple<int, int>, List<Puzzle>> added = new Dictionary<Tuple<int, int>, List<Puzzle>>();
        public Dictionary<Tuple<int, int>, Dictionary<int,List<Puzzle>>> added = new Dictionary<Tuple<int, int>, Dictionary<int,List<Puzzle>>>();
        //private List<Puzzle> allAdded = new List<Puzzle>();
        private Puzzle puz;
        private Puzzle goal;
        public RepoPuzzle(Puzzle puzzle, Puzzle goal)
        {
            tree = new NTree<Puzzle>(puzzle);
            this.puz = puzzle;
            this.goal = goal;
            Tuple<int, int> tuple = new Tuple<int, int>(puzzle.IndexE.First, puzzle.IndexE.Second);
            Dictionary<int, List<Puzzle>> dictionary = new Dictionary<int, List<Puzzle>>();
            List<Puzzle> listPuz = new List<Puzzle>();
            listPuz.Add(puzzle);
            dictionary.Add(getSum(puzzle), listPuz);
            added.Add(tuple, dictionary);
        }
        private int getSum(Puzzle puzzle)
        {
            int s = 0;
            //s = puzzle.PuzzleM[puzzle.PuzzleM.Count - 1][0]+ puzzle.PuzzleM[0][puzzle.PuzzleM.Count - 1];
           // s = puzzle.PuzzleM.Count * (puzzle.PuzzleM.Count - 1);
            s = puzzle.IndexE.First + puzzle.IndexE.Second + puzzle.PuzzleM[0][0];
            return s;
        }
        private bool check(Puzzle puzzle)
        {
            Tuple<int, int> tuple = new Tuple<int, int>(puzzle.IndexE.First, puzzle.IndexE.Second);
            Dictionary<int, List<Puzzle>> dictionary = new Dictionary<int, List<Puzzle>>();        
            List<Puzzle> listPuz = new List<Puzzle>();
            int sum = getSum(puzzle);
            if (!added.ContainsKey(tuple))
            {
                listPuz.Add(puzzle);
                dictionary.Add(sum, listPuz);
                added.Add(tuple, dictionary);
                return false;
                
            }
            
            if (!added[tuple].ContainsKey(sum))
            {
                listPuz.Add(puzzle);
                added[tuple].Add(sum, listPuz);
                return false;
            }
            List<Puzzle> listOfPuzzles = added[tuple][sum];
            int size = puzzle.PuzzleM.Count * puzzle.PuzzleM.Count;
            int lineSize = puzzle.PuzzleM.Count;
            foreach (var auxPuzzle in listOfPuzzles)
            {
                int k = 0;
                for (int i=0;i<lineSize;i++)
                {
                    
                    for(int j=0;j<lineSize;j++)
                    {
                        if (auxPuzzle.PuzzleM[i][j] == puzzle.PuzzleM[i][j])
                        {
                            k++;
                        }
                    }
                    if (k == size)
                    {
                        return true;
                    }
                }
            }
            added[tuple][sum].Add(puzzle);
            return false;
        }
        public List<Puzzle> generateO(Puzzle puzzle)
        {
            List<Puzzle> deReturnat = new List<Puzzle>();
            //Orizontal
            //a)Orizontal stanga
            Puzzle copie = new Puzzle(puzzle.generateCopy(), puzzle.IndexE);
            Pair<int, int> indexS = new Pair<int, int>(copie.IndexE.First, copie.IndexE.Second);
            indexS.Second = indexS.Second - 1;
            if (indexS.Second >= 0)
            {
                int vaux = copie.PuzzleM[copie.IndexE.First][copie.IndexE.Second];
                copie.PuzzleM[copie.IndexE.First][copie.IndexE.Second] = copie.PuzzleM[indexS.First][indexS.Second];
                copie.PuzzleM[indexS.First][indexS.Second] = vaux;
                //Schimb de index
                copie.IndexE = indexS;
                if (check(copie) == false)
                {
                    deReturnat.Add(copie);
                }
            }
            //b)Orizontal dreapta
            Puzzle copieD = new Puzzle(puzzle.generateCopy(), puzzle.IndexE);
            Pair<int, int> indexD = new Pair<int, int>(copieD.IndexE.First, copieD.IndexE.Second);
            indexD.Second = indexD.Second + 1;
            if (indexD.Second < copieD.PuzzleM[0].Count)
            {
                int vaux = copieD.PuzzleM[copieD.IndexE.First][copieD.IndexE.Second];
                copieD.PuzzleM[copieD.IndexE.First][copieD.IndexE.Second] = copieD.PuzzleM[indexD.First][indexD.Second];
                copieD.PuzzleM[indexD.First][indexD.Second] = vaux;
                //Schimb de index
                copieD.IndexE = indexD;
                if (check(copieD) == false)
                {                
                    deReturnat.Add(copieD);
                }
            }   
            return deReturnat;
        }
        public  List<Puzzle> generateV(Puzzle puzzle)
        {
            List<Puzzle> deReturnat = new List<Puzzle>();
            //Vertical
            //a)Vertical sus
            Puzzle copie = new Puzzle(puzzle.generateCopy(), puzzle.IndexE);
            Pair<int, int> indexS = new Pair<int, int>(copie.IndexE.First, copie.IndexE.Second);
            indexS.First = indexS.First - 1;
            if (indexS.First >= 0)
            {
                int vaux = copie.PuzzleM[copie.IndexE.First][copie.IndexE.Second];
                copie.PuzzleM[copie.IndexE.First][copie.IndexE.Second] = copie.PuzzleM[indexS.First][indexS.Second];
                copie.PuzzleM[indexS.First][indexS.Second] = vaux;
                //Schimb de index
                copie.IndexE = indexS;
                if (check(copie) == false)
                {
                    
                    deReturnat.Add(copie);
                }
            }
            //b)Vertical jos
            Puzzle copieD = new Puzzle(puzzle.generateCopy(), puzzle.IndexE);
            Pair<int, int> indexD = new Pair<int, int>(copieD.IndexE.First, copieD.IndexE.Second);
            indexD.First = indexD.First + 1;
            if (indexD.First < copieD.PuzzleM.Count)
            {
                int vaux = copieD.PuzzleM[copieD.IndexE.First][copieD.IndexE.Second];
                copieD.PuzzleM[copieD.IndexE.First][copieD.IndexE.Second] = copieD.PuzzleM[indexD.First][indexD.Second];
                copieD.PuzzleM[indexD.First][indexD.Second] = vaux;
                //Schimb de index
                copieD.IndexE = indexD;
                if (check(copieD) == false)
                {
                    deReturnat.Add(copieD);
                }
            }
            
            
            return deReturnat;

        }
        public int checkDiferences(Puzzle forCheck)
        {
            int d = 0;
            for (int i = 0; i < goal.PuzzleM.Count; i++)
            {
                for (int j = 0; j < goal.PuzzleM.Count; j++)
                {
                    if (goal.PuzzleM[i][j] == forCheck.PuzzleM[i][j])
                        d++;
                }
            }          
            return d;
        }
        public bool isGoal(Puzzle checkIfIsGoal)
        {
            int i = 0;
            int k = 0;
            int curent = 0;
            var matrice = checkIfIsGoal.PuzzleM;
            while (i < matrice.Count && curent==k)
            {
                int j = 0;
                while (j < matrice.Count&&curent==k)
                {
                    if (matrice[i][j] == goal.PuzzleM[i][j])
                    {
                        k++;
                    }
                    else
                    {
                        return false;
                    }
                    curent++;
                    j++;
                }
                i++;
            }
            return true;
        }
        public NTree<Puzzle>[] construireTree(Puzzle puz)
        {
            //allAdded.Add(puz);
            List<Puzzle> oriz = generateO(puz);
            List<Puzzle> vert = generateV(puz);
            //Console.WriteLine(oriz.Count+" "+vert.Count);
            if (oriz.Count == 0 && vert.Count == 0)
            {
                NTree<Puzzle>[] nTree1 = new NTree<Puzzle>[0];
                return null;
            }
            int c = 0;
            int size = oriz.Count + vert.Count;
            NTree<Puzzle>[] nTree = new NTree<Puzzle>[size];
            foreach (var e in oriz)
            {
                nTree[c] = new NTree<Puzzle>(e);
                c++;
            }
            foreach (var e in vert)
            {
                nTree[c] = new NTree<Puzzle>(e);
                c++;
            }
            return nTree;
        }
        
        public NTree<Puzzle> insert()
        {
            tree = new NTree<Puzzle>(puz, construireTree(puz));          
            Queue<Node<Puzzle>> q=new Queue<Node<Puzzle>>();
            q.Enqueue(tree.root);          
            while (q.Count() != 0)
            {
                Node<Puzzle> temp = q.Peek();
                q.Dequeue();
                //
                if (isGoal(temp.Value))
                {
                }
                NTree<Puzzle>[] noduri = construireTree(temp.Value);
                if (temp.ChildrensCount==0 && noduri.Count()!=0)
                {

                    if (noduri.Count() != 0)
                    {

                        //Console.WriteLine(allAdded.Count);
                        NTree<Puzzle> temporar = new NTree<Puzzle>(temp.Value, noduri);
                        temp.Childrens = temporar.root.Childrens;
                        foreach (var aux in temporar.root.Childrens)
                        {
                            q.Enqueue(aux);
                        }
                    }
                }
                //
                else
                {
                    foreach (var va1 in temp.Childrens)
                        q.Enqueue(va1);

                }

            }
            return tree;
        }
        public List<Puzzle> BFS()
        {
            tree = new NTree<Puzzle>(puz, construireTree(puz));
            List<Puzzle> allVisited = new List<Puzzle>();
            Queue<Node<Puzzle>> q = new Queue<Node<Puzzle>>();
            q.Enqueue(tree.root);
            while (q.Count() != 0)
            {
                Node<Puzzle> temp = q.Peek();
                q.Dequeue();
                //
                allVisited.Add(temp.Value);
                if (isGoal(temp.Value))
                {
                    return allVisited;
                }
                NTree<Puzzle>[] noduri = construireTree(temp.Value);
                if (temp.ChildrensCount == 0 && noduri.Count() != 0)
                {

                    if (noduri.Count() != 0)
                    {

                        //Console.WriteLine(allAdded.Count);
                        NTree<Puzzle> temporar = new NTree<Puzzle>(temp.Value, noduri);
                        temp.Childrens = temporar.root.Childrens;
                        foreach (var aux in temporar.root.Childrens)
                        {
                            q.Enqueue(aux);
                        }
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
    }
}
