using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Domain;

namespace Lab1AI.Service
{
    abstract class  InformedSearchMethod : SearchMethod
    {
        public abstract List<Puzzle> search(Puzzle puzzle);
        public abstract List<Puzzle> searchFromAnInstance(Puzzle puzzle);
    }
}
