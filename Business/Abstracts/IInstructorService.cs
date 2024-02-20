using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts
{
    public interface IInstructorService
    {
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
        Instructor Get(int id);
        List<Instructor> GetList();
    }

}
