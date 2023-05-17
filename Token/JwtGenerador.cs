using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NetSoloTalento.Models;
using Microsoft.IdentityModel.Tokens;

namespace NetSoloTalento.Token;

public class JwtGenerador : IJwtGenerador
{
    public string CrearToken(Usuario usuario)
    {
        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName!),
            new Claim("userId", usuario.Id),
            new Claim("email", usuario.Email!)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SoloTalentoE8A30B7D34597CCE7F81F2A5489275CA9A5F80A1741B4E7C74E8C4854CF6F7A4C"));
        var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescripcion = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(30),
            SigningCredentials = credenciales
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescripcion);
        return tokenHandler.WriteToken(token);
    }
}