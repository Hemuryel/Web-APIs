using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {
        INoticia _INoticia;
        IServicoNoticia _IServicoNoticia;

        public AplicacaoNoticia(INoticia INoticia, IServicoNoticia IServicoNoticia)
        {
            _INoticia = INoticia;
            _IServicoNoticia = IServicoNoticia;
        }

        public async Task AdicionarNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AdicionarNoticia(noticia);
        }

        public async Task AtualizarNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AtualizarNoticia(noticia);
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _IServicoNoticia.ListarNoticiasAtivas();
        }

        public async Task Adicionar(Noticia Objeto)
        {
            await _INoticia.Adicionar(Objeto);
        }

        public async Task Atualizar(Noticia Objeto)
        {
            await _INoticia.Atualizar(Objeto);
        }

        public async Task<Noticia> BuscarPorId(int Id)
        {
            return await _INoticia.BuscarPorId(Id);
        }

        public async Task Excluir(Noticia Objeto)
        {
            await _INoticia.Excluir(Objeto);
        }

        public async Task<List<Noticia>> Listar()
        {
            return await _INoticia.Listar();
        }
    }
}
