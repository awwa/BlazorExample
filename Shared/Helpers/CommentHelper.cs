using System.Reflection;
using HogeBlazor.Shared.Models.Db;
using Microsoft.EntityFrameworkCore;

public static class CommentHelper
{
    /// <summary>
    /// プロパティのCommentAttributeの値を返す
    /// </summary>
    /// <typeparam name="T">対象クラス</typeparam>
    /// <param name="property">プロパティ名</param>
    /// <returns>CommentAttributeの値</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string GetCommentAttributeOnProperty<T>(string property)
    {
        if (property == null)
        {
            return "";
        }
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

    /// <summary>
    /// constフィールドのCommentAttributeの値を返す
    /// </summary>
    /// <typeparam name="T">対象クラス</typeparam>
    /// <param name="field">フィールド名</param>
    /// <returns>CommentAttributeの値</returns>
    public static string GetCommentAttributeOnField<T>(string field)
    {
        if (field == null)
        {
            return "";
        }
        Type t = typeof(T);
        FieldInfo? fi = t.GetField(field);
        // nullの場合、フィールドが存在しないエラー
        if (fi == null) throw new NotImplementedException();
        // 最初のCommentAttributeを取得
        Attribute comment = Attribute.GetCustomAttributes(fi, typeof(CommentAttribute)).First();
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