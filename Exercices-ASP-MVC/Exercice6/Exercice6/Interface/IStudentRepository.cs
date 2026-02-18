using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice6.Models;

namespace GestionsEtudiants.Interface
{
    public interface IStudentRepository
    {
        int GetTotalCount();

        void AddStudent(Student student);

        Task<int> GetTotalCountAsync();
        Task<List<Student>> GetAllAsync();

        Task AddStudentAsync(Student student);    
    }
}