using Microsoft.AspNetCore.Mvc;
using Rommanel.Domain.Command;
using Rommanel.Domain.DTOs.ClienteDTO;
using Rommanel.Domain.Query;

namespace Rommanel.Api.Controllers;

[Route("api/clientes")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteCommandHandler _clienteCommandHandler;
    private readonly ClienteQueryHandler _clienteQueryHandler;

    public ClienteController(ClienteCommandHandler clienteCommandHandler, ClienteQueryHandler clienteQueryHandler)
    {
        _clienteQueryHandler = clienteQueryHandler;
        _clienteCommandHandler = clienteCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClientes()
    {
        var clientes = await _clienteQueryHandler.Handle(new GetAllClientesQuery());
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _clienteQueryHandler.Handle(new GetClienteByIdQuery { Id = id });
        if (cliente == null)
            return NotFound();
            
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] ClienteCreationDTO clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cliente = await _clienteCommandHandler.Handle(new CreateClienteCommand { ClienteDto = clienteDto });
        return CreatedAtAction(nameof(CreateCliente), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteCreationDTO clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _clienteCommandHandler.Handle(new UpdateClienteCommand { Id = id, ClienteDto = clienteDto });
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var deleted = await _clienteCommandHandler.Handle(new DeleteClienteCommand { Id = id });
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}
