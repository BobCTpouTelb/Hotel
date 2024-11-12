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
using Hotel.View.Pages;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
            // Открытие страницы пользователей по умолчанию
            MainFrame.Navigate(new UsersPage());
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            // Открытие страницы пользователей
            MainFrame.Navigate(new UsersPage());
        }

        private void roomsBTN_Click(object sender, RoutedEventArgs e)
        {
            // Открытие страницы номеров
            MainFrame.Navigate(new RoomsPage());
        }
    }
}
