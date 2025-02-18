using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Contractor_Company;
using Project_Universe.Frontend.src.Data.Entities.Customer_Company;
using Project_Universe.Frontend.src.Data.Entities.Priority;
using Project_Universe.Frontend.src.Data.Entities.Project;
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

namespace Project_Universe.Frontend.src.Pages.ProjectPages
{
    /// <summary>
    /// Логика взаимодействия для ProjectCommandsPage.xaml
    /// </summary>
    public partial class ProjectCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Project _project;
        private List<Contractor_Company> _allContractor;
        private List<Customer_Company> _allCustomer;
        private List<Priority> _allPriority;
        public ProjectCommandsPage(Project project = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _project = project ?? new Project();
            LoadEntity();

            TBoxName.Text = _project.name_project;
            TBoxDate.Text = _project.end_date_project.ToString();
            CmbSelectContractor.Text = _project.id_contractor_company.ToString();
            CmbSelectCustomer.Text = _project.id_customer_company.ToString();
            CmbSelectPriority.Text = _project.id_priority.ToString();
        }

        private async Task LoadEntity()
        {
            try
            {
                _allContractor = await _apiService.GetContractor_CompanyList();
                CmbSelectContractor.ItemsSource = _allContractor.ToList();
                CmbSelectContractor.SelectedValuePath = "id_contractor_company";
                CmbSelectContractor.DisplayMemberPath = "name_contractor_company";

                _allCustomer = await _apiService.GetCustomer_CompanyList();
                CmbSelectCustomer.ItemsSource = _allCustomer.ToList();
                CmbSelectCustomer.SelectedValuePath = "id_customer_company";
                CmbSelectCustomer.DisplayMemberPath = "name_customer_company";

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

        private async void ProjectSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _project.name_project = TBoxName.Text;
                _project.id_contractor_company = (int)CmbSelectContractor.SelectedValue;
                _project.id_customer_company = (int)CmbSelectCustomer.SelectedValue;
                _project.id_priority = (int)CmbSelectPriority.SelectedValue;
                _project.end_date_project = DateTime.Parse(TBoxDate.Text);
                _project.start_date_project = DateTime.Now;

                if (_project.id_project == 0)
                {
                    await _apiService.CreateProject(_project);
                    MessageBox.Show("Проект успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateProject(_project);
                    MessageBox.Show("Проект успешно обновлен");
                }
                NavigationService.Navigate(new ProjectPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранеии проекта: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectPage());
        }
    }
}
