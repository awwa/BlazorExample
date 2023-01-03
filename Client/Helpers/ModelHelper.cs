using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using HogeBlazor.Client.Helpers;
using System.Reflection;

namespace HogeBlazor.Client.Helpers;

public class ModelHelper
{
    public static string DisplayName(string className, string property)
    {
        Type? t = Type.GetType(className);
        if (t == null) throw new NotImplementedException();
        MemberInfo? pi = t.GetProperty(property);
        // nullの場合、プロパティが存在しないエラー
        if (pi == null) throw new NotImplementedException();
        // 最初のCommentAttributeを取得
        Attribute comment = Attribute.GetCustomAttributes(pi, typeof(DisplayNameAttribute)).First();
        DisplayNameAttribute? c = comment as DisplayNameAttribute;
        if (c is not null)
        {
            return c.DisplayName;
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// プロパティに有効な値を持つかチェック
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>true: 有効な値を持つ/false: 有効な値を持たない</returns>
    public static bool HasValidPropertyValue(object obj)
    {
        if (obj is null) return false;
        foreach (var prop in obj.GetType().GetProperties())
        {
            // 各プロパティの値がnullかチェック
            var v = prop.GetValue(obj);
            if (v is not null && v.ToString() != string.Empty)
            {
                // nullでない場合、名前空間がnullの場合は実装ミス
                if (v.GetType().Namespace == null) throw new NotImplementedException();
                // nullでない場合、名前空間にHogeBlazorを含んでいなかったら有効な値があると判断
                if (!v.GetType().Namespace!.Contains("HogeBlazor")) return true;
                // 上記以外はさらに1階層分プロパティが有効な値を持つか再帰的にチェック
                if (HasValidPropertyValue(v)) return true;
            }
        }
        return false;
    }
}
