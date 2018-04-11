using FluentValidation;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Commands;

namespace Unidas.CentralDeReservas.Aplicacao.Reservas.Validators
{
    public class CriarReservaCommandValidator : AbstractValidator<CriarReservaCommand>
    {
        public CriarReservaCommandValidator()
        {
            RuleFor(x => x.Acordo).NotEmpty().WithMessage("O Campo acordo é obrigatótio");

        }
    }
}
