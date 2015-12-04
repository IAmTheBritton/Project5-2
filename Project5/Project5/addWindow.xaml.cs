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
            try 
            {
                Polyline road = new Polyline();
                string[] points = roadTextBox.Text.Split('\n');
                string[] xAndY = new string[2];
                List<Double> xOfPoint = new List<Double>();
                List<Double> yOfPoint = new List<Double>();
                for (int i = 0; i < points.Length; i++)
                {
                    xAndY = points[i].Split(',');
                    xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                    yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                    road.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
                }
                road.Stroke = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                road.Name = "road";
                MainWindow.polylineList.Add(road);
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                mainWindowInstant.getCanvas.Children.Add(road);
                mainWindowInstant.reprintItemList();
                roadTextBox.Clear();
            }
            catch { }
        }

        private void addBorder(object sender, RoutedEventArgs e)
        {
            try
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
                border.Name = "border";
                MainWindow.polylineList.Add(border);
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                mainWindowInstant.getCanvas.Children.Add(border);
                mainWindowInstant.reprintItemList();
                borderTextBox.Clear();
            }
            catch { }
        }

        private void addRiver(object sender, RoutedEventArgs e)
        {
             try 
            {
                Polyline river = new Polyline();
                string[] points = riverTextBox.Text.Split('\n');
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
                river.Name = "river";
                MainWindow.polylineList.Add(river);
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                mainWindowInstant.getCanvas.Children.Add(river);
                mainWindowInstant.reprintItemList();
                riverTextBox.Clear();
            }
            catch { }
        }

        private void addCity(object sender, RoutedEventArgs e)
        {
            try 
            {
                Ellipse city = new Ellipse();
                city.Width = 10;
                city.Height = 10;
                city.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                city.Name = "city";
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                mainWindowInstant.setCanvas(city, Convert.ToDouble(xCityText.Text), Convert.ToDouble(yCityText.Text));
                MainWindow.pointList.Add(city);
                mainWindowInstant.getCanvas.Children.Add(city);
                mainWindowInstant.reprintItemList();
                xCityText.Clear(); yCityText.Clear();
            }
            catch { }
        }

        private void addMountain(object sender, RoutedEventArgs e)
        {
            try
            {
                Ellipse mountain = new Ellipse();
                mountain.Width = 10;
                mountain.Height = 10;
                mountain.Fill = new SolidColorBrush(Color.FromRgb(150, 150, 0));
                mountain.Name = "mountain";
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                mainWindowInstant.setCanvas(mountain, Convert.ToDouble(xMountainText.Text), Convert.ToDouble(yMountainText.Text));
                MainWindow.pointList.Add(mountain);
                mainWindowInstant.getCanvas.Children.Add(mountain);
                mainWindowInstant.reprintItemList();
                xCityText.Clear(); yCityText.Clear();
            }
            catch { }
        }

        private void addLand(object sender, RoutedEventArgs e)
        {
            try
            {
                Polygon land = new Polygon();
                string[] points = landTextBox.Text.Split('\n');
                string[] xAndY = new string[2];
                List<Double> xOfPoint = new List<Double>();
                List<Double> yOfPoint = new List<Double>();
                for (int i = 0; i < points.Length; i++)
                {
                    xAndY = points[i].Split(',');
                    xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                    yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                    land.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
                }
                land.Fill = new SolidColorBrush(Color.FromRgb(100, 255, 100));
                land.Name = "land";
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                MainWindow.polygonList.Add(land);
                mainWindowInstant.mapCanvas.Children.Add(land);
                mainWindowInstant.reprintItemList();
                landTextBox.Clear();
            }
            catch { }
        }

        private void addLake(object sender, RoutedEventArgs e)
        {
            try
            {
                Polygon lake = new Polygon();
                string[] points = lakeTextBox.Text.Split('\n');
                string[] xAndY = new string[2];
                List<Double> xOfPoint = new List<Double>();
                List<Double> yOfPoint = new List<Double>();
                for (int i = 0; i < points.Length; i++)
                {
                    xAndY = points[i].Split(',');
                    xOfPoint.Add(Convert.ToDouble(xAndY[0]));
                    yOfPoint.Add(Convert.ToDouble(xAndY[1]));
                    lake.Points.Add(new Point(xOfPoint[i], yOfPoint[i]));
                }
                lake.Fill = new SolidColorBrush(Color.FromRgb(100, 100, 255));
                lake.Name = "lake";
                var mainWindowInstant = (MainWindow)App.Current.MainWindow;
                MainWindow.polygonList.Add(lake);
                mainWindowInstant.mapCanvas.Children.Add(lake);
                mainWindowInstant.reprintItemList();
                landTextBox.Clear();
            }
            catch { }
        }
    }
}
