// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using HogeBlazor.Server.Helpers;
// using HogeBlazor.Shared.Models;
// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
// using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Authorization;
// using System.Security.Claims;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Cryptography;

// namespace HogeBlazor.Server.Controllers;

// [ApiController]
// public class UsersController : ControllerBase
// {
//     private readonly ProductContext _context = default!;
//     private readonly ILogger<UsersController> _logger = default!;

//     public UsersController(ProductContext context, ILogger<UsersController> logger)
//     {
//         _context = context;
//         _logger = logger;
//     }

//     /// <summary>
//     /// クライアント返却用クラス
//     /// </summary>
//     public class UserDTO
//     {
//         public int Id { get; set; } = default;
//         public string Name { get; set; } = string.Empty;
//         public string Email { get; set; } = string.Empty;
//         public User.RoleType Role { get; set; } = default;
//         public DateTime CreatedAt { get; set; } = default;
//         public DateTime UpdatedAt { get; set; } = default;
//         public bool IsDel { get; set; } = false;
//     }

//     /// <summary>
//     /// クエリによるユーザ一覧取得
//     /// 引数でnull指定することにより、Where句から条件指定を除外できる
//     /// 引数を指定しなかった場合のデフォルト値はnull
//     /// ASP.NET Core Web API のコントローラー アクションの戻り値の型
//     /// https://docs.microsoft.com/ja-jp/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
//     /// </summary>
//     /// <returns></returns>
//     [Authorize]
//     [HttpGet]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]")]
//     [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
//     public async Task<ActionResult<List<UserDTO>>> GetUserByQuery(
//         [FromQuery] string? name = null, string? email = null, User.RoleType? role = null
//     )
//     {
//         var exList = new List<Expression<Func<User, bool>>>();
//         if (name != null) exList.Add(x => x.Name == name);
//         if (email != null) exList.Add(x => x.Email == email);
//         if (role != null) exList.Add(x => x.Role == role);
//         var query = _context.Users.AsQueryable();
//         foreach (var ex in exList)
//         {
//             query = query.Where(ex);
//         }
//         var users = await query.ToListAsync<User>();
//         var dtos = users.Select(user => ItemToDTO(user)).ToList();
//         return Ok(dtos);
//     }

//     /// <summary>
//     /// IDをキーにしたユーザ1件取得
//     /// </summary>
//     /// <returns>該当データが見つかった場合：StatusOk+UserDTO、見つからなかった場合：StatusNotFound</returns>
//     [HttpGet]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]/{id}")]
//     [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<ActionResult> GetUserById(int id)
//     {
//         var user = await _context.Users.FindAsync(id);
//         if (user == null)
//         {
//             return NotFound();
//         }
//         UserDTO dto = ItemToDTO(user);
//         return Ok(dto);
//     }

//     /// <summary>
//     /// ユーザー削除
//     /// </summary>
//     /// <param name="id">削除するユーザーのID</param>
//     /// <returns>空</returns>
//     [HttpDelete]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]/{id}")]
//     [ProducesResponseType(StatusCodes.Status204NoContent)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<ActionResult> DeleteUser(int id)
//     {
//         var user = await _context.Users.FindAsync(id);
//         if (user == null)
//         {
//             return NotFound();
//         }
//         _context.Users.Remove(user);
//         // await _context.SaveChangesAsync();
//         return NoContent();
//     }

//     /// <summary>
//     /// ユーザーの更新
//     /// </summary>
//     /// <param name="id">更新するユーザーのID</param>
//     /// <param name="updUser">更新するユーザー情報。更新対象プロパティ：Name, Email, PlainPassword, Role</param>
//     /// <returns>ユーザーID</returns>
//     [HttpPatch]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]/{id}")]
//     [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<ActionResult> PatchUser(int id, [FromBody] User updUser)
//     {
//         var user = await _context.Users.FindAsync(id);
//         if (user == null)
//         {
//             return NotFound();
//         }
//         user.Name = updUser.Name;
//         user.Email = updUser.Email;
//         user.PlainPassword = updUser.PlainPassword;
//         user.Role = updUser.Role;
//         // int idUpdated = await _context.SaveChangesAsync();
//         // return Ok(idUpdated);
//         return Ok();
//     }

//     /// <summary>
//     /// ユーザー追加
//     /// </summary>
//     /// <param name="user">追加するユーザー</param>
//     /// <returns>更新後のユーザーデータ</returns>
//     [HttpPost]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]")]
//     [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDTO))]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<UserDTO>> PostUser(User user)
//     {
//         try
//         {
//             _context.Users.Add(user);
//             // int id = await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, ItemToDTO(user));
//         }
//         catch (Exception ex)
//         {
//             // わざわざExceptionをcatchしているのは、利用するDBによって挙動が異なるのを避けるため
//             // UTでSqliteをつかうと、SqliteExceptionが発生するが、PostgreSQLを使うと別の例外が発生する
//             return BadRequest(ex.Message);
//         }
//     }

//     // [HttpPost]
//     // [Route(Const.API_BASE_PATH_V1 + "users/login")]
//     // public async Task<ActionResult<TokenResponse>> Login([FromBody] AuthenticateRequest auth)
//     // {
//     //     var query = _context.Users.AsQueryable();
//     //     var user = await query.Where(x => x.Email == auth.Email).FirstOrDefaultAsync<User>();
//     //     if (user == null) return Unauthorized();
//     //     if (user.Authenticate(auth.PlainPassword))
//     //     {
//     //         Console.WriteLine("未認証なのでJWTを生成して返す");
//     //         string token = JWTHelper.Encode(user);
//     //         var tokenResp = new TokenResponse() { Token = token };
//     //         return Ok(tokenResp);
//     //     }
//     //     else
//     //     {
//     //         return Unauthorized();
//     //     }
//     // }

//     // [HttpPost]
//     // [Route(Const.API_BASE_PATH_V1 + "hoge")]
//     // public ActionResult Hoge(User user)
//     // {
//     //     return Ok();
//     // }

//     // private bool UserExists(int id)
//     // {
//     //     return _context.Users.Any(e => e.Id == id);
//     // }
//     /// <summary>
//     /// DBモデルからクライアント用モデルへの変換
//     /// </summary>
//     /// <param name="user"></param>
//     /// <returns></returns>
//     private static UserDTO ItemToDTO(User user) =>
//         new UserDTO
//         {
//             Id = user.Id,
//             Name = user.Name,
//             Email = user.Email,
//             Role = user.Role,
//             CreatedAt = user.CreatedAt,
//             UpdatedAt = user.UpdatedAt,
//             IsDel = user.IsDel
//         };

// }