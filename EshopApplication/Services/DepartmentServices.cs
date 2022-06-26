using Eshop.Models.ViewModel;

namespace EshopApplication.Services
{

    public interface IDepartmentService
    {
        Task<List<ViewModelDepartment>> GetAll();
        Task<ViewModelDepartment> Get(long Id);
        Task<ViewModelDepartment> Add(ViewModelDepartment model);
        Task<ViewModelDepartment> Update(ViewModelDepartment model);
        Task<bool> Remove(long Id);
    }

    public class DepartmentServices : IDepartmentService
    {

        HttpClient http;
        public DepartmentServices(HttpClient _http)
        {
            this.http = _http;
        }


        public async Task<List<ViewModelDepartment>> GetAll()
        {
            return await http.GetFromJsonAsync<List<ViewModelDepartment>>("api/Department");
        }


        public async Task<ViewModelDepartment> Get(long Id)
        {
            var response = await http.GetFromJsonAsync<ViewModelDepartment>("api/Department/" + Id);
            return response;
            
        }

      

        public async Task<ViewModelDepartment> Add(ViewModelDepartment model)
        {
            var response = await http.PostAsJsonAsync("api/Department", model);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //return await response.Content.ReadFromJsonAsync<ViewModelDepartment>();

                return await response.Content.ReadFromJsonAsync<ViewModelDepartment>();


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
            var response= await http.DeleteAsync("api/Department/"+ Id);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ViewModelDepartment> Update(ViewModelDepartment model)
        {
            var response= await http.PutAsJsonAsync("api/Department/"+ model.ID , model);

            if( response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ViewModelDepartment>();
            }
            else
            {
                return null;
            }


        }
    }
}
