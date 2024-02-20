using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public List<Instructor> GetList()
        {
            return _instructorDal.GetList();
        }

        public Instructor Get(int id)
        {
            return _instructorDal.Get(i => i.Id == id);
        }

        public void Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);
        }

        public void Delete(int instructorId)
        {
            _instructorDal.Delete(instructorId);
        }


    }

}
