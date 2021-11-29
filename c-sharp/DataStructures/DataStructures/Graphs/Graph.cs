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
    public GraphNode AddNode(string value)
    {
      var newNode = new GraphNode
      {
        Value = value,
      };

      nodes.Add(newNode);

      return newNode;
    }

    // add edge
    public void AddEdge(GraphNode node1, GraphNode node2)
    {
      node1.Neighbors.Add(new GraphEdge
      {
        Node = node2,
      });
    }

    // Private storage for our Nodes
    private readonly List<GraphNode> nodes = new List<GraphNode>();

    // Public should not be able to Add directly
    public IEnumerable<GraphNode> Nodes => nodes;

    // get neighbors
    public IEnumerable<GraphEdge> GetNeighbors(GraphNode node)
    {
      // Is this really useful? Not so much.
      return node.Neighbors;
    }

    // size
    public int Count => nodes.Count;
    // public int Count { get { return Nodes.Count();  } }
  }

  public class GraphNode
  {
    public string Value { get; set; }

    // Read-only property that always has a List, i.e. never null
    public List<GraphEdge> Neighbors { get; } = new List<GraphEdge>();
  }

  public class GraphEdge
  {
    public GraphNode Node { get; set; }
  }
}
