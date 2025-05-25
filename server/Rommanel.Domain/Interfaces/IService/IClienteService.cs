using Rommanel.Domain.DTOs.ClienteDTO;
using Rommanel.Domain.Models;

namespace Rommanel.Domain.Interfaces.IService;

public interface IClienteService
{
    Task<ClienteModel> CreateCliente(ClienteCreationDTO clienteDto);
    Task<bool> ClienteExistsByDocumentoOrEmail(string documento, string email);
    Task<List<ClienteModel>> GetAllClientes();
    Task<ClienteModel?> GetClienteById(int id);
    Task<ClienteModel?> UpdateCliente(int id, ClienteCreationDTO clienteDto);
    Task<bool> DeleteCliente(int id);
}
