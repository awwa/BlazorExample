// using System.Security.Claims;
// using HogeBlazor.Shared.Models;

// namespace HogeBlazor.Server.Helpers;

// public class ClaimsHelper
// {
//     /// <summary>
//     /// ClaimsPrincipalをUserに変換する
//     /// </summary>
//     /// <param name="claims"></param>
//     /// <returns></returns>
//     public static User ClaimsToUser(ClaimsPrincipal claims)
//     {
//         User.RoleType role;
//         if (!EnumHelper.TryParse<User.RoleType>(claims.FindFirstValue(ClaimTypes.Role), out role))
//         {
//             throw new Exception("Claimからユーザー情報の取得に失敗しました。");
//         }
//         int id;
//         if (!int.TryParse(claims.FindFirstValue(ClaimTypes.Sid), out id))
//         {
//             throw new Exception("Claimからユーザー情報の取得に失敗しました。");
//         }
//         var user = new User()
//         {
//             Id = id,
//             Name = claims.FindFirstValue(ClaimTypes.Name),
//             Email = claims.FindFirstValue(ClaimTypes.Email),
//             Role = role
//         };
//         return user;
//     }

//     /// <summary>
//     /// UserをClaimリストに変換する
//     /// </summary>
//     /// <param name="user"></param>
//     /// <returns></returns>
//     public static List<Claim> UserToClaims(User user)
//     {
//         var claims = new[] {
//             new Claim(ClaimTypes.Name, user.Name),
//             new Claim(ClaimTypes.Email, user.Email),
//             new Claim(ClaimTypes.Role, user.Role.ToString()),
//             new Claim(ClaimTypes.Sid, user.Id.ToString())
//         };
//         return claims.ToList<Claim>();
//     }
// }