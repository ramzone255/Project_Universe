using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Contractor_Company;
using Project_Universe.Frontend.src.Data.Entities.Customer_Company;
using Project_Universe.Frontend.src.Data.Entities.Entities_Contain;
using Project_Universe.Frontend.src.Data.Entities.Post;
using Project_Universe.Frontend.src.Data.Entities.Priority;
using Project_Universe.Frontend.src.Data.Entities.Project;
using Project_Universe.Frontend.src.Data.Entities.Status;
using Project_Universe.Frontend.src.Data.Entities.Task_Entity;
using Project_Universe.Frontend.src.Data.Entities.Task_Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Frontend.src.Data.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7248/") // Связь с Backend
            };
        }

        public async Task<User> SignIn(string User_name, string User_password)
        {
            var loginData = new { user_name = User_name, user_password = User_password };
            var response = await _httpClient.PostAsJsonAsync("api/User/SignIn", loginData);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        // Staff Entity

        public async Task<List<Staff>> GetStaffList()
        {
            var response = await _httpClient.GetAsync("api/Staff/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<StaffContain>();
            return result?.staff ?? new List<Staff>();

        }

        public async Task CreateStaff(Staff staff)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Staff/Create", staff);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStaff(Staff staff)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Staff/Update/{staff.id_staff}", staff);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStaff(int id_staff)
        {
            var response = await _httpClient.DeleteAsync($"api/Staff/Delete/{id_staff}");
            response.EnsureSuccessStatusCode();
        }

        // Post Entity

        public async Task<List<Post>> GetPostList()
        {
            var response = await _httpClient.GetAsync("api/Post/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PostContain>();
            return result?.post ?? new List<Post>();

        }

        // Priority Entity

        public async Task<List<Priority>> GetPriorityList()
        {
            var response = await _httpClient.GetAsync("api/Priority/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PriorityContain>();
            return result?.priority ?? new List<Priority>();

        }

        // Status Entity

        public async Task<List<Status>> GetStatusList()
        {
            var response = await _httpClient.GetAsync("api/Status/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<StatusContain>();
            return result?.status ?? new List<Status>();

        }

        // Contractor_Company Entity

        public async Task<List<Contractor_Company>> GetContractor_CompanyList()
        {
            var response = await _httpClient.GetAsync("api/Contractor_Company/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Contractor_CompanyContain>();
            return result?.contractor_company ?? new List<Contractor_Company>();

        }

        // Customer_Company Entity 

        public async Task<List<Customer_Company>> GetCustomer_CompanyList()
        {
            var response = await _httpClient.GetAsync("api/Customer_Company/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Customer_CompanyContain>();
            return result?.customer_company ?? new List<Customer_Company>();

        }

        // Task Entity

        public async Task<List<Task_Entity>> GetTaskList()
        {
            var response = await _httpClient.GetAsync("api/Task/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Task_EntityContain>();
            return result?.task ?? new List<Task_Entity>();

        }

        public async Task CreateTask(Task_Entity task_entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Task/Create", task_entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTask(Task_Entity task_entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Task/Update/{task_entity.id_task}", task_entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTask(int id_task)
        {
            var response = await _httpClient.DeleteAsync($"api/Task/Delete/{id_task}");
            response.EnsureSuccessStatusCode();
        }

        // Task_Staff Entity

        public async Task<List<Task_Staff>> GetTask_StaffList()
        {
            var response = await _httpClient.GetAsync("api/Task_Staff/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Task_StaffContain>();
            return result?.task_staff ?? new List<Task_Staff>();

        }

        public async Task CreateTask_Staff(Task_Staff task_staff_entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Task_Staff/Create", task_staff_entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTask_Staff(Task_Staff task_staff_entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Task_Staff/Update/{task_staff_entity.id_task_staff}", task_staff_entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTask_Staff(int id_task_staff)
        {
            var response = await _httpClient.DeleteAsync($"api/Task_Staff/Delete/{id_task_staff}");
            response.EnsureSuccessStatusCode();
        }

        // Project Entity

        public async Task<List<Project>> GetProjectList()
        {
            var response = await _httpClient.GetAsync("api/Project/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ProjectContain>();
            return result?.project ?? new List<Project>();

        }

        public async Task CreateProject(Project project)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Project/Create", project);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProject(Project project)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/Update/{project.id_project}", project);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProject(int id_project)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/Delete/{id_project}");
            response.EnsureSuccessStatusCode();
        }
    }
}
