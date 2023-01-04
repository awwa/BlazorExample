using System.Reflection;
using HogeBlazor.Shared.Models.Db;
using Microsoft.EntityFrameworkCore;

public static class CommentHelper
{
    /// <summary>
    /// constフィールドのCommentAttributeの値を返す
    /// </summary>
    /// <typeparam name="T">対象クラス</typeparam>
    /// <param name="field">フィールド名</param>
    /// <returns>CommentAttributeの値</returns>
    public static string GetCommentAttributeOnField<T>(string? field)
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