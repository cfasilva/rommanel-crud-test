using Microsoft.EntityFrameworkCore;
using Rommanel.Domain.DTOs.ClienteDTO;
using Rommanel.Domain.Interfaces.IService;
using Rommanel.Domain.Models;
using Rommanel.Infra.Context;

namespace Rommanel.Service;

public class ClienteService : IClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ClienteModel> CreateCliente(ClienteCreationDTO clienteDto)
    {
        var cliente = new ClienteModel
        {
            NomeRazaoSocial = clienteDto.NomeRazaoSocial,
            Documento = clienteDto.Documento,
            DataNascimento = clienteDto.DataNascimento,
            Telefone = clienteDto.Telefone,
            Email = clienteDto.Email,
            TipoPessoa = clienteDto.TipoPessoa,
            InscricaoEstadual = clienteDto.InscricaoEstadual,
            IsentoIE = clienteDto.IsentoIE,
            Endereco = new EnderecoModel
            {
                Cep = clienteDto.Endereco.Cep,
                Logradouro = clienteDto.Endereco.Logradouro,
                Numero = clienteDto.Endereco.Numero,
                Bairro = clienteDto.Endereco.Bairro,
                Cidade = clienteDto.Endereco.Cidade,
                Estado = clienteDto.Endereco.Estado
            }
        };
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> ClienteExistsByDocumentoOrEmail(string documento, string email)
    {
        return await _context.Clientes.AnyAsync(c => c.Documento == documento || c.Email == email);
    }

    public async Task<List<ClienteModel>> GetAllClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<ClienteModel?> GetClienteById(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<ClienteModel?> UpdateCliente(int id, ClienteCreationDTO clienteDto)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return null;

        cliente.NomeRazaoSocial = clienteDto.NomeRazaoSocial;
        cliente.Documento = clienteDto.Documento;
        cliente.DataNascimento = clienteDto.DataNascimento;
        cliente.Telefone = clienteDto.Telefone;
        cliente.Email = clienteDto.Email;
        cliente.TipoPessoa = clienteDto.TipoPessoa;
        cliente.InscricaoEstadual = clienteDto.InscricaoEstadual;
        cliente.IsentoIE = clienteDto.IsentoIE;
        cliente.Endereco.Cep = clienteDto.Endereco.Cep;
        cliente.Endereco.Logradouro = clienteDto.Endereco.Logradouro;
        cliente.Endereco.Numero = clienteDto.Endereco.Numero;
        cliente.Endereco.Bairro = clienteDto.Endereco.Bairro;
        cliente.Endereco.Cidade = clienteDto.Endereco.Cidade;
        cliente.Endereco.Estado = clienteDto.Endereco.Estado;

        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return false;
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}
