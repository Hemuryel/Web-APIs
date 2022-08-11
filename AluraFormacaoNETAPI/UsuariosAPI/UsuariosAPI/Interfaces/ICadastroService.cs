using UsuariosAPI.Models;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos;
using FluentResults;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Interfaces
{
    public interface ICadastroService
    {
        Result CadastrarUsuario(CreateUsuarioDto createDto);
        Result AtivarContaUsuario(AtivarContaRequest request);
    }
}
