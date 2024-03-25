using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            MesBox.Text = "";

            LoginBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            EmailBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            PasswordBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            PasswordBox2.BorderBrush = new SolidColorBrush(Colors.Gray);

            var login = LoginBox.Text;

            var pass = PasswordBox.Text;

            var pass2 = PasswordBox2.Text;

            var email = EmailBox.Text;

            var context = new AppDbContext();


            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Такой пользователь уже зарегестрирован";
            }
            else if (login.Length == 0)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Логин не может быть пустым";
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(mail\.ru|gmail\.ru)$"))
            {
                EmailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Пожалуйста, введите электронную почту в формате '@mail.ru' или '@gmail.ru'";
            }
           else if (email.Length == 0)
            {
                EmailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Email не может быть пустым";             
            }
            else if (pass.Length < 8)
            {

                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Пароль не может быть меньше 8 символов";              
            }
            else if (!Regex.IsMatch(pass, @"[!@#$%^&*()_+]"))
            {

                PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Пароль должен содержать спец. символы";               
            }
            else if (pass != pass2)
            {

                PasswordBox2.BorderBrush = new SolidColorBrush(Colors.Red);
                MesBox.Text = "";
                MesBox.Text = "Пароли не совпадают";              
            }
            else
            {
                var user = new User { Login = login, Password = pass, Email = email};
                context.Users.Add(user);
                context.SaveChanges();
                MesBox.Text = "";
                MesBox.Text = "Вы успешно зарегистрировались";              
            }
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
