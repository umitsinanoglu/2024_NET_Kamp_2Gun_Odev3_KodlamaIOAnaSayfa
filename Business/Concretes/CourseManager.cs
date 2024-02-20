using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.DTOs;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Delete(int courseId)
        {
            _courseDal.Delete(courseId);
        }
        public void Update(Course course)
        {
            _courseDal.Update(course);
        }

        public List<CourseDetailDto> GetCourseDetails()
        {
            return _courseDal.GetCourseDetails();
        }

        public Course Get(int courseId)
        {
            return _courseDal.Get(c => c.Id == courseId);
        }

        public List<Course> GetList()
        {
            // ICourseDal aracılığıyla GetList metodu çağrılıyor
            return _courseDal.GetList();
        }

        public List<Course> GetListByInstructor(int instructorId)
        {
            return _courseDal.GetList(c => c.InstructorId == instructorId).ToList();
        }

        public List<Course> GetListByCategory(int categoryId)
        {
            return _courseDal.GetList(c => c.CategoryId == categoryId).ToList();
        }

    }
}

