
using Autofac;
using ExaminantionSystem.API.Repositories;
using ExaminantionSystem.API.Services;

namespace ExaminantionSystem.API.Extensions
{
    public class AutoFacModul :  Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(CourseService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(StudentCourseService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(QuizServices)).AsImplementedInterfaces().InstancePerLifetimeScope();
        
        }

    }

}
