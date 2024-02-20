using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Abstracts;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract;
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(categoryId);
        }

        public Category Get(int categoryId)
        {
            return _categoryDal.Get(c => c.Id == categoryId);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList().ToList();
        }
    }

}
