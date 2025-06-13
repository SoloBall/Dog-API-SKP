namespace dog_api.Models
{
    public class CombinedResponse
    {
        public BreedListResponse breeds { get; set; }
        public DogImageResponse dog { get; set; }
    }
}
