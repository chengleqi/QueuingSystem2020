using System.Windows;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace QueuingSystem2020.view
{
    public class DynamicDataDisplay
    {
        public readonly ObservableDataSource<Point> DataSource = new ObservableDataSource<Point>();

        public double X { get; set; }
        public double Y { get; set; }

        public void AppendAsync(Dispatcher dispatcher)
        {
            DataSource.AppendAsync(dispatcher, new Point(X, Y));
        }
    }
}