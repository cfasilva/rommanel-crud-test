using Rommanel.Domain.Interfaces.IService;
using Rommanel.Domain.Models;

namespace Rommanel.Domain.Query;

public class ClienteQueryHandler
{
    private readonly IClienteService _clienteService;

    public ClienteQueryHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<List<ClienteModel>> Handle(GetAllClientesQuery query)
        => await _clienteService.GetAllClientes();

    public async Task<ClienteModel?> Handle(GetClienteByIdQuery query)
        => await _clienteService.GetClienteById(query.Id);
}
