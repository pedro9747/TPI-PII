using Microsoft.AspNetCore.Mvc;
using TorneoApi.Models;
using TorneoBack.Service.Contracts;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TorneoContext _context;
    private readonly IAuthService _authService;

    public AuthController(TorneoContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Usuario usuarioDto)
    {
        if (_context.Usuarios.Any(u => u.NombreUsuario == usuarioDto.NombreUsuario))
            return BadRequest("El nombre de usuario ya existe.");

        var usuario = new Usuario
        {
            NombreUsuario = usuarioDto.NombreUsuario,
            RolId = usuarioDto.RolId,
            Contraseña = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Contraseña)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuario registrado exitosamente." });

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario model)
    {
        var token = _authService.Authenticate(model.NombreUsuario, model.Contraseña);

        if (token == null)
            return Unauthorized("Credenciales incorrectas");

        return Ok(new { Token = token });
    }
}
