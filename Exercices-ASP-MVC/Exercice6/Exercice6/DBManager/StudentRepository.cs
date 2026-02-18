using Microsoft.EntityFrameworkCore;
using GestionEtudiants.DBManager;           
using GestionsEtudiants.Interface;       
using Exercice6.Models;           

namespace GestionsEtudiants.DBManager      
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public int GetTotalCount()
        {
            return _context.Students.Count();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Students.CountAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}