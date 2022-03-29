using HogeBlazor.Shared.Models;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;

namespace HogeBlazor.Server.Helpers;
public class JWTHelper
{
    private static string SECRET = "hoge";
    public static User Decode(string token)
    {
        var json = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
            .WithSecret(SECRET)
            .MustVerifySignature()
            .Decode(token);
        // JSON から User オブジェクトへのデシリアライズ
        User? user = JsonConvert.DeserializeObject<User>(json);
        if (user == null)
        {
            // 検証失敗
            throw new Exception("JWTトークンの検証に失敗しました。");
        }
        return user;
    }

    public static string Encode(User user)
    {
        return JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
            .WithSecret(SECRET)
            .AddClaim<long>("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
            .AddClaim<int>("id", user.Id)
            .AddClaim<string>("name", user.Name)
            .AddClaim<string>("email", user.Email)
            .AddClaim<User.RoleType>("role", user.Role)
            .Encode();
    }
}