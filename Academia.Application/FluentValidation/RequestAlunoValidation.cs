using Academia.Application.Dtos.AlunoDto;
using CodeUtils;
using FluentValidation;

namespace Academia.Application.FluentValidation
{
    public class RequestAlunoValidation : AbstractValidator<RequestAlunoDto>
    {
        public RequestAlunoValidation()
        {
            RuleFor(a => a.Nome).NotEmpty()
                .WithMessage("Informe um nome.")
                .MinimumLength(3).MaximumLength(100).WithMessage("Nome deve ter entre 3 e 100 caracteres.");

            RuleFor(c => c.Cpf).NotEmpty()
                .WithMessage("Informe um Cpf")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres")
                .Must(ValidaCpf).WithMessage("Cpf Invalido");

            RuleFor(d => d.DataNascimento).NotEmpty()
                .WithMessage("Data de nascimento obrigatório")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de nascimento deve ser menor ou igual à data atual.");

            RuleFor(d => d.DataCadastro).NotEmpty()
                .WithMessage("Data de cadastro obrigatória");

            RuleFor(e => e.Endereco).NotEmpty()
                .WithMessage("Endereço obrigatório")
                .MaximumLength(150);

            RuleFor(t => t.Telefone).NotEmpty()
                .WithMessage("Informar um telefone válido").Matches(@"^\d{2}\d{4,5}-\d{4}$")
                .WithMessage("Telefone precisa do prefixo antes do número XX9999-9999 ");

            RuleFor(p => p.Plano).NotEmpty()
                .WithMessage("Plano obrigatório")
                .IsInEnum().WithMessage("1-Básico / 2-Intermediario / 3-Premium");

        }

        private bool ValidaCpf(string cpf)
        {
            return Validations.ValidateCnpjOrCpf(cpf);
        }
    }
}
