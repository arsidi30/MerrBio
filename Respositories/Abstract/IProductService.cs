using FarmIt.Models.Domain;
using FarmIt.Models.DTO;

namespace FarmIt.Repositories.Abstract
{
    public interface IProductService
    {
       bool Add(Product model);
       bool Update(Product model);
       Product GetById(int id);
       bool Delete(int id);
       ProductListVm List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetCategoryByProductId(int productId);

    }
}
