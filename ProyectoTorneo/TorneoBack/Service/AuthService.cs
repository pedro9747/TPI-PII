using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using TorneoApi.Models;
using TorneoBack.Service.Contracts;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly TorneoContext _context;

    public AuthService(IConfiguration configuration, TorneoContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public string Authenticate(string username, string password)
    {
        var user = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Contraseña))
            return null;

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.NombreUsuario),
            new Claim(ClaimTypes.Role, user.RolId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


