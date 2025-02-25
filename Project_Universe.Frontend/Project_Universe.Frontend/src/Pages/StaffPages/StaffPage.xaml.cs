﻿using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Services;
using Project_Universe.Frontend.src.Pages.ProjectPages;
using Project_Universe.Frontend.src.Pages.StaffPages;
using Project_Universe.Frontend.src.Pages.Task_StaffPages;
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
                int id_postUser = UserSession.CurrentUser.id_post;
                if (id_postUser > 1)
                {
                    AddButton.Visibility = Visibility.Hidden;
                    UpdateButton.Visibility = Visibility.Hidden;
                    DeleteButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    AddButton.Visibility = Visibility.Visible;
                    UpdateButton.Visibility = Visibility.Visible;
                    DeleteButton.Visibility = Visibility.Visible;
                }
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

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (StaffListView.SelectedItem is Staff selectedStaff)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {selectedStaff.lastname_staff} {selectedStaff.name_staff}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteStaff(selectedStaff.id_staff);
                        MessageBox.Show("Сотрудник успешно удален.");
                        await LoadStaff();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }

        private void ProjectClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectPage());
        }

        private void TaskClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskPage());
        }

        private void Task_StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task_StaffPage());
        }
    }
}
