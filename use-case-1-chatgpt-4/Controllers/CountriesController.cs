using Microsoft.AspNetCore.Mvc;
using use_case_1_chatgpt_4.Dto;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace use_case_1_chatgpt_4.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CountriesController : ControllerBase
{
    private const string BASE_URL = "https://restcountries.com/v3.1/";

    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public async Task<IEnumerable<Country>> Get(string filterByName, string sort, int? takeFirst = null)
    {
        var result = Array.Empty<Country>();
        var countries =  (await GetAllCountriesAsync())
            .Where(c => filterByName != null?  c.Name.Common.Contains(filterByName, StringComparison.InvariantCultureIgnoreCase): true);

        return countries;
    }

    private async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(BASE_URL);
                var response = await client.GetAsync("all");

                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();

                return  JsonConvert.DeserializeObject<IEnumerable<Country>>(jsonContent);
            }
            catch (Exception e)
            {
                // You can handle exceptions here as necessary, for example:
                Console.WriteLine($"Request error: {e.Message}");

                return Array.Empty<Country>();
            }
        }
    }
}
