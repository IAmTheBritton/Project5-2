using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Project5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Polygon> polygonList = new List<Polygon>();
        List<Polyline> polylineList = new List<Polyline>();
        List<Ellipse> pointList = new List<Ellipse>();

        Rectangle highlight = new Rectangle();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openButtonClick(object sender, RoutedEventArgs e)
        {

            string[] line;
            OpenFileDialog read = new OpenFileDialog();
            if (read.ShowDialog() == true)
            {
                try
                {
                    string[] text = File.ReadAllLines(read.FileName);
                    foreach (string item in text)
                    {
                        line = item.Split(' ');
                        if (line[0] == "polygon")
                        {

                            Polygon tempPoly = new Polygon();
                            for (int i = 2; i < line.Length - 1; i += 2)
                            {
                                tempPoly.Points.Add(new Point(Convert.ToDouble(line[i]), Convert.ToDouble(line[i + 1])));
                            }
                            if (line[1] == "land")
                            {
                                tempPoly.Fill = new SolidColorBrush(Color.FromRgb(100, 255, 100));
                                tempPoly.Name = "land";
                            }
                            else
                            {
                                tempPoly.Fill = new SolidColorBrush(Color.FromRgb(100, 100, 255));
                                tempPoly.Name = "lake";
                            }
                            polygonList.Add(tempPoly);
                            mapCanvas.Children.Add(tempPoly);
                        }
                        else if (line[0] == "line")
                        {
                            Polyline tempLine = new Polyline();
                            for (int i = 2; i < line.Length - 1; i += 2)
                            {
                                tempLine.Points.Add(new Point(Convert.ToDouble(line[i]), Convert.ToDouble(line[i + 1])));
                            }
                            if (line[1] == "river")
                            {
                                tempLine.Stroke = new SolidColorBrush(Color.FromRgb(100, 100, 255));
                                tempLine.Name = "river";
                            }
                            else if (line[1] == "road")
                            {
                                tempLine.Stroke = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                                tempLine.Name = "road";
                            }
                            else
                            {
                                tempLine.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                tempLine.Name = "border";
                            }
                            polylineList.Add(tempLine);
                            mapCanvas.Children.Add(tempLine);
                        }
                        else
                        {

                            Ellipse tempElip = new Ellipse();
                            tempElip.Width = 10;
                            tempElip.Height = tempElip.Width;
                            Canvas.SetLeft(tempElip, Convert.ToDouble(line[2]) - 5);
                            Canvas.SetTop(tempElip, Convert.ToDouble(line[3]) - 5);
                            if (line[1] == "city")
                            {
                                tempElip.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                tempElip.Name = "city";
                            }
                            else
                            {
                                tempElip.Fill = new SolidColorBrush(Color.FromRgb(150, 150, 0));
                                tempElip.Name = "mountain";
                            }
                            pointList.Add(tempElip);
                            mapCanvas.Children.Add(tempElip);
                        }

                    }
                    foreach (var k in polygonList)
                    {
                        itemList.Items.Add(k.Name);
                    }
                    foreach (var k in polylineList)
                    {
                        itemList.Items.Add(k.Name);
                    }
                    foreach (var k in pointList)
                    {
                        itemList.Items.Add(k.Name);
                    }
                }
                catch (IOException i)
                {
                    itemList.Items.Add("Error in file");
                }
            }
        }

        private void itemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mapCanvas.Children.Remove(highlight);
            if (itemList.SelectedIndex >= polygonList.Count + polylineList.Count)
            {
                highlight.Width = 10;
                highlight.Height = 10;
                Canvas.SetLeft(highlight, Canvas.GetLeft(pointList[itemList.SelectedIndex - (polygonList.Count + polylineList.Count)]));
                Canvas.SetTop(highlight, Canvas.GetTop(pointList[itemList.SelectedIndex - (polygonList.Count + polylineList.Count)]));
            }
            else if (itemList.SelectedIndex >= polygonList.Count && itemList.SelectedIndex < polygonList.Count + polylineList.Count)
            {
                Point minp, maxp = new Point();
                minp = polylineList[itemList.SelectedIndex - polygonList.Count].Points[0];
                maxp = polylineList[itemList.SelectedIndex - polygonList.Count].Points[0];
                foreach (Point k in polylineList[itemList.SelectedIndex - polygonList.Count].Points)
                {
                    if (minp.X > k.X && minp.Y > k.Y)
                        minp = k;
                    if (maxp.X < k.X && maxp.Y < k.Y)
                        maxp = k;
                }
                highlight.Height = maxp.Y - minp.Y;
                highlight.Width = maxp.X - minp.X;
                Canvas.SetLeft(highlight, minp.X);
                Canvas.SetTop(highlight, minp.Y);
            }
            else 
            {
                Point minp, maxp = new Point();
                minp = polygonList[itemList.SelectedIndex].Points[0];
                maxp = polygonList[itemList.SelectedIndex].Points[0];
                foreach (Point k in polygonList[itemList.SelectedIndex].Points)
                {
                    if (minp.X > k.X && minp.Y > k.Y)
                        minp = k;
                    if (maxp.X < k.X && maxp.Y < k.Y)
                        maxp = k;
                }
                highlight.Height = maxp.Y - minp.Y;
                highlight.Width = maxp.X - minp.X;
                Canvas.SetLeft(highlight, minp.X);
                Canvas.SetTop(highlight, minp.Y);
            }
            highlight.Stroke = new SolidColorBrush(Color.FromRgb(200, 100, 100));
            mapCanvas.Children.Add(highlight);
        }

        private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = ".txt";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (savefile.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    foreach (Polygon k in polygonList)
                    {
                        sw.Write("polygon " + k.Name + " ");
                        foreach (Point i in k.Points)
                        {
                            sw.Write(i.X + " " + i.Y + " ");
                        }
                        sw.WriteLine();
                    }
                    foreach (Polyline k in polylineList)
                    {
                        sw.Write("line " + k.Name + " ");
                        foreach (Point i in k.Points)
                        {
                            sw.Write(i.X + " " + i.Y + " ");
                        }
                        sw.WriteLine();
                    }
                    foreach (Ellipse k in pointList)
                    {
                        sw.WriteLine("point " + k.Name + (Canvas.GetLeft(k) + 5) + " " + (Canvas.GetTop(k) + 5));
                    }
                }
            }
        }
    }
}
