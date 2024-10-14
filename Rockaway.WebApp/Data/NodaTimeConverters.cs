using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

// ReSharper disable ClassNeverInstantiated.Local

namespace Rockaway.WebApp.Data;

public static class NodaTimeConverters {

	public static ModelConfigurationBuilder AddNodaTimeConverters(this ModelConfigurationBuilder builder) {
		builder.Properties<Instant>().HaveConversion<InstantToDateTimeOffsetConverter>();
		builder.Properties<LocalDate>().HaveConversion<LocalDateConverter>();
		builder.Properties<LocalTime>().HaveConversion<LocalTimeConverter>();
		builder.Properties<LocalDateTime>().HaveConversion<LocalDateTimeConverter>();
		return builder;
	}

	private class InstantToDateTimeOffsetConverter()
		: ValueConverter<Instant, DateTimeOffset>(i => i.ToDateTimeOffset(),
			dto => Instant.FromDateTimeOffset(dto));

	private class LocalDateTimeConverter()
		: ValueConverter<LocalDateTime, DateTime>(ld => ld.ToDateTimeUnspecified(),
			dt => LocalDateTime.FromDateTime(dt));

	private class LocalDateConverter()
		: ValueConverter<LocalDate, DateOnly>(ld => ld.ToDateOnly(),
			d => LocalDate.FromDateOnly(d));

	private class LocalTimeConverter()
		: ValueConverter<LocalTime, TimeOnly>(lt => lt.ToTimeOnly(),
			t => LocalTime.FromTimeOnly(t));

}