using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Concrete.InMemory;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InMemoryCourseDal : ICourseDal
    {
        List<Course> _courses;
        List<Category> _categories;
        List<Instructor> _instructors;

        public InMemoryCourseDal()
        {
            _courses = new List<Course> {
            new Course{Id=1, InstructorId=1, CategoryId=1, ImageUrl="Https://imgur.com/1", Name = "Senior Yazılım Geliştirici Yetiştirme Kampı (.NET)", Description = "Senior Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=2, InstructorId=2, CategoryId=2, ImageUrl="Https://imgur.com/2", Name = "Yazılım Geliştirici Yetiştirme Kampı (C# + ANGULAR)", Description = "2 ay sürecek Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=3, InstructorId=3, CategoryId=3, ImageUrl="Https://imgur.com/3", Name = "(2023) Yazılım Geliştirici Yetiştirme Kampı - Python &amp; Selenium", Description = "Python &amp; Selenium Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=4, InstructorId=4, CategoryId=4, ImageUrl="Https://imgur.com/4", Name = "(2022) Yazılım Geliştirici Yetiştirme Kampı - JAVA", Description = "Java Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=5, InstructorId=5, CategoryId=5, ImageUrl="Https://imgur.com/5", Name = "Yazılım Geliştirici Yetiştirme Kampı (JavaScript)", Description = "1,5 ay sürecek Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=6, InstructorId=6, CategoryId=6, ImageUrl="Https://imgur.com/6", Name = "Yazılım Geliştirici Yetiştirme Kampı (JAVA + REACT)", Description = "2 ay sürecek Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=7, InstructorId=7, CategoryId=7, ImageUrl="Https://imgur.com/7", Name = "2024 Yazılım Geliştirici Yetiştirme Kampı (C#)", Description = "2 ay sürecek Yazılım Geliştirici Yetiştirme Kampımızın takip, döküman ve duyurularını buradan yapacağız"},
            new Course{Id=8, InstructorId=8, CategoryId=8, ImageUrl="Https://imgur.com/8", Name = "Programlamaya Giriş için Temel Kurs", Description = "PYTHON, JAVA, C# gibi tüm programlama dilleri için temel programlama mantığını anlaşılır örneklerle öğrenin"}
            };

            _categories = new InMemoryCategoryDal().GetAll();
            _instructors = new InMemoryInstructorDal().GetAll();
        }

        public void Add(Course course)
        {
            _courses.Add(course);
        }

        public void Delete(int courseId)
        {
            Course courseToDelete = _courses.FirstOrDefault(c => c.Id == courseId);
            if (courseToDelete != null)
            {
                _courses.Remove(courseToDelete);
            }
        }

        public Course Get(Expression<Func<Course, bool>> filter)
        {
            return _courses.SingleOrDefault(filter.Compile());
        }

        public List<CourseDetailDto> GetCourseDetails()
        {
            var courseDetails = _courses
              .Join(
                _instructors,
                course => course.InstructorId,
                instructor => instructor.Id,
                (course, instructor) => new
                {
                    Course = course,
                    Instructor = instructor
                }
              )
              .Join(
                _categories,
                result => result.Course.CategoryId,
                category => category.Id,
                (result, category) => new CourseDetailDto
                {
                    CourseName = result.Course.Name,
                    InstructorName = result.Instructor.Name,
                    CategoryName = category.Name
                }
              )
              .ToList();

            return courseDetails;
        }

        public List<Course> GetList(Expression<Func<Course, bool>> filter)
        {
            if (filter == null)
            {
                return _courses;
            }
            else
            {
                return _courses.Where(filter.Compile()).ToList();
            }
        }



        public void Update(Course updatedCourse)
        {
            Course courseToUpdate = _courses.FirstOrDefault(c => c.Id == updatedCourse.Id);

            if (courseToUpdate != null)
            {
                courseToUpdate.InstructorId = updatedCourse.InstructorId;
                courseToUpdate.CategoryId = updatedCourse.CategoryId;
                courseToUpdate.Name = updatedCourse.Name;
                courseToUpdate.Description = updatedCourse.Description;
                courseToUpdate.ImageUrl = updatedCourse.ImageUrl;
            }
            else
            {
                throw new Exception("Course not found!");
            }
        }
    }
}
