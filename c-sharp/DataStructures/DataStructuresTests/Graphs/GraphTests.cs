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
  }
}
