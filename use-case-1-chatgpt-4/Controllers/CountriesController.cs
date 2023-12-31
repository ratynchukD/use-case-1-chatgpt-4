using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using use_case_1_chatgpt_4.Dto;
using use_case_1_chatgpt_4.Utilities;

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

    /// <summary>
    /// Returns countries from by defined parameters.
    /// </summary>
    /// <param name="name">Part of the country common name.</param>
    /// <param name="population">A number (in millions) that defines the population threshold under which countries are returned.</param>
    /// <param name="sortDirection">Order in which countries are sorted by their common name.</param>
    /// <param name="takeFirst">A number which defines a limit of countries to return.</param>
    /// <returns>Countries by defined parameters.</returns>
    [HttpGet(Name = "Get")]
    public async Task<IEnumerable<Country>> Get(
        string name = null,
        short? population = null,
        string sortDirection = null,
        int? takeFirst = null)
    {
        var countries =  await GetAllCountriesAsync();

        countries = CountryUtilities.FilterByName(countries, name);
        countries = CountryUtilities.FilterByPopulation(countries, population);
        countries = CountryUtilities.SortByName(countries, sortDirection);
        countries = CountryUtilities.Paginate(countries, takeFirst);

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
