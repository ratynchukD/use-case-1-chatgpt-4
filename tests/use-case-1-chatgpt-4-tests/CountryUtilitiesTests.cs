using use_case_1_chatgpt_4.Utilities;
using use_case_1_chatgpt_4.Dto;

namespace use_case_1_chatgpt_4_tests;

public class CountryUtilitiesTests
{
    [Fact]
    public void FilterByName_MatchingName_ReturnsFilteredCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Canada" } },
            new Country { Name = new Name { Common = "Cambodia" } },
            new Country { Name = new Name { Common = "Cameroon" } }
        };
        var nameToFilter = "Cam";

        // Act
        var result = CountryUtilities.FilterByName(countries, nameToFilter);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.DoesNotContain(countries[0], result);
    }

    [Fact]
    public void FilterByName_NonMatchingName_ReturnsEmptyList()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Canada" } }
        };
        var nameToFilter = "XYZ";

        // Act
        var result = CountryUtilities.FilterByName(countries, nameToFilter);

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void FilterByName_InvalidName_ReturnsAllCountries(string nameToFilter)
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Canada" } },
            new Country { Name = new Name { Common = "Cambodia" } }
        };

        // Act
        var result = CountryUtilities.FilterByName(countries, nameToFilter);

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void FilterByPopulation_WithThreshold_ReturnsCountriesBelowThreshold()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Population = 500_000 },
            new Country { Population = 1_500_000 },
            new Country { Population = 3_000_000 }
        };
        short? populationThreshold = 2;  // 2 million

        // Act
        var result = CountryUtilities.FilterByPopulation(countries, populationThreshold);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.DoesNotContain(countries[2], result);
    }

    [Fact]
    public void FilterByPopulation_WithThresholdNoneBelow_ReturnsEmptyList()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Population = 3_000_000 },
            new Country { Population = 4_000_000 }
        };
        short? populationThreshold = 2;  // 2 million

        // Act
        var result = CountryUtilities.FilterByPopulation(countries, populationThreshold);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FilterByPopulation_WithoutThreshold_ReturnsAllCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Population = 500_000 },
            new Country { Population = 3_000_000 }
        };
        short? populationThreshold = null;

        // Act
        var result = CountryUtilities.FilterByPopulation(countries, populationThreshold);

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void SortByName_AscendSortsCountriesAscendingByName()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Zimbabwe" } },
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Mongolia" } }
        };

        // Act
        var result = CountryUtilities.SortByName(countries, "ascend").ToList();

        // Assert
        Assert.Equal("Argentina", result[0].Name.Common);
        Assert.Equal("Mongolia", result[1].Name.Common);
        Assert.Equal("Zimbabwe", result[2].Name.Common);
    }

    [Fact]
    public void SortByName_DescendSortsCountriesDescendingByName()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Zimbabwe" } },
            new Country { Name = new Name { Common = "Mongolia" } }
        };

        // Act
        var result = CountryUtilities.SortByName(countries, "descend").ToList();

        // Assert
        Assert.Equal("Zimbabwe", result[0].Name.Common);
        Assert.Equal("Mongolia", result[1].Name.Common);
        Assert.Equal("Argentina", result[2].Name.Common);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("invalidDirection")]
    public void SortByName_InvalidOrNoSortDirection_ReturnsOriginalOrder(string sortDirection)
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Zimbabwe" } },
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Mongolia" } }
        };

        // Act
        var result = CountryUtilities.SortByName(countries, sortDirection).ToList();

        // Assert
        Assert.Equal("Zimbabwe", result[0].Name.Common);
        Assert.Equal("Argentina", result[1].Name.Common);
        Assert.Equal("Mongolia", result[2].Name.Common);
    }

    [Fact]
    public void Paginate_TakeFew_ReturnsFirstNCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Zimbabwe" } },
            new Country { Name = new Name { Common = "Mongolia" } }
        };

        // Act
        var result = CountryUtilities.Paginate(countries, 2).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Argentina", result[0].Name.Common);
        Assert.Equal("Zimbabwe", result[1].Name.Common);
    }

    [Fact]
    public void Paginate_TakeMoreThanCount_ReturnsAllCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Zimbabwe" } }
        };

        // Act
        var result = CountryUtilities.Paginate(countries, 5).ToList();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Paginate_TakeIsNull_ReturnsAllCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Name = new Name { Common = "Argentina" } },
            new Country { Name = new Name { Common = "Zimbabwe" } }
        };

        // Act
        var result = CountryUtilities.Paginate(countries, null).ToList();

        // Assert
        Assert.Equal(2, result.Count);
    }
}
