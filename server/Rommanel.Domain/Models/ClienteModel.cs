namespace Rommanel.Domain.Models;

public class ClienteModel
{
    public int Id { get; set; }
    public string NomeRazaoSocial { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string TipoPessoa { get; set; } = string.Empty;
    public string? InscricaoEstadual { get; set; }
    public bool IsentoIE { get; set; }
    public EnderecoModel Endereco { get; set; } = new EnderecoModel();
}

public class EnderecoModel
{
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
