using Hotel.AppData;
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

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void EntryBTN_Click(object sender, RoutedEventArgs e)
        {
            if(LoginTB.Text == string.Empty && PasswordPB.Password == string.Empty)
            {
                Feedback.Warning("Поля для ввода логина и пароля обязательны для заполнения. Введитите логин и пароль.");
            }
            else if(LoginTB.Text == string.Empty)
            {
                Feedback.Warning("Поле для ввода логина обязательно для заполнения. Введите логин.");
            }
            else if (PasswordPB.Password == string.Empty)
            {
                Feedback.Warning("Поле для ввода пароля обязательно для заполнения. Введите пароль.");
            }
            else
            {
                // Поля для ввода логина и пароля заполенены, требуется проверка введённых данных.
                App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTB.Text && user.Password == PasswordPB.Password);

                if(App.currentUser == null)
                {
                    Feedback.Error("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");
                }
                else if (App.currentUser.IsBlocked == false)
                {
                    Feedback.Error("Вы заблокированы. Обратитесь к администратору.");
                }
                else if (App.currentUser.IsActivated == false)
                {
                    ChagePasswordWindow chagePasswordWindow = new ChagePasswordWindow();
                    chagePasswordWindow.Show();
                    Hide();
                }
                else
                {
                    Feedback.Info("Вы успешно авторизовались.");
                    
                    switch (App.currentUser.RoleId)
                    {
                        case 1:
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            break;
                        case 2:
                            break;
                    }

                    Close();
                }
            }
        }
    }
}
