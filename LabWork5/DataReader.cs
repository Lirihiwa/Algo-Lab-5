using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork5
{
    internal class DataReader
    {
        public static int[,] AdjacencyMatrix { get => ReadAdjacencyMatrix(); }
        public static string[] VertexNames { get => GetVertexNames(); }
        
        private static int[,] ReadAdjacencyMatrix()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\AdjacencyMatrix.txt"));

            int[,] adjMatrix = new int[lines.Length - 1, lines[0].Length / 2];

            int row = 0;
            int column = 0;

            foreach (string line in lines)
            {
                foreach(string el in line.Split(" "))
                {
                    if(row != 0 && column != 0) adjMatrix[row - 1, column - 1] = Convert.ToInt32(el);

                    column++;
                }
                column = 0;
                row++;
            }

            return adjMatrix;
        }

        private static string[] GetVertexNames()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\AdjacencyMatrix.txt"));

            string[] names = lines[0].Split(" ").ToList().Skip(1).ToArray();

            return names;
        }
    }
}
