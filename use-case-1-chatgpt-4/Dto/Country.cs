using System.Collections.Generic;
using System;

namespace use_case_1_chatgpt_4.Dto
{

    public partial class Country
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public long Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public Currencies Currencies { get; set; }
        public Idd Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public Languages Languages { get; set; }
        public Dictionary<string, Translation> Translations { get; set; }
        public List<long> Latlng { get; set; }
        public bool Landlocked { get; set; }
        public List<string> Borders { get; set; }
        public long Area { get; set; }
        public Demonyms Demonyms { get; set; }
        public string Flag { get; set; }
        public Maps Maps { get; set; }
        public long Population { get; set; }
        public Dictionary<string, double> Gini { get; set; }
        public string Fifa { get; set; }
        public Car Car { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Continents { get; set; }
        public Flags Flags { get; set; }
        public CoatOfArms CoatOfArms { get; set; }
        public string StartOfWeek { get; set; }
        public CapitalInfo CapitalInfo { get; set; }
        public PostalCode PostalCode { get; set; }
    }

    public partial class CapitalInfo
    {
        public List<double> Latlng { get; set; }
    }

    public partial class Car
    {
        public List<string> Signs { get; set; }
        public string Side { get; set; }
    }

    public partial class CoatOfArms
    {
        public Uri Png { get; set; }
        public Uri Svg { get; set; }
    }

    public partial class Currencies
    {
        public Zar Zar { get; set; }
    }

    public partial class Zar
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }

    public partial class Demonyms
    {
        public Eng Eng { get; set; }
        public Eng Fra { get; set; }
    }

    public partial class Eng
    {
        public string F { get; set; }
        public string M { get; set; }
    }

    public partial class Flags
    {
        public Uri Png { get; set; }
        public Uri Svg { get; set; }
        public string Alt { get; set; }
    }

    public partial class Idd
    {
        public string Root { get; set; }
        public List<string> Suffixes { get; set; }
    }

    public partial class Languages
    {
        public string Afr { get; set; }
        public string Eng { get; set; }
        public string Nbl { get; set; }
        public string Nso { get; set; }
        public string Sot { get; set; }
        public string Ssw { get; set; }
        public string Tsn { get; set; }
        public string Tso { get; set; }
        public string Ven { get; set; }
        public string Xho { get; set; }
        public string Zul { get; set; }
    }

    public partial class Maps
    {
        public Uri GoogleMaps { get; set; }
        public Uri OpenStreetMaps { get; set; }
    }

    public partial class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Dictionary<string, Translation> NativeName { get; set; }
    }

    public partial class Translation
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public partial class PostalCode
    {
        public string Format { get; set; }
        public string Regex { get; set; }
    }
}
