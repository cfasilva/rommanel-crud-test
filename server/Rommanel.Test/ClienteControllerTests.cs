using Microsoft.AspNetCore.Mvc;
using Moq;
using Rommanel.Api.Controllers;
using Rommanel.Domain.Command;
using Rommanel.Domain.DTOs.ClienteDTO;
using Rommanel.Domain.Models;
using Rommanel.Domain.Query;
using Xunit;

namespace Rommanel.Test;

public class ClienteControllerTests
{
    private readonly Mock<ClienteCommandHandler> _mockCommandHandler;
    private readonly Mock<ClienteQueryHandler> _mockQueryHandler;
    private readonly ClienteController _clienteController;

    public ClienteControllerTests()
    {
        _mockCommandHandler = new Mock<ClienteCommandHandler>();
        _mockQueryHandler = new Mock<ClienteQueryHandler>();
        _clienteController = new ClienteController(_mockCommandHandler.Object, _mockQueryHandler.Object);
    }

    [Fact]
    public async Task GetClientes_ShouldReturnOkResult_WithListOfClientes()
    {
        var clientes = new List<ClienteModel>
        {
            new ClienteModel { Id = 1, NomeRazaoSocial = "Cliente 1", Documento = "11111111111", TipoPessoa = "F" },
            new ClienteModel { Id = 2, NomeRazaoSocial = "Cliente 2", Documento = "11111111111111", TipoPessoa = "J" }
        };
        _mockQueryHandler.Setup(handler => handler.Handle(It.IsAny<GetAllClientesQuery>()))
            .ReturnsAsync(clientes);

        var result = await _clienteController.GetAllClientes();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ClienteModel>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetCliente_ShouldReturnOkResult_WithCliente()
    {
        var cliente = new ClienteModel { Id = 1, NomeRazaoSocial = "Cliente 1" };
        _mockQueryHandler.Setup(handler => handler.Handle(It.IsAny<GetClienteByIdQuery>()))
            .ReturnsAsync(cliente);

        var result = await _clienteController.GetClienteById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ClienteModel>(okResult.Value);
        Assert.Equal(cliente.Id, returnValue.Id);
    }

    [Fact]
    public async Task CreateCliente_ShouldReturnCreatedAtActionResult_WithCliente()
    {
        var clienteDto = new ClienteCreationDTO { NomeRazaoSocial = "Cliente 1" };
        var cliente = new ClienteModel { Id = 1, NomeRazaoSocial = "Cliente 1" };

        _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<CreateClienteCommand>()))
            .ReturnsAsync(cliente);

        var result = await _clienteController.CreateCliente(clienteDto);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<ClienteModel>(createdAtActionResult.Value);
        Assert.Equal(cliente.Id, returnValue.Id);
    }

    [Fact]
    public async Task UpdateCliente_ShouldReturnOkResult_WithUpdatedCliente()
    {
        var clienteDto = new ClienteCreationDTO { NomeRazaoSocial = "Cliente Atualizado" };
        var cliente = new ClienteModel { Id = 1, NomeRazaoSocial = "Cliente Atualizado" };

        _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<UpdateClienteCommand>()))
            .ReturnsAsync(cliente);

        var result = await _clienteController.UpdateCliente(1, clienteDto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ClienteModel>(okResult.Value);
        Assert.Equal(cliente.Id, returnValue.Id);
    }

    [Fact]
    public async Task DeleteCliente_ShouldReturnNoContentResult()
    {
        _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<DeleteClienteCommand>()))
            .ReturnsAsync(true);

        var result = await _clienteController.DeleteCliente(1);

        Assert.IsType<NoContentResult>(result);
    }
}
