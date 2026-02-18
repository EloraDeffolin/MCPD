using GestionsEtudiants.Interface;
using Exercice6.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionsEtudiants.Services   
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            
            return await _repository.GetAllAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _repository.AddStudentAsync(student);
        }
    }
}