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

namespace WPFTestApp
{
    /// <summary>
    /// Interaktionslogik für MyClock.xaml
    /// </summary>
    public partial class MyClock : UserControl
    {
        public MyClock()
        {
            InitializeComponent();
            var angle = Enumerable.Range(0, 6).Select(p => p * 30);
            Control.ItemsSource = angle;
        }

        public Color MyColor
        {
            set
            {
                brush.Color = value;
            }
        }
    }
}
