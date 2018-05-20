using Estudos.ViewModel;
using FluentValidation;

namespace Estudos.Validators
{
    public class ClienteValidator: AbstractValidator<ClienteViewModel>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório")
                .Length(3, 50).WithMessage("O campo nome deve ter no mínimo 3 caracteres e no máximo 50 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo e-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

        }
    }
}
