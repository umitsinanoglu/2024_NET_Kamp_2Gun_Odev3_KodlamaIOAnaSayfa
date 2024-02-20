using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.DTOs;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts
{
    public interface ICourseService
    {
        void Add(Course course);
        void Update(Course course);
        void Delete(int courseId);
        Course Get(int courseId);
        List<Course> GetList();
        List<Course> GetListByInstructor(int instructorId);
        List<Course> GetListByCategory(int categoryId);
        List<CourseDetailDto> GetCourseDetails();
    }
}
