using Rommanel.Domain.DTOs.ClienteDTO;

namespace Rommanel.Domain.Command;

public class CreateClienteCommand
{
    public ClienteCreationDTO ClienteDto { get; set; } = new();
}

public class UpdateClienteCommand
{
    public int Id { get; set; }
    public ClienteCreationDTO ClienteDto { get; set; } = new();
}

public class DeleteClienteCommand
{
    public int Id { get; set; }
}
