using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesAPI.Interfaces
{
    public interface ICinemaService
    {
        ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto);
        List<ReadCinemaDto> RecuperarCinemas(string nomeDoFilme);
        ReadCinemaDto RecuperarCinemasPorId(int id);
        Result AtualizarCinema(int id, UpdateCinemaDto cinemaDto);
        Result DeletarCinema(int id);
    }
}
