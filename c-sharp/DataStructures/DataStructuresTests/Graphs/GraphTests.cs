using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructuresTests.Graphs
{
  public class GraphTests
  {
    [Fact]
    public void Graph_starts_empty()
    {
      // Arrange / Act
      var graph = new Graph();

      // Assert
      Assert.Empty(graph.Nodes);
      Assert.Equal(0, graph.Count);
    }

    [Fact]
    public void AddNode_with_value_returns_new_GraphNode()
    {
      // Arrange
      var graph = new Graph();

      // Act
      GraphNode result = graph.AddNode("DeltaV");

      // Assert
      Assert.NotNull(result);
      Assert.Equal("DeltaV", result.Value);

      Assert.NotEmpty(graph.Nodes);
      Assert.Equal(1, graph.Count);
      Assert.Contains(result, graph.Nodes);

      Assert.Empty(result.Neighbors);

      // Reference Equality, like === in JS
      Assert.Same(result.Neighbors, graph.GetNeighbors(result));
    }

    [Fact]
    public void AddEdge_with_nodes_makes_them_Neighbors()
    {
      // Arrange
      var graph = new Graph();
      var node1 = graph.AddNode("Oscar");
      var node2 = graph.AddNode("Big Bird");

      // Act
      graph.AddEdge(node1, node2);

      // Assert
      Assert.Contains(node1.Neighbors, edge => edge.Node == node2);
      //Assert.True(node1.Neighbors.Any(edge => edge.Node == node2));

      // Should not link from 2 to 1 yet
      Assert.Empty(node2.Neighbors);

      // Act again
      graph.AddEdge(node2, node1);

      // Assert
      Assert.Contains(node2.Neighbors, edge => edge.Node == node1);

      // Is 1 still linked to 2?
      Assert.Contains(node1.Neighbors, edge => edge.Node == node2);
    }
  }
}
