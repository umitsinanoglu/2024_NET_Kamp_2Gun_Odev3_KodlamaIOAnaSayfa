using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.DTOs;
using System.Linq.Expressions;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract
{
    public interface ICourseDal
    {
        void Add(Course course);
        void Update(Course course);
        void Delete(int courseId);
        Course Get(Expression<Func<Course, bool>> filter);
        List<Course> GetList(Expression<Func<Course, bool>> filter = null);
        List<CourseDetailDto> GetCourseDetails();
    }
}
