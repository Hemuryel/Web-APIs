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
using MailKit.Security;

namespace UsuariosAPI.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario,
            string assunto,
            int usuarioId,
            string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, codigoAtivacao);

            var mensagemEmail = CriarCorpoEmail(mensagem);
            Enviar(mensagemEmail);
        }

        public MimeMessage CriarCorpoEmail(Mensagem mensagem){
            var mensagemEmail = new MimeMessage();
            // mensagemEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mensagemEmail.From.Add(new MailboxAddress(_configuration["EmailSettings:From"]));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemEmail;
        }

        public void Enviar(MimeMessage mensagemEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    // client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    //     _configuration.GetValue<int>("EmailSettings:Port"),
                    //     SecureSocketOptions.StartTls //ssl
                    // );
                    client.Connect(_configuration["EmailSettings:SmtpServer"],
                        int.Parse(_configuration["EmailSettings:Port"]),
                        SecureSocketOptions.StartTls //ssl
                    );

                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    // client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                    //     _configuration.GetValue<string>("EmailSettings:Password")
                    // );
                    client.Authenticate(_configuration["EmailSettings:From"],
                        _configuration["EmailSettings:Password"]
                    );

                    client.Send(mensagemEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
