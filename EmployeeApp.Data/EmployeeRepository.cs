using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EmployeeApp.Data.Models;

namespace EmployeeApp.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;
        public EmployeeRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "Employees");
            var response = await this._httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());
        }

    }
}
