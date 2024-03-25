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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_ClickEye(object sender, RoutedEventArgs e)
        {
                    
        }
        bool p = true;

        private void glaz_Click(object sender, RoutedEventArgs e)
        {
            if (p)
            {

                PasswordBox.Visibility = Visibility.Collapsed;
                glazz.Source = new BitmapImage(new Uri("Recources/15.png", UriKind.Relative));
                TextBox1.Text = PasswordBox.Password;
                TextBox1.Visibility = Visibility.Visible;

                p = false;
            }
            else
            {

                PasswordBox.Visibility = Visibility.Visible;
                glazz.Source = new BitmapImage(new Uri("Recources/13.png", UriKind.Relative));
                PasswordBox.Password = TextBox1.Text;
                TextBox1.Visibility = Visibility.Collapsed;
                p = true;
            }
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var password = PasswordBox.Password;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null)
            {
                MesBox.Text = "Не правильный логин или пароль";               
            }           
            this.Hide();
            Priv priv = new Priv();
            priv.Show();
            priv.Name.Text = "Салам, " + LoginBox.Text;
        }

        private void zareg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg reg = new Reg();
            reg.Show();
        }
    }
}
