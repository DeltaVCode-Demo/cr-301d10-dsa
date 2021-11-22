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

      // TODO: has no edges
    }
  }
}
