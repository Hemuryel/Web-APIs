using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesAPI.Interfaces
{
    public interface IEnderecoService
    {
        ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto enderecoDto);
        List<ReadEnderecoDto> RecuperarEnderecos();
        ReadEnderecoDto RecuperarEnderecosPorId(int id);
        Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto);
        Result DeletarEndereco(int id);
    }
}
