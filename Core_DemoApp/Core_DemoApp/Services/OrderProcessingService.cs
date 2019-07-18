using System.Collections.Generic;

namespace Core_DemoApp.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly IProductService productService;
        private readonly IBillingService billingService;

        public OrderProcessingService(IProductService productService, IBillingService billingService)
        {
            this.productService = productService;
            this.billingService = billingService;
        }

        public void PlaceOrder(List<int> orderedProductIds)
        {
            List<int> orderedProducts = new List<int>();

            foreach (var id in orderedProductIds)
            {
                if (productService.Products.ContainsKey(id))
                {
                    orderedProducts.Add(id);
                }
            }
            billingService.CalculateBill(orderedProducts);
        }
    }
}
