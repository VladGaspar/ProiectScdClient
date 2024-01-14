using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SCRDesktopApp
{
    internal class EmployeeService
    {
        static HttpClient client = new HttpClient();
        private string token;
        public void createConnection()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = null;

            // Set the Bearer token in the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);

            // Send the GET request
            HttpResponseMessage response = client.GetAsync("api/employee/getAll").Result;

            // Reset the Authorization header to its default state
            client.DefaultRequestHeaders.Authorization = null;

            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                
                employees = JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees;
            }

            return null;
        }

        public string login() {
            LoginDto loginDto = new LoginDto("admin", "admin");

            // Serialize the User object to JSON
            string jsonUser = JsonSerializer.Serialize(loginDto);
            Console.WriteLine(loginDto.username +" "+loginDto.password);
            // Create the request content with the serialized User object
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = client.PostAsync("api/auth/login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.TryGetValues("Authorization", out IEnumerable<string> headerValues))
                {
                    // Extract the token from the header
                    this.token = headerValues.FirstOrDefault();

                    const string bearerPrefix = "Bearer ";
                    this.token = this.token.Substring(bearerPrefix.Length);

                    // You might need to do additional processing here if the token comes with a prefix like "Bearer"
                    // For example, if the header is "Bearer <token>", you'll need to remove the "Bearer " part.

                    return this.token;
                }
            }

            return null;
        }

        public List<Department> getDepartments()
        {
            List<Department> departments = null;

            // Set the Bearer token in the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);

            // Send the GET request
            HttpResponseMessage response = client.GetAsync("api/department/getAll").Result;

            // Reset the Authorization header to its default state
            client.DefaultRequestHeaders.Authorization = null;

            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;

                departments = JsonSerializer.Deserialize<List<Department>>(resultString);
                return departments;
            }

            return null;
        }

        public List<Employee> getEmployeesByDepartment(int departmentId)
        {
            List<Employee> employees = null;

            // Set the Bearer token in the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);

            // Send the GET request
            HttpResponseMessage response = client.GetAsync($"api/employee/getByDepartment/{departmentId}").Result;

            // Reset the Authorization header to its default state
            client.DefaultRequestHeaders.Authorization = null;

            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;

                employees = JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees;
            }

            return null;
        }

        public List<Department> getAllByNumber(int employeeThreshold)
        {
            List<Department> departments = null;

            // Set the Bearer token in the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);

            // Send the GET request
            HttpResponseMessage response = client.GetAsync($"api/department/getByEmployeeNumber/{employeeThreshold}").Result;

            // Reset the Authorization header to its default state
            client.DefaultRequestHeaders.Authorization = null;

            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;

                departments = JsonSerializer.Deserialize<List<Department>>(resultString);
                return departments;
            }

            return null;
        }
    }
}
