using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.ProjectPages;
using Project_Universe.Frontend.src.Pages.StaffPages;
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

namespace Project_Universe.Frontend.src.Pages.TaskPages
{
    /// <summary>
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        private readonly ApiService _apiService;
        private List<Task_Entity> _allTask;
        public TaskPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadTask();
        }

        private async Task LoadTask()
        {
            try
            {
                _allTask = await _apiService.GetTaskList();
                TaskListView.ItemsSource = _allTask.OrderByDescending(x => x.id_priority);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач: {ex.Message}");
            }
        }

        private void StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }

        private void ProjectClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is Task_Entity selectedTask)
            {
                NavigationService.Navigate(new TaskCommandsPage(selectedTask));
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is Task_Entity selectedTask)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить задание {selectedTask.name_task}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteTask(selectedTask.id_task);
                        MessageBox.Show("Задание успешно удален.");
                        await LoadTask();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении задания: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите задание для удаления.");
            }
        }

        private void Task_StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task_StaffPage());
        }
    }
}
