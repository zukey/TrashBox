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

namespace FilterControl
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var panel = this.FindName("pnlItems2") as StackPanel;

            var chk = new CheckBox();
            chk.Content = "Addtion";
            chk.Height = 20;
            chk.Width = 88;

            var cmb = new ComboBox();
            cmb.Height = 25;
            cmb.Width = 123;

            var newPanel = new StackPanel();
            newPanel.Orientation = Orientation.Horizontal;
            newPanel.Margin = new Thickness(5, 15, 5, 5);
            newPanel.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            newPanel.Children.Add(chk);
            newPanel.Children.Add(cmb);

            panel.Children.Add(newPanel);

        }
    }
}
