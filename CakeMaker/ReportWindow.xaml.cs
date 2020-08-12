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
    public partial class ReportWindow : Window
    {
        public ReportWindow(Cake cake)
        {
            InitializeComponent();
            report_price.Text = cake.Price.ToString("$#.00");
            report_time.Text = cake.TimeToMake.ToString("c");
            foreach (Ingredient i in cake.Ingredients)
            {
                TextBlock tb = new TextBlock()
                {
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Text = i.Quantity.ToString() + " " + i.Unit + " " + i.Name
                };
                report_ingredients.Children.Add(tb);
            }
        }
    }
}
