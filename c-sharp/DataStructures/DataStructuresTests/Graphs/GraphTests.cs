using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

    [Fact]
    public void BreadthFirst_works()
    {
      // Arrange
      //   (A) -> (B)
      //    | \    |
      //    |  \   |
      //    |   \  |
      //    |    \ |
      //    |     \|
      //    V      V
      //   (C) -> (D)
      var graph = new Graph();

      var a = graph.AddNode("A");
      var b = graph.AddNode("B");
      var c = graph.AddNode("C");
      var d = graph.AddNode("D");

      // Adjacency list
      graph.AddEdge(a, b);
      graph.AddEdge(a, c);
      graph.AddEdge(a, d);
      graph.AddEdge(b, d);
      graph.AddEdge(c, d);

      // Act
      var resultA = graph.BreadthFirst(a);

      // Assert
      Assert.Equal(new[] { a, b, c, d }, resultA);

      // Act
      var resultB = graph.BreadthFirst(b);

      // Assert
      Assert.Equal(new[] { b, d }, resultB); // Can't get to A or C

      // Act
      var resultC = graph.BreadthFirst(c);

      // Assert
      Assert.Equal(new[] { c, d }, resultC); // Can't get to A or B

      // Act
      var resultD = graph.BreadthFirst(d);

      // Assert
      Assert.Equal(new[] { d }, resultD); // Can't get to A, B or C
    }

    [Theory]
    [MemberData(nameof(DepthFirstMethods))]
    public void DepthFirst_works(Expression<Func<Graph, GraphNode, IEnumerable<GraphNode>>> depthFirst)
    {
      // Arrange
      var graph = new Graph();

      var a = graph.AddNode("A");
      var b = graph.AddNode("B");
      var c = graph.AddNode("C");
      var d = graph.AddNode("D");
      var e = graph.AddNode("E");
      var f = graph.AddNode("F");
      var g = graph.AddNode("G");
      var h = graph.AddNode("H");

      graph.AddEdge(a, b);
      graph.AddEdge(a, d);
      graph.AddEdge(b, c);
      graph.AddEdge(b, d);
      graph.AddEdge(c, g);
      graph.AddEdge(d, a);
      graph.AddEdge(d, b);
      graph.AddEdge(d, e);
      graph.AddEdge(d, h);
      graph.AddEdge(d, f);
      graph.AddEdge(e, d);
      graph.AddEdge(f, d);
      graph.AddEdge(f, h);
      graph.AddEdge(h, f);

      // Act
      var result = depthFirst.Compile()(graph, a);

      // Assert
      Assert.Equal(new[] { a, b, c, g, d, e, h, f }, result);
    }

    public static TheoryData<Expression<Func<Graph, GraphNode, IEnumerable<GraphNode>>>> DepthFirstMethods =>
      new()
      {
        (graph, start) => graph.DepthFirstRecursive(start),
        (graph, start) => graph.DepthFirstIterative(start),
      };
  }
}
