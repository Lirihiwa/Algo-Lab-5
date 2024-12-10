using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork5
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();
        }

        public void DrawGraph(Graph graph)
        {
            int numVertices = graph.AdjacencyMatrix.GetLength(0);
            double canvasWidth = graphCanvas.ActualWidth;
            double canvasHeight = graphCanvas.ActualHeight;
            double vertexRadius = 25;
            double centerX = canvasWidth / 2;
            double centerY = canvasHeight / 2;
            double radius = Math.Min(centerX, centerY) - vertexRadius * 5;
            
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (graph.AdjacencyMatrix[i, j] == 1)
                    {
                        double angle1 = 2 * Math.PI * i / numVertices;
                        double angle2 = 2 * Math.PI * j / numVertices;
                        double x1 = centerX + radius * Math.Cos(angle1);
                        double y1 = centerY + radius * Math.Sin(angle1);
                        double x2 = centerX + radius * Math.Cos(angle2);
                        double y2 = centerY + radius * Math.Sin(angle2);

                        EdgeControl edge = new EdgeControl();
                        edge.SetPoints(new Point(x1, y1), new Point(x2, y2));
                        graphCanvas.Children.Add(edge);
                    }
                }
            }

            for (int i = 0; i < numVertices; i++)
            {
                double angle = 2 * Math.PI * i / numVertices;
                double x = centerX + radius * Math.Cos(angle);
                double y = centerY + radius * Math.Sin(angle);

                VertexControl vertex = new VertexControl
                {
                    Label = graph.VertexNames[i],
                    Width = vertexRadius * 2,
                    Height = vertexRadius * 2
                };
                Canvas.SetLeft(vertex, x - vertexRadius);
                Canvas.SetTop(vertex, y - vertexRadius);
                graphCanvas.Children.Add(vertex);
            }            

            graphCanvas.UpdateLayout();
        }

        public void HighlightVertex(string label)
        {
            foreach (UIElement element in graphCanvas.Children)
            {
                if (element is VertexControl vertex && vertex.Label == label)
                {
                    vertex.Highlight();
                }
            }
        }

        public void ResetHighlight()
        {
            foreach (UIElement element in graphCanvas.Children)
            {
                if (element is VertexControl vertex)
                {
                    vertex.ResetHighlight();
                }
            }
        }
    }
}
