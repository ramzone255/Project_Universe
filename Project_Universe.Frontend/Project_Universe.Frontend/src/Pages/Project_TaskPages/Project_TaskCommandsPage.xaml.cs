using Project_Universe.Frontend.src.Data.Entities.Project;
using Project_Universe.Frontend.src.Data.Entities.Project_Task;
using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Entities.Task_Staff;
using Project_Universe.Frontend.src.Data.Services;
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
    /// Логика взаимодействия для Project_TaskCommandsPage.xaml
    /// </summary>
    public partial class Project_TaskCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Project_Task _projectTask;
        private List<Task_Entity> _allTask;
        private List<Project> _allProject;
        public Project_TaskCommandsPage(Project_Task project_task = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _projectTask = project_task ?? new Project_Task();
            LoadEntities();

            CmbSelectTask.Text = _projectTask.id_task.ToString();
            CmbSelectProject.Text = _projectTask.id_project.ToString();

        }

        private async Task LoadEntities()
        {
            try
            {
                _allTask = await _apiService.GetTaskList();
                CmbSelectTask.ItemsSource = _allTask.ToList();
                CmbSelectTask.SelectedValuePath = "id_task";
                CmbSelectTask.DisplayMemberPath = "name_task";

                _allProject = await _apiService.GetProjectList();
                CmbSelectProject.ItemsSource = _allProject.ToList();
                CmbSelectProject.SelectedValuePath = "id_project";
                CmbSelectProject.DisplayMemberPath = "name_project";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сущностей: {ex.Message}");
            }
        }

        private async void Project_TaskSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _projectTask.id_task = (int)CmbSelectTask.SelectedValue;
                _projectTask.id_project = (int)CmbSelectProject.SelectedValue;

                if (_projectTask.id_project_task == 0)
                {
                    await _apiService.CreateProject_Task(_projectTask);
                    MessageBox.Show("Прикрепление успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateProject_Task(_projectTask);
                    MessageBox.Show("Прикрепление успешно обновлен");
                }
                NavigationService.Navigate(new Project_TaskPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранеии прикрепления: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Project_TaskPage());
        }
    }
}
