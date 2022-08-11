using UsuariosAPI.Models;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace UsuariosAPI.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser usuario, string role);
    }
}
