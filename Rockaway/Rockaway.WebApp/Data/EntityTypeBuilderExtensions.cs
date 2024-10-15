using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rockaway.WebApp.Data;

public static class EntityTypeBuilderExtensions {

	public static KeyBuilder<TEntity> HasKey<TEntity>(
		this EntityTypeBuilder<TEntity> builder,
		params Expression<Func<TEntity, object?>>[] keyExpressions
	) where TEntity : class =>
		builder.HasKey(keyExpressions.Select(ColumnName).ToArray());

	public static string ColumnName<TEntity>(Expression<Func<TEntity, object?>> expr) =>
		expr.Body switch {
			MemberExpression mx => ColumnName(mx),
			UnaryExpression { Operand: MemberExpression mx } => ColumnName(mx),
			_ => throw new("Only member expressions are supported")
		};

	private static string ColumnName(Expression? expr) {
		if (expr is not MemberExpression mx) return String.Empty;
		return ColumnName(mx.Expression) + mx.Member.Name;
	}
}