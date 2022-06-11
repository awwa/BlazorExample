using System.Reflection;
using Microsoft.EntityFrameworkCore;

public static class CommentHelper
{
    /// <summary>
    /// CommentAttributeの値を返す
    /// </summary>
    /// <typeparam name="T">対象クラス</typeparam>
    /// <param name="property">プロパティ名</param>
    /// <returns>CommentAttributeの値</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string GetCommentAttribute<T>(string property)
    {
        Type t = typeof(T);
        MemberInfo? pi = t.GetProperty(property);
        // nullの場合、プロパティが存在しないエラー
        if (pi == null) throw new NotImplementedException();
        // 最初のCommentAttributeを取得
        Attribute comment = Attribute.GetCustomAttributes(pi, typeof(CommentAttribute)).First();
        CommentAttribute? c = comment as CommentAttribute;
        if (c is not null)
        {
            return c.Comment;
        }
        else
        {
            return "";
        }
    }
}