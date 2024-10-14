using AngleSharp;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit.Abstractions;

namespace Rockaway.WebApp.Tests;

public class PageTests(ITestOutputHelper output) {
	// private readonly ITestOutputHelper output = output;

	[Fact]
	public async Task Index_Page_Returns_Success() {
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/");
		response.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Homepage_Has_Correct_Title() {
		var browsingContext = BrowsingContext.New(Configuration.Default);
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		var html = await client.GetStringAsync("/");
		//TODO: fix this... ?
		output.WriteLine(html);
		var dom = await browsingContext.OpenAsync(req => req.Content(html));
		var title = dom.QuerySelector("title");
		title.ShouldNotBeNull();
		title.InnerHtml.ShouldBe("Rockaway");
	}

	[Theory]
	[InlineData("/", "Rockaway")]
	[InlineData("/privacy", "Privacy Policy")]
	public async Task Page_Has_Correct_Title(string url, string title) {
		var browsingContext = BrowsingContext.New(Configuration.Default);
		await using var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync(url);
		var dom = await browsingContext.OpenAsync(req => req.Content(html));
		var titleElement = dom.QuerySelector("title");
		titleElement.ShouldNotBeNull();
		titleElement.InnerHtml.ShouldBe(title);
	}
}