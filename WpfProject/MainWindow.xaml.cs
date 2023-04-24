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
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.WebModels;
using WpfProject.Windows;

namespace WpfProject
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

        private void Registration_Button(object sender, MouseButtonEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Close();
        }

        private void MainMenu_Button(object sender, RoutedEventArgs e)
        {
            MainMenuGuest m = new MainMenuGuest();
            MessageBox.Show("Вы вошли как гость.");
            m.Show();
            this.Close();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (showPassToggle.IsChecked == true)
            {
                passBox_passwordhidden.Text = passBox_password.Password;
                passBox_passwordhidden.Visibility = Visibility.Visible;
                passBox_password.Visibility = Visibility.Collapsed;
            }
            else
            {
                passBox_password.Password = passBox_passwordhidden.Text;
                passBox_password.Visibility = Visibility.Visible;
                passBox_passwordhidden.Visibility = Visibility.Collapsed;
            }
        }

        private async void btn_sign(object sender, RoutedEventArgs e)
        {

            var json = await HttpApi.Post("Users", "Auth", new Auth { Login = textBox_login.Text, Password = passBox_password.Password });
            User result = HttpApi.Deserialize<User>(json);


            {
                
                 if (result.PostId == 3)
                {
                    MainMenuEmployee m = new MainMenuEmployee();
                    m.Show();
                    this.Close();
                }

                else if (result.PostId == 4)
                {
                    MainMenu m = new MainMenu();
                    m.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Неверно!", "Аккаунта не существет!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
