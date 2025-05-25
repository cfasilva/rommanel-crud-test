using FluentValidation;
using Rommanel.Domain.DTOs.ClienteDTO;
using System.Text.RegularExpressions;

namespace Rommanel.Domain.Validators;

public class ClienteCreationDTOValidator : AbstractValidator<ClienteCreationDTO>
{
    public ClienteCreationDTOValidator()
    {
        RuleFor(x => x.NomeRazaoSocial)
            .NotEmpty().WithMessage("Nome/Razão Social é obrigatório.");

        RuleFor(x => x.Documento)
            .NotEmpty().WithMessage("CPF/CNPJ é obrigatório.")
            .Must(IsCpfOrCnpj).WithMessage("Documento deve ser um CPF ou CNPJ válido.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("Telefone é obrigatório.");

        RuleFor(x => x.TipoPessoa)
            .NotEmpty().WithMessage("Tipo de pessoa é obrigatório.")
            .Must(x => x == "F" || x == "J").WithMessage("Tipo de pessoa deve ser 'F' ou 'J'.");

        When(x => x.TipoPessoa == "F", () =>
        {
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage("Data de nascimento é obrigatória para pessoa física.")
                .Must(BeAtLeast18YearsOld).WithMessage("Idade mínima para pessoa física é 18 anos.");
        });

        When(x => x.TipoPessoa == "J", () =>
        {
            RuleFor(x => x.InscricaoEstadual)
                .NotEmpty().When(x => !x.IsentoIE).WithMessage("IE é obrigatória para pessoa jurídica não isenta.");
        });

        RuleFor(x => x.Endereco).SetValidator(new EnderecoDTOValidator());
    }

    private bool IsCpfOrCnpj(string documento)
    {
        documento = Regex.Replace(documento ?? "", "[^0-9]", "");
        return documento.Length == 11 || documento.Length == 14;
    }

    private bool BeAtLeast18YearsOld(DateTime? dataNascimento)
    {
        if (!dataNascimento.HasValue) return false;
        var idade = DateTime.Today.Year - dataNascimento.Value.Year;
        if (dataNascimento.Value.Date > DateTime.Today.AddYears(-idade)) idade--;
        return idade >= 18;
    }
}

public class EnderecoDTOValidator : AbstractValidator<EnderecoDTO>
{
    public EnderecoDTOValidator()
    {
        RuleFor(x => x.Cep).NotEmpty();
        RuleFor(x => x.Logradouro).NotEmpty();
        RuleFor(x => x.Numero).NotEmpty();
        RuleFor(x => x.Bairro).NotEmpty();
        RuleFor(x => x.Cidade).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();
    }
}
