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

namespace CakeMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CakeSizeChanged(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            UpdateEnabled(rb.Name);
            UpdatePrices(rb.Name);
            UpdateTotal();
        }
        private void UpdatePrice_Check(object sender, RoutedEventArgs e)
        {
            UpdateTotal();
        }
        private void UpdateEnabled(string cakeSize)
        {
            switch (cakeSize)
            {
                case "Round_8":
                    choc_fill.IsEnabled = true;
                    van_fill.IsEnabled = true;
                    pis_fill.IsEnabled = true;
                    choc_frost.IsEnabled = true;
                    car_frost.IsEnabled = true;
                    bac_frost.IsEnabled = true;
                    writing_grid.IsEnabled = true;
                    drawing_grid.IsEnabled = true;
                    photo_grid.IsEnabled = false;
                    photo_desc.Text = "";
                    candles_grid.IsEnabled = true;
                    break;
                case "Round_10":
                    choc_fill.IsEnabled = true;
                    van_fill.IsEnabled = true;
                    pis_fill.IsEnabled = true;
                    choc_frost.IsEnabled = true;
                    car_frost.IsEnabled = true;
                    bac_frost.IsEnabled = true;
                    writing_grid.IsEnabled = true;
                    drawing_grid.IsEnabled = true;
                    photo_grid.IsEnabled = false;
                    photo_desc.Text = "";
                    candles_grid.IsEnabled = true;
                    break;
                case "Square":
                    choc_fill.IsEnabled = true;
                    van_fill.IsEnabled = true;
                    pis_fill.IsEnabled = true;
                    choc_frost.IsEnabled = true;
                    car_frost.IsEnabled = true;
                    bac_frost.IsEnabled = true;
                    writing_grid.IsEnabled = true;
                    drawing_grid.IsEnabled = true;
                    photo_grid.IsEnabled = true;
                    candles_grid.IsEnabled = true;
                    break;
                case "Rectangle":
                    choc_fill.IsEnabled = true;
                    van_fill.IsEnabled = true;
                    pis_fill.IsEnabled = false;
                    pis_fill.IsChecked = false;
                    choc_frost.IsEnabled = true;
                    car_frost.IsEnabled = true;
                    bac_frost.IsEnabled = false;
                    bac_frost.IsChecked = false;
                    writing_grid.IsEnabled = true;
                    drawing_grid.IsEnabled = false;
                    drawing_desc.Text = "";
                    photo_grid.IsEnabled = true;
                    candles_grid.IsEnabled = true;
                    break;
                default:
                    choc_fill.IsEnabled = true;
                    van_fill.IsEnabled = true;
                    pis_fill.IsEnabled = true;
                    choc_frost.IsEnabled = true;
                    car_frost.IsEnabled = true;
                    bac_frost.IsEnabled = true;
                    writing_grid.IsEnabled = true;
                    drawing_grid.IsEnabled = true;
                    photo_grid.IsEnabled = false;
                    photo_desc.Text = "";
                    candles_grid.IsEnabled = true;
                    break;
            }
        }
        private void UpdatePrices(string cakeSize)
        {
            switch (cakeSize)
            {
                case "Round_8":
                    choc_fill.ToolTip = "$1";
                    van_fill.ToolTip = "$1";
                    pis_fill.ToolTip = "$2";
                    choc_frost.ToolTip = "$1";
                    car_frost.ToolTip = "$2";
                    bac_frost.ToolTip = "$3";
                    writing_grid.ToolTip = "$0.25/Character";
                    drawing_grid.ToolTip = "$5";
                    candles_grid.ToolTip = "$0.50/each";
                    break;
                case "Round_10":
                    choc_fill.ToolTip = "$1";
                    van_fill.ToolTip = "$1";
                    pis_fill.ToolTip = "$2";
                    choc_frost.ToolTip = "$1";
                    car_frost.ToolTip = "$2";
                    bac_frost.ToolTip = "$3";
                    writing_grid.ToolTip = "$0.25/Character";
                    drawing_grid.ToolTip = "$5";
                    candles_grid.ToolTip = "$0.50/each";
                    break;
                case "Square":
                    choc_fill.ToolTip = "$2";
                    van_fill.ToolTip = "$2";
                    pis_fill.ToolTip = "$3";
                    choc_frost.ToolTip = "$2";
                    car_frost.ToolTip = "$3";
                    bac_frost.ToolTip = "$5";
                    writing_grid.ToolTip = "$0.25/Character";
                    drawing_grid.ToolTip = "$7";
                    photo_grid.ToolTip = "$10";
                    candles_grid.ToolTip = "$0.50/each";
                    break;
                case "Rectangle":
                    choc_fill.ToolTip = "$3";
                    van_fill.ToolTip = "$3";
                    choc_frost.ToolTip = "$2";
                    car_frost.ToolTip = "$5";
                    writing_grid.ToolTip = "$0.25/Character";
                    photo_grid.ToolTip = "$15";
                    candles_grid.ToolTip = "$0.50/each";
                    break;
                default:
                    choc_fill.ToolTip = "$1";
                    van_fill.ToolTip = "$1";
                    pis_fill.ToolTip = "$2";
                    choc_frost.ToolTip = "$1";
                    car_frost.ToolTip = "$2";
                    bac_frost.ToolTip = "$3";
                    writing_grid.ToolTip = "$0.25/Character";
                    drawing_grid.ToolTip = "$5";
                    candles_grid.ToolTip = "$0.50/each";
                    break;
            }
        }
        private void UpdateTotal()
        {
            double total = 0.0;

            total += (bool)Round_8.IsChecked ? 5.0 : (bool)Round_10.IsChecked ? 6.0 : (bool)Square.IsChecked ? 7.0 : (bool)Rectangle.IsChecked ? 10.0 : 0.0;

            foreach (CheckBox el in fillings_panel.Children.OfType<CheckBox>())
            {
                total += (bool)el.IsChecked ? double.Parse(el.ToolTip.ToString()[1..]) : 0.0;
            }

            total += writing_desc.Text.Replace(" ", "").Length * 0.25;

            total += !(bool)drawing_check.IsChecked ? 0.0 : (bool)Round_8.IsChecked ? 5.0 : (bool)Round_10.IsChecked ? 5.0 : (bool)Square.IsChecked ? 7.0 : 0.0;

            total += !(bool)photo_check.IsChecked ? 0.0 : (bool)Square.IsChecked ? 10.0 : (bool)Rectangle.IsChecked ? 15.0 : 0.0;

            total += (!(bool)candles_check.IsChecked || candles_desc.Text.Length == 0) ? 0.0 : int.Parse(candles_desc.Text) * 0.50;

            TotalPrice.Content = total.ToString("$#.00");
        }
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            string s = (bool)Round_8.IsChecked ? "8\" Round" :
                       (bool)Round_10.IsChecked ? "10\" Round" :
                       (bool)Square.IsChecked ? "12\" x 12\" Square" :
                       (bool)Rectangle.IsChecked ? "12\" x 24\" Square" : "";
            List<string> f = new List<string>();
            List<string> d = new List<string>();

            foreach (CheckBox el in fillings_panel.Children.OfType<CheckBox>())
            {
                if ((bool)el.IsChecked)
                    f.Add(el.Content.ToString());
            }

            foreach (Grid g in decorations_panel.Children.OfType<Grid>())
            {
                if ((bool)g.Children.OfType<CheckBox>().First().IsChecked)
                    d.Add(string.Join(":", g.Children.OfType<CheckBox>().First().Content,
                        g.Children.OfType<TextBox>().First().Text.Trim()));
            }

            Cake cake = new Cake(s, f, d, double.Parse(TotalPrice.Content.ToString()[1..]));

            cake.CreateReport();
        }
    }
}
