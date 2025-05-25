using Rommanel.Domain.Interfaces.IService;
using Rommanel.Domain.Models;

namespace Rommanel.Domain.Command;

public class ClienteCommandHandler
{
    private readonly IClienteService _clienteService;

    public ClienteCommandHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<ClienteModel> Handle(CreateClienteCommand command)
    {
        if (command.ClienteDto == null)
            throw new ArgumentNullException(nameof(command.ClienteDto), "Cliente DTO cannot be null");

        if (await _clienteService.ClienteExistsByDocumentoOrEmail(command.ClienteDto.Documento, command.ClienteDto.Email))
            throw new InvalidOperationException("Já existe um cliente com este CPF/CNPJ ou e-mail.");

        return await _clienteService.CreateCliente(command.ClienteDto);
    }

    public async Task<ClienteModel?> Handle(UpdateClienteCommand command)
        => await _clienteService.UpdateCliente(command.Id, command.ClienteDto);

    public async Task<bool> Handle(DeleteClienteCommand command)
        => await _clienteService.DeleteCliente(command.Id);
}
