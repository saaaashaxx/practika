using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace practika
{
    public class Supplier
    {
        public int ID_Suppliers { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }


    public partial class Suppliers : Window
    {
        private Window admin;
        private ObservableCollection<Supplier> suppliersList;

        public Suppliers()
        {
            InitializeComponent();
            LoadSuppliersData();
        }

        private void LoadSuppliersData()
        {
            suppliersList = new ObservableCollection<Supplier>();

            suppliersList.Add(new Supplier
            {
                ID_Suppliers = 1,
                Name = "Григорий",
                Telephone = "+7(912)972-39-60",
                Email = "6u3of@comfythings.com",
                Adress = "Лахтинская 21"
            });

            suppliersList.Add(new Supplier
            {
                ID_Suppliers = 2,
                Name = "Олег",
                Telephone = "+7(912)373-32-39",
                Email = "lvzi4@comfythings.com",
                Adress = "Марата 56-58"
            });

            suppliersList.Add(new Supplier
            {
                ID_Suppliers = 3,
                Name = "Ольга",
                Telephone = "+7(965)805-90-04",
                Email = "lovusuddeuyou-5103@yopmail.com",
                Adress = "Каменноостровский 23"
            });

            suppliersList.Add(new Supplier
            {
                ID_Suppliers = 4,
                Name = "Елена",
                Telephone = "+7(965)588-01-85",
                Email = "tremmacuvewou-5259@yopmail.com",
                Adress = "Озерной 2-4"
            });

            SuppliersDataGrid.ItemsSource = suppliersList;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin = new admin();
            admin.Show();
            this.Close();
        }

        private void SuppliersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Supplier newSupplier = new Supplier
            {
                ID_Suppliers = suppliersList.Count > 0 ? suppliersList.Max(s => s.ID_Suppliers) + 1 : 1,
                Name = "Новый поставщик",
                Telephone = "",
                Email = "",
                Adress = ""
            };

            suppliersList.Add(newSupplier);

            SuppliersDataGrid.SelectedItem = newSupplier;
            SuppliersDataGrid.ScrollIntoView(newSupplier);
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;

            Supplier supplierToDelete = deleteButton.DataContext as Supplier;

            if (supplierToDelete != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить поставщика: {supplierToDelete.Name} (ID: {supplierToDelete.ID_Suppliers})?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    suppliersList.Remove(supplierToDelete);
                }
            }
        }
    }
}