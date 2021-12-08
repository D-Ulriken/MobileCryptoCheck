using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CryptoCheck.coingeckoResponse;

namespace CryptoCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Coin> _employees;
        private CoinGeckoResponse _coinGeckoResponse;
        public MainWindow()
        {
            InitializeComponent();
           
            _coinGeckoResponse = new CoinGeckoResponse();
            
            _employees = new ObservableCollection<Coin>();
           
            foreach (var coin in _coinGeckoResponse.GetCoins())
            {
                _employees.Add(coin);
            }
            DG1.ItemsSource = _employees;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DG1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //DG1.Columns[0].Header = "";
            
            if (e.PropertyName == "image")
            {
                e.Column = new DataGridTemplateColumn
                {
                    CellTemplate = (sender as DataGrid).Resources["ImgCell"] as DataTemplate,
                    HeaderTemplate = e.Column.HeaderTemplate,
                    Header = e.Column.Header
                };
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _coinGeckoResponse = new CoinGeckoResponse();
            _employees = new ObservableCollection<Coin>();
            foreach (var coin in _coinGeckoResponse.GetCoins())
            {
                _employees.Add(coin);
            }
            DG1.ItemsSource = _employees;
        }
    }
}
