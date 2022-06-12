using System.Linq.Expressions;

namespace HogeBlazor.Server.Helpers;

public class QueryHelper
{
    /// <summary>
    /// Expression「where T.property.Equals(searchValues[0]) || T.property.Equals(searchValues[1]) || ...」を構築する
    /// </summary>
    /// <param name="property">検索先プロパティ名</param>
    /// <param name="searchValues">検索対象の値リスト(要素数1以上を指定する)</param>
    /// <typeparam name="T">検索先クラス</typeparam>
    /// <returns>Expression</returns>
    public static Expression<Func<T, bool>> GetOrExpression<T>(string property, List<string> searchValues)
    {
        if (searchValues.Count == 0) throw new ArgumentException("searchValuesには1以上の要素を指定する必要があります");
        // string.Equalsメソッド
        var equals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
        if (equals == null) throw new Exception("equals is null");
        // ラムダ式に渡すパラメータ
        var paramExpr = Expression.Parameter(typeof(T), "x");
        Expression bodyExpr = default!;
        foreach (var o in searchValues)
        {
            if (o.Length == 0) continue;
            if (bodyExpr == default)
            {
                // x.MakerName.Equals("値")のコードと等価
                bodyExpr = Expression.Call(
                    Expression.Property(paramExpr, property), equals, Expression.Constant(o)
                );
            }
            else
            {
                // 既に式があればOR演算する
                bodyExpr = Expression.OrElse(
                    bodyExpr,
                    Expression.Call(
                        Expression.Property(paramExpr, property), equals, Expression.Constant(o)
                    )
                );
            }
        }
        return Expression.Lambda<Func<T, bool>>(bodyExpr, paramExpr);
    }
}