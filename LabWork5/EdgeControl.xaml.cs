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
    /// Interaction logic for EdgeControl.xaml
    /// </summary>
    public partial class EdgeControl : UserControl
    {
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(int), typeof(EdgeControl), new PropertyMetadata(0));

        public int Weight
        {
            get { return (int)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        public EdgeControl()
        {
            InitializeComponent();
        }

        public void SetPoints(Point start, Point end)
        {
            edgeLine.X1 = start.X;
            edgeLine.Y1 = start.Y;
            edgeLine.X2 = end.X;
            edgeLine.Y2 = end.Y;

            double midX = (start.X + end.X) / 2;
            double midY = (start.Y + end.Y) / 2;
            Canvas.SetLeft(edgeTextBlock, midX - edgeTextBlock.ActualWidth / 2);
            Canvas.SetTop(edgeTextBlock, midY - edgeTextBlock.ActualHeight / 2);
        }
    }
}
