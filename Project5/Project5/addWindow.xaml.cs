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
using System.Windows.Shapes;

namespace Project5
{
    /// <summary>
    /// Interaction logic for addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        public addWindow()
        {
            InitializeComponent();
        }

        private void addRoad(object sender, RoutedEventArgs e)
        {
            Polyline road = new Polyline();
            string[] points = roadTextBox.Text.Split('\n');
            string[] xAndY = new string[2];
            List<Double> xOfPoint = new List<Double>();
            List<Double> yOfPoint = new List<Double>();
            for(int i = 0; i < points.Length; i++)
            {
                xAndY = points[i].Split(',');
                xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                road.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
            }
            road.Stroke = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            MainWindow.polylineList.Add(road);
            var mainWindowInstant = (MainWindow)App.Current.MainWindow;
            mainWindowInstant.getCanvas.Children.Add(road);

        }

        private void addBorder(object sender, RoutedEventArgs e)
        {
            Polyline border = new Polyline();
            string[] points = borderTextBox.Text.Split('\n');
            string[] xAndY = new string[2];
            List<Double> xOfPoint = new List<Double>();
            List<Double> yOfPoint = new List<Double>();
            for (int i = 0; i < points.Length; i++)
            {
                xAndY = points[i].Split(',');
                xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                border.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
            }
            border.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            MainWindow.polylineList.Add(border);
            var mainWindowInstant = (MainWindow)App.Current.MainWindow;
            mainWindowInstant.getCanvas.Children.Add(border);
        }

        private void addRiver(object sender, RoutedEventArgs e)
        {
            Polyline river = new Polyline();
            string[] points = borderTextBox.Text.Split('\n');
            string[] xAndY = new string[2];
            List<Double> xOfPoint = new List<Double>();
            List<Double> yOfPoint = new List<Double>();
            for (int i = 0; i < points.Length; i++)
            {
                xAndY = points[i].Split(',');
                xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                river.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
            }
            river.Stroke = new SolidColorBrush(Color.FromRgb(100, 100, 255));
            MainWindow.polylineList.Add(river);
            var mainWindowInstant = (MainWindow)App.Current.MainWindow;
            mainWindowInstant.getCanvas.Children.Add(river);
        }
    }
}
