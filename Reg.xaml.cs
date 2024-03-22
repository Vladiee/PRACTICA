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

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var pass = PasswordBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован");
                return;
            }

            if ((email.Text.Contains("@gmail.com") || email.Text.Contains("@mail.ru") || email.Text.Contains("@yandex.ru")) == false)
            {
                MessageBox.Show("Не верное название");
                return;
            }                     

            var user = new User { Login = login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались");

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
