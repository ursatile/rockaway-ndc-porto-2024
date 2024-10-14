using AngleSharp;
using Microsoft.AspNetCore.Mvc.Testing;
using Rockaway.WebApp.Services;
using Shouldly;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Rockaway.WebApp.Tests;


public class StatusTests {

	private static readonly ServerStatus testStatus = new() {
		Assembly = "TEST_ASSEMBLY",
		Modified = new DateTimeOffset(2021, 2, 3, 4, 5, 6, TimeSpan.Zero).ToString("O"),
		Hostname = "TEST_HOST",
		DateTime = new DateTimeOffset(2022, 3, 4, 5, 6, 7, TimeSpan.Zero).ToString("O")
	};

	private class TestStatusReporter : IStatusReporter {
		public ServerStatus GetStatus() => testStatus;
	}

	private static readonly JsonSerializerOptions jsonSerializerOptions
		= new(JsonSerializerDefaults.Web);

	[Fact]
	public async Task StatusEndpointReturnsCorrectStatus() {

		await using var factory = new WebApplicationFactory<Program>()
			.WithWebHostBuilder(builder => builder.ConfigureServices(services => {
				services.AddSingleton<IStatusReporter>(new TestStatusReporter());
			}));
		using var client = factory.CreateClient();
		var json = await client.GetStringAsync("/status");
		var status = JsonSerializer.Deserialize<ServerStatus>(json, jsonSerializerOptions);
		status.ShouldNotBeNull();
		status.ShouldBeEquivalentTo(testStatus);
	}
}

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