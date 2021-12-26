using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools.AStar;

public interface IWeightedGraph<T>
{
    long Cost(T start, T end);
    IEnumerable<T> Neighbours(T id);
}