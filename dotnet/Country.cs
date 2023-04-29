namespace dotnet;

public partial class Country
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Iso3 { get; set; } = null!;

    public string Iso2 { get; set; } = null!;

    public string NumericCode { get; set; } = null!;

    public string PhoneCode { get; set; } = null!;

    public string? Capital { get; set; }

    public string Currency { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string CurrencySymbol { get; set; } = null!;

    public string Tld { get; set; } = null!;

    public string? Native { get; set; }

    public string? Region { get; set; }

    public string? Subregion { get; set; }

    public string Timezones { get; set; } = null!;

    public string Translations { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public string Emoji { get; set; } = null!;

    public string EmojiU { get; set; } = null!;
}
