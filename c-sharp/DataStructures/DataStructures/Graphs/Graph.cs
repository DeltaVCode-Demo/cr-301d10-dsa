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

    public IEnumerable<GraphNode> BreadthFirst(GraphNode start)
    {
      // var results = new List<GraphNode>(); // using yield return instead
      var breadth = new Queue<GraphNode>();
      var visited = new HashSet<GraphNode>();

      breadth.Enqueue(start);
      visited.Add(start);

      // while (breadth.Count > 0) // or use TryDequeue
      while (breadth.TryDequeue(out GraphNode front))
      {
        // var front = breadth.Dequeue();
        // results.Add(front); 
        yield return front;

        foreach (var edge in front.Neighbors)
        {
          var neighbor = edge.Node;

          if (!visited.Contains(neighbor))
          {
            breadth.Enqueue(neighbor);
            visited.Add(neighbor);
          }
        }
      }

      // return results; // using yield return instead
    }
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
