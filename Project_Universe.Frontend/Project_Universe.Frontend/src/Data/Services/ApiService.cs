using Project_Universe.Frontend.src.Data.Entities;
using Project_Universe.Frontend.src.Data.Entities.Entities_Contain;
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

        internal async Task<List<Staff>> GetStaffList()
        {
            var response = await _httpClient.GetAsync("api/Staff/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<StaffContain>();
            return result?.staff ?? new List<Staff>();

        }

    }
}
