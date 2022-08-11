using UsuariosAPI.Models;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos;
using FluentResults;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Interfaces
{
    public interface ILoginService
    {
        Result LogarUsuario(LoginRequest request);
        Result SolicitarResetSenhaUsuario(SolicitarResetRequest request);
        Result ResetarSenhaUsuario(EfetuarResetRequest request);
    }
}
