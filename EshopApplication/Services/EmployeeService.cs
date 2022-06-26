using Eshop.Models.ViewModel;

namespace EshopApplication.Services
{
    public interface IEmployeeService
    {
        Task<List<ViewModelEmployee>> GetAll();
        Task<ViewModelEmployee> Get(long Id);
        Task<ViewModelEmployee> Add(ViewModelEmployee model);
        Task<ViewModelEmployee> Update(ViewModelEmployee model);
        Task<bool> Remove(long Id);
     }
    public class EmployeeService : IEmployeeService
    {
        HttpClient http;
        public EmployeeService(HttpClient _http)
        {
            this.http = _http;
        }
        public async Task<List<ViewModelEmployee>> GetAll()
        {
            return await http.GetFromJsonAsync<List<ViewModelEmployee>>("api/Employee");
        }
        public async Task<ViewModelEmployee> Get(long Id)
        {
            var response = await http.GetFromJsonAsync<ViewModelEmployee>("api/Employee/" + Id);
            return response;
        }
        public async Task<ViewModelEmployee> Add(ViewModelEmployee model)
        {
            var response = await http.PostAsJsonAsync("api/Employee", model);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ViewModelEmployee>();

                // return JsonConvert.DeserializeObject<AppsViewModel>(response.Content.ReadAsStringAsync().Result);

                //return await result.Content.ReadFromJsonAsync<UserToken>();
            }
            else
            {
                return null;
            }
        }
        public async Task<ViewModelEmployee> Update(ViewModelEmployee model)
        {
            var response = await http.PutAsJsonAsync("api/Employee/" + model.Id, model);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ViewModelEmployee>();

                // return JsonConvert.DeserializeObject<AppsViewModel>(response.Content.ReadAsStringAsync().Result);

                //return await result.Content.ReadFromJsonAsync<UserToken>();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Remove(long Id)
        {
            var response = await http.DeleteAsync("api/Employee/" + Id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
