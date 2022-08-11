using AutoMapper;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
        }
    }
}
