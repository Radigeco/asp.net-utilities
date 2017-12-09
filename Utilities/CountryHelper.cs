using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Helper function which gives you all built in countries
    /// </summary>
    public static class CountryHelper
    {
        public static IEnumerable<CountryModel> GetCountries()
        {
            return from regionInfo in
                       from cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                       select new RegionInfo(cultureInfo.LCID)
                   group regionInfo by regionInfo.TwoLetterISORegionName into groupped
                   select new CountryModel
                   {
                       Id = groupped.Key,
                       Name = groupped.First().DisplayName
                   };
        }

        public class CountryModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }

    