using FluentValidation;

namespace ExaminantionSystem.API.Contracts.Quiz
{
    public class QuizRequestValidators : AbstractValidator<QuizRequest>
    {
        public QuizRequestValidators()
        {
            RuleFor(x => x.Title)
                    .NotEmpty();

            RuleFor(x => x.Type)
                        .NotEmpty();

        }
    }
}
