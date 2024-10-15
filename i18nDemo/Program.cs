using System.Globalization;

// get culture names
List<string> list = new List<string>();
foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
{
  string specName = "(none)";
  try { specName = CultureInfo.CreateSpecificCulture(ci.Name).Name; } catch { }
  list.Add(String.Format("{0,-12}{1,-12}{2}    {3}", ci.Name, specName, ci.EnglishName,
  DateTime.Now.ToString("yyyy ddd dd MMM", ci)
  ));
}

list.Sort();  // sort by name

// write to console
Console.WriteLine("CULTURE   SPEC.CULTURE  ENGLISH NAME");
Console.WriteLine("--------------------------------------------------------------");
foreach (string str in list)
  Console.WriteLine(str);