using Microsoft.AspNetCore.Identity;

namespace Rockaway.WebApp.Data.Sample;

public static partial class SampleData {
	public static class Users {
		static Users() {
			var hasher = new PasswordHasher<IdentityUser>();
			Admin = new() {
				Id = "rockaway-sample-admin-user",
				Email = "admin@rockaway.dev",
				NormalizedEmail = "admin@rockaway.dev".ToUpperInvariant(),
				UserName = "admin@rockaway.dev",
				NormalizedUserName = "admin@rockaway.dev".ToUpperInvariant(),
				LockoutEnabled = true,
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString()
			};
			Admin.PasswordHash = hasher.HashPassword(Admin, "p@ssw0rd");
		}
		public static IdentityUser Admin { get; }
	}
}