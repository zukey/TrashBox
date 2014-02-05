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
        List<SampleData> sampleData;

        public MainWindow()
        {
            InitializeComponent();
            sampleData = new List<SampleData>();
            sampleData.Add(new SampleData() { Name = "Data1", Val = 10, Selection = SampleEnum.Item1 });
            sampleData.Add(new SampleData() { Name = "Data2", Val = 20, Selection = SampleEnum.Item2 });
            sampleData.Add(new SampleData() { Name = "Data3", Val = 30, Selection = SampleEnum.Item3 });

            var dataGrid = FindName("DataGrid1") as DataGrid;
            dataGrid.DataContext = sampleData;
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

        private void Binding_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Binding();
            dlg.ShowDialog();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ValidationWindow();
            dlg.ShowDialog();
        }
    }
}
