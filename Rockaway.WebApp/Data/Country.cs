namespace Rockaway.WebApp.Data;

public partial class Country {

	public string Code { get; set; }
	public string Name { get; set; }

	public static IList<Country> Iso3166List => iso3166;

	private Country(string code, string name) {
		Code = code;
		Name = name;
	}

	public static string GetName(string code)
		=> FromCode(code)?.Name ?? String.Empty;

	public static Country? FromCode(string countryCode)
		=> Iso3166List.FirstOrDefault(c => c.Code.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase));
}