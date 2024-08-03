using ExaminantionSystem.API.Contracts.StudentQuize;
using ExaminantionSystem.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExaminantionSystem.API.Services
{
    public interface IStudentQuizService
    {
        Task<bool> ParticipateQuizzesAsync(string userId, StudentQuizeRequest request);





    }
}
