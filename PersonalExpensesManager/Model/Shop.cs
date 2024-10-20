using System.ComponentModel.DataAnnotations;

namespace PersonalExpensesManager.Model
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Receipt>? Receipts { get; set; }
    }
}
