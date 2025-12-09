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
    /// Логика взаимодействия для corzina2.xaml
    /// </summary>
    public partial class corzina2 : Window
    {
        private practika2 practika2;

        public corzina2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            practika2 = new practika2();
            practika2.Show();
            this.Close();
        }
    }
}
