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
using Hotel.AppData;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChagePasswordWindow.xaml
    /// </summary>
    public partial class ChagePasswordWindow : Window
    {
        public ChagePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePasswordBTN_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }

        public void ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPasswordPB.Password) || 
                string.IsNullOrEmpty(NewPasswordPB.Password) || 
                string.IsNullOrEmpty(AcceptNewPasswordPB.Password))
            {
                Feedback.Warning("Все поля обязательны для заполнения! Заполните каждое поле!");
            }
            else if (OldPasswordPB.Password != App.currentUser.Password)
            {
                Feedback.Error("Неверно введен текущий пароль! Попробуйте снова");
            }
            else if (NewPasswordPB.Password != AcceptNewPasswordPB.Password)
            {
                Feedback.Error("Новые пароли не совпадают! Попробуйте снова");
            }
            else if (OldPasswordPB.Password == NewPasswordPB.Password)
            {
                Feedback.Error("Старый и новый пароль совпадают! Придумайте новый пароль.");
            }
            else
            {
                App.currentUser.Password = NewPasswordPB.Password;
                App.currentUser.IsActivated = true;

                App.context.SaveChanges();

                Feedback.Info("Пароль успешно изменен");

                Close();
            }
        }
    }
}
