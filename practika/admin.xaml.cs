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

namespace practika
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class admin : Window
    {
        private zakaz zakaz;
        private practika2 practika2;
        private client client;

        public admin()
        {
            InitializeComponent();
        }

        public Product Product { get; private set; }
        public Suppliers Suppliers { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zakaz = new zakaz();
            zakaz.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            practika2 = new practika2();
            practika2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            zakaz = new zakaz();
            zakaz.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            client = new client();
            client.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Product = new Product();
            Product.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Suppliers = new Suppliers();
            Suppliers.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            practika2 = new practika2();
            practika2.Show();
            this.Close();
        }
    }
}
