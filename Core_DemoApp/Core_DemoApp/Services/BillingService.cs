using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public class BillingService : IBillingService
    {
        private readonly IProductService productService;

        public BillingService(IProductService productService)
        {
            this.productService = productService;
        }

        public decimal TotalAmount { get; set; }

        public void CalculateBill(List<int> orderedProductIds)
        {
            foreach (var id in orderedProductIds)
            {
                TotalAmount += productService.Products[id].UnitPrice;
            }
        }
    }
}
