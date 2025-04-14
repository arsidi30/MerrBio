using FarmIt.Models.Domain;
using FarmIt.Models.DTO;

namespace FarmIt.Repositories.Abstract
{
    public interface IRecepiesService
    {
       bool Add(Recepies model);
       bool Update(Recepies model);
       Recepies GetById(int id);
       bool Delete(int id);
       RecepiesListVm List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetCategoryByProductId(int productId);

    }
}
