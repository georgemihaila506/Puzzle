using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Domain;
using Lab1AI.Repository;
using Lab1AI.Service;

namespace Lab1AI
{
    class Program
    {

        static void Main(string[] args)
        {
            List<List<int>> puz = new List<List<int>>();
            List<List<int>> puz2 = new List<List<int>>();
            List<List<int>> goalP2 = new List<List<int>>();
            /*
            int n = 3;
            Console.WriteLine("Initial");
            for (int i = 0; i < n; i++)
            {
                List<int> temp = new List<int>();
                Console.WriteLine("Linie");
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Da valoare ");
                    int val= int.Parse(Console.ReadLine());


                }
                puz2.Add(temp);
            }
            Console.WriteLine("Goal");
            for (int i = 0; i < n; i++)
            {
                List<int> temp = new List<int>();
                Console.WriteLine("Linie");
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Da valoare ");
                    int val = int.Parse(Console.ReadLine());


                }
                goalP2.Add(temp);
                Console.WriteLine("Goal");
                }
               */ 
            List<int> arg = new List<int>();        
            arg.Add(3);
           // arg.Add(7);
            arg.Add(4);
            List<int> arg2 = new List<int>();
            arg2.Add(1);
            arg2.Add(0);//5
            //arg2.Add(8);
            List<int> arg3 = new List<int>();
            arg3.Add(6);
            arg3.Add(2);
            arg3.Add(0);
            puz.Add(arg);
            puz.Add(arg2);
           // puz.Add(arg3);
            List<List<int>> goal = new List<List<int>>();
            List<int> argG = new List<int>();
            argG.Add(0);
            argG.Add(1);
            //argG.Add(2);
            List<int> argG2 = new List<int>();
            argG2.Add(3);
            argG2.Add(4);
           // argG2.Add(5);
            List<int> argG3 = new List<int>();
            argG3.Add(6);
            argG3.Add(7);
            argG3.Add(8);
            goal.Add(argG);
            goal.Add(argG2);
           // goal.Add(argG3);
            Puzzle puzzle = new Puzzle(puz, new Pair<int, int>(1, 1)); //2 2
            Puzzle pGoal = new Puzzle(goal, new Pair<int, int>(0, 0));
            List<int> listI = new List<int>();
            RepoPuzzle repoPuzzle = new RepoPuzzle(puzzle, pGoal);
            Console.WriteLine(puzzle);
            Console.WriteLine(pGoal);
            Console.WriteLine("1.BFS");
            Console.WriteLine("2.GBFS");
            Console.WriteLine("Alege o optiune");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                SearchMethod bFS = new BFS(repoPuzzle);
                var e = bFS.search(puzzle);
                //var e = bFS.searchFromAnInstance(puzzle);
                if (e == null)
                    Console.WriteLine("Nu s a gasit!");
                else
                {
                    foreach (var element in e)
                        Console.WriteLine(element);
                    Console.WriteLine(e.Count);
                }
            }
            if (opt == 2)
            {
                SearchMethod gbFS = new GBFS(repoPuzzle);
                var e = gbFS.search(puzzle);
                //var e = gbFS.searchFromAnInstance(puzzle);
                if (e == null)
                    Console.WriteLine("Nu s a gasit!");
                else
                {
                    foreach (var element in e)
                        Console.WriteLine(element);
                    Console.WriteLine(e.Count);
                }
            }

            Console.Read();
                




        }

    }
}
