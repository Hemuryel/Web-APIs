using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;
using UsuariosAPI.Interfaces;

namespace UsuariosAPI.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private ITokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.Username.ToUpper());

                // Problema no GetRolesAsync
                Token token = _tokenService
                    .CreateToken(identityUser, _signInManager
                        .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                //Token token = _tokenService
                //    .CreateToken(identityUser, "regular");

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }

        public Result SolicitarResetSenhaUsuario(SolicitarResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperarUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoRecuperacao = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinação");
        }

        public Result ResetarSenhaUsuario(EfetuarResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperarUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;

            if (resultadoIdentity.Succeeded) return Result.Ok()
                .WithSuccess("Senha redefinida com sucesso!");

            return Result.Fail("Houve um erro na operação");
        }

        public CustomIdentityUser RecuperarUsuarioPorEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
