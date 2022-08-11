using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesAPI.Interfaces
{
    public interface IGerenteService
    {
        ReadGerenteDto AdicionarGerente(CreateGerenteDto gerenteDto);
        ReadGerenteDto RecuperarGerentesPorId(int id);
        Result DeletarGerente(int id);
    }
}
