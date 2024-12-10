using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LabWork5
{
    public class GraphViewModel : INotifyPropertyChanged
    {
        private Graph? _graph = null;
        private GraphView? _graphView = null;

        public Graph? Graph
        {
            get { return _graph; }
            set
            {
                _graph = value;
                OnPropertyChanged();
            }
        }

        public GraphView? GraphView
        {
            get { return _graphView; }
            set
            {
                _graphView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ObhodGraphCommand { get; }
        public ICommand MaxFlowCommand { get; }
        public ICommand MinSpanningTreeCommand { get; }
        public ICommand ShortestPathCommand { get; }

        public GraphViewModel()
        {
            ObhodGraphCommand = new RelayCommand(async (param) => await ObhodGraphAsync());
            MaxFlowCommand = new RelayCommand(MaxFlow);
            MinSpanningTreeCommand = new RelayCommand(MinSpanningTree);
            ShortestPathCommand = new RelayCommand(ShortestPath);
        }

        private async Task ObhodGraphAsync()
        {
            if (GraphView == null) return;
            GraphView.ResetHighlight();

            Console.WriteLine("Обход графа в глубину (DFS):");
            await DFSAsync(Graph.AdjacencyMatrix, 0, new bool[Graph.AdjacencyMatrix.GetLength(0)]);
        }

        private async Task DFSAsync(int[,] adjacencyMatrix, int vertex, bool[] visited)
        {
            if (GraphView == null) return;
            visited[vertex] = true;
            Console.Write(Graph.VertexNames[vertex] + " ");
            GraphView.HighlightVertex(Graph.VertexNames[vertex]);
            await Task.Delay(500);

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                if (adjacencyMatrix[vertex, i] != 0 && !visited[i])
                {
                    await DFSAsync(adjacencyMatrix, i, visited);
                }
            }

            GraphView.ResetHighlight();
        }

        private void MaxFlow(object parameter)
        {
            // Реализация алгоритма поиска максимального потока
        }

        private void MinSpanningTree(object parameter)
        {
            // Реализация алгоритма построения минимального остовного дерева
        }

        private void ShortestPath(object parameter)
        {
            // Реализация алгоритма поиска кратчайшего пути
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool>? _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}