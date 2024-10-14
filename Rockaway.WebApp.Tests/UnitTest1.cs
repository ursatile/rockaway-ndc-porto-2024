using Microsoft.AspNetCore.Mvc.Testing;

namespace Rockaway.WebApp.Tests;

public class UnitTest1 {
	[Fact]
	public async Task Index_Page_Returns_Success() {
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/");
		response.EnsureSuccessStatusCode();
	}
}