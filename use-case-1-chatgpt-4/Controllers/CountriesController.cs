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
    public async Task<IEnumerable<Country>> Get(
        string filterByName = null,
        short? filterByPopulation = null,
        string sort = null,
        int? takeFirst = null)
    {
        var countries =  await GetAllCountriesAsync();

        if (filterByName != null) {
            countries = countries.Where(c => c.Name.Common.Contains(filterByName, StringComparison.InvariantCultureIgnoreCase));
        }

        if (filterByPopulation.HasValue) {
            long filterCriterion = filterByPopulation.Value * 1_000_000;

            countries = countries.Where(c => c.Population < filterCriterion);
        }

        if (sort.Equals("ascend", StringComparison.InvariantCultureIgnoreCase)) {
            countries = countries.OrderBy(c => c.Name.Common);
        }
        else if (sort.Equals("descend", StringComparison.InvariantCultureIgnoreCase)) {
            countries = countries.OrderByDescending(c => c.Name.Common);
        }

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
