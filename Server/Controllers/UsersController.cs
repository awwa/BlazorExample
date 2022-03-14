using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly HogeBlazorDbContext _context;

    public UsersController(HogeBlazorDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _context.Users.ToList<User>();
    }

    // [HttpDelete]
    // public void Delete()
    // {
    //     _context.Users
    // }
}