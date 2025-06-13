using dog_api.Models;
using System.Text.Json;

namespace dog_api.Services
{
    public class DogApiService
    {
        private readonly HttpClient _http;

        public DogApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<DogImageResponse> GetBreedImage(string breed, string subBreed = "")
        {
            var response = await _http.GetAsync($"https://dog.ceo/api/breed/{breed}/images/random");
            if (subBreed != "")
            {
                response = await _http.GetAsync($"https://dog.ceo/api/breed/{subBreed}/{breed}/images/random");
            }
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DogImageResponse>(content);
            return result!;
        }
        public async Task<BreedListResponse> GetAllBreedsAsync()
        {
            var response = await _http.GetAsync("https://dog.ceo/api/breeds/list/all");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BreedListResponse>(content);
            return result!;
        }
    }
}

