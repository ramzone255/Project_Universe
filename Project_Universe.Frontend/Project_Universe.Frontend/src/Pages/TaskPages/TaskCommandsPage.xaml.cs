using Project_Universe.Frontend.src.Data.Entities.Post;
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
using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Entities.Status;
using Project_Universe.Frontend.src.Data.Entities.Priority;

namespace Project_Universe.Frontend.src.Pages.TaskPages
{
    /// <summary>
    /// Логика взаимодействия для TaskCommandsPage.xaml
    /// </summary>
    public partial class TaskCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Task_Entity _task;
        private List<Status> _allStatus;
        private List<Priority> _allPriority;
        public TaskCommandsPage(Task_Entity task = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _task = task ?? new Task_Entity();
            LoadEntities();

            TBoxName.Text = _task.name_task;
            TBoxComment.Text = _task.comment;
            CmbSelectStatus.Text = _task.id_status.ToString();
            CmbSelectPriority.Text = _task.id_priority.ToString();
        }

        private async Task LoadEntities()
        {
            try
            {
                _allStatus = await _apiService.GetStatusList();
                CmbSelectStatus.ItemsSource = _allStatus.ToList();
                CmbSelectStatus.SelectedValuePath = "id_status";
                CmbSelectStatus.DisplayMemberPath = "name_status";

                _allPriority = await _apiService.GetPriorityList();
                CmbSelectPriority.ItemsSource = _allPriority.ToList();
                CmbSelectPriority.SelectedValuePath = "id_priority";
                CmbSelectPriority.DisplayMemberPath = "name_priority";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сущностей: {ex.Message}");
            }
        }

        private async void TaskSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _task.name_task = TBoxName.Text;
                _task.comment = TBoxComment.Text;
                _task.id_status = (int)CmbSelectStatus.SelectedValue;
                _task.id_priority = (int)CmbSelectPriority.SelectedValue;

                if (_task.id_task == 0)
                {
                    await _apiService.CreateTask(_task);
                    MessageBox.Show("Задание успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateTask(_task);
                    MessageBox.Show("Задание успешно обновлен");
                }
                NavigationService.Navigate(new TaskPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранеии задания: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskPage());
        }
    }
}
