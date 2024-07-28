using FluentValidation;

namespace ExaminantionSystem.API.Contracts.Course
{
    public class CourseRequestValidators : AbstractValidator<CourseRequest>
    {
        public CourseRequestValidators()
        {
            RuleFor(x => x.Description).NotEmpty();
           
            RuleFor(x => x.Title).NotEmpty();
            
            RuleFor(x => x.Language).NotEmpty();
           
            RuleFor(x => x.Rating).NotEmpty();
        }
    }
}
