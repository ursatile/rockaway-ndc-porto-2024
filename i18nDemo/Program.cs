using System.Globalization;

var price = 123.45m;

string[] cultures = [
	"en-GB",
	"pt-PT",
	"es-ES",
	"de-DE",
	"is-IS"
];

foreach(var culture in cultures) {
	Console.WriteLine(price.ToString("C", new CultureInfo(culture)));
}





