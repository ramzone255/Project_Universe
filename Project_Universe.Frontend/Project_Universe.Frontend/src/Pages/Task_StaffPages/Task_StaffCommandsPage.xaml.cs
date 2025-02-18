using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Entities.Task_Staff;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.TaskPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Логика взаимодействия для Task_StaffCommandsPage.xaml
    /// </summary>
    public partial class Task_StaffCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Task_Staff _taskStaff;
        private List<Staff> _allStaff;
        private List<Task_Entity> _allTask;
        public Task_StaffCommandsPage(Task_Staff task_staff = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _taskStaff = task_staff ?? new Task_Staff();
            LoadEntities();

            CmbSelectTask.Text = _taskStaff.id_task.ToString();
            CmbSelectStaff.Text = _taskStaff.id_staff.ToString();
        }

        private async Task LoadEntities()
        {
            try
            {
                _allTask = await _apiService.GetTaskList();
                CmbSelectTask.ItemsSource = _allTask.ToList();
                CmbSelectTask.SelectedValuePath = "id_task";
                CmbSelectTask.DisplayMemberPath = "name_task";

                _allStaff = await _apiService.GetStaffList();
                CmbSelectStaff.ItemsSource = _allStaff.ToList();
                CmbSelectStaff.SelectedValuePath = "id_staff";
                CmbSelectStaff.DisplayMemberPath = "lastname_staff";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сущностей: {ex.Message}");
            }
        }

        private async void Task_StaffSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _taskStaff.id_task = (int)CmbSelectTask.SelectedValue;
                _taskStaff.id_staff = (int)CmbSelectStaff.SelectedValue;

                if (_taskStaff.id_task_staff == 0)
                {
                    await _apiService.CreateTask_Staff(_taskStaff);
                    MessageBox.Show("Прикрепление успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateTask_Staff(_taskStaff);
                    MessageBox.Show("Прикрепление успешно обновлен");
                }
                NavigationService.Navigate(new Task_StaffPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранеии прикрепления: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task_StaffPage());
        }
    }
}
