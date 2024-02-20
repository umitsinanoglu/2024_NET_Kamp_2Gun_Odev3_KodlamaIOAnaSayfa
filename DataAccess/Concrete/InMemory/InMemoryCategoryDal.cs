using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using System.Linq.Expressions;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        private static List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Programming" },
            new Category { Id = 2, Name = "Mathematics" },
            new Category { Id = 3, Name = "History" }
        };
        }

        public List<Category> GetAll()
        {
            return _categories;

        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
            }
        }

        public void Delete(int id)
        {
            Category categoryToDelete = _categories.FirstOrDefault(c => c.Id == id);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            if (filter == null)
            {
                // Eğer filtre null ise, hata fırlat
                throw new ArgumentNullException(nameof(filter), "Filtre boş olamaz");
            }
            else
            {
                // Filter kullanıcı tarafından belirtilmişse, uygun kategoriyi döndür
                return _categories.SingleOrDefault(filter.Compile());
            }
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter)
        {
            if (filter == null)
            {
                return _categories;
            }
            else
            {
                return _categories.Where(filter.Compile()).ToList();
            }
        }
    }
}