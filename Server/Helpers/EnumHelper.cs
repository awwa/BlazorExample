namespace HogeBlazor.Server.Helpers;
public static class EnumHelper
{
    /// <summary>
    /// 文字列をEnumに変換する
    /// </summary>
    public static bool TryParse<TEnum>(string s, out TEnum enm) where TEnum : struct
    {
        return Enum.TryParse(s, out enm) && Enum.IsDefined(typeof(TEnum), enm);
    }
}