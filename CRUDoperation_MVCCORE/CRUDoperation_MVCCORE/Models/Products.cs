namespace CRUDoperation_MVCCORE.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Category Category { get; set; }
    }
}
