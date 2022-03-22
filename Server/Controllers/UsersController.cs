using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HogeBlazor.Server.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly HogeBlazorDbContext _context = default!;
    private readonly ILogger<UsersController> _logger;

    public UsersController(HogeBlazorDbContext context, ILogger<UsersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public class UserDTO
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public User.RoleType Role { get; set; } = default;
        public DateTime CreatedAt { get; set; } = default;
        public DateTime UpdatedAt { get; set; } = default;
    }

    /// <summary>
    /// クエリによるユーザ一覧取得
    /// 引数でnull指定することにより、Where句から条件指定を除外できる
    /// ASP.NET Core Web API のコントローラー アクションの戻り値の型
    /// https://docs.microsoft.com/ja-jp/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route(Const.API_BASE_PATH_V1 + "users")]
    public async Task<ActionResult<UserDTO>> GetByQuery([FromQuery] string? name, string? email, User.RoleType? role)
    {
        var exList = new List<Expression<Func<User, bool>>>();
        if (name != null) exList.Add(x => x.Name == name);
        if (email != null) exList.Add(x => x.Email == email);
        if (role != null) exList.Add(x => x.Role == role);
        var query = _context.Users.AsQueryable();
        foreach (var ex in exList)
        {
            query = query.Where(ex);
        }
        var users = await query.ToListAsync<User>();
        var dtos = users.Select(user => ItemToDTO(user)).ToList();
        return Ok(dtos);
    }

    /// <summary>
    /// IDをキーにしてユーザ1件取得
    /// </summary>
    /// <returns>該当データが見つかった場合：StatusOk+UserDTO、見つからなかった場合：StatusNotFound</returns>
    [HttpGet]
    [Route(Const.API_BASE_PATH_V1 + "users/{id}")]
    public async Task<ActionResult<UserDTO>> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        UserDTO dto = ItemToDTO(user);
        return Ok(dto);
    }

    // TODO
    // [HttpDelete]
    // public void Delete()
    // {
    //     _context.Users
    // }

    // TODO
    // [HttpPut]

    // TODO
    // [HttpPost]

    private static UserDTO ItemToDTO(User user) =>
        new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };

}