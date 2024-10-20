using System.ComponentModel.DataAnnotations;

namespace PersonalExpensesManager.Requests
{
    public class ShopRequest
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
