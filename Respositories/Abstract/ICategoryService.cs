using FarmIt.Models.Domain;
using FarmIt.Models.DTO;

namespace FarmIt.Respositories.Abstract
{
    public interface ICategoryService
    {
        bool Add(Category model);
        bool Update(Category model);
        Category GetById(int id);
        bool Delete(int id);
        IQueryable<Category> List();





    }
}
