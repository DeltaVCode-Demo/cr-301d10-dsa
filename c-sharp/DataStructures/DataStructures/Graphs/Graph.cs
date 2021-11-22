using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
  public class Graph
  {
    // add node
    // add edge
    // get nodes
    public IEnumerable<GraphNode> Nodes { get; } = new List<GraphNode>();
    // get neighbors
    // size

    public int Count => Nodes.Count();
    // public int Count { get { return Nodes.Count();  } }
  }

  public class GraphNode
  {
  }
}
