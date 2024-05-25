using Newtonsoft.Json;
using PhotoGalleryApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoGallery.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "https://jsonplaceholder.typicode.com/photos";

        public PhotoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Photo>> GetPhotosAsync(int page, int pageSize)
        {
            var response = await _httpClient.GetStringAsync($"{apiUrl}?_page={page}&_limit={pageSize}");
            return JsonConvert.DeserializeObject<List<Photo>>(response);
        }

        public async Task<int> GetTotalPhotosAsync()
        {
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Photo>>(responseBody).Count;
        }
    }
}
