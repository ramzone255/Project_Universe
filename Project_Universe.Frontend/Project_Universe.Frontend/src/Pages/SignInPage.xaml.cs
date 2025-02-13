using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Services;
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

namespace Project_Universe.Frontend.src.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private readonly ApiService _apiService;
        public SignInPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            string User_name = TBoxUserName.Text;
            string User_password = TBoxUserPassword.Text;

                var user = await _apiService.SignIn(User_name, User_password);
                if (user != null)
                {
                    UserSession.CurrentUser = user;
                    NavigationService.Navigate(new StaffPage());
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            
        }
    }
}
