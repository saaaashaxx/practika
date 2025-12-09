using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel; // Добавляем для ObservableCollection

namespace practika
{
    public class ProductModel
    {
        public int ID_Products { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int ID_Suppliers { get; set; }
        public int ID_Categories { get; set; }
        public int ID_Brands { get; set; }
        public string img { get; set; }
    }

    public partial class Product : Window
    {
        private Window admin;

        // КЛЮЧЕВОЕ ИЗМЕНЕНИЕ 1: Список продуктов делаем полем класса и используем ObservableCollection
        private ObservableCollection<ProductModel> productsList;

        public Product()
        {
            InitializeComponent();
            LoadProductsData();
        }

        private void LoadProductsData()
        {
            // Инициализируем ObservableCollection
            productsList = new ObservableCollection<ProductModel>
            {
                new ProductModel
                {
                    ID_Products = 1,
                    Name = "Парфюмерная вода\r\nDARLING* Eau de Parfum Citopia",
                    Volume = "100ml",
                    Price = 4500.00m,
                    QuantityInStock = 50,
                    ID_Suppliers = 1,
                    ID_Categories = 2,
                    ID_Brands = 3,
                    img = "/img/flora.png"
                },
                new ProductModel
                {
                    ID_Products = 2,
                    Name = "Термозащитный несмываемый спрей для волос\r\nRAD Saf",
                    Volume = "50ml",
                    Price = 1200.50m,
                    QuantityInStock = 120,
                    ID_Suppliers = 4,
                    ID_Categories = 1,
                    ID_Brands = 1,
                    img = "/img/cream.png"
                },
                new ProductModel
                {
                    ID_Products = 3,
                    Name = "BB крем для лица SPF 20\r\nErborian BB Creme",
                    Volume = "250ml",
                    Price = 350.00m,
                    QuantityInStock = 200,
                    ID_Suppliers = 2,
                    ID_Categories = 3,
                    ID_Brands = 2,
                    img = "/Img/bb.png"
                },
                new ProductModel
                {
                    ID_Products = 4,
                    Name = "Гиалуроновый крем для лица\r\nInnisfree Green Tea Se",
                    Volume = "5ml",
                    Price = 899.99m,
                    QuantityInStock = 75,
                    ID_Suppliers = 3,
                    ID_Categories = 4,
                    ID_Brands = 3,
                    img = "/Img/inni.png"
                }
            };


            ProductsDataGrid.ItemsSource = productsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin = new admin();
            admin.Show();
            this.Close();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;

            ProductModel productToDelete = deleteButton.DataContext as ProductModel;

            if (productToDelete != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить продукт: {productToDelete.Name.Replace("\r\n", " ")} (ID: {productToDelete.ID_Products})?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    productsList.Remove(productToDelete);
                }
            }
        }
    }
}