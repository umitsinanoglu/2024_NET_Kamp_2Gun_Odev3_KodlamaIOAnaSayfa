using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes;
using System.Linq.Expressions;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.DataAccess.Abstract
{
    public interface ICategoryDal
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
        Category Get(Expression<Func<Category, bool>> filter);
        List<Category> GetList(Expression<Func<Category, bool>> filter = null);
    }

}
