using Microsoft.AspNetCore.Mvc;
using MoneiroService.DTOs;
using MoneiroService.Interfaces;

namespace MoneiroAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateNewUser([FromBody] CreateUserRequest input)
    {
        UserResponse createdUser = await _userService.CreateNewUser(input);
        return Ok(createdUser);
    }
}
