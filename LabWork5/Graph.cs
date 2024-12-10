using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork5
{
    public class Graph
    {
        public int[,] AdjacencyMatrix { get; set; }
        public List<int>[,] IncidenceMatrix { get; set; }
        public string[] VertexNames { get; set; }

        public Graph(int[,] adjacencyMatrix, List<int>[,] incidenceMatrix, string[] vertexNames)
        {
            AdjacencyMatrix = adjacencyMatrix;
            IncidenceMatrix = incidenceMatrix;
            VertexNames = vertexNames;
        }
    }
}
