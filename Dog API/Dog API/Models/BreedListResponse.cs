namespace dog_api.Models
{
    public class BreedListResponse
    {
        public Dictionary<string, string[]> message { get; set; }
        public string status { get; set; }
    }
}
