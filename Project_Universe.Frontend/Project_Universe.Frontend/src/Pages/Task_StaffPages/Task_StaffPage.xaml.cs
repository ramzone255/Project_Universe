using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Entities.Task_Staff;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.TaskPages;
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

namespace Project_Universe.Frontend.src.Pages.Task_StaffPages
{
    /// <summary>
    /// Логика взаимодействия для Task_StaffPage.xaml
    /// </summary>
    public partial class Task_StaffPage : Page
    {
        private readonly ApiService _apiService;

        private List<Task_Staff> _allTask_Staff;
        public Task_StaffPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadTask_Staff();
        }

        private async Task LoadTask_Staff()
        {
            try
            {
                _allTask_Staff = await _apiService.GetTask_StaffList();
                Task_StaffListView.ItemsSource = _allTask_Staff.OrderBy(x => x.id_task);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки прикреплений: {ex.Message}");
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task_StaffCommandsPage());
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Task_StaffListView.SelectedItem is Task_Staff selectedTask_Staff)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите прикрепление задания {selectedTask_Staff.name_task} для {selectedTask_Staff.lastname_staff}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteTask_Staff(selectedTask_Staff.id_task_staff);
                        MessageBox.Show("Прикрепление успешно удалено.");
                        await LoadTask_Staff();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении прикрепления: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите прикрепление для удаления.");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (Task_StaffListView.SelectedItem is Task_Staff selectedTask_Staff)
            {
                NavigationService.Navigate(new Task_StaffCommandsPage(selectedTask_Staff));
            }
            else
            {
                MessageBox.Show("Выберите прикрепление для редактирования");
            }
        }
    }
}
