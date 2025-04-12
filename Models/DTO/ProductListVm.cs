using FarmIt.Models.Domain;

namespace FarmIt.Models.DTO
{
    public class ProductListVm
    {
        public IQueryable<Product> ProductList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
