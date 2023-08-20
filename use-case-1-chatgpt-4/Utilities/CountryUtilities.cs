using System.Collections.Generic;
using System;
using use_case_1_chatgpt_4.Dto;

namespace use_case_1_chatgpt_4.Utilities
{
    public static class CountryUtilities
    {
        public static IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return countries.Where(c => c.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
            }

            return countries;
        }

        public static IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, short? population)
        {
            if (population.HasValue)
            {
                long filterCriterion = population.Value * 1_000_000;

                return countries.Where(c => c.Population < filterCriterion);
            }

            return countries;
        }

        public static IEnumerable<Country> SortByName(IEnumerable<Country> countries, string sortDirection)
        {
            if (!string.IsNullOrWhiteSpace(sortDirection))
            {
                if (sortDirection.Equals("ascend", StringComparison.InvariantCultureIgnoreCase))
                {
                    return countries.OrderBy(c => c.Name.Common);
                }
                else if (sortDirection.Equals("descend", StringComparison.InvariantCultureIgnoreCase))
                {
                    return countries.OrderByDescending(c => c.Name.Common);
                }
            }

            return countries;
        }

        public static IEnumerable<Country> Paginate(IEnumerable<Country> countries, int? takeFirst)
        {
            if (takeFirst.HasValue)
            {
                return countries.Take(takeFirst.Value);
            }

            return countries;
        }
    }
}