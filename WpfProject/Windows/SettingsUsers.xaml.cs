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
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для SettingsUsers.xaml
    /// </summary>
    public partial class SettingsUsers : Window
    {
        public SettingsUsers()
        {
            InitializeComponent();
        }

        private async void Submit(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Users", "SaveUser", new User
            {
                FirstName = txt_Name.Text,
                LastName = txt_LastName.Text,
                PatronomycName = txt_PatronomycName.Text,
                PhoneNumber = long.Parse(txt_Phone.Text),
                Mail = txt_Email.Text,
                Login = txt_Login.Text,
                Password = txt_Password.Text,                
            });
            User result = HttpApi.Deserialize<User>(json);


            if (result.LastName != null || result.FirstName != null)
            {
                MessageBox.Show("Успешно сохранено!");

                SettingsUsers s = new SettingsUsers();
                s.Close();

            }           
            else
            {
                MessageBox.Show("Ошибка!", "Введены не все данные");
            }
        }

        private void DeleteAccount(object sender, RoutedEventArgs e)
        {



            MessageBox.Show("Удалилось");

            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        
    }
}
