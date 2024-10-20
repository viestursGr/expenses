namespace PersonalExpensesManager.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime? Paid { get; set; }
        public bool? IsCashTransaction { get; set; }
        public string? ExpenseItem { get; set; }
        public double? ExpenseAmount { get; set; }
        public string? ExpenseQuantity { get; set; }
        public int? CategoryId { get; set; }
        public int? ReceiptId { get; set; }
        public Category? Category { get; set; }
        public Receipt? Receipt { get; set; }
    }
}
