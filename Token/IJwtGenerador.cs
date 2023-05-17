using NetSoloTalento.Models;

namespace NetSoloTalento.Token;

public interface IJwtGenerador {
    string CrearToken(Usuario usuario);
}