using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;
using UsuariosAPI.Interfaces;

namespace UsuariosAPI.Interfaces
{
    public interface ILogoutService
    {
        Result DeslogarUsuario();
    }
}
