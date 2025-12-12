using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq; // ДОБАВЛЕНО: Необходимо для использования метода Max()

namespace practika
{
    public class Order
    {
        public int ID_Orders { get; set; }
        public int Status { get; set; }
        public int TypeofOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public string DateOfOrder { get; set; }
        public int PaymentMethod { get; set; }
        public int ID_User { get; set; }
        public int ID_Products { get; set; }
    }

    public partial class zakaz : Window
    {
        private Window admin;

        private ObservableCollection<Order> ordersList;

        public zakaz()
        {
            InitializeComponent();
            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            ordersList = new ObservableCollection<Order>
            {
                new Order
                {
                    ID_Orders = 1,
                    Status = 1,
                    TypeofOrder = 1,
                    TotalAmount = 6500m,
                    DateOfOrder = "2025-11-11",
                    PaymentMethod = 2,
                    ID_User = 3,
                    ID_Products = 1
                },
                new Order
                {
                    ID_Orders = 2,
                    Status = 1,
                    TypeofOrder = 2,
                    TotalAmount = 1500m,
                    DateOfOrder = "2025-11-21",
                    PaymentMethod = 2,
                    ID_User = 7,
                    ID_Products = 4
                },
                new Order
                {
                    ID_Orders = 3,
                    Status = 2,
                    TypeofOrder = 1,
                    TotalAmount = 670m,
                    DateOfOrder = "2025-10-13",
                    PaymentMethod = 2,
                    ID_User = 2,
                    ID_Products = 2
                },
                new Order
                {
                    ID_Orders = 4,
                    Status = 3,
                    TypeofOrder = 1,
                    TotalAmount = 1000m,
                    DateOfOrder = "2025-11-05",
                    PaymentMethod = 2,
                    ID_User = 5,
                    ID_Products = 3
                }
            };

            // В XAML вы назвали DataGrid как ProductsDataGrid, используем это имя
            ProductsDataGrid.ItemsSource = ordersList;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin = new admin();
            admin.Show();
            this.Close();
        }

        // --- ДОБАВЛЕННЫЙ МЕТОД: ЛОГИКА КНОПКИ "ДОБАВИТЬ" ---
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Определяем новый ID, основываясь на максимальном существующем ID
            int newId = ordersList.Count > 0 ? ordersList.Max(o => o.ID_Orders) + 1 : 1;

            // Создаем новый объект заказа с данными по умолчанию
            Order newOrder = new Order
            {
                ID_Orders = newId,
                Status = 1, // По умолчанию: Новый заказ
                TypeofOrder = 1,
                TotalAmount = 0m,
                DateOfOrder = DateTime.Now.ToString("yyyy-MM-dd"),
                PaymentMethod = 1,
                ID_User = 1, // Предполагаемый ID пользователя по умолчанию
                ID_Products = 1 // Предполагаемый ID продукта по умолчанию
            };

            // Добавляем новый заказ в ObservableCollection. DataGrid обновляется автоматически.
            ordersList.Add(newOrder);

            // Выделяем новую строку для удобства редактирования
            ProductsDataGrid.SelectedItem = newOrder;
            ProductsDataGrid.ScrollIntoView(newOrder);
        }
        // --------------------------------------------------------

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            Order orderToDelete = deleteButton.DataContext as Order;

            if (orderToDelete != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить заказ №{orderToDelete.ID_Orders}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ordersList.Remove(orderToDelete);
                }
            }
        }
    }
}