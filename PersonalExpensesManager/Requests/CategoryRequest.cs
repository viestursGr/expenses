using System.ComponentModel.DataAnnotations;

namespace PersonalExpensesManager.Requests
{
    public class CategoryRequest
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
