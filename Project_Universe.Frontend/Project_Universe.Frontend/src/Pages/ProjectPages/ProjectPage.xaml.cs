using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Project;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.Project_TaskPages;
using Project_Universe.Frontend.src.Pages.StaffPages;
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

namespace Project_Universe.Frontend.src.Pages.ProjectPages
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private readonly ApiService _apiService;

        private List<Project> _allProject;
        public ProjectPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadProject();
        }

        private async Task LoadProject()
        {
            try
            {
                _allProject = await _apiService.GetProjectList();
                ProjectListView.ItemsSource = _allProject.OrderByDescending(x => x.id_priority);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки проектов: {ex.Message}");
            }
        }

        private void TaskClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskPage());
        }

        private void StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is Project selectedProject)
            {
                NavigationService.Navigate(new ProjectCommandsPage(selectedProject));
            }
            else
            {
                MessageBox.Show("Выберите проект для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is Project selectedProject)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить проект {selectedProject.name_project}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteProject(selectedProject.id_project);
                        MessageBox.Show("Проект успешно удален.");
                        await LoadProject();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении проекта: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите проект для удаления.");
            }
        }

        private void Project_TaskClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Project_TaskPage());
        }
    }
}
