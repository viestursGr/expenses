namespace PersonalExpensesManager.Model
{
    public class Receipt
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Created { get; set; }
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
