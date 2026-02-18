using System.Collections.Generic;
using System.Threading.Tasks;
using Exercice6.Models;

namespace GestionsEtudiants.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
    }
}