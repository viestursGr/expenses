namespace PersonalExpensesManager.Requests
{
    public class ReceiptRequest
    {
        public int? Id { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Created { get; set; }
        public int? ShopId { get; set; }
    }
}
