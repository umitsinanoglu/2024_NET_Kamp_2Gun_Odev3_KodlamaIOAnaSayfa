using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using System.Linq.Expressions;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Concrete.InMemory
{
    public class InMemoryInstructorDal : IInstructorDal
    {
        private static List<Instructor> _instructors;
        public InMemoryInstructorDal()
        {
            _instructors = new List<Instructor>
            {
            new Instructor { Id = 1, Name = "John Doe" },
            new Instructor { Id = 2, Name = "Jane Smith" },
            new Instructor { Id = 3, Name = "Michael Johnson" }
            };
        }

        public List<Instructor> GetAll()
        {
            return _instructors;
        }

        public void Add(Instructor instructor)
        {
            _instructors.Add(instructor);
        }
        public void Update(Instructor instructor)
        {
            Instructor instructorToUpdate = _instructors.FirstOrDefault(i => i.Id == instructor.Id);
            if (instructorToUpdate != null)
            {
                instructorToUpdate.Name = instructor.Name;
            }
        }
        public void Delete(int instructorId)
        {
            Instructor instructorToDelete = _instructors.FirstOrDefault(i => i.Id == instructorId);
            if (instructorToDelete != null)
            {
                _instructors.Remove(instructorToDelete);
            }
        }
        public Instructor Get(Expression<Func<Instructor, bool>> filter)
        {
            return _instructors.SingleOrDefault(filter.Compile());
        }
        public List<Instructor> GetList(Expression<Func<Instructor, bool>> filter)
        {
            if (filter == null)
            {
                return _instructors;
            }
            else
            {
                return _instructors.Where(filter.Compile()).ToList();
            }
        }

    }
}