using System.Text;
using System.Globalization;
using System.Net.Mime;
using Microsoft.AspNetCore.Builder;

string[] cultures = [
	"en-GB",
	"pt-PT",
	"es-ES",
	"de-DE",
	"is-IS"
];

var price = 123.45m;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/prices", () => cultures.Select(cultureName
	=> price.ToString("C", new CultureInfo(cultureName))).ToArray());
app.MapGet("/invariant", () => price.ToString("C", CultureInfo.InvariantCulture));
app.MapGet("/cultures", () => CultureInfo.GetCultures(CultureTypes.AllCultures));
app.Run();

//string ListPrices() {

//	var sb = new StringBuilder();
//	foreach (var culture in cultures) {
//		sb.Append(price.ToString("C", new CultureInfo(culture)));
//		sb.Append("<br />");
//	}
//	return sb.ToString();
//}

////class HtmlResult : IResult {
////	private readonly string _html;

////	public HtmlResult(string html) {
////		_html = html;
////	}

////	public Task ExecuteAsync(HttpContext httpContext) {
////		httpContext.Response.ContentType = MediaTypeNames.Text.Html;
////		httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_html);
////		return httpContext.Response.WriteAsync(_html, Encoding.UTF8);
////	}
////}






