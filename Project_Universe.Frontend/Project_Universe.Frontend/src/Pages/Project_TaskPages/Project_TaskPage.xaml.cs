using Project_Universe.Frontend.src.Data.Entities.Project_Task;
using Project_Universe.Frontend.src.Data.Entities.Task_Staff;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.ProjectPages;
using Project_Universe.Frontend.src.Pages.Task_StaffPages;
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

namespace Project_Universe.Frontend.src.Pages.Project_TaskPages
{
    /// <summary>
    /// Логика взаимодействия для Project_TaskPage.xaml
    /// </summary>
    public partial class Project_TaskPage : Page
    {
        private readonly ApiService _apiService;

        private List<Project_Task> _allProject_Task;
        public Project_TaskPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadProject_Task();
        }

        private async Task LoadProject_Task()
        {
            try
            {
                _allProject_Task = await _apiService.GetProject_TaskList();
                Project_TaskListView.ItemsSource = _allProject_Task.OrderBy(x => x.id_project);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки прикреплений: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Project_TaskCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (Project_TaskListView.SelectedItem is Project_Task selectedProject_Task)
            {
                NavigationService.Navigate(new Project_TaskCommandsPage(selectedProject_Task));
            }
            else
            {
                MessageBox.Show("Выберите прикрепление для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Project_TaskListView.SelectedItem is Project_Task selectedProject_Task)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите прикрепление проекта {selectedProject_Task.name_project} для {selectedProject_Task.name_task}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteProject_Task(selectedProject_Task.id_project_task);
                        MessageBox.Show("Прикрепление успешно удалено.");
                        await LoadProject_Task();
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
    }
}
