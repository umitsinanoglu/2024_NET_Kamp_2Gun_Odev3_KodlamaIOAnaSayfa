using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using System.Linq.Expressions;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract
{
    public interface IInstructorDal
    {
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int instructorId);
        Instructor Get(Expression<Func<Instructor, bool>> filter);
        List<Instructor> GetList(Expression<Func<Instructor, bool>> filter = null);
    }

}
