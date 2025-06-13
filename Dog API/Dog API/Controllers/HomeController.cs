using dog_api.Models;
using dog_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace dog_api.Controllers
{
    public class HomeController : Controller
    {
        private DogApiService _dogApi;

        public HomeController(DogApiService dogApi)
        {
            _dogApi = dogApi;
        }
        public async Task<IActionResult> Index()
        {
            string breed = "affenpinscher";
            if (HttpContext.Request.QueryString.ToString() != "")
            {
                breed = HttpContext.Request.QueryString.ToString().Substring(7);
            }
            DogImageResponse dog = new();
            if (!string.IsNullOrEmpty(breed))
            {
                int subBreedIndex = breed.IndexOf("+");
                if (subBreedIndex != -1)
                {
                    dog = await _dogApi.GetBreedImage(breed.Substring(0, subBreedIndex), breed.Substring(subBreedIndex + 1));
                }
                else
                {
                    dog = await _dogApi.GetBreedImage(breed);
                }

            }
            Console.WriteLine(HttpContext.Request.QueryString); 
            var breeds = await _dogApi.GetAllBreedsAsync();
            CombinedResponse combinedResponse = new CombinedResponse(); 
            combinedResponse.breeds = breeds;
            combinedResponse.dog = dog;
            return View(combinedResponse);
        }
    }
}
