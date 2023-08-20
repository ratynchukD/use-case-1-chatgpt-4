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
        string name = null,
        short? population = null,
        string sortDirection = null,
        int? takeFirst = null)
    {
        var countries =  await GetAllCountriesAsync();

        countries = FilterByName(countries, name);
        countries = FilterByPopulation(countries, population);
        countries = SortByName(countries, sortDirection);
        countries = Paginate(countries, takeFirst);

        return countries;
    }

    private IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string name){
        if (!string.IsNullOrWhiteSpace(name)) {
            return countries.Where(c => c.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        return countries;
    }

    private IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, short? population){
        if (population.HasValue) {
            long filterCriterion = population.Value * 1_000_000;

            return countries.Where(c => c.Population < filterCriterion);
        }

        return countries;
    }

    private IEnumerable<Country> SortByName(IEnumerable<Country> countries, string sortDirection){
        if (!string.IsNullOrWhiteSpace(sortDirection)) {
            if (sortDirection.Equals("ascend", StringComparison.InvariantCultureIgnoreCase)) {
                return countries.OrderBy(c => c.Name.Common);
            }
            else if (sortDirection.Equals("descend", StringComparison.InvariantCultureIgnoreCase)) {
                return countries.OrderByDescending(c => c.Name.Common);
            }
        }

        return countries;
    }

    private IEnumerable<Country> Paginate(IEnumerable<Country> countries, int? takeFirst){
        if (takeFirst.HasValue) {
            return countries.Take(takeFirst.Value);
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
