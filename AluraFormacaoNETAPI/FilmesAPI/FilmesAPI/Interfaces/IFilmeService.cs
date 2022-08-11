using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesAPI.Interfaces
{
    public interface IFilmeService
    {
        ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDto);
        List<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria);
        ReadFilmeDto RecuperarFilmesPorId(int id);
        Result AtualizarFilme(int id, UpdateFilmeDto filmeDto);
        Result DeletarFilme(int id);
    }
}
