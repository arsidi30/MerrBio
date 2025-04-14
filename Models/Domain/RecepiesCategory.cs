using System.ComponentModel.DataAnnotations;

namespace FarmIt.Models.Domain
{
    public class RecepiesCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        public int CategoryId { get; set; }
    }
}
