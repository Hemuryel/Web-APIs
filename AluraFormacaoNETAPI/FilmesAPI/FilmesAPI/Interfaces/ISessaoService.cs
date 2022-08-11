using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesAPI.Interfaces
{
    public interface ISessaoService
    {
        ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto);
        ReadSessaoDto RecuperarSessoesPorId(int id);
    }
}
