using FluentValidation;

namespace ExaminantionSystem.API.Contracts.StudentQuize
{
    public class StudentQuizeRequestValidators : AbstractValidator<StudentQuizeRequest>
    {
        public StudentQuizeRequestValidators()
        {

            RuleFor(x => x.CoursetId)
                    .NotEmpty();


            RuleFor(x => x.QuizId)
                    .NotEmpty();

        }
    }
}
