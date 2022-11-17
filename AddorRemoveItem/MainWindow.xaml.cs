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

namespace AddorRemoveItem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush costumeColor;
        Random rnd = new Random();
        public MainWindow() => InitializeComponent();

        private void AddOrRemove(object sender, MouseButtonEventArgs e)
        {
            //while (e.ButtonState == MouseButtonState.Pressed)
            //{
                if (e.OriginalSource is Ellipse)
                {
                    Ellipse current = (Ellipse)e.OriginalSource;
                    mycanva.Children.Remove(current);
                }
                else
                {
                    costumeColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                    Ellipse rectangle = new Ellipse
                    {
                        Width = 20,
                        Height = 20,
                        Fill = costumeColor
                    };
                    Canvas.SetLeft(rectangle, Mouse.GetPosition(mycanva).X - 10);
                    Canvas.SetTop(rectangle, Mouse.GetPosition(mycanva).Y - 10);
                    mycanva.Children.Add(rectangle);
                }
            //}
        }

        private void Clear(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
                mycanva.Children.Clear();
        }
    }
}
