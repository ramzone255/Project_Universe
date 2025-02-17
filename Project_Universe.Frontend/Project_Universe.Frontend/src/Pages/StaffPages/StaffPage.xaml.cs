using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.StaffPages;
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
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly ApiService _apiService;

        private List<Staff> _allStaff;
        public StaffPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadStaff();
        }

        private async Task LoadStaff()
        {
            try
            {
                _allStaff = await _apiService.GetStaffList();
                StaffListView.ItemsSource = _allStaff.OrderBy(x => x.id_post);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (StaffListView.SelectedItem is Staff selectedStaff)
            {
                NavigationService.Navigate(new StaffCommandsPage(selectedStaff));
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования");
            }
        }
    }
}
