using FluentResults;
using AutoMapper;
using UsuariosAPI.Models;
using UsuariosAPI.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosAPI.Interfaces;
using UsuariosAPI.Data.Requests;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace UsuariosAPI.Interfaces
{
    public interface IEmailService
    {
        void EnviarEmail(string[] destinatario,
            string ssunto,
            int usuarioId,
            string codigoAtivacao);

        MimeMessage CriarCorpoEmail(Mensagem mensagem);
        void Enviar(MimeMessage mensagemEmail);
    }
}
