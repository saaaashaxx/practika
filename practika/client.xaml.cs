using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel; // Добавляем для ObservableCollection
using System.Linq;
using Example; // ДОБАВЛЕНО: Необходимо для использования метода Max()

namespace practika
{
    public class User
    {
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Data_Of_Birth { get; set; }
        public int Role { get; set; }
    }

    public partial class client : Window
    {
        private Window admin;

        // КЛЮЧЕВОЕ ИЗМЕНЕНИЕ 1: Список пользователей делаем полем класса и используем ObservableCollection
        private ObservableCollection<User> usersList;

        public client()
        {
            InitializeComponent();
            LoadUsersData();
        }

        private void LoadUsersData()
        {
            // Инициализируем ObservableCollection
            usersList = new ObservableCollection<User>
            {
                new User
                {
                    ID_User = 1,
                    Login = "root",
                    Password = "root",
                    Email = "boimaddufemou-3774@yopmail.com",
                    Name = "Богдан",
                    Adress = "Набережная канала Грибоедова, 12",
                    Data_Of_Birth = "1990-05-05",
                    Role = 2
                },
                new User
                {
                    ID_User = 2,
                    Login = "queibaq",
                    Password = "112233",
                    Email = "queibaquiseike-6174@yopmail.com",
                    Name = "Наталья",
                    Adress = "Каменноостровский проспект, 26-28",
                    Data_Of_Birth = "2001-05-10",
                    Role = 1
                },
                new User
                {
                    ID_User = 3,
                    Login = "Lerysik",
                    Password = "Mp189756_",
                    Email = "heviniworo-9009@yopmail.com",
                    Name = "Валерия",
                    Adress = "Большой проспект В.О., 89",
                    Data_Of_Birth = "2002-11-04",
                    Role = 1
                },
                new User
                {
                    ID_User = 4,
                    Login = "Cucumblria",
                    Password = "123327QQ",
                    Email = "rakoibrannefrou-9531@yopmail.com",
                    Name = "Камелия",
                    Adress = "7-я Красноармейская 6-8",
                    Data_Of_Birth = "1989-03-12",
                    Role = 3
                },
                new User
                {
                    ID_User = 5,
                    Login = "RusBlind",
                    Password = "2007ggrr11",
                    Email = "yanaubruquime-5934@yopmail.com",
                    Name = "Яна",
                    Adress = "Маршала Жукова 56 к1",
                    Data_Of_Birth = "2000-07-16",
                    Role = 1
                },
                new User
                {
                    ID_User = 7,
                    Login = "GRISHA",
                    Password = "20090989_",
                    Email = "dudaceche-4986@yopmail.com",
                    Name = "Григорий",
                    Adress = "Щербакова 11",
                    Data_Of_Birth = "2004-11-12",
                    Role = 1
                }
            };

            // Привязываем ObservableCollection к DataGrid
            UsersDataGrid.ItemsSource = usersList;
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
            int newId = usersList.Count > 0 ? usersList.Max(u => u.ID_User) + 1 : 1;

            // Создаем новый объект пользователя с данными по умолчанию
            User newUser = new User
            {
                ID_User = newId,
                Login = "новый_логин",
                Password = "123",
                Email = "email@example.com",
                Name = "Новый пользователь",
                Adress = "Адрес по умолчанию",
                Data_Of_Birth = DateTime.Now.ToString("yyyy-MM-dd"),
                Role = 1 // Роль по умолчанию (например, клиент)
            };

            // Добавляем нового пользователя в ObservableCollection. DataGrid обновляется автоматически.
            usersList.Add(newUser);

            // Выделяем новую строку для удобства редактирования
            UsersDataGrid.SelectedItem = newUser;
            UsersDataGrid.ScrollIntoView(newUser);
        }
        // --------------------------------------------------------

        // РЕАЛИЗАЦИЯ ЛОГИКИ УДАЛЕНИЯ
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            // 1. Получаем объект Button, который был нажат
            Button deleteButton = sender as Button;

            // 2. Получаем объект User (пользователь), связанный с этой строкой DataGrid
            User userToDelete = deleteButton.DataContext as User;

            if (userToDelete != null)
            {
                // Диалоговое окно для подтверждения
                MessageBoxResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить пользователя: {userToDelete.Name} (ID: {userToDelete.ID_User})?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // 3. Удаляем объект из ObservableCollection.
                    // DataGrid автоматически обновится.
                    DbService.DeleteUser(userToDelete.ID_User);
                    usersList.Remove(userToDelete);
                }
            }
        }
    }
}