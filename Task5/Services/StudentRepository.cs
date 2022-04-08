using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task5.DATA;
using Task5.Entites;

namespace Task5.Services
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly StudentDBContext _context;

        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }

        public void Add(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Student item)
        {
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}