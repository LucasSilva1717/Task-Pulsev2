using FluentValidation;
using TaskPulse.Application.UseCases.Tasks.CreateTask; // Ajuste o namespace conforme a sua estrutura

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
            .MaximumLength(150).WithMessage("O título não pode exceder 150 caracteres.");

        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("O identificador do projeto é obrigatório.");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("A prioridade informada é inválida.");
    }
}