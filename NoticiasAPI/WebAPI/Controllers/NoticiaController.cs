using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly IAplicacaoNoticia _IAplicacaoNoticia;

        public NoticiaController(IAplicacaoNoticia IAplicacaoNoticia)
        {
            _IAplicacaoNoticia = IAplicacaoNoticia;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarNoticias")]
        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _IAplicacaoNoticia.ListarNoticiasAtivas();
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarNoticia")]
        public async Task<List<Notifica>> AdicionarNoticia(NoticiaModel noticia)
        {
            var noticiaNova = new Noticia();
            noticiaNova.Titulo = noticia.Titulo;
            noticiaNova.Informacao = noticia.Informacao;
            noticiaNova.UserId = await RetornarIdUsuarioLogado();
            await _IAplicacaoNoticia.AdicionarNoticia(noticiaNova);

            return noticiaNova.Notificacoes;
        }


        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarNoticia")]
        public async Task<List<Notifica>> AtualizarNoticia(NoticiaModel noticia)
        {
            var noticiaNova = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);
            noticiaNova.Titulo = noticia.Titulo;
            noticiaNova.Informacao = noticia.Informacao;
            noticiaNova.UserId = await RetornarIdUsuarioLogado();
            await _IAplicacaoNoticia.AtualizarNoticia(noticiaNova);

            return noticiaNova.Notificacoes;
        }


        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/ExcluirNoticia")]
        public async Task<List<Notifica>> ExcluirNoticia(NoticiaModel noticia)
        {
            var noticiaNova = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);

            await _IAplicacaoNoticia.Excluir(noticiaNova);

            return noticiaNova.Notificacoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/BuscarPorId")]
        public async Task<Noticia> BuscarPorId(NoticiaModel noticia)
        {
            var noticiaNova = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);

            return noticiaNova;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idusuario = User.FindFirst("idUsuario");
                return idusuario.Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
