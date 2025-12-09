using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public client()
        {
            InitializeComponent();
            LoadUsersData();
        }

        private void LoadUsersData()
        {
            List<User> users = new List<User>
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

            UsersDataGrid.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             admin = new admin();
             admin.Show();
             this.Close();
        }

      
    }
}