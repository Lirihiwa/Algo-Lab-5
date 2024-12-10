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
    /// Interaction logic for VertexControl.xaml
    /// </summary>
    public partial class VertexControl : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(VertexControl), new PropertyMetadata(string.Empty));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public VertexControl()
        {
            InitializeComponent();
        }

        public void Highlight()
        {
            vertexEllipse.Fill = Brushes.Green;
        }

        public void ResetHighlight()
        {
            vertexEllipse.Fill = Brushes.Blue;
        }
    }
}
