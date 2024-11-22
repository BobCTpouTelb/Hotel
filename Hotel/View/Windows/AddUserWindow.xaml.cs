using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
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
using Hotel.AppData;
using Hotel.Model;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addUserBTN_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        public void AddUser()
        {
            try
            {
                User newUser = new User()
                {
                    Fullname = FullNameTB.Text,
                    Login = LoginTB.Text,
                    Password = PasswordPB.Password,
                    RegistrationDate = DateTime.Now.Date,
                    IsActivated = false,
                    IsBlocked = false,
                    RoleId = 2
                };

                App.context.User.Add(newUser);
                App.context.SaveChanges();

                Feedback.Info("Пользователь успешно добавлен");

                DialogResult = true;
            }
            catch (DbUpdateException exception)
            {
                Feedback.Error($"Пользователь с таким логином уже существует. {exception.Message}");
                DialogResult = false;
            }
            catch (Exception exception)
            {
                Feedback.Error($"Ошибка при добавлении пользователя. {exception.Message}");
            }
        }
    }
}
