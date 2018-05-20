using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1AI.Domain
{
    public class Pair<T, U>
    {
        private T first;
        private U second;
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.first = first;
            this.second = second;
        }

        public T First { get => first; set => first = value; }
        public U Second { get => second; set => second = value; }
        public
           override string ToString()
        {
            return First+";"+Second;
        }
    };
    class Puzzle
    {
        private List<List<int>> puzzle;
        private Pair<int,int> indexE;
        public Puzzle(List<List<int>> puzzle, Pair<int, int> indexE)
        {
            this.puzzle = puzzle;
            this.indexE = indexE;
        }

        public List<List<int>> PuzzleM { get => puzzle; set => puzzle = value; }
        public Pair<int, int> IndexE { get => indexE; set => indexE = value; }
        public
            override string ToString()
        {
            foreach (var l in puzzle)
            {
                foreach (var c in l)
                    Console.Write(c);
                Console.WriteLine();
            }
            return "\n";
        }
        public List<List<int>> generateCopy()
        {
            List<List<int>> copie = puzzle.Select(x => x.ToList()).ToList();
            return copie;
        }
        public List<List<int>> generateCopy1()
        {
            List<List<int>> copie = new List<List<int>>();
            
            foreach (List<int> lista in puzzle)
            {
                //           rez.Clear(); 
                List<int> rez = new List<int>();
                foreach (int el in lista)
                {
                    rez.Add(el);
                }
                copie.Add(rez);
            }
            return copie;
        }
    }
}
