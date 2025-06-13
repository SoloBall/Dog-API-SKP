using dog_api.Models;
using dog_api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<DogImageResponse>();
builder.Services.AddHttpClient<CombinedResponse>();
builder.Services.AddHttpClient<BreedListResponse>();
builder.Services.AddHttpClient<DogApiService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
