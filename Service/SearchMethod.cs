using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1AI.Domain;

namespace Lab1AI.Service
{
    interface SearchMethod
    {
        List<Puzzle> search(Puzzle puzzle);
        List<Puzzle> searchFromAnInstance(Puzzle puzzle);
    }
}
