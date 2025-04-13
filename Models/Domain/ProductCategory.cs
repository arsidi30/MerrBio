using System.ComponentModel.DataAnnotations;

namespace FarmIt.Models.Domain
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        public int CategoryId { get; set; }
    }
}
