using System.ComponentModel.DataAnnotations;

namespace Rommanel.Domain.DTOs.ClienteDTO;

public class ClienteCreationDTO
{
    [Required]
    public string NomeRazaoSocial { get; set; } = string.Empty;
    [Required]
    public string Documento { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }
    [Required]
    public string Telefone { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string TipoPessoa { get; set; } = string.Empty;
    public string? InscricaoEstadual { get; set; }
    public bool IsentoIE { get; set; }
    [Required]
    public EnderecoDTO Endereco { get; set; } = new EnderecoDTO();
}

public class EnderecoDTO
{
    [Required]
    public string Cep { get; set; } = string.Empty;
    [Required]
    public string Logradouro { get; set; } = string.Empty;
    [Required]
    public string Numero { get; set; } = string.Empty;
    [Required]
    public string Bairro { get; set; } = string.Empty;
    [Required]
    public string Cidade { get; set; } = string.Empty;
    [Required]
    public string Estado { get; set; } = string.Empty;
}
