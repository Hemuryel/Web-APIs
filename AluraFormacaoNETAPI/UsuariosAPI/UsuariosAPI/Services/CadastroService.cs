using FluentResults;
using AutoMapper;
using UsuariosAPI.Models;
using UsuariosAPI.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosAPI.Interfaces;
using UsuariosAPI.Data.Requests;
using System.Web;
using System.Linq;

namespace UsuariosAPI.Services
{
    public class CadastroService : ICadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private IEmailService _emailService;

        public CadastroService(IMapper mapper,
            UserManager<CustomIdentityUser> userManager,
            IEmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                _userManager.AddToRoleAsync(usuarioIdentity, "regular");

                var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCodigoAtivacao = HttpUtility.UrlEncode(codigoAtivacao);

                _emailService.EnviarEmail(
                    new [] { usuarioIdentity.Email },
                    "Link de ativação",
                    usuarioIdentity.Id,
                    encodedCodigoAtivacao
                );

                return Result.Ok().WithSuccess(codigoAtivacao);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivarContaUsuario(AtivarContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
