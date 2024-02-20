using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Concrete.InMemory;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.DTOs;
using DataAccess.Concrete;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Presentation
{
    class Program
    {
        private static ICourseService _courseService;
        private static IInstructorService _instructorService;
        private static ICategoryService _categoryService;
        static void Main(string[] args)
        {

            // CourseManager ile CRUD operasyonlarını simüle et
            CourseManagerTest();

            // CategoryManager ile CRUD operasyonlarını simüle et
            CategoryManagerTest();

            // InstructorManager ile CRUD operasyonlarını simüle et
            InstructorManagerTest();

        }

        private static void InstructorManagerTest()
        {
            IInstructorDal instructorDal = new InMemoryInstructorDal();
            _instructorService = new InstructorManager(instructorDal);

            //Instructor Ekleyin
            AddInstructor();

            // Instructor'ları listeleyin
            ListInstructors();

            //Get Instructor Detail By Id
            ListInstructorDetailById(1);

            // Instructor güncelleyin
            UpdateInstructor();

            // Bir Instructor'u silin
            DeleteInstructor();

        }

        private static void DeleteInstructor()
        {
            int instructorIdToDelete = 1; // Silmek istediğiniz eğitmenin Id'si
            _instructorService.Delete(instructorIdToDelete);
            Console.WriteLine("Instructor deleted successfully!");
        }

        private static void UpdateInstructor()
        {
            int instructorIdToUpdate = 1; // Güncellemek istediğiniz eğitmenin Id'si
            Instructor updatedInstructor = new Instructor
            {
                Id = instructorIdToUpdate,
                Name = "Updated Instructor Name"
            };
            _instructorService.Update(updatedInstructor);
            Console.WriteLine("Instructor updated successfully!");
        }

        private static void ListInstructorDetailById(int id)
        {
            var instructorDetail = _instructorService.Get(id);
            Console.WriteLine($"Instructor Id: {instructorDetail.Id}, Name: {instructorDetail.Name}");
        }

        private static void ListInstructors()
        {
            var instructors = _instructorService.GetList();
            foreach (var instructor in instructors)
            {
                Console.WriteLine($"Instructor Id: {instructor.Id}, Name: {instructor.Name}");
            }
        }


        private static void AddInstructor()
        {
            Instructor instructor = new Instructor
            {
                Id = 10,
                Name = "John Doe"
            };

            _instructorService.Add(instructor);
            Console.WriteLine("Instructor added successfully!");
        }


        private static void CategoryManagerTest()
        {
            ICategoryDal categoryDal = new InMemoryCategoryDal();
            _categoryService = new CategoryManager(categoryDal);


            // Kategori eklemek için
            AddCategory();

            // Kategori güncellemek için
            UpdateCategory();

            // Kategori silmek için
            DeleteCategory();

            // Bir kategorinin detaylarını Id ile listelemek için
            ListCategoryById(10);

            // Tüm kategorileri listelemek için
            ListCategories();
        }

        private static void ListCategories()
        {
            var categories = _categoryService.GetList();
            foreach (var category in categories)
            {
                Console.WriteLine($"Category Id: {category.Id}, Name: {category.Name}");
            }
        }

        private static void ListCategoryById(int id)
        {
            var category = _categoryService.Get(id);
            Console.WriteLine($"Category Id: {category.Id}, Name: {category.Name}");
        }

        private static void DeleteCategory()
        {
            var categoryIdToDelete = 1; // Silmek istediğiniz kategorinin Id'si
            _categoryService.Delete(categoryIdToDelete);
            Console.WriteLine("Category deleted successfully.");
        }

        private static void UpdateCategory()
        {
            var categoryIdToUpdate = 1; // Güncellemek istediğiniz kategorinin Id'si
            var updatedCategory = new Category { Id = categoryIdToUpdate, Name = "Updated Category Name" };
            _categoryService.Update(updatedCategory);
            Console.WriteLine("Category updated successfully.");
        }

        private static void AddCategory()
        {
            var newCategory = new Category { Id = 10, Name = "New Category" };
            _categoryService.Add(newCategory);
            Console.WriteLine("Category added successfully.");
        }


        private static void CourseManagerTest()
        {
            ICourseDal courseDal = new InMemoryCourseDal();
            _courseService = new CourseManager(courseDal);

            // Course ekleyin
            AddCourse();

            //Id 1 olan kursu listele
            ListCourseById(1);
            // Course'ları listeleyin
            ListCourses();

            //Get Course Detail By Id
            ListCourseDetailById(1);

            // Course güncelleyin
            UpdateCourse();

            // Bir Course'u silin
            DeleteCourse();
        }

        private static void ListCourseById(int id)
        {
            Console.WriteLine(_courseService.Get(id));
        }

        private static void ListCourseDetailById(int id)
        {
            // CourseDetailDto veritabanından çekilir ya da oluşturulur
            CourseDetailDto courseDetail = GetCourseDetailByIdFromDatabase(id);

            // Eğer courseDetail null değilse, bilgiler konsola yazdırılır
            if (courseDetail != null)
            {
                Console.WriteLine("Course Name: " + courseDetail.CourseName);
                Console.WriteLine("Instructor Name: " + courseDetail.InstructorName);
                Console.WriteLine("Category Name: " + courseDetail.CategoryName);
            }
            else
            {
                Console.WriteLine("Course not found with the given id: " + id);
            }
        }

        // Örnek bir metod: Veritabanından CourseDetailDto alır ya da doldurur
        private static CourseDetailDto GetCourseDetailByIdFromDatabase(int id)
        {
            // Burada veritabanına sorgu yapılır veya sabit bir değer döndürülür
            // Örnek olarak sabit bir değer döndürelim
            return new CourseDetailDto
            {
                CourseName = "Programming Basics",
                InstructorName = "John Doe",
                CategoryName = "Programming"
            };
        }


        private static void AddCourse()
        {
            Course course = new Course
            {
                Id = 10, // Örnek bir ID
                Name = "C# Programming", // Örnek bir kurs adı
                Description = "Learn C# programming language", // Örnek bir açıklama
                InstructorId = 1, // Örnek bir eğitmen ID'si
                CategoryId = 1 // Örnek bir kategori ID'si
            };

            _courseService.Add(course);
            Console.WriteLine("Course added successfully.");
        }

        private static void ListCourses()
        {
            var courses = _courseService.GetList();
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Description: {course.Description}");
            }
        }

        private static void UpdateCourse()
        {
            Course courseToUpdate = _courseService.Get(1); // Güncellenecek kursun ID'sini belirtin
            if (courseToUpdate != null)
            {
                courseToUpdate.Name = "Updated C# Programming"; // Yeni kurs adı
                _courseService.Update(courseToUpdate);
                Console.WriteLine("Course updated successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        private static void DeleteCourse()
        {
            int courseIdToDelete = 1; // Silinecek kursun ID'sini belirtin
            _courseService.Delete(courseIdToDelete);
            Console.WriteLine("Course deleted successfully.");
        }
    }
}

